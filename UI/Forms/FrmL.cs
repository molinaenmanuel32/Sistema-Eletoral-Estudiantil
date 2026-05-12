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
                txtPass.Focus();
        }

        private void TxtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BtnLogin_Click(sender, e);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            if (txtUser.Text.Trim().ToLower() == "resetadmin")
            {
                string hash = AuthService.HashPassword("039");

                MessageBox.Show(hash);
                Clipboard.SetText(hash);

                MessageBox.Show("Hash copiado al portapapeles.");
                return;
            }

            btnLogin.Enabled = false;
            btnLogin.Text = "Verificando...";

            var resultado = _auth.Login(txtUser.Text.Trim(), txtPass.Text);

            btnLogin.Enabled = true;
            btnLogin.Text = "Iniciar Sesión";

            bool ok = resultado.Item1;
            string msg = resultado.Item2;
            var user = resultado.Item3;

            if (!ok || user == null)
            {
                lblError.Text = msg;
                txtPass.Clear();
                txtPass.Focus();
                return;
            }

            string rol = user.RolNombre.Trim();

            Form siguiente;

            if (rol.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                siguiente = new FrmMenuAdmin();
            else if (rol.Equals("AdminPartido", StringComparison.OrdinalIgnoreCase))
                siguiente = new FrmMenuAdminPartido(user.Nombre, user.UsuarioId);
            else
                siguiente = new FrmVotacion();

            this.Hide();

            siguiente.FormClosed += (s, args) => this.Close();

            siguiente.Show();
        }
    }
}