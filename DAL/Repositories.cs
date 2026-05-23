using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using SistemaVotacion.Models;

namespace SistemaVotacion.DAL
{
    // ════════════════════════════════════════════════════════════
    //  VOTACIÓN
    // ════════════════════════════════════════════════════════════
    public class VotacionRepository
    {
        public IEnumerable<Votacion> GetAll()
        {
            using (var con = DbConnection.GetConnection())
                return con.Query<Votacion>("SELECT * FROM Votaciones ORDER BY FechaCreacion DESC");
        }

        public Votacion GetActiva()
        {
            using (var con = DbConnection.GetConnection())
                return con.QueryFirstOrDefault<Votacion>(
                    "SELECT TOP 1 * FROM Votaciones WHERE Activa = 1 ORDER BY FechaInicio DESC");
        }

        public Votacion GetById(int id)
        {
            using (var con = DbConnection.GetConnection())
                return con.QueryFirstOrDefault<Votacion>(
                    "SELECT * FROM Votaciones WHERE VotacionId = @Id", new { Id = id });
        }

        public int Insert(Votacion v)
        {
            using (var con = DbConnection.GetConnection())
            {
                const string sql =
                    "INSERT INTO Votaciones (Titulo, Descripcion, FechaInicio, FechaFin, Activa, CreadoPor) " +
                    "OUTPUT INSERTED.VotacionId " +
                    "VALUES (@Titulo, @Descripcion, @FechaInicio, @FechaFin, @Activa, @CreadoPor)";
                return con.ExecuteScalar<int>(sql, v);
            }
        }

        public bool Update(Votacion v)
        {
            using (var con = DbConnection.GetConnection())
            {
                const string sql =
                    "UPDATE Votaciones " +
                    "SET Titulo = @Titulo, Descripcion = @Descripcion, " +
                    "    FechaInicio = @FechaInicio, FechaFin = @FechaFin, Activa = @Activa " +
                    "WHERE VotacionId = @VotacionId";
                return con.Execute(sql, v) > 0;
            }
        }

        public bool Activar(int id)
        {
            using (var con = DbConnection.GetConnection())
            {
                con.Execute("UPDATE Votaciones SET Activa = 0");
                return con.Execute("UPDATE Votaciones SET Activa = 1 WHERE VotacionId = @Id", new { Id = id }) > 0;
            }
        }

        public bool Desactivar(int id)
        {
            using (var con = DbConnection.GetConnection())
                return con.Execute("UPDATE Votaciones SET Activa = 0 WHERE VotacionId = @Id", new { Id = id }) > 0;
        }
    }

    // ════════════════════════════════════════════════════════════
    //  PADRÓN
    // ════════════════════════════════════════════════════════════
    public class PadronRepository
    {
        public IEnumerable<Padron> GetByVotacion(int votacionId)
        {
            using (var con = DbConnection.GetConnection())
            {
                const string sql =
                    "SELECT pad.*, u.Nombre + ' ' + u.Apellido AS NombreCompleto, " +
                    "       u.Matricula, u.Curso, u.Seccion " +
                    "FROM Padrones pad " +
                    "INNER JOIN Usuarios u ON u.UsuarioId = pad.UsuarioId " +
                    "WHERE pad.VotacionId = @vid " +
                    "ORDER BY u.Apellido, u.Nombre";
                return con.Query<Padron>(sql, new { vid = votacionId });
            }
        }

        public bool Agregar(int votacionId, int usuarioId)
        {
            try
            {
                using (var con = DbConnection.GetConnection())
                {
                    con.Execute(
                        "INSERT INTO Padrones (VotacionId, UsuarioId) VALUES (@v, @u)",
                        new { v = votacionId, u = usuarioId });
                    return true;
                }
            }
            catch { return false; }
        }

        public bool Eliminar(int padronId)
        {
            using (var con = DbConnection.GetConnection())
                return con.Execute("DELETE FROM Padrones WHERE PadronId = @Id", new { Id = padronId }) > 0;
        }

        public Padron GetByUsuarioVotacion(int votacionId, int usuarioId)
        {
            using (var con = DbConnection.GetConnection())
                return con.QueryFirstOrDefault<Padron>(
                    "SELECT * FROM Padrones WHERE VotacionId = @v AND UsuarioId = @u",
                    new { v = votacionId, u = usuarioId });
        }
    }

    // ════════════════════════════════════════════════════════════
    //  VOTOS
    // ════════════════════════════════════════════════════════════
    public class VotoRepository
    {
        public bool RegistrarVoto(int votacionId, int padronId, int? planchaId)
        {
            using (var con = DbConnection.GetConnection())
            {
                bool esNulo = planchaId == null;
                const string sql =
                    "INSERT INTO Votos (VotacionId, PadronId, PlanchaId, EsNulo) " +
                    "VALUES (@vid, @pid, @plid, @nulo)";
                return con.Execute(sql, new { vid = votacionId, pid = padronId, plid = planchaId, nulo = esNulo }) > 0;
            }
        }

        public Voto GetVotoByPadron(int votacionId, int padronId)
        {
            using (var con = DbConnection.GetConnection())
                return con.QueryFirstOrDefault<Voto>(
                    "SELECT * FROM Votos WHERE VotacionId = @v AND PadronId = @p",
                    new { v = votacionId, p = padronId });
        }

        public bool UsuarioYaVoto(int votacionId, int padronId)
        {
            var voto = GetVotoByPadron(votacionId, padronId);
            if (voto == null) return false;
            return !voto.EsNulo;
        }

        public EstadisticasVotacion GetEstadisticas(int votacionId)
        {
            using (var con = DbConnection.GetConnection())
            {
                var result = con.QueryMultiple("sp_EstadisticasVotacion",
                    new { VotacionId = votacionId },
                    commandType: System.Data.CommandType.StoredProcedure);

                var stats = result.ReadFirst<EstadisticasVotacion>();
                stats.PorPlancha = result.Read<EstadisticaPlancha>().ToList();
                return stats;
            }
        }

        public bool MarcarNulos(int votacionId)
        {
            using (var con = DbConnection.GetConnection())
            {
                con.Execute("sp_MarcarVotosNulos",
                    new { VotacionId = votacionId },
                    commandType: System.Data.CommandType.StoredProcedure);
                return true;
            }
        }

        public IEnumerable<dynamic> GetReporteGeneral(int votacionId)
        {
            using (var con = DbConnection.GetConnection())
            {
                const string sql =
                    "SELECT " +
                    "    u.Nombre + ' ' + u.Apellido AS Participante, " +
                    "    u.Matricula, u.Curso, u.Seccion, " +
                    "    CASE WHEN v.VotoId IS NULL THEN 'Pendiente' " +
                    "         WHEN v.EsNulo = 1     THEN 'Nulo' " +
                    "         ELSE 'Emitido' END     AS EstadoVoto, " +
                    "    v.FechaVoto, " +
                    "    p.Nombre AS PlanchaNombre " +
                    "FROM Padrones pad " +
                    "INNER JOIN Usuarios u ON u.UsuarioId = pad.UsuarioId " +
                    "LEFT JOIN  Votos    v ON v.PadronId  = pad.PadronId " +
                    "           AND v.VotacionId = @vid " +
                    "LEFT JOIN  Planchas p ON p.PlanchaId = v.PlanchaId " +
                    "WHERE pad.VotacionId = @vid " +
                    "ORDER BY u.Apellido, u.Nombre";
                return con.Query(sql, new { vid = votacionId });
            }
        }
    }

    // ════════════════════════════════════════════════════════════
    //  AUDITORÍA
    // ════════════════════════════════════════════════════════════
    public class AuditoriaRepository
    {
        public void Registrar(int? usuarioId, string accion, string detalle = null)
        {
            try
            {
                using (var con = DbConnection.GetConnection())
                    con.Execute(
                        "INSERT INTO LogAuditoria (UsuarioId, Accion, Detalle) VALUES (@u, @a, @d)",
                        new { u = usuarioId, a = accion, d = detalle });
            }
            catch { /* No interrumpir el flujo por un log fallido */ }
        }

        public IEnumerable<LogAuditoria> GetRecientes(int top = 100)
        {
            using (var con = DbConnection.GetConnection())
                return con.Query<LogAuditoria>(
                    string.Format("SELECT TOP {0} * FROM LogAuditoria ORDER BY Fecha DESC", top));
        }
    }
}