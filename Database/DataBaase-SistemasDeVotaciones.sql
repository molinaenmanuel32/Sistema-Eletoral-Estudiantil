-- =============================================
-- SISTEMA DE VOTACIÓN ESCOLAR
-- Script de Creación de Base de Datos
-- SQL Server 2022
-- =============================================

USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = 'SistemaVotacion')
    DROP DATABASE SistemaVotacion;
GO

CREATE DATABASE SistemaVotacion;
GO

USE SistemaVotacion;
GO

-- =============================================
-- TABLA: Roles
-- =============================================
CREATE TABLE Roles (
    RolId       INT IDENTITY(1,1) PRIMARY KEY,
    Nombre      NVARCHAR(50)  NOT NULL UNIQUE,
    Descripcion NVARCHAR(200) NULL
);
GO

INSERT INTO Roles (Nombre, Descripcion) VALUES
('Admin',         'Administrador general del sistema'),
('AdminPartido',  'Administrador de una plancha electoral'),
('Votante',       'Estudiante con derecho a voto');
GO

-- =============================================
-- TABLA: Usuarios
-- =============================================
CREATE TABLE Usuarios (
    UsuarioId   INT IDENTITY(1,1) PRIMARY KEY,
    Nombre      NVARCHAR(100) NOT NULL,
    Apellido    NVARCHAR(100) NOT NULL,
    Matricula   NVARCHAR(20)  NOT NULL UNIQUE,
    Curso       NVARCHAR(50)  NULL,
    Seccion     NVARCHAR(10)  NULL,
    Email       NVARCHAR(150) NULL,
    Username    NVARCHAR(50)  NOT NULL UNIQUE,
    PasswordHash NVARCHAR(256) NOT NULL,
    RolId       INT           NOT NULL REFERENCES Roles(RolId),
    Activo      BIT           NOT NULL DEFAULT 1,
    FechaRegistro DATETIME2  NOT NULL DEFAULT GETDATE()
);
GO

-- =============================================
-- TABLA: Planchas (Partidos electorales)
-- =============================================
CREATE TABLE Planchas (
    PlanchaId      INT IDENTITY(1,1) PRIMARY KEY,
    Nombre         NVARCHAR(150) NOT NULL,
    Descripcion    NVARCHAR(500) NULL,
    Mision         NVARCHAR(500) NULL,
    LogoPath       NVARCHAR(500) NULL,
    Color          NVARCHAR(20)  NULL DEFAULT '#007BFF',
    AdminUserId    INT           NOT NULL REFERENCES Usuarios(UsuarioId),
    Activa         BIT           NOT NULL DEFAULT 1,
    FechaCreacion  DATETIME2     NOT NULL DEFAULT GETDATE(),
    FechaModificacion DATETIME2  NULL
);
GO

-- =============================================
-- TABLA: MiembrosPlanchas (Candidatos por plancha)
-- =============================================
CREATE TABLE MiembrosPlanchas (
    MiembroId   INT IDENTITY(1,1) PRIMARY KEY,
    PlanchaId   INT           NOT NULL REFERENCES Planchas(PlanchaId),
    UsuarioId   INT           NOT NULL REFERENCES Usuarios(UsuarioId),
    Puesto      NVARCHAR(100) NOT NULL,
    Orden       INT           NOT NULL DEFAULT 1,
    Descripcion NVARCHAR(300) NULL,
    CONSTRAINT UQ_MiembroPlanchaUsuario UNIQUE (UsuarioId)  -- Un usuario en una sola plancha
);
GO

-- =============================================
-- TABLA: Votaciones (Configuración de la votación)
-- =============================================
CREATE TABLE Votaciones (
    VotacionId    INT IDENTITY(1,1) PRIMARY KEY,
    Titulo        NVARCHAR(200) NOT NULL,
    Descripcion   NVARCHAR(500) NULL,
    FechaInicio   DATETIME2     NOT NULL,
    FechaFin      DATETIME2     NOT NULL,
    Activa        BIT           NOT NULL DEFAULT 0,
    CreadoPor     INT           NOT NULL REFERENCES Usuarios(UsuarioId),
    FechaCreacion DATETIME2     NOT NULL DEFAULT GETDATE()
);
GO

-- =============================================
-- TABLA: Padrones (Participantes habilitados por votación)
-- =============================================
CREATE TABLE Padrones (
    PadronId    INT IDENTITY(1,1) PRIMARY KEY,
    VotacionId  INT NOT NULL REFERENCES Votaciones(VotacionId),
    UsuarioId   INT NOT NULL REFERENCES Usuarios(UsuarioId),
    CONSTRAINT UQ_PadronVotacion UNIQUE (VotacionId, UsuarioId)
);
GO

-- =============================================
-- TABLA: Votos (Registro de votación - anónimo)
-- =============================================
CREATE TABLE Votos (
    VotoId      INT IDENTITY(1,1) PRIMARY KEY,
    VotacionId  INT       NOT NULL REFERENCES Votaciones(VotacionId),
    PadronId    INT       NOT NULL REFERENCES Padrones(PadronId),
    PlanchaId   INT       NULL     REFERENCES Planchas(PlanchaId),  -- NULL = Voto nulo
    EsNulo      BIT       NOT NULL DEFAULT 0,
    FechaVoto   DATETIME2 NOT NULL DEFAULT GETDATE(),
    CONSTRAINT UQ_VotoPadron UNIQUE (VotacionId, PadronId)          -- Un voto por padrón
);
GO

-- =============================================
-- TABLA: LogAuditoria
-- =============================================
CREATE TABLE LogAuditoria (
    LogId       INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioId   INT           NULL REFERENCES Usuarios(UsuarioId),
    Accion      NVARCHAR(100) NOT NULL,
    Detalle     NVARCHAR(500) NULL,
    Fecha       DATETIME2     NOT NULL DEFAULT GETDATE(),
    Ip          NVARCHAR(50)  NULL
);
GO

-- =============================================
-- PROCEDIMIENTOS ALMACENADOS
-- =============================================

-- Obtener estadísticas en tiempo real de una votación
CREATE OR ALTER PROCEDURE sp_EstadisticasVotacion
    @VotacionId INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Total padrón
    DECLARE @TotalPadron INT = (SELECT COUNT(*) FROM Padrones WHERE VotacionId = @VotacionId);
    -- Total votos emitidos
    DECLARE @TotalVotos  INT = (SELECT COUNT(*) FROM Votos    WHERE VotacionId = @VotacionId);
    -- Votos nulos
    DECLARE @VotosNulos  INT = (SELECT COUNT(*) FROM Votos    WHERE VotacionId = @VotacionId AND EsNulo = 1);

    SELECT
        @TotalPadron                                            AS TotalPadron,
        @TotalVotos                                             AS TotalVotos,
        @VotosNulos                                             AS VotosNulos,
        @TotalVotos - @VotosNulos                               AS VotosValidos,
        @TotalPadron - @TotalVotos                              AS SinVotar,
        CASE WHEN @TotalPadron > 0
             THEN CAST(@TotalVotos * 100.0 / @TotalPadron AS DECIMAL(5,2))
             ELSE 0 END                                         AS PorcentajeParticipacion;

    -- Votos por plancha
    SELECT
        p.PlanchaId,
        p.Nombre        AS Plancha,
        p.Color,
        COUNT(v.VotoId) AS TotalVotos,
        CASE WHEN (@TotalVotos - @VotosNulos) > 0
             THEN CAST(COUNT(v.VotoId) * 100.0 / (@TotalVotos - @VotosNulos) AS DECIMAL(5,2))
             ELSE 0 END AS Porcentaje
    FROM Planchas p
    LEFT JOIN Votos v ON v.PlanchaId = p.PlanchaId AND v.VotacionId = @VotacionId AND v.EsNulo = 0
    WHERE p.Activa = 1
    GROUP BY p.PlanchaId, p.Nombre, p.Color
    ORDER BY TotalVotos DESC;
END
GO

-- Marcar como nulos los votos de quienes no votaron al expirar el tiempo
CREATE OR ALTER PROCEDURE sp_MarcarVotosNulos
    @VotacionId INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Insertar voto nulo para cada usuario en el padrón que no haya votado
    INSERT INTO Votos (VotacionId, PadronId, PlanchaId, EsNulo, FechaVoto)
    SELECT
        pad.VotacionId,
        pad.PadronId,
        NULL,
        1,
        GETDATE()
    FROM Padrones pad
    WHERE pad.VotacionId = @VotacionId
      AND NOT EXISTS (
            SELECT 1 FROM Votos v
            WHERE v.VotacionId = @VotacionId
              AND v.PadronId   = pad.PadronId
      );
END
GO

-- Verificar si un usuario ya votó
CREATE OR ALTER PROCEDURE sp_VerificarVoto
    @VotacionId INT,
    @UsuarioId  INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        v.VotoId,
        v.EsNulo,
        CASE WHEN v.EsNulo = 0 AND v.PlanchaId IS NOT NULL THEN 1 ELSE 0 END AS YaVoto,
        v.FechaVoto
    FROM Padrones pad
    LEFT JOIN Votos v ON v.PadronId = pad.PadronId AND v.VotacionId = @VotacionId
    WHERE pad.VotacionId = @VotacionId
      AND pad.UsuarioId  = @UsuarioId;
END
GO

-- =============================================
-- DATOS INICIALES DE PRUEBA
-- =============================================

-- Admin por defecto (password: Admin123!)
INSERT INTO Usuarios (Nombre, Apellido, Matricula, Curso, Seccion, Username, PasswordHash, RolId)
VALUES ('Super', 'Admin', 'ADM-0001', 'Administración', 'N/A',
        'admin',
        -- SHA-256 de "Admin123!" – cambiar en producción
        '0392dc0b7d9d7b5c4e0a1b2c3d4e5f6a7b8c9d0e1f2a3b4c5d6e7f8a9b0c1d2e',
        1);
GO

PRINT '✅ Base de datos SistemaVotacion creada correctamente.';
GO

UPDATE Usuarios
SET PasswordHash = '123'
WHERE Username = 'admin';

use SistemaVotacion

UPDATE Usuarios
SET PasswordHash = '$2a$12$wuoC9Xo7hs5H/SQMSOt0TuaGqo1yWwxh86NQ4ZIHYdmZkGGME4iNu',
    Activo = 1
WHERE Username = 'admin';

SELECT Username, PasswordHash, Activo
FROM Usuarios
WHERE Username = 'admin';

SELECT 
    Username,
    PasswordHash,
    LEN(PasswordHash) AS LargoHash,
    Activo
FROM Usuarios
WHERE Username = 'admin';



---- Actualizar matrículas de usuarios según su rol



USE SistemaVotacion;
GO

;WITH UsuariosOrdenados AS
(
    SELECT
        u.UsuarioId,
        r.Nombre AS RolNombre,
        ROW_NUMBER() OVER (
            PARTITION BY r.Nombre
            ORDER BY u.UsuarioId
        ) AS Numero
    FROM Usuarios u
    INNER JOIN Roles r ON r.RolId = u.RolId
)
UPDATE u
SET Matricula =
    CASE 
        WHEN x.RolNombre = 'Admin' THEN 'ADM-' + RIGHT('0000' + CAST(x.Numero AS VARCHAR(4)), 4)
        WHEN x.RolNombre = 'AdminPartido' THEN 'ADP-' + RIGHT('0000' + CAST(x.Numero AS VARCHAR(4)), 4)
        WHEN x.RolNombre = 'Votante' THEN 'VOT-' + RIGHT('0000' + CAST(x.Numero AS VARCHAR(4)), 4)
    END
FROM Usuarios u
INNER JOIN UsuariosOrdenados x ON x.UsuarioId = u.UsuarioId;
GO

SELECT 
    p.Nombre AS Plancha,
    p.LogoPath,
    COUNT(v.VotoId) AS TotalVotos
FROM Planchas p
LEFT JOIN Votos v ON v.PlanchaId = p.PlanchaId
GROUP BY p.Nombre, p.LogoPath

SELECT PlanchaId, Nombre, LogoPath
FROM Planchas;

UPDATE Planchas
SET LogoPath = 'C:\Users\elp48\Downloads\Elison.jpeg'
WHERE Nombre = 'Elison';


ALTER PROCEDURE sp_EstadisticasVotacion
    @VotacionId INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @TotalPadron INT;
    DECLARE @TotalVotos INT;
    DECLARE @VotosNulos INT;
    DECLARE @VotosValidos INT;
    DECLARE @SinVotar INT;

    SELECT @TotalPadron = COUNT(*)
    FROM Padrones
    WHERE VotacionId = @VotacionId;

    SELECT @TotalVotos = COUNT(*)
    FROM Votos
    WHERE VotacionId = @VotacionId
      AND EsNulo = 0;

    SELECT @VotosNulos = COUNT(*)
    FROM Votos
    WHERE VotacionId = @VotacionId
      AND EsNulo = 1;

    SET @VotosValidos = @TotalVotos;
    SET @SinVotar = @TotalPadron - (@TotalVotos + @VotosNulos);

    SELECT
        @TotalPadron AS TotalPadron,
        @TotalVotos AS TotalVotos,
        @VotosNulos AS VotosNulos,
        @VotosValidos AS VotosValidos,
        @SinVotar AS SinVotar,
        CASE 
            WHEN @TotalPadron = 0 THEN 0
            ELSE CAST(((@TotalVotos + @VotosNulos) * 100.0 / @TotalPadron) AS DECIMAL(10,2))
        END AS PorcentajeParticipacion;

    SELECT
        p.PlanchaId,
        p.Nombre AS Plancha,
        p.Color,
        p.LogoPath,
        COUNT(v.VotoId) AS TotalVotos,
        CASE 
            WHEN @TotalVotos = 0 THEN 0
            ELSE CAST((COUNT(v.VotoId) * 100.0 / @TotalVotos) AS DECIMAL(10,2))
        END AS Porcentaje
    FROM Planchas p
    LEFT JOIN Votos v 
        ON v.PlanchaId = p.PlanchaId
       AND v.VotacionId = @VotacionId
       AND v.EsNulo = 0
    GROUP BY p.PlanchaId, p.Nombre, p.Color, p.LogoPath
    ORDER BY COUNT(v.VotoId) DESC;
END;
GO

SELECT 
    u.UsuarioId,
    u.Nombre,
    u.Username,
    r.Nombre AS RolNombre,
    u.PlanchaId
FROM Usuarios u
INNER JOIN Roles r ON r.RolId = u.RolId;

use SistemaVotacion

SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE';

ALTER TABLE Usuarios
ADD PlanchaId INT NULL;

ALTER TABLE MiembrosPlanchas
ADD Nombre VARCHAR(100) NULL,
    Matricula VARCHAR(50) NULL;