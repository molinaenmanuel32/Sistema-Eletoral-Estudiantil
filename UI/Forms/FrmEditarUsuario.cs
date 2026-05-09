using SistemaVotacion.BLL;
using SistemaVotacion.Models;
using SistemaVotacion.Utils;
using System;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    public partial class FrmEditarUsuario : Form
    {
        private readonly Usuario? _usuario;
        private readonly UsuarioService _svc = new();

        public FrmEditarUsuario(Usuario? usuario)
        {
            _usuario = usuario;

            InitializeComponent();

            CargarRoles();

            if (_usuario != null)
                CargarDatos();
        }

        private void CargarRoles()
        {
            cmbRol.Items.Clear();
            cmbRol.Items.Add("Admin");
            cmbRol.Items.Add("AdminPartido");
            cmbRol.Items.Add("Votante");
            cmbRol.SelectedIndex = 2;
        }

        private string GenerarMatriculaPorRol(string rol)
        {
            string prefijo = rol switch
            {
                "Admin" => "ADM",
                "AdminPartido" => "ADP",
                _ => "VOT"
            };

            var usuarios = _svc.GetAll();

            int ultimoNumero = usuarios
                .Where(u => u.Matricula != null && u.Matricula.StartsWith(prefijo + "-"))
                .Select(u =>
                {
                    string numero = u.Matricula.Replace(prefijo + "-", "");
                    return int.TryParse(numero, out int n) ? n : 0;
                })
                .DefaultIfEmpty(0)
                .Max();

            return $"{prefijo}-{(ultimoNumero + 1):0000}";
        }

        private void CargarDatos()
        {
            Text = "Editar Usuario";
            lblTitulo.Text = "Editar Usuario";
            lblSubtitulo.Text = "Modifica la información del usuario seleccionado.";

            txtNombre.Text = _usuario!.Nombre;
            txtApellido.Text = _usuario.Apellido;
            txtMatricula.Text = _usuario.Matricula;
            txtCurso.Text = _usuario.Curso ?? "";
            txtSeccion.Text = _usuario.Seccion ?? "";
            txtEmail.Text = _usuario.Email ?? "";
            txtUsername.Text = _usuario.Username;
            txtPassword.PlaceholderText = "Dejar en blanco para no cambiar";
            cmbRol.SelectedItem = _usuario.RolNombre;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                Helpers.MsgError("Completa los campos obligatorios.");
                return;
            }

            var u = _usuario ?? new Usuario();

            u.Nombre = txtNombre.Text.Trim();
            u.Apellido = txtApellido.Text.Trim();

            if (_usuario == null)
            {
                string rol = cmbRol.SelectedItem?.ToString() ?? "Votante";
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
            u.RolNombre = cmbRol.SelectedItem?.ToString() ?? "Votante";
            u.RolId = u.RolNombre switch
            {
                "Admin" => 1,
                "AdminPartido" => 2,
                _ => 3
            };
            u.Activo = true;

            (bool ok, string msg) result;

            if (_usuario == null)
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    Helpers.MsgError("La contraseña es obligatoria.");
                    return;
                }

                result = _svc.Crear(u, txtPassword.Text);
            }
            else
            {
                result = _svc.Actualizar(u);

                if (result.ok && !string.IsNullOrWhiteSpace(txtPassword.Text))
                    _svc.CambiarPassword(u.UsuarioId, txtPassword.Text);
            }

            if (!result.ok)
            {
                Helpers.MsgError(result.msg);
                return;
            }

            Helpers.MsgExito(result.msg);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}