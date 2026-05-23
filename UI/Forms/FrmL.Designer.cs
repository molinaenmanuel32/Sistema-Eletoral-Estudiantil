using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    partial class FrmL
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlLeft;
        private PictureBox picLogo;
        private Label lblSystemTitle;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblVoteIcon;
        private Label lblSlogan;
        private Label lblFooter;

        private SistemaVotacion.UI.Controls.RoundedPanel pnlLoginCard;
        private Label lblUserIcon;
        private Label lblTitle;
        private Label lblSubtitle;
        private TextBox txtUser;
        private TextBox txtPass;
        private CheckBox chkRecordarme;
        private Label lblOlvido;
        private Button btnLogin;
        private Label lblSecure;
        private Label lblError;

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

            this.pnlLeft = new Panel();
            this.picLogo = new PictureBox();
            this.lblSystemTitle = new Label();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.lblVoteIcon = new Label();
            this.lblSlogan = new Label();
            this.lblFooter = new Label();

            this.pnlLoginCard = new SistemaVotacion.UI.Controls.RoundedPanel();
            this.lblUserIcon = new Label();
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.txtUser = new TextBox();
            this.txtPass = new TextBox();
            this.chkRecordarme = new CheckBox();
            this.lblOlvido = new Label();
            this.btnLogin = new Button();
            this.lblSecure = new Label();
            this.lblError = new Label();

            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlLoginCard.SuspendLayout();
            this.SuspendLayout();

            // FORM
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.White;
            this.ClientSize = new Size(1080, 720);
            this.MinimumSize = new Size(1080, 720);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Sistema de Votaciones";
            this.Name = "FrmL";

            // PANEL IZQUIERDO
            this.pnlLeft.BackColor = Color.FromArgb(5, 38, 115);
            this.pnlLeft.BackgroundImage = Properties.Resources.login_fondo1;
            this.pnlLeft.BackgroundImageLayout = ImageLayout.Stretch;
            this.pnlLeft.Dock = DockStyle.Left;
            this.pnlLeft.Size = new Size(480, 720);

            // LOGO
            this.picLogo.BackColor = Color.Transparent;
            this.picLogo.Image = ((Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new Point(105, 35);
            this.picLogo.Size = new Size(270, 285);
            this.picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            this.picLogo.TabStop = false;

            // SISTEMA DE
            this.lblSystemTitle.BackColor = Color.Transparent;
            this.lblSystemTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblSystemTitle.ForeColor = Color.White;
            this.lblSystemTitle.Location = new Point(60, 315);
            this.lblSystemTitle.Size = new Size(360, 45);
            this.lblSystemTitle.Text = "Sistema de";
            this.lblSystemTitle.TextAlign = ContentAlignment.MiddleCenter;

            // VOTACIONES
            this.label1.BackColor = Color.Transparent;
            this.label1.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            this.label1.ForeColor = Color.White;
            this.label1.Location = new Point(45, 360);
            this.label1.Size = new Size(390, 65);
            this.label1.Text = "Votaciones";
            this.label1.TextAlign = ContentAlignment.MiddleCenter;

            // ESTUDIANTILES
            this.label2.BackColor = Color.Transparent;
            this.label2.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            this.label2.ForeColor = Color.DodgerBlue;
            this.label2.Location = new Point(70, 420);
            this.label2.Size = new Size(340, 45);
            this.label2.Text = "Estudiantiles";
            this.label2.TextAlign = ContentAlignment.MiddleCenter;

            // LINEA
            this.label3.BackColor = Color.Transparent;
            this.label3.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.label3.ForeColor = Color.Firebrick;
            this.label3.Location = new Point(160, 460);
            this.label3.Size = new Size(160, 30);
            this.label3.Text = "_______";
            this.label3.TextAlign = ContentAlignment.MiddleCenter;

            // ICONO VOTO
            this.lblVoteIcon.BackColor = Color.Transparent;
            this.lblVoteIcon.Font = new Font("Segoe UI Emoji", 38F);
            this.lblVoteIcon.ForeColor = Color.White;
            this.lblVoteIcon.Location = new Point(185, 495);
            this.lblVoteIcon.Size = new Size(110, 75);
            this.lblVoteIcon.Text = "🗳️";
            this.lblVoteIcon.TextAlign = ContentAlignment.MiddleCenter;

            // SLOGAN
            this.lblSlogan.BackColor = Color.Transparent;
            this.lblSlogan.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            this.lblSlogan.ForeColor = Color.White;
            this.lblSlogan.Location = new Point(80, 575);
            this.lblSlogan.Size = new Size(340, 70);
            this.lblSlogan.Text = "Tu voto, tu voz,\r\ntu futuro.";
            this.lblSlogan.TextAlign = ContentAlignment.MiddleCenter;

            // FOOTER
            this.lblFooter.BackColor = Color.Transparent;
            this.lblFooter.Font = new Font("Segoe UI", 9F);
            this.lblFooter.ForeColor = Color.LightGray;
            this.lblFooter.Location = new Point(55, 670);
            this.lblFooter.Size = new Size(370, 30);
            this.lblFooter.Text = "© 2026 CAFAM - Todos los derechos reservados";
            this.lblFooter.TextAlign = ContentAlignment.MiddleCenter;

            // CARD LOGIN
            this.pnlLoginCard.BackColor = Color.WhiteSmoke;
            this.pnlLoginCard.Location = new Point(595, 100);
            this.pnlLoginCard.Size = new Size(385, 550);
            this.pnlLoginCard.Anchor = AnchorStyles.None;

            // ICON USER
            this.lblUserIcon.Font = new Font("Segoe UI Emoji", 42F);
            this.lblUserIcon.ForeColor = Color.FromArgb(22, 97, 255);
            this.lblUserIcon.Location = new Point(130, 45);
            this.lblUserIcon.Size = new Size(125, 85);
            this.lblUserIcon.Text = "👤";
            this.lblUserIcon.TextAlign = ContentAlignment.MiddleCenter;

            // TITULO LOGIN
            this.lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(5, 38, 115);
            this.lblTitle.Location = new Point(40, 130);
            this.lblTitle.Size = new Size(305, 55);
            this.lblTitle.Text = "Iniciar Sesión";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // SUBTITULO
            this.lblSubtitle.Font = new Font("Segoe UI", 10.5F);
            this.lblSubtitle.ForeColor = Color.DimGray;
            this.lblSubtitle.Location = new Point(35, 185);
            this.lblSubtitle.Size = new Size(315, 30);
            this.lblSubtitle.Text = "Ingresa tus credenciales para continuar";
            this.lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;

            // USUARIO
            this.txtUser.Font = new Font("Segoe UI", 11F);
            this.txtUser.Location = new Point(45, 250);
            this.txtUser.Size = new Size(295, 32);
            this.txtUser.Name = "txtUser";
            this.txtUser.TabIndex = 1;
            this.txtUser.KeyDown += new KeyEventHandler(this.TxtUser_KeyDown);

            // CONTRASEÑA
            this.txtPass.Font = new Font("Segoe UI", 11F);
            this.txtPass.Location = new Point(45, 305);
            this.txtPass.Size = new Size(295, 32);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '●';
            this.txtPass.TabIndex = 2;
            this.txtPass.KeyDown += new KeyEventHandler(this.TxtPass_KeyDown);

            // ERROR
            this.lblError.Font = new Font("Segoe UI", 9F);
            this.lblError.ForeColor = Color.Red;
            this.lblError.Location = new Point(45, 340);
            this.lblError.Size = new Size(295, 25);
            this.lblError.TextAlign = ContentAlignment.MiddleCenter;

            // RECORDARME
            this.chkRecordarme.Font = new Font("Segoe UI", 9F);
            this.chkRecordarme.ForeColor = Color.DimGray;
            this.chkRecordarme.Location = new Point(45, 365);
            this.chkRecordarme.Size = new Size(120, 30);
            this.chkRecordarme.Text = "Recordarme";
            this.chkRecordarme.UseVisualStyleBackColor = true;

            // OLVIDO
            this.lblOlvido.Font = new Font("Segoe UI", 9F);
            this.lblOlvido.ForeColor = Color.FromArgb(22, 97, 255);
            this.lblOlvido.Location = new Point(170, 365);
            this.lblOlvido.Size = new Size(170, 30);
            this.lblOlvido.Text = "¿Olvidaste tu contraseña?";
            this.lblOlvido.TextAlign = ContentAlignment.MiddleRight;

            // BOTON
            this.btnLogin.BackColor = Color.FromArgb(22, 97, 255);
            this.btnLogin.Cursor = Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnLogin.ForeColor = Color.White;
            this.btnLogin.Location = new Point(45, 410);
            this.btnLogin.Size = new Size(295, 50);
            this.btnLogin.Text = "🔐  Iniciar Sesión";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new EventHandler(this.BtnLogin_Click);

            // SEGURO
            this.lblSecure.Font = new Font("Segoe UI", 9F);
            this.lblSecure.ForeColor = Color.Gray;
            this.lblSecure.Location = new Point(45, 470);
            this.lblSecure.Size = new Size(295, 30);
            this.lblSecure.Text = "🔒 Acceso seguro y confidencial";
            this.lblSecure.TextAlign = ContentAlignment.MiddleCenter;

            // AGREGAR CONTROLES
            this.pnlLeft.Controls.Add(this.picLogo);
            this.pnlLeft.Controls.Add(this.lblSystemTitle);
            this.pnlLeft.Controls.Add(this.label1);
            this.pnlLeft.Controls.Add(this.label2);
            this.pnlLeft.Controls.Add(this.label3);
            this.pnlLeft.Controls.Add(this.lblVoteIcon);
            this.pnlLeft.Controls.Add(this.lblSlogan);
            this.pnlLeft.Controls.Add(this.lblFooter);

            this.pnlLoginCard.Controls.Add(this.lblUserIcon);
            this.pnlLoginCard.Controls.Add(this.lblTitle);
            this.pnlLoginCard.Controls.Add(this.lblSubtitle);
            this.pnlLoginCard.Controls.Add(this.txtUser);
            this.pnlLoginCard.Controls.Add(this.txtPass);
            this.pnlLoginCard.Controls.Add(this.lblError);
            this.pnlLoginCard.Controls.Add(this.chkRecordarme);
            this.pnlLoginCard.Controls.Add(this.lblOlvido);
            this.pnlLoginCard.Controls.Add(this.btnLogin);
            this.pnlLoginCard.Controls.Add(this.lblSecure);

            this.Controls.Add(this.pnlLoginCard);
            this.Controls.Add(this.pnlLeft);

            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlLoginCard.ResumeLayout(false);
            this.pnlLoginCard.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}