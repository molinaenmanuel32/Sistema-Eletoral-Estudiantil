using System.Collections.Generic;
using System.Linq;
using Dapper;
using SistemaVotacion.Models;

namespace SistemaVotacion.DAL
{
    public class PlanchaRepository
    {
        public IEnumerable<Plancha> GetAll()
        {
            using (var con = DbConnection.GetConnection())
            {
                const string sql =
                    "SELECT p.*, u.Nombre + ' ' + u.Apellido AS AdminNombre " +
                    "FROM Planchas p " +
                    "INNER JOIN Usuarios u ON u.UsuarioId = p.AdminUserId " +
                    "ORDER BY p.Nombre";
                return con.Query<Plancha>(sql);
            }
        }

        public Plancha GetById(int id)
        {
            using (var con = DbConnection.GetConnection())
            {
                const string sql =
                    "SELECT p.*, u.Nombre + ' ' + u.Apellido AS AdminNombre " +
                    "FROM Planchas p " +
                    "INNER JOIN Usuarios u ON u.UsuarioId = p.AdminUserId " +
                    "WHERE p.PlanchaId = @Id";
                var plancha = con.QueryFirstOrDefault<Plancha>(sql, new { Id = id });
                if (plancha != null)
                    plancha.Miembros = GetMiembros(id).ToList();
                return plancha;
            }
        }

        public int Insert(Plancha p)
        {
            using (var con = DbConnection.GetConnection())
            {
                const string sql =
                    "INSERT INTO Planchas (Nombre, Descripcion, Mision, LogoPath, Color, AdminUserId, Activa) " +
                    "OUTPUT INSERTED.PlanchaId " +
                    "VALUES (@Nombre, @Descripcion, @Mision, @LogoPath, @Color, @AdminUserId, @Activa)";
                return con.ExecuteScalar<int>(sql, p);
            }
        }

        public bool Update(Plancha p)
        {
            using (var con = DbConnection.GetConnection())
            {
                const string sql =
                    "UPDATE Planchas " +
                    "SET Nombre = @Nombre, Descripcion = @Descripcion, Mision = @Mision, " +
                    "    LogoPath = @LogoPath, Color = @Color, AdminUserId = @AdminUserId, " +
                    "    Activa = @Activa, FechaModificacion = GETDATE() " +
                    "WHERE PlanchaId = @PlanchaId";
                return con.Execute(sql, p) > 0;
            }
        }

        public IEnumerable<MiembroPlancha> GetMiembros(int planchaId)
        {
            using (var con = DbConnection.GetConnection())
            {
                const string sql =
                    "SELECT mp.*, u.Nombre + ' ' + u.Apellido AS NombreCompleto, u.Matricula " +
                    "FROM MiembrosPlanchas mp " +
                    "INNER JOIN Usuarios u ON u.UsuarioId = mp.UsuarioId " +
                    "WHERE mp.PlanchaId = @PlanchaId " +
                    "ORDER BY mp.Orden";
                return con.Query<MiembroPlancha>(sql, new { PlanchaId = planchaId });
            }
        }

        public MiembroPlancha GetMiembroById(int miembroId)
        {
            using (var con = DbConnection.GetConnection())
            {
                const string sql =
                    "SELECT mp.*, u.Nombre + ' ' + u.Apellido AS NombreCompleto, u.Matricula " +
                    "FROM MiembrosPlanchas mp " +
                    "INNER JOIN Usuarios u ON u.UsuarioId = mp.UsuarioId " +
                    "WHERE mp.MiembroId = @MiembroId";
                return con.QueryFirstOrDefault<MiembroPlancha>(sql, new { MiembroId = miembroId });
            }
        }

        public bool AddMiembro(MiembroPlancha m)
        {
            using (var con = DbConnection.GetConnection())
            {
                int existe = con.ExecuteScalar<int>(
                    "SELECT COUNT(1) FROM MiembrosPlanchas WHERE UsuarioId = @UsuarioId",
                    new { m.UsuarioId });
                if (existe > 0) return false;

                const string sql =
                    "INSERT INTO MiembrosPlanchas " +
                    "(PlanchaId, UsuarioId, Puesto, Orden, Descripcion, Nombre, Matricula, FotoPath) " +
                    "VALUES (@PlanchaId, @UsuarioId, @Puesto, @Orden, @Descripcion, @Nombre, @Matricula, @FotoPath)";
                return con.Execute(sql, m) > 0;
            }
        }

        public bool UpdateMiembro(MiembroPlancha m)
        {
            using (var con = DbConnection.GetConnection())
            {
                const string sql =
                    "UPDATE MiembrosPlanchas " +
                    "SET Puesto = @Puesto, Orden = @Orden, Descripcion = @Descripcion, " +
                    "    Nombre = @Nombre, Matricula = @Matricula, FotoPath = @FotoPath " +
                    "WHERE MiembroId = @MiembroId";
                return con.Execute(sql, m) > 0;
            }
        }

        public bool ExistePuestoEnPlancha(int planchaId, string puesto, int miembroIdExcluir = 0)
        {
            using (var con = DbConnection.GetConnection())
                return con.ExecuteScalar<int>(
                    "SELECT COUNT(1) FROM MiembrosPlanchas " +
                    "WHERE PlanchaId = @PlanchaId " +
                    "  AND LOWER(LTRIM(RTRIM(Puesto))) = LOWER(LTRIM(RTRIM(@Puesto))) " +
                    "  AND MiembroId <> @MiembroIdExcluir",
                    new { PlanchaId = planchaId, Puesto = puesto, MiembroIdExcluir = miembroIdExcluir }) > 0;
        }

        public bool RemoveMiembro(int miembroId)
        {
            using (var con = DbConnection.GetConnection())
                return con.Execute(
                    "DELETE FROM MiembrosPlanchas WHERE MiembroId = @Id",
                    new { Id = miembroId }) > 0;
        }

        public bool Delete(int planchaId)
        {
            using (var con = DbConnection.GetConnection())
            {
                con.Execute("DELETE FROM MiembrosPlanchas WHERE PlanchaId = @Id", new { Id = planchaId });
                return con.Execute("DELETE FROM Planchas WHERE PlanchaId = @Id", new { Id = planchaId }) > 0;
            }
        }
    }
}
