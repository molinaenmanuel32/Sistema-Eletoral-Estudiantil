<<<<<<< HEAD
﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
=======
﻿namespace SistemaVotacion.UI.Forms
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
{
    partial class FrmL
    {
        private System.ComponentModel.IContainer components = null;

<<<<<<< HEAD
        private Panel pnlLeft;
        private Label lblFooter;
        private Label lblSlogan;
        private Label lblVoteIcon;
        private Label lblSystemTitle;
        private PictureBox picLogo;

        private SistemaVotacion.UI.Controls.RoundedPanel pnlLoginCard;
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
=======
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.Label lblSlogan;
        private System.Windows.Forms.Label lblVoteIcon;
        private System.Windows.Forms.Label lblSystemTitle;
        private System.Windows.Forms.PictureBox picLogo;

        private SistemaVotacion.UI.Controls.RoundedPanel pnlLoginCard;
        private System.Windows.Forms.Label lblSecure;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.CheckBox chkRecordarme;
        private System.Windows.Forms.Label lblOlvido;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUserIcon;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
<<<<<<< HEAD
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
            this.lblSecure = new Label();
            this.btnLogin = new Button();
            this.chkRecordarme = new CheckBox();
            this.lblOlvido = new Label();
            this.lblError = new Label();
            this.txtPass = new TextBox();
            this.txtUser = new TextBox();
            this.lblSubtitle = new Label();
            this.lblTitle = new Label();
            this.lblUserIcon = new Label();

            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlLoginCard.SuspendLayout();

            this.SuspendLayout();

            // =====================================================
            // pnlLeft
            // =====================================================

            this.pnlLeft.BackColor = Color.FromArgb(5, 38, 115);

            try
            {
                this.pnlLeft.BackgroundImage = Properties.Resources.login_fondo1;
            }
            catch
            {
            }

            this.pnlLeft.BackgroundImageLayout = ImageLayout.Stretch;
            this.pnlLeft.Dock = DockStyle.Left;
            this.pnlLeft.Location = new Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new Size(554, 933);

            // =====================================================
            // picLogo
            // =====================================================

            this.picLogo.BackColor = Color.Transparent;

            try
            {
                this.picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            }
            catch
            {
            }

            this.picLogo.Location = new Point(111, 46);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new Size(352, 381);
            this.picLogo.SizeMode = PictureBoxSizeMode.Zoom;

            // =====================================================
            // lblSystemTitle
            // =====================================================

            this.lblSystemTitle.BackColor = Color.Transparent;
            this.lblSystemTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblSystemTitle.ForeColor = Color.White;
            this.lblSystemTitle.Location = new Point(63, 430);
            this.lblSystemTitle.Size = new Size(436, 50);
            this.lblSystemTitle.Text = "Sistema de";
            this.lblSystemTitle.TextAlign = ContentAlignment.MiddleCenter;

            // =====================================================
            // label1
            // =====================================================

            this.label1.BackColor = Color.Transparent;
            this.label1.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            this.label1.ForeColor = Color.White;
            this.label1.Location = new Point(120, 485);
            this.label1.Size = new Size(320, 62);
            this.label1.Text = "Votaciones";
            this.label1.TextAlign = ContentAlignment.MiddleCenter;

            // =====================================================
            // label2
            // =====================================================

            this.label2.BackColor = Color.Transparent;
            this.label2.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.label2.ForeColor = Color.DodgerBlue;
            this.label2.Location = new Point(122, 540);
            this.label2.Size = new Size(324, 45);
            this.label2.Text = "Estudiantiles";
            this.label2.TextAlign = ContentAlignment.MiddleCenter;

            // =====================================================
            // label3
            // =====================================================

            this.label3.BackColor = Color.Transparent;
            this.label3.Font = new Font("Segoe UI Black", 15F, FontStyle.Bold);
            this.label3.ForeColor = Color.Firebrick;
            this.label3.Location = new Point(97, 580);
            this.label3.Size = new Size(366, 45);
            this.label3.Text = "__________";
            this.label3.TextAlign = ContentAlignment.MiddleCenter;

            // =====================================================
            // lblVoteIcon
            // =====================================================

            this.lblVoteIcon.BackColor = Color.Transparent;
            this.lblVoteIcon.Font = new Font("Segoe UI Emoji", 40F);
            this.lblVoteIcon.ForeColor = Color.White;
            this.lblVoteIcon.Location = new Point(225, 640);
            this.lblVoteIcon.Size = new Size(115, 83);
            this.lblVoteIcon.Text = "🗳️";
            this.lblVoteIcon.TextAlign = ContentAlignment.MiddleCenter;

            // =====================================================
            // lblSlogan
            // =====================================================

            this.lblSlogan.BackColor = Color.Transparent;
            this.lblSlogan.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            this.lblSlogan.ForeColor = Color.White;
            this.lblSlogan.Location = new Point(97, 720);
            this.lblSlogan.Size = new Size(366, 80);
            this.lblSlogan.Text = "Tu voto, tu voz,\ntu futuro.";
            this.lblSlogan.TextAlign = ContentAlignment.MiddleCenter;

            // =====================================================
            // lblFooter
            // =====================================================

            this.lblFooter.BackColor = Color.Transparent;
            this.lblFooter.Font = new Font("Segoe UI", 10F);
            this.lblFooter.ForeColor = Color.LightGray;
            this.lblFooter.Location = new Point(78, 860);
            this.lblFooter.Size = new Size(400, 33);
            this.lblFooter.Text = "© 2026 CAFAM - Todos los derechos reservados";
            this.lblFooter.TextAlign = ContentAlignment.MiddleCenter;

            // =====================================================
            // pnlLoginCard
            // =====================================================

            this.pnlLoginCard.BackColor = Color.WhiteSmoke;
            this.pnlLoginCard.Location = new Point(675, 115);
            this.pnlLoginCard.Name = "pnlLoginCard";
            this.pnlLoginCard.Size = new Size(465, 690);

            // =====================================================
            // lblUserIcon
            // =====================================================

            this.lblUserIcon.Font = new Font("Segoe UI Emoji", 42F);
            this.lblUserIcon.ForeColor = Color.FromArgb(22, 97, 255);
            this.lblUserIcon.Location = new Point(163, 64);
            this.lblUserIcon.Size = new Size(126, 100);
            this.lblUserIcon.Text = "👤";
            this.lblUserIcon.TextAlign = ContentAlignment.MiddleCenter;

            // =====================================================
            // lblTitle
            // =====================================================

            this.lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(5, 38, 115);
            this.lblTitle.Location = new Point(51, 155);
            this.lblTitle.Size = new Size(343, 60);
            this.lblTitle.Text = "Iniciar Sesión";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // =====================================================
            // lblSubtitle
            // =====================================================

            this.lblSubtitle.Font = new Font("Segoe UI", 11F);
            this.lblSubtitle.ForeColor = Color.DimGray;
            this.lblSubtitle.Location = new Point(46, 215);
            this.lblSubtitle.Size = new Size(354, 40);
            this.lblSubtitle.Text = "Ingresa tus credenciales para continuar";
            this.lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;

            // =====================================================
            // txtUser
            // =====================================================

            this.txtUser.Font = new Font("Segoe UI", 12F);
            this.txtUser.Location = new Point(51, 295);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new Size(342, 34);
            this.txtUser.KeyDown += TxtUser_KeyDown;

            // =====================================================
            // txtPass
            // =====================================================

            this.txtPass.Font = new Font("Segoe UI", 12F);
            this.txtPass.Location = new Point(51, 370);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '●';
            this.txtPass.Size = new Size(342, 34);
            this.txtPass.KeyDown += TxtPass_KeyDown;

            // =====================================================
            // lblError
            // =====================================================

            this.lblError.Font = new Font("Segoe UI", 9F);
            this.lblError.ForeColor = Color.Red;
            this.lblError.Location = new Point(51, 420);
            this.lblError.Size = new Size(343, 30);
            this.lblError.TextAlign = ContentAlignment.MiddleCenter;

            // =====================================================
            // chkRecordarme
            // =====================================================

            this.chkRecordarme.Font = new Font("Segoe UI", 9.5F);
            this.chkRecordarme.ForeColor = Color.DimGray;
            this.chkRecordarme.Location = new Point(51, 455);
            this.chkRecordarme.Size = new Size(137, 33);
            this.chkRecordarme.Text = "Recordarme";

            // =====================================================
            // lblOlvido
            // =====================================================

            this.lblOlvido.Font = new Font("Segoe UI", 9.5F);
            this.lblOlvido.ForeColor = Color.FromArgb(22, 97, 255);
            this.lblOlvido.Location = new Point(206, 455);
            this.lblOlvido.Size = new Size(189, 33);
            this.lblOlvido.Text = "¿Olvidaste tu contraseña?";
            this.lblOlvido.TextAlign = ContentAlignment.MiddleRight;

            // =====================================================
            // btnLogin
            // =====================================================

            this.btnLogin.BackColor = Color.FromArgb(22, 97, 255);
            this.btnLogin.Cursor = Cursors.Hand;
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.btnLogin.ForeColor = Color.White;
            this.btnLogin.Location = new Point(51, 510);
            this.btnLogin.Size = new Size(343, 58);
            this.btnLogin.Text = "Iniciar Sesión";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += BtnLogin_Click;

            // =====================================================
            // lblSecure
            // =====================================================

            this.lblSecure.Font = new Font("Segoe UI", 9F);
            this.lblSecure.ForeColor = Color.Gray;
            this.lblSecure.Location = new Point(51, 590);
            this.lblSecure.Size = new Size(343, 27);
            this.lblSecure.Text = "Acceso seguro y confidencial";
            this.lblSecure.TextAlign = ContentAlignment.MiddleCenter;

            // =====================================================
            // AGREGAR CONTROLES
            // =====================================================

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

            // =====================================================
            // FrmL
            // =====================================================

            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(1257, 933);

            this.Controls.Add(this.pnlLoginCard);
            this.Controls.Add(this.pnlLeft);

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmL";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Sistema de Votaciones";

            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlLoginCard.ResumeLayout(false);
            this.pnlLoginCard.PerformLayout();

            this.ResumeLayout(false);
=======
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmL));
            pnlLeft = new Panel();
            picLogo = new PictureBox();
            lblSystemTitle = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lblVoteIcon = new Label();
            lblSlogan = new Label();
            lblFooter = new Label();
            pnlLoginCard = new SistemaVotacion.UI.Controls.RoundedPanel();
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
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            pnlLoginCard.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.FromArgb(5, 38, 115);
            pnlLeft.BackgroundImage = Properties.Resources.login_fondo1;
            pnlLeft.BackgroundImageLayout = ImageLayout.Stretch;
            pnlLeft.Controls.Add(picLogo);
            pnlLeft.Controls.Add(lblSystemTitle);
            pnlLeft.Controls.Add(label1);
            pnlLeft.Controls.Add(label2);
            pnlLeft.Controls.Add(label3);
            pnlLeft.Controls.Add(lblVoteIcon);
            pnlLeft.Controls.Add(lblSlogan);
            pnlLeft.Controls.Add(lblFooter);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(554, 933);
            pnlLeft.TabIndex = 0;
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(111, 46);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(352, 381);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // lblSystemTitle
            // 
            lblSystemTitle.BackColor = Color.Transparent;
            lblSystemTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblSystemTitle.ForeColor = Color.White;
            lblSystemTitle.Location = new Point(63, 430);
            lblSystemTitle.Name = "lblSystemTitle";
            lblSystemTitle.Size = new Size(436, 50);
            lblSystemTitle.TabIndex = 1;
            lblSystemTitle.Text = "Sistema de";
            lblSystemTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(120, 485);
            label1.Name = "label1";
            label1.Size = new Size(320, 62);
            label1.TabIndex = 2;
            label1.Text = "Votaciones";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label2.ForeColor = Color.DodgerBlue;
            label2.Location = new Point(122, 540);
            label2.Name = "label2";
            label2.Size = new Size(324, 45);
            label2.TabIndex = 3;
            label2.Text = "Estudiantiles";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Black", 15F, FontStyle.Bold);
            label3.ForeColor = Color.Firebrick;
            label3.Location = new Point(97, 580);
            label3.Name = "label3";
            label3.Size = new Size(366, 45);
            label3.TabIndex = 4;
            label3.Text = "__________";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblVoteIcon
            // 
            lblVoteIcon.BackColor = Color.Transparent;
            lblVoteIcon.Font = new Font("Segoe UI Emoji", 40F);
            lblVoteIcon.ForeColor = Color.White;
            lblVoteIcon.Location = new Point(225, 640);
            lblVoteIcon.Name = "lblVoteIcon";
            lblVoteIcon.Size = new Size(115, 83);
            lblVoteIcon.TabIndex = 5;
            lblVoteIcon.Text = "🗳️";
            lblVoteIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSlogan
            // 
            lblSlogan.BackColor = Color.Transparent;
            lblSlogan.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblSlogan.ForeColor = Color.White;
            lblSlogan.Location = new Point(97, 720);
            lblSlogan.Name = "lblSlogan";
            lblSlogan.Size = new Size(366, 80);
            lblSlogan.TabIndex = 6;
            lblSlogan.Text = "Tu voto, tu voz,\ntu futuro.";
            lblSlogan.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFooter
            // 
            lblFooter.BackColor = Color.Transparent;
            lblFooter.Font = new Font("Segoe UI", 10F);
            lblFooter.ForeColor = Color.LightGray;
            lblFooter.Location = new Point(78, 860);
            lblFooter.Name = "lblFooter";
            lblFooter.Size = new Size(400, 33);
            lblFooter.TabIndex = 7;
            lblFooter.Text = "© 2026 CAFAM - Todos los derechos reservados";
            lblFooter.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlLoginCard
            // 
            pnlLoginCard.BackColor = Color.WhiteSmoke;
            pnlLoginCard.Controls.Add(lblSecure);
            pnlLoginCard.Controls.Add(btnLogin);
            pnlLoginCard.Controls.Add(chkRecordarme);
            pnlLoginCard.Controls.Add(lblOlvido);
            pnlLoginCard.Controls.Add(lblError);
            pnlLoginCard.Controls.Add(txtPass);
            pnlLoginCard.Controls.Add(txtUser);
            pnlLoginCard.Controls.Add(lblSubtitle);
            pnlLoginCard.Controls.Add(lblTitle);
            pnlLoginCard.Controls.Add(lblUserIcon);
            pnlLoginCard.Location = new Point(675, 115);
            pnlLoginCard.Name = "pnlLoginCard";
            pnlLoginCard.Size = new Size(465, 690);
            pnlLoginCard.TabIndex = 1;
            // 
            // lblSecure
            // 
            lblSecure.Font = new Font("Segoe UI", 9F);
            lblSecure.ForeColor = Color.Gray;
            lblSecure.Location = new Point(51, 590);
            lblSecure.Name = "lblSecure";
            lblSecure.Size = new Size(343, 27);
            lblSecure.TabIndex = 9;
            lblSecure.Text = "🔒 Acceso seguro y confidencial";
            lblSecure.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(22, 97, 255);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(51, 510);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(343, 58);
            btnLogin.TabIndex = 8;
            btnLogin.Text = "🔐  Iniciar Sesión";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += BtnLogin_Click;
            // 
            // chkRecordarme
            // 
            chkRecordarme.Font = new Font("Segoe UI", 9.5F);
            chkRecordarme.ForeColor = Color.DimGray;
            chkRecordarme.Location = new Point(51, 455);
            chkRecordarme.Name = "chkRecordarme";
            chkRecordarme.Size = new Size(137, 33);
            chkRecordarme.TabIndex = 6;
            chkRecordarme.Text = "Recordarme";
            chkRecordarme.UseVisualStyleBackColor = true;
            // 
            // lblOlvido
            // 
            lblOlvido.Font = new Font("Segoe UI", 9.5F);
            lblOlvido.ForeColor = Color.FromArgb(22, 97, 255);
            lblOlvido.Location = new Point(206, 455);
            lblOlvido.Name = "lblOlvido";
            lblOlvido.Size = new Size(189, 33);
            lblOlvido.TabIndex = 7;
            lblOlvido.Text = "¿Olvidaste tu contraseña?";
            lblOlvido.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblError
            // 
            lblError.Font = new Font("Segoe UI", 9F);
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(51, 420);
            lblError.Name = "lblError";
            lblError.Size = new Size(343, 30);
            lblError.TabIndex = 5;
            lblError.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtPass
            // 
            txtPass.Font = new Font("Segoe UI", 12F);
            txtPass.Location = new Point(51, 370);
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '●';
            txtPass.PlaceholderText = "Contraseña";
            txtPass.Size = new Size(342, 34);
            txtPass.TabIndex = 4;
            txtPass.KeyDown += TxtPass_KeyDown;
            // 
            // txtUser
            // 
            txtUser.Font = new Font("Segoe UI", 12F);
            txtUser.Location = new Point(51, 295);
            txtUser.Name = "txtUser";
            txtUser.PlaceholderText = "Usuario";
            txtUser.Size = new Size(342, 34);
            txtUser.TabIndex = 3;
            txtUser.KeyDown += TxtUser_KeyDown;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Font = new Font("Segoe UI", 11F);
            lblSubtitle.ForeColor = Color.DimGray;
            lblSubtitle.Location = new Point(46, 215);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(354, 40);
            lblSubtitle.TabIndex = 2;
            lblSubtitle.Text = "Ingresa tus credenciales para continuar";
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(5, 38, 115);
            lblTitle.Location = new Point(51, 155);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(343, 60);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Iniciar Sesión";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUserIcon
            // 
            lblUserIcon.Font = new Font("Segoe UI Emoji", 42F);
            lblUserIcon.ForeColor = Color.FromArgb(22, 97, 255);
            lblUserIcon.Location = new Point(163, 64);
            lblUserIcon.Name = "lblUserIcon";
            lblUserIcon.Size = new Size(126, 100);
            lblUserIcon.TabIndex = 0;
            lblUserIcon.Text = "👤";
            lblUserIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmL
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1257, 933);
            Controls.Add(pnlLoginCard);
            Controls.Add(pnlLeft);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmL";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Votaciones";
            pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            pnlLoginCard.ResumeLayout(false);
            pnlLoginCard.PerformLayout();
            ResumeLayout(false);
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
        }

        #endregion
    }
}