using Dapper;
using SistemaVotacion.Models;

namespace SistemaVotacion.DAL;

public class PlanchaRepository
{
    public IEnumerable<Plancha> GetAll()
    {
        using var con = DbConnection.GetConnection();
        const string sql = """
            SELECT p.*, u.Nombre + ' ' + u.Apellido AS AdminNombre
            FROM Planchas p
            INNER JOIN Usuarios u ON u.UsuarioId = p.AdminUserId
            ORDER BY p.Nombre
            """;
        return con.Query<Plancha>(sql);
    }

    public Plancha? GetById(int id)
    {
        using var con = DbConnection.GetConnection();
        const string sql = """
            SELECT p.*, u.Nombre + ' ' + u.Apellido AS AdminNombre
            FROM Planchas p
            INNER JOIN Usuarios u ON u.UsuarioId = p.AdminUserId
            WHERE p.PlanchaId = @Id
            """;
        var plancha = con.QueryFirstOrDefault<Plancha>(sql, new { Id = id });
        if (plancha is not null)
            plancha.Miembros = GetMiembros(id).ToList();
        return plancha;
    }

    public int Insert(Plancha p)
    {
        using var con = DbConnection.GetConnection();
        const string sql = """
            INSERT INTO Planchas (Nombre, Descripcion, Mision, LogoPath, Color, AdminUserId, Activa)
            OUTPUT INSERTED.PlanchaId
            VALUES (@Nombre, @Descripcion, @Mision, @LogoPath, @Color, @AdminUserId, @Activa)
            """;
        return con.ExecuteScalar<int>(sql, p);
    }

    public bool Update(Plancha p)
    {
        using var con = DbConnection.GetConnection();
        const string sql = """
            UPDATE Planchas
            SET Nombre = @Nombre, Descripcion = @Descripcion, Mision = @Mision,
                LogoPath = @LogoPath, Color = @Color, AdminUserId = @AdminUserId,
                Activa = @Activa, FechaModificacion = GETDATE()
            WHERE PlanchaId = @PlanchaId
            """;
        return con.Execute(sql, p) > 0;
    }

    // ── Miembros ─────────────────────────────────────────────────────────────
    public IEnumerable<MiembroPlancha> GetMiembros(int planchaId)
    {
        using var con = DbConnection.GetConnection();
        const string sql = """
            SELECT mp.*, u.Nombre + ' ' + u.Apellido AS NombreCompleto, u.Matricula
            FROM MiembrosPlanchas mp
            INNER JOIN Usuarios u ON u.UsuarioId = mp.UsuarioId
            WHERE mp.PlanchaId = @pid
            ORDER BY mp.Orden
            """;
        return con.Query<MiembroPlancha>(sql, new { pid = planchaId });
    }

    public bool AddMiembro(MiembroPlancha m)
    {
        // Verificar que el usuario no esté ya en otra plancha
        using var con = DbConnection.GetConnection();
        int existe = con.ExecuteScalar<int>(
            "SELECT COUNT(1) FROM MiembrosPlanchas WHERE UsuarioId = @uid",
            new { uid = m.UsuarioId });
        if (existe > 0) return false;

        const string sql = """
            INSERT INTO MiembrosPlanchas (PlanchaId, UsuarioId, Puesto, Orden, Descripcion)
            VALUES (@PlanchaId, @UsuarioId, @Puesto, @Orden, @Descripcion)
            """;
        return con.Execute(sql, m) > 0;
    }

    public bool RemoveMiembro(int miembroId)
    {
        using var con = DbConnection.GetConnection();
        return con.Execute("DELETE FROM MiembrosPlanchas WHERE MiembroId = @Id", new { Id = miembroId }) > 0;
    }

    public bool UsuarioEnPlancha(int usuarioId)
    {
        using var con = DbConnection.GetConnection();
        return con.ExecuteScalar<int>(
            "SELECT COUNT(1) FROM MiembrosPlanchas WHERE UsuarioId = @uid",
            new { uid = usuarioId }) > 0;
    }
}
