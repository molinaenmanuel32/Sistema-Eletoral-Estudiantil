using SistemaVotacion.BLL;
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
                Clipboard.SetText(hash);
                MessageBox.Show("Hash copiado al portapapeles. Pégalo en SQL.");

                return;
            }

            btnLogin.Enabled = false;
            btnLogin.Text = "Verificando...";

            var resultado = _auth.Login(txtUser.Text.Trim(), txtPass.Text);

            btnLogin.Enabled = true;
            btnLogin.Text = "Iniciar Sesión";

            if (!resultado.ok || resultado.user == null)
            {
                lblError.Text = resultado.msg;
                txtPass.Clear();
                txtPass.Focus();
                return;
            }

            Form siguiente;

            string rol = resultado.user.RolNombre.Trim();
            MessageBox.Show("Rol detectado: " + rol);

            if (rol.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                siguiente = new FrmMenuAdmin();
            }
            else if (rol.Equals("AdminPartido", StringComparison.OrdinalIgnoreCase))
            {
                siguiente = new FrmMenuAdminPartido(
                    resultado.user.Nombre,
                    resultado.user.UsuarioId
                );
            }
            else
            {
                siguiente = new FrmVotacion();
            }

            this.Hide();
            siguiente.FormClosed += (s, args) => this.Close();
            siguiente.Show();
        }
    }
}