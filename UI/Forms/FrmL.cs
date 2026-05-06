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
            btnLogin.Enabled = false;
            btnLogin.Text = "Verificando...";

            var resultado = _auth.Login(txtUser.Text.Trim(), txtPass.Text);

            btnLogin.Enabled = true;
            btnLogin.Text = "Iniciar Sesión";

            if (!resultado.ok)
            {
                lblError.Text = resultado.msg;
                txtPass.Clear();
                txtPass.Focus();
                return;
            }

            Form siguiente;

            if (resultado.user != null && resultado.user.RolNombre == "Admin")
            {
                siguiente = new FMA();
            }
            else if (resultado.user != null && resultado.user.RolNombre == "AdminPartido")
            {
                siguiente = new FMA();
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