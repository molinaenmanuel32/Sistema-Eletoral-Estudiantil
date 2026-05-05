using Dapper;
using SistemaVotacion.Models;

namespace SistemaVotacion.DAL;

public class UsuarioRepository
{
    // ── Autenticación ───────────────────────────────────────────────────────
    public Usuario? Login(string username, string passwordHash)
    {
        using var con = DbConnection.GetConnection();
        const string sql = """
            SELECT u.*, r.Nombre AS RolNombre
            FROM Usuarios u
            INNER JOIN Roles r ON r.RolId = u.RolId
            WHERE u.Username = @Username
              AND u.PasswordHash = @PasswordHash
              AND u.Activo = 1
            """;
        return con.QueryFirstOrDefault<Usuario>(sql, new { Username = username, PasswordHash = passwordHash });
    }

    // ── CRUD ────────────────────────────────────────────────────────────────
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
            INSERT INTO Usuarios (Nombre, Apellido, Matricula, Curso, Seccion, Email, Username, PasswordHash, RolId, Activo)
            OUTPUT INSERTED.UsuarioId
            VALUES (@Nombre, @Apellido, @Matricula, @Curso, @Seccion, @Email, @Username, @PasswordHash, @RolId, @Activo)
            """;
        return con.ExecuteScalar<int>(sql, u);
    }

    public bool Update(Usuario u)
    {
        using var con = DbConnection.GetConnection();
        const string sql = """
            UPDATE Usuarios
            SET Nombre = @Nombre, Apellido = @Apellido, Matricula = @Matricula,
                Curso  = @Curso,  Seccion  = @Seccion,  Email     = @Email,
                Username = @Username, RolId = @RolId, Activo = @Activo
            WHERE UsuarioId = @UsuarioId
            """;
        return con.Execute(sql, u) > 0;
    }

    public bool UpdatePassword(int id, string newHash)
    {
        using var con = DbConnection.GetConnection();
        return con.Execute("UPDATE Usuarios SET PasswordHash = @h WHERE UsuarioId = @id",
                           new { h = newHash, id }) > 0;
    }

    public bool Delete(int id)
    {
        using var con = DbConnection.GetConnection();
        return con.Execute("UPDATE Usuarios SET Activo = 0 WHERE UsuarioId = @Id", new { Id = id }) > 0;
    }

    public bool ExisteMatricula(string matricula, int excludeId = 0)
    {
        using var con = DbConnection.GetConnection();
        return con.ExecuteScalar<int>(
            "SELECT COUNT(1) FROM Usuarios WHERE Matricula = @m AND UsuarioId <> @e",
            new { m = matricula, e = excludeId }) > 0;
    }

    public bool ExisteUsername(string username, int excludeId = 0)
    {
        using var con = DbConnection.GetConnection();
        return con.ExecuteScalar<int>(
            "SELECT COUNT(1) FROM Usuarios WHERE Username = @u AND UsuarioId <> @e",
            new { u = username, e = excludeId }) > 0;
    }

    public IEnumerable<Usuario> GetVotantesDisponibles(int votacionId)
    {
        // Usuarios con rol Votante que no están ya en el padrón de esta votación
        using var con = DbConnection.GetConnection();
        const string sql = """
            SELECT u.*, r.Nombre AS RolNombre
            FROM Usuarios u
            INNER JOIN Roles r ON r.RolId = u.RolId
            WHERE r.Nombre = 'Votante'
              AND u.Activo  = 1
              AND u.UsuarioId NOT IN (
                    SELECT UsuarioId FROM Padrones WHERE VotacionId = @vid
              )
            ORDER BY u.Apellido, u.Nombre
            """;
        return con.Query<Usuario>(sql, new { vid = votacionId });
    }
}
