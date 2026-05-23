using System;
using System.Collections.Generic;
using System.Linq;
using SistemaVotacion.DAL;
using SistemaVotacion.Models;

namespace SistemaVotacion.BLL
{
    // ════════════════════════════════════════════════════════════
    //  SESIÓN (usuario en memoria)
    // ════════════════════════════════════════════════════════════
    public static class Sesion
    {
        public static Usuario UsuarioActual { get; private set; }

        public static bool EsAdmin
        {
            get { return UsuarioActual != null && UsuarioActual.RolNombre == "Admin"; }
        }

        public static bool EsAdminPartido
        {
            get { return UsuarioActual != null && UsuarioActual.RolNombre == "AdminPartido"; }
        }

        public static bool EsVotante
        {
            get { return UsuarioActual != null && UsuarioActual.RolNombre == "Votante"; }
        }

        public static void Iniciar(Usuario u)
        {
            UsuarioActual = u;
        }

        public static void Cerrar()
        {
            UsuarioActual = null;
        }

        public static void Requiere(params string[] roles)
        {
            if (UsuarioActual == null || !roles.Contains(UsuarioActual.RolNombre))
            {
                throw new UnauthorizedAccessException(
                    "Acceso denegado. Se requiere uno de los roles: " +
                    string.Join(", ", roles));
            }
        }
    }

    // ════════════════════════════════════════════════════════════
    //  AUTENTICACIÓN
    // ════════════════════════════════════════════════════════════
    public class AuthService
    {
        private readonly UsuarioRepository _repo =
            new UsuarioRepository();

        private readonly AuditoriaRepository _audit =
            new AuditoriaRepository();

        public Tuple<bool, string, Usuario> Login(
            string username,
            string password)
        {
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                return Tuple.Create<bool, string, Usuario>(
                    false,
                    "Complete usuario y contraseña.",
                    null);
            }

            username = username.Trim();

            Usuario user = _repo.Login(username);

            if (user == null)
            {
                _audit.Registrar(
                    null,
                    "LOGIN_FAIL",
                    "Usuario no existe o está inactivo: " + username);

                return Tuple.Create<bool, string, Usuario>(
                    false,
                    "Usuario o contraseña incorrectos.",
                    null);
            }

            bool passwordOk = false;

            try
            {
                passwordOk = BCrypt.Net.BCrypt.Verify(
                    password,
                    user.PasswordHash);
            }
            catch
            {
                passwordOk = false;
            }

            if (!passwordOk)
            {
                _audit.Registrar(
                    user.UsuarioId,
                    "LOGIN_FAIL",
                    "Contraseña incorrecta: " + username);

                return Tuple.Create<bool, string, Usuario>(
                    false,
                    "Usuario o contraseña incorrectos.",
                    null);
            }

            Sesion.Iniciar(user);

            _audit.Registrar(
                user.UsuarioId,
                "LOGIN_OK",
                "Sesión iniciada: " + username);

            return Tuple.Create(
                true,
                "Bienvenido.",
                user);
        }

        public void Logout()
        {
            _audit.Registrar(
                Sesion.UsuarioActual != null
                    ? (int?)Sesion.UsuarioActual.UsuarioId
                    : null,
                "LOGOUT");

            Sesion.Cerrar();
        }

        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(
                password,
                workFactor: 12);
        }

        public static bool VerifyPassword(
            string password,
            string hash)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(
                    password,
                    hash);
            }
            catch
            {
                return false;
            }
        }
    }

    // ════════════════════════════════════════════════════════════
    //  USUARIOS
    // ════════════════════════════════════════════════════════════
    public class UsuarioService
    {
        private readonly UsuarioRepository _repo =
            new UsuarioRepository();

        private readonly AuditoriaRepository _audit =
            new AuditoriaRepository();

        public IEnumerable<Usuario> GetAll()
        {
            return _repo.GetAll();
        }

        public Usuario GetById(int id)
        {
            return _repo.GetById(id);
        }

        public Tuple<bool, string> Crear(
            Usuario u,
            string password)
        {
            Sesion.Requiere("Admin");

            if (_repo.ExisteMatricula(u.Matricula))
            {
                return Tuple.Create(
                    false,
                    "Matrícula ya registrada.");
            }

            if (_repo.ExisteUsername(u.Username))
            {
                return Tuple.Create(
                    false,
                    "Username ya en uso.");
            }

            if (password.Length < 6)
            {
                return Tuple.Create(
                    false,
                    "La contraseña debe tener mínimo 6 caracteres.");
            }

            u.PasswordHash =
                AuthService.HashPassword(password);

            int newId = _repo.Insert(u);

            _audit.Registrar(
                Sesion.UsuarioActual.UsuarioId,
                "USUARIO_CREADO",
                "Id:" + newId + " " + u.Username);

            return Tuple.Create(
                true,
                "Usuario creado correctamente.");
        }

        public Tuple<bool, string> Actualizar(Usuario u)
        {
            Sesion.Requiere("Admin");

            if (_repo.ExisteMatricula(
                u.Matricula,
                u.UsuarioId))
            {
                return Tuple.Create(
                    false,
                    "Matrícula ya registrada.");
            }

            if (_repo.ExisteUsername(
                u.Username,
                u.UsuarioId))
            {
                return Tuple.Create(
                    false,
                    "Username ya en uso.");
            }

            _repo.Update(u);

            _audit.Registrar(
                Sesion.UsuarioActual.UsuarioId,
                "USUARIO_ACTUALIZADO",
                "Id:" + u.UsuarioId);

            return Tuple.Create(
                true,
                "Usuario actualizado.");
        }

        public Tuple<bool, string> CambiarPassword(
            int id,
            string newPass)
        {
            if (newPass.Length < 6)
            {
                return Tuple.Create(
                    false,
                    "Mínimo 6 caracteres.");
            }

            _repo.UpdatePassword(
                id,
                AuthService.HashPassword(newPass));

            _audit.Registrar(
                Sesion.UsuarioActual != null
                    ? (int?)Sesion.UsuarioActual.UsuarioId
                    : null,
                "PASSWORD_CAMBIADO",
                "Id:" + id);

            return Tuple.Create(
                true,
                "Contraseña actualizada.");
        }

        public Tuple<bool, string> Eliminar(int id)
        {
            Sesion.Requiere("Admin");

            _repo.Delete(id);

            _audit.Registrar(
                Sesion.UsuarioActual.UsuarioId,
                "USUARIO_DESACTIVADO",
                "Id:" + id);

            return Tuple.Create(
                true,
                "Usuario desactivado.");
        }

        public IEnumerable<Usuario> GetVotantesDisponibles(
            int votacionId)
        {
            return _repo.GetVotantesDisponibles(votacionId);
        }
    }

    // ════════════════════════════════════════════════════════════
    //  PLANCHAS
    // ════════════════════════════════════════════════════════════
    public class PlanchaService
    {
        private readonly PlanchaRepository _repo =
            new PlanchaRepository();

        public IEnumerable<Plancha> GetAll()
        {
            return _repo.GetAll();
        }

        public Plancha GetById(int id)
        {
            return _repo.GetById(id);
        }

        public IEnumerable<MiembroPlancha> GetMiembros(
            int planchaId)
        {
            return _repo.GetMiembros(planchaId);
        }

        public MiembroPlancha GetMiembroById(
            int miembroId)
        {
            return _repo.GetMiembroById(miembroId);
        }

        public int Crear(Plancha plancha)
        {
            return _repo.Insert(plancha);
        }

        public bool Actualizar(Plancha plancha)
        {
            // AdminPartido solo puede editar su propia plancha
            if (Sesion.EsAdminPartido)
            {
                var existing = _repo.GetById(plancha.PlanchaId);
                if (existing == null ||
                    existing.AdminUserId != Sesion.UsuarioActual.UsuarioId)
                {
                    throw new UnauthorizedAccessException(
                        "Solo puedes editar tu propia plancha.");
                }
            }
            else
            {
                Sesion.Requiere("Admin", "AdminPartido");
            }

            return _repo.Update(plancha);
        }


        public bool Eliminar(int planchaId)
        {
            return _repo.Delete(planchaId);
        }

        public bool EliminarMiembro(int miembroId)
        {
            return _repo.RemoveMiembro(miembroId);
        }

        public Tuple<bool, string> AgregarMiembro(
            MiembroPlancha miembro)
        {
            // AdminPartido solo puede gestionar su propia plancha
            if (Sesion.EsAdminPartido)
            {
                var plancha = _repo.GetById(miembro.PlanchaId);
                if (plancha == null ||
                    plancha.AdminUserId != Sesion.UsuarioActual.UsuarioId)
                {
                    return Tuple.Create(
                        false,
                        "Solo puedes gestionar tu propia plancha.");
                }
            }

            if (string.IsNullOrWhiteSpace(miembro.Puesto))
            {
                return Tuple.Create(
                    false,
                    "Debe seleccionar un cargo.");
            }

            if (EsCargoUnico(miembro.Puesto))
            {
                if (_repo.ExistePuestoEnPlancha(
                    miembro.PlanchaId,
                    miembro.Puesto))
                {
                    return Tuple.Create(
                        false,
                        "Ya existe un " +
                        miembro.Puesto +
                        " en esta plancha.");
                }
            }

            bool ok = _repo.AddMiembro(miembro);

            if (ok)
            {
                return Tuple.Create(
                    true,
                    "Miembro agregado correctamente.");
            }

            return Tuple.Create(
                false,
                "Este usuario ya pertenece a una plancha.");
        }

        public Tuple<bool, string> EditarMiembro(
            MiembroPlancha miembro)
        {
            // AdminPartido solo puede gestionar su propia plancha
            if (Sesion.EsAdminPartido)
            {
                var plancha = _repo.GetById(miembro.PlanchaId);
                if (plancha == null ||
                    plancha.AdminUserId != Sesion.UsuarioActual.UsuarioId)
                {
                    return Tuple.Create(
                        false,
                        "Solo puedes gestionar tu propia plancha.");
                }
            }

            if (string.IsNullOrWhiteSpace(miembro.Puesto))
            {
                return Tuple.Create(
                    false,
                    "Debe seleccionar un cargo.");
            }

            if (EsCargoUnico(miembro.Puesto))
            {
                if (_repo.ExistePuestoEnPlancha(
                    miembro.PlanchaId,
                    miembro.Puesto,
                    miembro.MiembroId))
                {
                    return Tuple.Create(
                        false,
                        "Ya existe un " +
                        miembro.Puesto +
                        " en esta plancha.");
                }
            }

            bool ok = _repo.UpdateMiembro(miembro);

            if (ok)
            {
                return Tuple.Create(
                    true,
                    "Miembro actualizado correctamente.");
            }

            return Tuple.Create(
                false,
                "No se pudo actualizar el miembro.");
        }

        private bool EsCargoUnico(string puesto)
        {
            return puesto.Equals(
                       "Presidente",
                       StringComparison.OrdinalIgnoreCase)
                   ||
                   puesto.Equals(
                       "Vicepresidente",
                       StringComparison.OrdinalIgnoreCase);
        }
    }

    // ════════════════════════════════════════════════════════════
    //  VOTACIÓN
    // ════════════════════════════════════════════════════════════
    public class VotacionService
    {
        private readonly VotacionRepository _votRepo =
            new VotacionRepository();

        private readonly PadronRepository _padRepo =
            new PadronRepository();

        private readonly VotoRepository _votoRepo =
            new VotoRepository();

        private readonly AuditoriaRepository _audit =
            new AuditoriaRepository();

        public IEnumerable<Votacion> GetAll()
        {
            return _votRepo.GetAll();
        }

        public Votacion GetActiva()
        {
            return _votRepo.GetActiva();
        }

        public Votacion GetById(int id)
        {
            return _votRepo.GetById(id);
        }

        public Tuple<bool, string> Actualizar(Votacion v)
        {
            Sesion.Requiere("Admin");

            if (v.FechaFin <= v.FechaInicio)
            {
                return Tuple.Create(
                    false,
                    "La fecha fin debe ser mayor que la de inicio.");
            }

            _votRepo.Update(v);

            _audit.Registrar(
                Sesion.UsuarioActual.UsuarioId,
                "VOTACION_ACTUALIZADA",
                "Id:" + v.VotacionId + " " + v.Titulo);

            return Tuple.Create(
                true,
                "Votación actualizada correctamente.");
        }

        public Tuple<bool, string, int> Crear(
            Votacion v)
        {
            Sesion.Requiere("Admin");

            if (v.FechaFin <= v.FechaInicio)
            {
                return Tuple.Create(
                    false,
                    "La fecha fin debe ser mayor que la de inicio.",
                    0);
            }

            v.CreadoPor =
                Sesion.UsuarioActual.UsuarioId;

            int id = _votRepo.Insert(v);

            _audit.Registrar(
                Sesion.UsuarioActual.UsuarioId,
                "VOTACION_CREADA",
                v.Titulo);

            return Tuple.Create(
                true,
                "Votación creada.",
                id);
        }

        public Tuple<bool, string> Activar(int id)
        {
            Sesion.Requiere("Admin");

            _votRepo.Activar(id);

            _audit.Registrar(
                Sesion.UsuarioActual.UsuarioId,
                "VOTACION_ACTIVADA",
                "Id:" + id);

            return Tuple.Create(
                true,
                "Votación activada.");
        }

        public Tuple<bool, string> Cerrar(int id)
        {
            Sesion.Requiere("Admin");

            _votoRepo.MarcarNulos(id);
            _votRepo.Desactivar(id);

            _audit.Registrar(
                Sesion.UsuarioActual.UsuarioId,
                "VOTACION_CERRADA",
                "Id:" + id);

            return Tuple.Create(
                true,
                "Votación cerrada. Votos nulos marcados.");
        }

        /// <summary>
        /// Cierra automáticamente votaciones expiradas y marca votos nulos.
        /// Se llama desde el timer de fondo en Program.cs cada 30 segundos.
        /// </summary>
        public void CerrarVotacionesExpiradas()
        {
            try
            {
                var activa = _votRepo.GetActiva();
                if (activa != null &&
                    !activa.EnCurso &&
                    activa.FechaFin < DateTime.Now)
                {
                    _votoRepo.MarcarNulos(activa.VotacionId);
                    _votRepo.Desactivar(activa.VotacionId);
                    _audit.Registrar(
                        null,
                        "VOTACION_EXPIRADA_AUTO",
                        "Cerrada automáticamente: " + activa.Titulo);
                }
            }
            catch { /* No interrumpir el proceso en background */ }
        }

        public IEnumerable<Padron> GetPadron(
            int votacionId)
        {
            return _padRepo.GetByVotacion(votacionId);
        }

        public Tuple<bool, string> AgregarAlPadron(
            int votacionId,
            int usuarioId)
        {
            Sesion.Requiere("Admin");

            bool ok = _padRepo.Agregar(
                votacionId,
                usuarioId);

            if (ok)
            {
                return Tuple.Create(
                    true,
                    "Participante agregado.");
            }

            return Tuple.Create(
                false,
                "El usuario ya está en el padrón.");
        }

        public bool EliminarDelPadron(int padronId)
        {
            return _padRepo.Eliminar(padronId);
        }

        public Tuple<bool, string> Votar(
            int votacionId,
            int? planchaId)
        {
            Sesion.Requiere(
                "Votante",
                "AdminPartido");

            Votacion votacion =
                _votRepo.GetById(votacionId);

            if (votacion == null)
            {
                throw new Exception(
                    "Votación no encontrada.");
            }

            if (!votacion.EnCurso)
            {
                return Tuple.Create(
                    false,
                    "La votación no está activa o ya terminó.");
            }

            Padron padron =
                _padRepo.GetByUsuarioVotacion(
                    votacionId,
                    Sesion.UsuarioActual.UsuarioId);

            if (padron == null)
            {
                return Tuple.Create(
                    false,
                    "No estás habilitado para votar en esta votación.");
            }

            if (_votoRepo.UsuarioYaVoto(
                votacionId,
                padron.PadronId))
            {
                return Tuple.Create(
                    false,
                    "Ya has emitido tu voto.");
            }

            bool ok = _votoRepo.RegistrarVoto(
                votacionId,
                padron.PadronId,
                planchaId);

            if (ok)
            {
                _audit.Registrar(
                    Sesion.UsuarioActual.UsuarioId,
                    "VOTO_EMITIDO",
                    "Votacion:" + votacionId +
                    " Nulo:" + (planchaId == null));
            }

            if (ok)
            {
                return Tuple.Create(
                    true,
                    "Voto registrado exitosamente.");
            }

            return Tuple.Create(
                false,
                "Error al registrar el voto.");
        }

        public EstadisticasVotacion GetEstadisticas(
            int votacionId)
        {
            return _votoRepo.GetEstadisticas(votacionId);
        }

        public IEnumerable<dynamic> GetReporteGeneral(
            int votacionId)
        {
            return _votoRepo.GetReporteGeneral(votacionId);
        }

        public bool VerificarSiVoto(int votacionId)
        {
            if (Sesion.UsuarioActual == null)
            {
                return false;
            }

            Padron padron =
                _padRepo.GetByUsuarioVotacion(
                    votacionId,
                    Sesion.UsuarioActual.UsuarioId);

            if (padron == null)
            {
                return false;
            }

            return _votoRepo.UsuarioYaVoto(
                votacionId,
                padron.PadronId);
        }
    }
}