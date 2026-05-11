<<<<<<< HEAD
using System.Collections.Generic;
using Dapper;
using SistemaVotacion.Models;

namespace SistemaVotacion.DAL
{
    public class UsuarioRepository
    {
        public Usuario Login(string username)
        {
            using (var con = DbConnection.GetConnection())
            {
                const string sql =
                    "SELECT u.*, r.Nombre AS RolNombre " +
                    "FROM Usuarios u " +
                    "INNER JOIN Roles r ON r.RolId = u.RolId " +
                    "WHERE LTRIM(RTRIM(u.Username)) = @Username " +
                    "  AND u.Activo = 1";
                return con.QueryFirstOrDefault<Usuario>(sql, new { Username = username.Trim() });
            }
        }

        public IEnumerable<Usuario> GetAll()
        {
            using (var con = DbConnection.GetConnection())
            {
                const string sql =
                    "SELECT u.*, r.Nombre AS RolNombre " +
                    "FROM Usuarios u " +
                    "INNER JOIN Roles r ON r.RolId = u.RolId " +
                    "ORDER BY u.Apellido, u.Nombre";
                return con.Query<Usuario>(sql);
            }
        }

        public Usuario GetById(int id)
        {
            using (var con = DbConnection.GetConnection())
            {
                const string sql =
                    "SELECT u.*, r.Nombre AS RolNombre " +
                    "FROM Usuarios u " +
                    "INNER JOIN Roles r ON r.RolId = u.RolId " +
                    "WHERE u.UsuarioId = @Id";
                return con.QueryFirstOrDefault<Usuario>(sql, new { Id = id });
            }
        }

        public int Insert(Usuario u)
        {
            using (var con = DbConnection.GetConnection())
            {
                const string sql =
                    "INSERT INTO Usuarios " +
                    "(Nombre, Apellido, Matricula, Curso, Seccion, Email, Username, PasswordHash, RolId, Activo, PlanchaId) " +
                    "OUTPUT INSERTED.UsuarioId " +
                    "VALUES (@Nombre, @Apellido, @Matricula, @Curso, @Seccion, @Email, @Username, @PasswordHash, @RolId, @Activo, @PlanchaId)";
                return con.ExecuteScalar<int>(sql, u);
            }
        }

        public bool Update(Usuario u)
        {
            using (var con = DbConnection.GetConnection())
            {
                const string sql =
                    "UPDATE Usuarios " +
                    "SET Nombre = @Nombre, Apellido = @Apellido, Matricula = @Matricula, " +
                    "    Curso = @Curso, Seccion = @Seccion, Email = @Email, " +
                    "    Username = @Username, RolId = @RolId, Activo = @Activo, PlanchaId = @PlanchaId " +
                    "WHERE UsuarioId = @UsuarioId";
                return con.Execute(sql, u) > 0;
            }
        }

        public bool UpdatePassword(int id, string newHash)
        {
            using (var con = DbConnection.GetConnection())
                return con.Execute(
                    "UPDATE Usuarios SET PasswordHash = @Hash WHERE UsuarioId = @Id",
                    new { Hash = newHash, Id = id }) > 0;
        }

        public bool SetPlanchaId(int usuarioId, int? planchaId)
        {
            using (var con = DbConnection.GetConnection())
                return con.Execute(
                    "UPDATE Usuarios SET PlanchaId = @PlanchaId WHERE UsuarioId = @UsuarioId",
                    new { UsuarioId = usuarioId, PlanchaId = planchaId }) > 0;
        }

        public int GetRolIdPorNombre(string nombreRol)
        {
            using (var con = DbConnection.GetConnection())
                return con.ExecuteScalar<int>(
                    "SELECT RolId FROM Roles WHERE LOWER(LTRIM(RTRIM(Nombre))) = LOWER(LTRIM(RTRIM(@NombreRol)))",
                    new { NombreRol = nombreRol });
        }

        public bool Delete(int id)
        {
            using (var con = DbConnection.GetConnection())
                return con.Execute(
                    "UPDATE Usuarios SET Activo = 0 WHERE UsuarioId = @Id",
                    new { Id = id }) > 0;
        }

        public bool ExisteMatricula(string matricula, int excludeId = 0)
        {
            if (string.IsNullOrWhiteSpace(matricula)) return false;
            using (var con = DbConnection.GetConnection())
                return con.ExecuteScalar<int>(
                    "SELECT COUNT(1) FROM Usuarios WHERE LTRIM(RTRIM(Matricula)) = @Matricula AND UsuarioId <> @ExcludeId",
                    new { Matricula = matricula.Trim(), ExcludeId = excludeId }) > 0;
        }

        public bool ExisteUsername(string username, int excludeId = 0)
        {
            if (string.IsNullOrWhiteSpace(username)) return false;
            using (var con = DbConnection.GetConnection())
                return con.ExecuteScalar<int>(
                    "SELECT COUNT(1) FROM Usuarios WHERE LTRIM(RTRIM(Username)) = @Username AND UsuarioId <> @ExcludeId",
                    new { Username = username.Trim(), ExcludeId = excludeId }) > 0;
        }

        public IEnumerable<Usuario> GetVotantesDisponibles(int votacionId)
        {
            using (var con = DbConnection.GetConnection())
            {
                const string sql =
                    "SELECT u.*, r.Nombre AS RolNombre " +
                    "FROM Usuarios u " +
                    "INNER JOIN Roles r ON r.RolId = u.RolId " +
                    "WHERE r.Nombre = 'Votante' " +
                    "  AND u.Activo = 1 " +
                    "  AND u.UsuarioId NOT IN " +
                    "  (SELECT UsuarioId FROM Padrones WHERE VotacionId = @VotacionId) " +
                    "ORDER BY u.Apellido, u.Nombre";
                return con.Query<Usuario>(sql, new { VotacionId = votacionId });
            }
        }
    }
}
=======
using Dapper;
using SistemaVotacion.Models;

namespace SistemaVotacion.DAL;

public class UsuarioRepository
{
    public Usuario? Login(string username)
    {
        using var con = DbConnection.GetConnection();

        const string sql = """
            SELECT u.*, r.Nombre AS RolNombre
            FROM Usuarios u
            INNER JOIN Roles r ON r.RolId = u.RolId
            WHERE LTRIM(RTRIM(u.Username)) = @Username
              AND u.Activo = 1
            """;

        return con.QueryFirstOrDefault<Usuario>(
            sql,
            new { Username = username.Trim() });
    }

    public IEnumerable<Usuario> GetAll()
    {
        using var con = DbConnection.GetConnection();

        const string sql = """
            SELECT u.*, r.Nombre AS RolNombre
            FROM Usuarios u
            INNER JOIN Roles r ON r.RolId = u.RolId
            ORDER BY u.Apellido, u.Nombre
            """;

        return con.Query<Usuario>(sql);
    }

    public Usuario? GetById(int id)
    {
        using var con = DbConnection.GetConnection();

        const string sql = """
            SELECT u.*, r.Nombre AS RolNombre
            FROM Usuarios u
            INNER JOIN Roles r ON r.RolId = u.RolId
            WHERE u.UsuarioId = @Id
            """;

        return con.QueryFirstOrDefault<Usuario>(sql, new { Id = id });
    }

    public int Insert(Usuario u)
    {
        using var con = DbConnection.GetConnection();

        const string sql = """
            INSERT INTO Usuarios 
            (
                Nombre, 
                Apellido, 
                Matricula, 
                Curso, 
                Seccion, 
                Email, 
                Username, 
                PasswordHash, 
                RolId, 
                Activo,
                PlanchaId
            )
            OUTPUT INSERTED.UsuarioId
            VALUES 
            (
                @Nombre, 
                @Apellido, 
                @Matricula, 
                @Curso, 
                @Seccion, 
                @Email, 
                @Username, 
                @PasswordHash, 
                @RolId, 
                @Activo,
                @PlanchaId
            )
            """;

        return con.ExecuteScalar<int>(sql, u);
    }

    public bool Update(Usuario u)
    {
        using var con = DbConnection.GetConnection();

        const string sql = """
            UPDATE Usuarios
            SET 
                Nombre = @Nombre, 
                Apellido = @Apellido, 
                Matricula = @Matricula,
                Curso = @Curso,  
                Seccion = @Seccion,  
                Email = @Email,
                Username = @Username, 
                RolId = @RolId, 
                Activo = @Activo,
                PlanchaId = @PlanchaId
            WHERE UsuarioId = @UsuarioId
            """;

        return con.Execute(sql, u) > 0;
    }

    public bool UpdatePassword(int id, string newHash)
    {
        using var con = DbConnection.GetConnection();

        const string sql = """
            UPDATE Usuarios 
            SET PasswordHash = @Hash 
            WHERE UsuarioId = @Id
            """;

        return con.Execute(sql, new { Hash = newHash, Id = id }) > 0;
    }

    public bool SetPlanchaId(int usuarioId, int? planchaId)
    {
        using var con = DbConnection.GetConnection();

        const string sql = """
            UPDATE Usuarios
            SET PlanchaId = @PlanchaId
            WHERE UsuarioId = @UsuarioId
            """;

        return con.Execute(sql, new { UsuarioId = usuarioId, PlanchaId = planchaId }) > 0;
    }

    public int GetRolIdPorNombre(string nombreRol)
    {
        using var con = DbConnection.GetConnection();

        const string sql = """
            SELECT RolId
            FROM Roles
            WHERE LOWER(LTRIM(RTRIM(Nombre))) = LOWER(LTRIM(RTRIM(@NombreRol)))
            """;

        return con.ExecuteScalar<int>(sql, new { NombreRol = nombreRol });
    }

    public bool Delete(int id)
    {
        using var con = DbConnection.GetConnection();

        const string sql = """
            UPDATE Usuarios 
            SET Activo = 0 
            WHERE UsuarioId = @Id
            """;

        return con.Execute(sql, new { Id = id }) > 0;
    }

    public bool ExisteMatricula(string? matricula, int excludeId = 0)
    {
        if (string.IsNullOrWhiteSpace(matricula))
            return false;

        using var con = DbConnection.GetConnection();

        const string sql = """
            SELECT COUNT(1) 
            FROM Usuarios 
            WHERE LTRIM(RTRIM(Matricula)) = @Matricula 
              AND UsuarioId <> @ExcludeId
            """;

        return con.ExecuteScalar<int>(
            sql,
            new
            {
                Matricula = matricula.Trim(),
                ExcludeId = excludeId
            }) > 0;
    }

    public bool ExisteUsername(string? username, int excludeId = 0)
    {
        if (string.IsNullOrWhiteSpace(username))
            return false;

        using var con = DbConnection.GetConnection();

        const string sql = """
            SELECT COUNT(1) 
            FROM Usuarios 
            WHERE LTRIM(RTRIM(Username)) = @Username 
              AND UsuarioId <> @ExcludeId
            """;

        return con.ExecuteScalar<int>(
            sql,
            new
            {
                Username = username.Trim(),
                ExcludeId = excludeId
            }) > 0;
    }

    public IEnumerable<Usuario> GetVotantesDisponibles(int votacionId)
    {
        using var con = DbConnection.GetConnection();

        const string sql = """
            SELECT u.*, r.Nombre AS RolNombre
            FROM Usuarios u
            INNER JOIN Roles r ON r.RolId = u.RolId
            WHERE r.Nombre = 'Votante'
              AND u.Activo = 1
              AND u.UsuarioId NOT IN 
              (
                    SELECT UsuarioId 
                    FROM Padrones 
                    WHERE VotacionId = @VotacionId
              )
            ORDER BY u.Apellido, u.Nombre
            """;

        return con.Query<Usuario>(sql, new { VotacionId = votacionId });
    }
}
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
