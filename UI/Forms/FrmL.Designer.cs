using SistemaVotacion.Utils;

namespace SistemaVotacion.UI.Forms
{
    partial class FrmL
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlLogo;
        private Panel pnlRight;
        private Label lblTitulo;
        private Label lblSub;
        private Label lblVersion;
        private Label lblBienvenido;
        private Label lblIngresa;
        private Label lblU;
        private Label lblP;
        private Label lblError;
        private TextBox txtUser;
        private TextBox txtPass;
        private Button btnLogin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSub = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();

            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.lblIngresa = new System.Windows.Forms.Label();
            this.lblU = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblP = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // FORM
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 580);
            this.Text = "Sistema de Votación Cafam - Iniciar Sesión";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Tema.Fondo;

            // PANEL LOGO
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLogo.Width = 420;
            this.pnlLogo.BackColor = Tema.PrimarioOscuro;

            // TITULO
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Text = "🗳️ VotaCafam";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(40, 160);

            // SUBTITULO
            this.lblSub.AutoSize = true;
            this.lblSub.Text = "Sistema de Votación\nElectoral Escolar";
            this.lblSub.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblSub.ForeColor = System.Drawing.Color.FromArgb(200, 230, 255);
            this.lblSub.Location = new System.Drawing.Point(40, 220);

            // VERSION
            this.lblVersion.AutoSize = true;
            this.lblVersion.Text = "v1.0.0 | SQL Server + Dapper";
            this.lblVersion.Font = Tema.FuentePequeña;
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(150, 200, 255);
            this.lblVersion.Location = new System.Drawing.Point(40, 490);

            this.pnlLogo.Controls.Add(this.lblTitulo);
            this.pnlLogo.Controls.Add(this.lblSub);
            this.pnlLogo.Controls.Add(this.lblVersion);

            // PANEL DERECHO
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.BackColor = Tema.FondoPanel;
            this.pnlRight.Padding = new System.Windows.Forms.Padding(50, 80, 50, 50);

            // BIENVENIDO
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Text = "Bienvenido";
            this.lblBienvenido.Font = Tema.FuenteTitulo;
            this.lblBienvenido.ForeColor = Tema.Texto;
            this.lblBienvenido.Location = new System.Drawing.Point(50, 80);

            // INGRESA
            this.lblIngresa.AutoSize = true;
            this.lblIngresa.Text = "Ingresa tus credenciales para continuar";
            this.lblIngresa.Font = Tema.FuenteNormal;
            this.lblIngresa.ForeColor = Tema.TextoSecundario;
            this.lblIngresa.Location = new System.Drawing.Point(50, 120);

            // LABEL USER
            this.lblU.AutoSize = true;
            this.lblU.Text = "Usuario";
            this.lblU.Font = Tema.FuenteNormal;
            this.lblU.ForeColor = Tema.Texto;
            this.lblU.Location = new System.Drawing.Point(50, 170);

            // TEXT USER
            this.txtUser.Location = new System.Drawing.Point(50, 195);
            this.txtUser.Size = new System.Drawing.Size(360, 30);
            this.txtUser.PlaceholderText = "Nombre de usuario";
            this.txtUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtUser_KeyDown);

            // LABEL PASS
            this.lblP.AutoSize = true;
            this.lblP.Text = "Contraseña";
            this.lblP.Font = Tema.FuenteNormal;
            this.lblP.ForeColor = Tema.Texto;
            this.lblP.Location = new System.Drawing.Point(50, 245);

            // TEXT PASS
            this.txtPass.Location = new System.Drawing.Point(50, 270);
            this.txtPass.Size = new System.Drawing.Size(360, 30);
            this.txtPass.PlaceholderText = "Contraseña";
            this.txtPass.PasswordChar = '•';
            this.txtPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPass_KeyDown);

            // ERROR
            this.lblError.AutoSize = true;
            this.lblError.Text = "";
            this.lblError.Font = Tema.FuenteNormal;
            this.lblError.ForeColor = Tema.Peligro;
            this.lblError.Location = new System.Drawing.Point(50, 320);

            // BOTON
            this.btnLogin.Text = "Iniciar Sesión";
            this.btnLogin.Location = new System.Drawing.Point(50, 355);
            this.btnLogin.Size = new System.Drawing.Size(360, 48);
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);

            this.pnlRight.Controls.Add(this.lblBienvenido);
            this.pnlRight.Controls.Add(this.lblIngresa);
            this.pnlRight.Controls.Add(this.lblU);
            this.pnlRight.Controls.Add(this.txtUser);
            this.pnlRight.Controls.Add(this.lblP);
            this.pnlRight.Controls.Add(this.txtPass);
            this.pnlRight.Controls.Add(this.lblError);
            this.pnlRight.Controls.Add(this.btnLogin);

            // ADD FORM
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLogo);

            this.ResumeLayout(false);
        }

        #endregion
    }
}