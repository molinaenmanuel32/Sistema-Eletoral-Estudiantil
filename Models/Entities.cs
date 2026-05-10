namespace SistemaVotacion.Models;

// ─────────────────────────────────────────────
// ROL
// ─────────────────────────────────────────────
public class Rol
{
    public int    RolId       { get; set; }
    public string Nombre      { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
}

// ─────────────────────────────────────────────
// USUARIO
// ─────────────────────────────────────────────
public class Usuario
{
    public int      UsuarioId      { get; set; }
    public string   Nombre         { get; set; } = string.Empty;
    public string   Apellido       { get; set; } = string.Empty;
    public string   NombreCompleto => $"{Nombre} {Apellido}";
    public string   Matricula      { get; set; } = string.Empty;
    public string?  Curso          { get; set; }
    public string?  Seccion        { get; set; }
    public string?  Email          { get; set; }
    public string   Username       { get; set; } = string.Empty;
    public string   PasswordHash   { get; set; } = string.Empty;
    public int      RolId          { get; set; }
    public string   RolNombre      { get; set; } = string.Empty;   // JOIN
    public bool     Activo         { get; set; } = true;
    public DateTime FechaRegistro  { get; set; }
    public int PlanchaId { get; set; }
}

// ─────────────────────────────────────────────
// PLANCHA
// ─────────────────────────────────────────────
public class Plancha
{
    public int PlanchaId { get; set; }

    public string Nombre { get; set; } = "";

    public string? Descripcion { get; set; }

    public string? Mision { get; set; }

    public string? LogoPath { get; set; }

    public string? Color { get; set; }

    public int AdminUserId { get; set; }

    public bool Activa { get; set; }

    public string? AdminNombre { get; set; }

    public List<MiembroPlancha> Miembros { get; set; } = new();
}
// ─────────────────────────────────────────────
// MIEMBRO DE PLANCHA
// ─────────────────────────────────────────────
public class MiembroPlancha
{
    public int     MiembroId   { get; set; }
    public int     PlanchaId   { get; set; }
    public int     UsuarioId   { get; set; }
    public string  NombreCompleto { get; set; } = string.Empty;  // JOIN
    public string  Matricula   { get; set; } = string.Empty;
    public string  Puesto      { get; set; } = string.Empty;
    public int     Orden       { get; set; }
    public string? Descripcion { get; set; }
}

// ─────────────────────────────────────────────
// VOTACIÓN
// ─────────────────────────────────────────────
public class Votacion
{
    public int      VotacionId    { get; set; }
    public string   Titulo        { get; set; } = string.Empty;
    public string?  Descripcion   { get; set; }
    public DateTime FechaInicio   { get; set; }
    public DateTime FechaFin      { get; set; }
    public bool     Activa        { get; set; }
    public int      CreadoPor     { get; set; }
    public DateTime FechaCreacion { get; set; }

    // Calculados
    public bool     EnCurso    => Activa && DateTime.Now >= FechaInicio && DateTime.Now <= FechaFin;
    public TimeSpan TiempoRestante => FechaFin - DateTime.Now;
}


// ─────────────────────────────────────────────
// PADRÓN
// ─────────────────────────────────────────────
public class Padron
{
    public int    PadronId   { get; set; }
    public int    VotacionId { get; set; }
    public int    UsuarioId  { get; set; }
    public string NombreCompleto { get; set; } = string.Empty;
    public string Matricula  { get; set; } = string.Empty;
    public string Curso      { get; set; } = string.Empty;
    public string Seccion    { get; set; } = string.Empty;
}

// ─────────────────────────────────────────────
// VOTO
// ─────────────────────────────────────────────
public class Voto
{
    public int      VotoId     { get; set; }
    public int      VotacionId { get; set; }
    public int      PadronId   { get; set; }
    public int?     PlanchaId  { get; set; }
    public bool     EsNulo     { get; set; }
    public DateTime FechaVoto  { get; set; }
}

// ─────────────────────────────────────────────
// ESTADÍSTICAS (DTO para dashboard)
// ─────────────────────────────────────────────
public class EstadisticasVotacion
{
    public int TotalPadron { get; set; }
    public int TotalVotos { get; set; }
    public int VotosNulos { get; set; }
    public int VotosValidos { get; set; }
    public int SinVotar { get; set; }
    public decimal PorcentajeParticipacion { get; set; }

    public List<EstadisticaPlancha> PorPlancha { get; set; } = [];
}

public class EstadisticaPlancha
{
    public int PlanchaId { get; set; }

    public string Plancha { get; set; } = string.Empty;

    public string Color { get; set; } = "#007BFF";

    public int TotalVotos { get; set; }

    public decimal Porcentaje { get; set; }

    public string? LogoPath { get; set; }
}

// ─────────────────────────────────────────────
// LOG DE AUDITORÍA
// ─────────────────────────────────────────────
public class LogAuditoria
{
    public int      LogId     { get; set; }
    public int?     UsuarioId { get; set; }
    public string   Accion    { get; set; } = string.Empty;
    public string?  Detalle   { get; set; }
    public DateTime Fecha     { get; set; }
    public string?  Ip        { get; set; }
}
