<<<<<<< HEAD
using SistemaVotacion.BLL;
using SistemaVotacion.Models;
using SistemaVotacion.Utils;
using System;
using System.Linq;
=======
﻿using SistemaVotacion.BLL;
using SistemaVotacion.Models;
using SistemaVotacion.Utils;
using System;
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    public partial class FrmEditarUsuario : Form
    {
<<<<<<< HEAD
        private readonly Usuario _usuario;
        private readonly UsuarioService _svc = new UsuarioService();

        public FrmEditarUsuario(Usuario usuario = null)
=======
        private readonly Usuario? _usuario;
        private readonly UsuarioService _svc = new();

        public FrmEditarUsuario(Usuario? usuario)
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
        {
            _usuario = usuario;

            InitializeComponent();

<<<<<<< HEAD
            cmbRol.SelectedIndexChanged += cmbRol_SelectedIndexChanged;

=======
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
            CargarRoles();

            if (_usuario != null)
                CargarDatos();
<<<<<<< HEAD
            else
                txtMatricula.Text = GenerarMatriculaPorRol("Votante");
=======
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
        }

        private void CargarRoles()
        {
            cmbRol.Items.Clear();
<<<<<<< HEAD

            cmbRol.Items.Add("Admin");
            cmbRol.Items.Add("AdminPartido");
            cmbRol.Items.Add("Votante");

            cmbRol.SelectedIndex = 2;
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_usuario == null)
            {
                string rol = "Votante";

                if (cmbRol.SelectedItem != null)
                    rol = cmbRol.SelectedItem.ToString();

                txtMatricula.Text = GenerarMatriculaPorRol(rol);
            }
        }

        private string GenerarMatriculaPorRol(string rol)
        {
            string prefijo;

            if (rol == "Admin")
                prefijo = "ADM";
            else if (rol == "AdminPartido")
                prefijo = "ADP";
            else
                prefijo = "VOT";
=======
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
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

            var usuarios = _svc.GetAll();

            int ultimoNumero = usuarios
                .Where(u => u.Matricula != null && u.Matricula.StartsWith(prefijo + "-"))
                .Select(u =>
                {
                    string numero = u.Matricula.Replace(prefijo + "-", "");
<<<<<<< HEAD

                    int n;

                    if (int.TryParse(numero, out n))
                        return n;

                    return 0;
=======
                    return int.TryParse(numero, out int n) ? n : 0;
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
                })
                .DefaultIfEmpty(0)
                .Max();

<<<<<<< HEAD
            return string.Format("{0}-{1:0000}", prefijo, ultimoNumero + 1);
=======
            return $"{prefijo}-{(ultimoNumero + 1):0000}";
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
        }

        private void CargarDatos()
        {
            Text = "Editar Usuario";
<<<<<<< HEAD

            lblTitulo.Text = "Editar Usuario";
            lblSubtitulo.Text = "Modifica la información del usuario seleccionado.";

            txtNombre.Text = _usuario.Nombre;
            txtApellido.Text = _usuario.Apellido;
            txtMatricula.Text = _usuario.Matricula;
            txtCurso.Text = _usuario.Curso;
            txtSeccion.Text = _usuario.Seccion;
            txtEmail.Text = _usuario.Email;
            txtUsername.Text = _usuario.Username;

=======
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
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
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

<<<<<<< HEAD
            Usuario u;

            if (_usuario == null)
                u = new Usuario();
            else
                u = _usuario;
=======
            var u = _usuario ?? new Usuario();
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

            u.Nombre = txtNombre.Text.Trim();
            u.Apellido = txtApellido.Text.Trim();

            if (_usuario == null)
            {
<<<<<<< HEAD
                string rol = "Votante";

                if (cmbRol.SelectedItem != null)
                    rol = cmbRol.SelectedItem.ToString();

=======
                string rol = cmbRol.SelectedItem?.ToString() ?? "Votante";
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
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
<<<<<<< HEAD

            if (cmbRol.SelectedItem != null)
                u.RolNombre = cmbRol.SelectedItem.ToString();
            else
                u.RolNombre = "Votante";

            if (u.RolNombre == "Admin")
                u.RolId = 1;
            else if (u.RolNombre == "AdminPartido")
                u.RolId = 2;
            else
                u.RolId = 3;

            u.Activo = true;

            Tuple<bool, string> result;
=======
            u.RolNombre = cmbRol.SelectedItem?.ToString() ?? "Votante";
            u.RolId = u.RolNombre switch
            {
                "Admin" => 1,
                "AdminPartido" => 2,
                _ => 3
            };
            u.Activo = true;

            (bool ok, string msg) result;
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

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

<<<<<<< HEAD
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

=======
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
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}