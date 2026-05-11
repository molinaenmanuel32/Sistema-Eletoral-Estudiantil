<<<<<<< HEAD
using SistemaVotacion.BLL;
=======
﻿using SistemaVotacion.BLL;
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
using SistemaVotacion.Utils;
using System;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    public partial class FrmL : Form
    {
        private readonly AuthService _auth = new AuthService();

        public FrmL()
        {
            InitializeComponent();
<<<<<<< HEAD

=======
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
            Tema.EstilizarBoton(btnLogin);
        }

        private void TxtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPass.Focus();
            }
        }

        private void TxtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnLogin_Click(sender, e);
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            if (txtUser.Text.Trim().Equals("resetadmin", StringComparison.OrdinalIgnoreCase))
            {
                string hash = AuthService.HashPassword("039");

                MessageBox.Show(hash, "HASH BCrypt para admin");
<<<<<<< HEAD

                Clipboard.SetText(hash);

=======
                Clipboard.SetText(hash);
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
                MessageBox.Show("Hash copiado al portapapeles. Pégalo en SQL.");

                return;
            }

            btnLogin.Enabled = false;
            btnLogin.Text = "Verificando...";

            var resultado = _auth.Login(txtUser.Text.Trim(), txtPass.Text);

            btnLogin.Enabled = true;
            btnLogin.Text = "Iniciar Sesión";

<<<<<<< HEAD
            bool ok = resultado.Item1;
            string msg = resultado.Item2;
            var user = resultado.Item3;

            if (!ok || user == null)
            {
                lblError.Text = msg;

                txtPass.Clear();
                txtPass.Focus();

=======
            if (!resultado.ok || resultado.user == null)
            {
                lblError.Text = resultado.msg;
                txtPass.Clear();
                txtPass.Focus();
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
                return;
            }

            Form siguiente;

<<<<<<< HEAD
            string rol = user.RolNombre.Trim();

=======
            string rol = resultado.user.RolNombre.Trim();
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
            MessageBox.Show("Rol detectado: " + rol);

            if (rol.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                siguiente = new FrmMenuAdmin();
            }
            else if (rol.Equals("AdminPartido", StringComparison.OrdinalIgnoreCase))
            {
<<<<<<< HEAD
                siguiente = new FrmMenuAdminPartido(user.Nombre, user.UsuarioId);
=======
                siguiente = new FrmMenuAdminPartido(
                    resultado.user.Nombre,
                    resultado.user.UsuarioId
                );
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
            }
            else
            {
                siguiente = new FrmVotacion();
            }

            this.Hide();
<<<<<<< HEAD

            siguiente.FormClosed += delegate
            {
                this.Close();
            };

=======
            siguiente.FormClosed += (s, args) => this.Close();
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
            siguiente.Show();
        }
    }
}