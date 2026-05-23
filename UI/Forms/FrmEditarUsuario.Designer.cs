using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    partial class FrmEditarUsuario
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Panel pnlBody;
        private Panel pnlFooter;

        private Label lblTitulo;
        private Label lblSubtitulo;

        private Label lblNombre;
        private Label lblApellido;
        private Label lblMatricula;
        private Label lblCurso;
        private Label lblSeccion;
        private Label lblEmail;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblRol;

        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtMatricula;
        private TextBox txtCurso;
        private TextBox txtSeccion;
        private TextBox txtEmail;
        private TextBox txtUsername;
        private TextBox txtPassword;

        private ComboBox cmbRol;

        private Button btnGuardar;
        private Button btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.lblCurso = new System.Windows.Forms.Label();
            this.txtCurso = new System.Windows.Forms.TextBox();
            this.lblSeccion = new System.Windows.Forms.Label();
            this.txtSeccion = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(620, 115);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 60, 170);
            this.lblTitulo.Location = new System.Drawing.Point(35, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(188, 50);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "● Usuario";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(80, 85, 100);
            this.lblSubtitulo.Location = new System.Drawing.Point(40, 75);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(339, 25);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Registra o modifica los datos del usuario.";
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(243, 245, 250);
            this.pnlBody.Controls.Add(this.lblNombre);
            this.pnlBody.Controls.Add(this.txtNombre);
            this.pnlBody.Controls.Add(this.lblApellido);
            this.pnlBody.Controls.Add(this.txtApellido);
            this.pnlBody.Controls.Add(this.lblMatricula);
            this.pnlBody.Controls.Add(this.txtMatricula);
            this.pnlBody.Controls.Add(this.lblCurso);
            this.pnlBody.Controls.Add(this.txtCurso);
            this.pnlBody.Controls.Add(this.lblSeccion);
            this.pnlBody.Controls.Add(this.txtSeccion);
            this.pnlBody.Controls.Add(this.lblEmail);
            this.pnlBody.Controls.Add(this.txtEmail);
            this.pnlBody.Controls.Add(this.lblUsername);
            this.pnlBody.Controls.Add(this.txtUsername);
            this.pnlBody.Controls.Add(this.lblPassword);
            this.pnlBody.Controls.Add(this.txtPassword);
            this.pnlBody.Controls.Add(this.lblRol);
            this.pnlBody.Controls.Add(this.cmbRol);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 115);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(30, 20, 30, 10);
            this.pnlBody.Size = new System.Drawing.Size(620, 470);
            this.pnlBody.TabIndex = 0;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(40, 50, 80);
            this.lblNombre.Location = new System.Drawing.Point(30, 20);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(82, 21);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre *";
            // 
            // txtNombre
            // 
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombre.Location = new System.Drawing.Point(30, 40);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(250, 30);
            this.txtNombre.TabIndex = 1;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblApellido.ForeColor = System.Drawing.Color.FromArgb(40, 50, 80);
            this.lblApellido.Location = new System.Drawing.Point(310, 20);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(83, 21);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Apellido *";
            // 
            // txtApellido
            // 
            this.txtApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellido.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtApellido.Location = new System.Drawing.Point(310, 40);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(250, 30);
            this.txtApellido.TabIndex = 3;
            // 
            // lblMatricula
            // 
            this.lblMatricula.AutoSize = true;
            this.lblMatricula.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMatricula.ForeColor = System.Drawing.Color.FromArgb(40, 50, 80);
            this.lblMatricula.Location = new System.Drawing.Point(30, 85);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(78, 21);
            this.lblMatricula.TabIndex = 4;
            this.lblMatricula.Text = "Matrícula";
            // 
            // txtMatricula
            // 
            this.txtMatricula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMatricula.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMatricula.Location = new System.Drawing.Point(30, 105);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(250, 30);
            this.txtMatricula.TabIndex = 5;
            // 
            // lblCurso
            // 
            this.lblCurso.AutoSize = true;
            this.lblCurso.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCurso.ForeColor = System.Drawing.Color.FromArgb(40, 50, 80);
            this.lblCurso.Location = new System.Drawing.Point(310, 85);
            this.lblCurso.Name = "lblCurso";
            this.lblCurso.Size = new System.Drawing.Size(52, 21);
            this.lblCurso.TabIndex = 6;
            this.lblCurso.Text = "Curso";
            // 
            // txtCurso
            // 
            this.txtCurso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurso.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCurso.Location = new System.Drawing.Point(310, 105);
            this.txtCurso.Name = "txtCurso";
            this.txtCurso.Size = new System.Drawing.Size(250, 30);
            this.txtCurso.TabIndex = 7;
            // 
            // lblSeccion
            // 
            this.lblSeccion.AutoSize = true;
            this.lblSeccion.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSeccion.ForeColor = System.Drawing.Color.FromArgb(40, 50, 80);
            this.lblSeccion.Location = new System.Drawing.Point(30, 150);
            this.lblSeccion.Name = "lblSeccion";
            this.lblSeccion.Size = new System.Drawing.Size(67, 21);
            this.lblSeccion.TabIndex = 8;
            this.lblSeccion.Text = "Sección";
            // 
            // txtSeccion
            // 
            this.txtSeccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSeccion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSeccion.Location = new System.Drawing.Point(30, 170);
            this.txtSeccion.Name = "txtSeccion";
            this.txtSeccion.Size = new System.Drawing.Size(250, 30);
            this.txtSeccion.TabIndex = 9;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(40, 50, 80);
            this.lblEmail.Location = new System.Drawing.Point(310, 150);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(48, 21);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Location = new System.Drawing.Point(310, 170);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(250, 30);
            this.txtEmail.TabIndex = 11;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(40, 50, 80);
            this.lblUsername.Location = new System.Drawing.Point(30, 215);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(76, 21);
            this.lblUsername.TabIndex = 12;
            this.lblUsername.Text = "Usuario *";
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsername.Location = new System.Drawing.Point(30, 235);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(250, 30);
            this.txtUsername.TabIndex = 13;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(40, 50, 80);
            this.lblPassword.Location = new System.Drawing.Point(310, 215);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(92, 21);
            this.lblPassword.TabIndex = 14;
            this.lblPassword.Text = "Contraseña";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location = new System.Drawing.Point(310, 235);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(250, 30);
            this.txtPassword.TabIndex = 15;
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblRol.ForeColor = System.Drawing.Color.FromArgb(40, 50, 80);
            this.lblRol.Location = new System.Drawing.Point(30, 280);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(34, 21);
            this.lblRol.TabIndex = 16;
            this.lblRol.Text = "Rol";
            // 
            // cmbRol
            // 
            this.cmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRol.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbRol.Location = new System.Drawing.Point(30, 300);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(250, 31);
            this.cmbRol.TabIndex = 17;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnGuardar);
            this.pnlFooter.Controls.Add(this.btnCancelar);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 585);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(0, 15, 25, 15);
            this.pnlFooter.Size = new System.Drawing.Size(620, 75);
            this.pnlFooter.TabIndex = 1;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(22, 97, 255);
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(295, 15);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(155, 42);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 205, 215);
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(60, 65, 80);
            this.btnCancelar.Location = new System.Drawing.Point(460, 15);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(130, 42);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmEditarUsuario
            // 
            this.BackColor = System.Drawing.Color.FromArgb(243, 245, 250);
            this.ClientSize = new System.Drawing.Size(620, 660);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmEditarUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Usuario";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}