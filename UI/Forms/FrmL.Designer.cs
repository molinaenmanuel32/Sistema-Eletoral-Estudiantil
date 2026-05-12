using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    partial class FrmL
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlLeft;
        private Panel pnlLoginCard;

        private Label lblFooter;
        private Label lblSlogan;
        private Label lblVoteIcon;
        private Label lblSystemTitle;
        private PictureBox picLogo;

        private Label lblSecure;
        private Button btnLogin;
        private CheckBox chkRecordarme;
        private Label lblOlvido;
        private Label lblError;
        private TextBox txtPass;
        private TextBox txtUser;
        private Label lblSubtitle;
        private Label lblTitle;
        private Label lblUserIcon;

        private Label label1;
        private Label label2;
        private Label label3;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(FrmL));

            pnlLeft = new Panel();
            pnlLoginCard = new Panel();

            picLogo = new PictureBox();
            lblSystemTitle = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lblVoteIcon = new Label();
            lblSlogan = new Label();
            lblFooter = new Label();

            lblSecure = new Label();
            btnLogin = new Button();
            chkRecordarme = new CheckBox();
            lblOlvido = new Label();
            lblError = new Label();
            txtPass = new TextBox();
            txtUser = new TextBox();
            lblSubtitle = new Label();
            lblTitle = new Label();
            lblUserIcon = new Label();

            pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(picLogo)).BeginInit();
            pnlLoginCard.SuspendLayout();
            SuspendLayout();

            // =========================
            // pnlLeft
            // =========================
            pnlLeft.BackColor = Color.FromArgb(5, 38, 115);
            pnlLeft.BackgroundImage = Properties.Resources.login_fondo1;
            pnlLeft.BackgroundImageLayout = ImageLayout.Stretch;
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Size = new Size(554, 933);

            // Logo
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(111, 46);
            picLogo.Size = new Size(352, 381);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;

            // Títulos
            lblSystemTitle.Text = "Sistema de";
            lblSystemTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblSystemTitle.ForeColor = Color.White;
            lblSystemTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblSystemTitle.Location = new Point(63, 430);
            lblSystemTitle.Size = new Size(436, 50);

            label1.Text = "Votaciones";
            label1.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(120, 485);
            label1.Size = new Size(320, 62);
            label1.TextAlign = ContentAlignment.MiddleCenter;

            label2.Text = "Estudiantiles";
            label2.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label2.ForeColor = Color.DodgerBlue;
            label2.Location = new Point(122, 540);
            label2.Size = new Size(324, 45);
            label2.TextAlign = ContentAlignment.MiddleCenter;

            label3.Text = "__________";
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label3.ForeColor = Color.Firebrick;
            label3.Location = new Point(97, 580);
            label3.Size = new Size(366, 45);
            label3.TextAlign = ContentAlignment.MiddleCenter;

            lblVoteIcon.Text = "🗳️";
            lblVoteIcon.Font = new Font("Segoe UI Emoji", 40F);
            lblVoteIcon.ForeColor = Color.White;
            lblVoteIcon.Location = new Point(225, 640);
            lblVoteIcon.Size = new Size(115, 83);

            lblSlogan.Text = "Tu voto, tu voz,\ntu futuro.";
            lblSlogan.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblSlogan.ForeColor = Color.White;
            lblSlogan.Location = new Point(97, 720);
            lblSlogan.Size = new Size(366, 80);
            lblSlogan.TextAlign = ContentAlignment.MiddleCenter;

            lblFooter.Text = "© 2026 CAFAM - Todos los derechos reservados";
            lblFooter.Font = new Font("Segoe UI", 10F);
            lblFooter.ForeColor = Color.LightGray;
            lblFooter.Location = new Point(78, 860);
            lblFooter.Size = new Size(400, 33);
            lblFooter.TextAlign = ContentAlignment.MiddleCenter;

            pnlLeft.Controls.Add(picLogo);
            pnlLeft.Controls.Add(lblSystemTitle);
            pnlLeft.Controls.Add(label1);
            pnlLeft.Controls.Add(label2);
            pnlLeft.Controls.Add(label3);
            pnlLeft.Controls.Add(lblVoteIcon);
            pnlLeft.Controls.Add(lblSlogan);
            pnlLeft.Controls.Add(lblFooter);

            // =========================
            // LOGIN CARD
            // =========================
            pnlLoginCard.BackColor = Color.WhiteSmoke;
            pnlLoginCard.Location = new Point(675, 115);
            pnlLoginCard.Size = new Size(465, 690);

            lblUserIcon.Text = "👤";
            lblUserIcon.Font = new Font("Segoe UI Emoji", 42F);
            lblUserIcon.ForeColor = Color.FromArgb(22, 97, 255);
            lblUserIcon.Location = new Point(163, 64);
            lblUserIcon.Size = new Size(126, 100);

            lblTitle.Text = "Iniciar Sesión";
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(5, 38, 115);
            lblTitle.Location = new Point(51, 155);
            lblTitle.Size = new Size(343, 60);

            lblSubtitle.Text = "Ingresa tus credenciales para continuar";
            lblSubtitle.Font = new Font("Segoe UI", 11F);
            lblSubtitle.ForeColor = Color.DimGray;
            lblSubtitle.Location = new Point(46, 215);
            lblSubtitle.Size = new Size(354, 40);

            txtUser.Location = new Point(51, 295);
            txtUser.Size = new Size(342, 34);

            txtPass.Location = new Point(51, 370);
            txtPass.Size = new Size(342, 34);
            txtPass.PasswordChar = '●';

            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(51, 420);
            lblError.Size = new Size(343, 30);

            chkRecordarme.Text = "Recordarme";
            chkRecordarme.Location = new Point(51, 455);

            lblOlvido.Text = "¿Olvidaste tu contraseña?";
            lblOlvido.ForeColor = Color.FromArgb(22, 97, 255);
            lblOlvido.Location = new Point(206, 455);

            btnLogin.Text = "Iniciar Sesión";
            btnLogin.BackColor = Color.FromArgb(22, 97, 255);
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Location = new Point(51, 510);
            btnLogin.Size = new Size(343, 58);
            btnLogin.Click += BtnLogin_Click;

            lblSecure.Text = "Acceso seguro y confidencial";
            lblSecure.ForeColor = Color.Gray;
            lblSecure.Location = new Point(51, 590);
            lblSecure.Size = new Size(343, 27);

            pnlLoginCard.Controls.Add(lblUserIcon);
            pnlLoginCard.Controls.Add(lblTitle);
            pnlLoginCard.Controls.Add(lblSubtitle);
            pnlLoginCard.Controls.Add(txtUser);
            pnlLoginCard.Controls.Add(txtPass);
            pnlLoginCard.Controls.Add(lblError);
            pnlLoginCard.Controls.Add(chkRecordarme);
            pnlLoginCard.Controls.Add(lblOlvido);
            pnlLoginCard.Controls.Add(btnLogin);
            pnlLoginCard.Controls.Add(lblSecure);

            // =========================
            // FORM
            // =========================
            ClientSize = new Size(1257, 933);
            Controls.Add(pnlLoginCard);
            Controls.Add(pnlLeft);
            Text = "Sistema de Votaciones";
            StartPosition = FormStartPosition.CenterScreen;

            pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(picLogo)).EndInit();
            pnlLoginCard.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}