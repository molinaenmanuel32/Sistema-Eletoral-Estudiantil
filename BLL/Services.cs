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

        string hash = HashPassword(password);
        var user = _repo.Login(username, hash);

        if (user is null)
        {
            _audit.Registrar(null, "LOGIN_FAIL", $"Intento fallido: {username}");
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

    public static bool VerifyPassword(string password, string hash) =>
        BCrypt.Net.BCrypt.Verify(password, hash);
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
    private readonly AuditoriaRepository _audit = new();

    public IEnumerable<Plancha> GetAll() => _repo.GetAll();
    public Plancha? GetById(int id)       => _repo.GetById(id);
    public IEnumerable<MiembroPlancha> GetMiembros(int id) => _repo.GetMiembros(id);

    public (bool ok, string msg, int id) Crear(Plancha p)
    {
        Sesion.Requiere("Admin", "AdminPartido");
        if (Sesion.EsAdminPartido)
            p.AdminUserId = Sesion.UsuarioActual!.UsuarioId;

        int newId = _repo.Insert(p);
        _audit.Registrar(Sesion.UsuarioActual!.UsuarioId, "PLANCHA_CREADA", p.Nombre);
        return (true, "Plancha creada.", newId);
    }

    public (bool ok, string msg) Actualizar(Plancha p)
    {
        // AdminPartido solo puede editar SU plancha
        if (Sesion.EsAdminPartido && p.AdminUserId != Sesion.UsuarioActual!.UsuarioId)
            return (false, "Solo puede editar su propia plancha.");

        _repo.Update(p);
        _audit.Registrar(Sesion.UsuarioActual!.UsuarioId, "PLANCHA_ACTUALIZADA", $"Id:{p.PlanchaId}");
        return (true, "Plancha actualizada.");
    }

    public (bool ok, string msg) AgregarMiembro(MiembroPlancha m)
    {
        if (_repo.UsuarioEnPlancha(m.UsuarioId))
            return (false, "Este usuario ya pertenece a una plancha.");

        bool ok = _repo.AddMiembro(m);
        if (ok) _audit.Registrar(Sesion.UsuarioActual?.UsuarioId, "MIEMBRO_AGREGADO",
                                  $"Plancha:{m.PlanchaId} Usuario:{m.UsuarioId}");
        return ok ? (true, "Miembro agregado.") : (false, "No se pudo agregar el miembro.");
    }

    public bool EliminarMiembro(int miembroId) => _repo.RemoveMiembro(miembroId);
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
