using System;
using System.Linq;
using System.Windows.Forms;
using SistemaVotacion.BLL;
using SistemaVotacion.Models;
using SistemaVotacion.Utils;

namespace SistemaVotacion.UI.Forms
{
    public partial class FrmEditarUsuario : Form
    {
        private readonly Usuario _usuario;
        private readonly UsuarioService _svc = new UsuarioService();

        public FrmEditarUsuario(Usuario usuario = null)
        {
            _usuario = usuario;

            InitializeComponent();

            cmbRol.SelectedIndexChanged += new EventHandler(cmbRol_SelectedIndexChanged);

            CargarRoles();

            if (_usuario != null)
                CargarDatos();
            else
                txtMatricula.Text = GenerarMatriculaPorRol("Votante");
        }

        // ── Carga de roles ────────────────────────────────────────────
        private void CargarRoles()
        {
            cmbRol.Items.Clear();
            cmbRol.Items.Add("Admin");
            cmbRol.Items.Add("AdminPartido");
            cmbRol.Items.Add("Votante");
            cmbRol.SelectedIndex = 2;
        }

        // ── Cuando cambia el rol, actualiza la matrícula sugerida ─────
        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_usuario == null)
            {
                string rol = cmbRol.SelectedItem != null
                    ? cmbRol.SelectedItem.ToString()
                    : "Votante";
                txtMatricula.Text = GenerarMatriculaPorRol(rol);
            }
        }

        // ── Genera matrícula automática según rol ─────────────────────
        private string GenerarMatriculaPorRol(string rol)
        {
            string prefijo;

            if (rol == "Admin")
                prefijo = "ADM";
            else if (rol == "AdminPartido")
                prefijo = "ADP";
            else
                prefijo = "VOT";

            var usuarios = _svc.GetAll();

            int ultimoNumero = usuarios
                .Where(u => u.Matricula != null &&
                            u.Matricula.StartsWith(prefijo + "-"))
                .Select(u =>
                {
                    string numero = u.Matricula.Replace(prefijo + "-", "");
                    int n;
                    return int.TryParse(numero, out n) ? n : 0;
                })
                .DefaultIfEmpty(0)
                .Max();

            return prefijo + "-" + (ultimoNumero + 1).ToString("0000");
        }

        // ── Rellena los campos cuando se edita un usuario existente ───
        private void CargarDatos()
        {
            Text = "Editar Usuario";
            lblTitulo.Text = "Editar Usuario";
            lblSubtitulo.Text = "Modifica la información del usuario seleccionado.";

            txtNombre.Text = _usuario.Nombre ?? "";
            txtApellido.Text = _usuario.Apellido ?? "";
            txtMatricula.Text = _usuario.Matricula ?? "";
            txtCurso.Text = _usuario.Curso ?? "";
            txtSeccion.Text = _usuario.Seccion ?? "";
            txtEmail.Text = _usuario.Email ?? "";
            txtUsername.Text = _usuario.Username ?? "";

            cmbRol.SelectedItem = _usuario.RolNombre;
        }

        // ── Guardar ───────────────────────────────────────────────────
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                Helpers.MsgError("Completa los campos obligatorios (Nombre, Apellido, Username).");
                return;
            }

            Usuario u = _usuario ?? new Usuario();

            u.Nombre = txtNombre.Text.Trim();
            u.Apellido = txtApellido.Text.Trim();

            // La matrícula solo se autogenera al crear; en edición se respeta la existente
            if (_usuario == null)
            {
                string rol = cmbRol.SelectedItem != null
                    ? cmbRol.SelectedItem.ToString()
                    : "Votante";
                u.Matricula = GenerarMatriculaPorRol(rol);
            }
            else
            {
                u.Matricula = txtMatricula.Text.Trim();
            }

            u.Curso = txtCurso.Text.Trim();
            u.Seccion = txtSeccion.Text.Trim();
            u.Email = txtEmail.Text.Trim();
            u.Username = txtUsername.Text.Trim();

            u.RolNombre = cmbRol.SelectedItem != null
                ? cmbRol.SelectedItem.ToString()
                : "Votante";

            if (u.RolNombre == "Admin")
                u.RolId = 1;
            else if (u.RolNombre == "AdminPartido")
                u.RolId = 2;
            else
                u.RolId = 3;

            u.Activo = true;

            Tuple<bool, string> result;

            if (_usuario == null)
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    Helpers.MsgError("La contraseña es obligatoria al crear un usuario.");
                    return;
                }
                result = _svc.Crear(u, txtPassword.Text);
            }
            else
            {
                result = _svc.Actualizar(u);

                if (result.Item1 && !string.IsNullOrWhiteSpace(txtPassword.Text))
                    _svc.CambiarPassword(u.UsuarioId, txtPassword.Text);
            }

            if (!result.Item1)
            {
                Helpers.MsgError(result.Item2);
                return;
            }

            Helpers.MsgExito(result.Item2);
            DialogResult = DialogResult.OK;
            Close();
        }

        // ── Cancelar ──────────────────────────────────────────────────
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}