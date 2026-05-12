using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    partial class FrmEditarUsuario
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Panel pnlBody;

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
            this.pnlHeader = new Panel();
            this.pnlBody = new Panel();

            this.lblTitulo = new Label();
            this.lblSubtitulo = new Label();

            this.lblNombre = new Label();
            this.lblApellido = new Label();
            this.lblMatricula = new Label();
            this.lblCurso = new Label();
            this.lblSeccion = new Label();
            this.lblEmail = new Label();
            this.lblUsername = new Label();
            this.lblPassword = new Label();
            this.lblRol = new Label();

            this.txtNombre = new TextBox();
            this.txtApellido = new TextBox();
            this.txtMatricula = new TextBox();
            this.txtCurso = new TextBox();
            this.txtSeccion = new TextBox();
            this.txtEmail = new TextBox();
            this.txtUsername = new TextBox();
            this.txtPassword = new TextBox();

            this.cmbRol = new ComboBox();

            this.btnGuardar = new Button();
            this.btnCancelar = new Button();

            // FORM
            this.SuspendLayout();

            this.BackColor = Color.FromArgb(243, 245, 250);
            this.ClientSize = new Size(620, 620);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Usuario";

            // HEADER
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Height = 115;
            this.pnlHeader.BackColor = Color.White;

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.FromArgb(0, 60, 170);
            this.lblTitulo.Location = new Point(35, 25);
            this.lblTitulo.Text = "● Usuario";

            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new Font("Segoe UI", 10.5F);
            this.lblSubtitulo.ForeColor = Color.FromArgb(80, 85, 100);
            this.lblSubtitulo.Location = new Point(40, 75);
            this.lblSubtitulo.Text = "Registra o modifica los datos del usuario.";

            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblSubtitulo);

            // BODY
            this.pnlBody.Dock = DockStyle.Fill;
            this.pnlBody.BackColor = Color.FromArgb(243, 245, 250);

            // CAMPOS - LABELS Y TEXTBOXES

            // Nombre
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new Point(30, 20);
            this.lblNombre.Text = "Nombre";
            this.txtNombre.Location = new Point(30, 40);
            this.txtNombre.Size = new Size(250, 28);

            // Apellido
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new Point(310, 20);
            this.lblApellido.Text = "Apellido";
            this.txtApellido.Location = new Point(310, 40);
            this.txtApellido.Size = new Size(250, 28);

            // Matrícula
            this.lblMatricula.AutoSize = true;
            this.lblMatricula.Location = new Point(30, 80);
            this.lblMatricula.Text = "Matrícula";
            this.txtMatricula.Location = new Point(30, 100);
            this.txtMatricula.Size = new Size(250, 28);

            // Curso
            this.lblCurso.AutoSize = true;
            this.lblCurso.Location = new Point(310, 80);
            this.lblCurso.Text = "Curso";
            this.txtCurso.Location = new Point(310, 100);
            this.txtCurso.Size = new Size(250, 28);

            // Sección
            this.lblSeccion.AutoSize = true;
            this.lblSeccion.Location = new Point(30, 140);
            this.lblSeccion.Text = "Sección";
            this.txtSeccion.Location = new Point(30, 160);
            this.txtSeccion.Size = new Size(250, 28);

            // Email
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new Point(310, 140);
            this.lblEmail.Text = "Email";
            this.txtEmail.Location = new Point(310, 160);
            this.txtEmail.Size = new Size(250, 28);

            // Username
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new Point(30, 200);
            this.lblUsername.Text = "Usuario";
            this.txtUsername.Location = new Point(30, 220);
            this.txtUsername.Size = new Size(250, 28);

            // Password
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new Point(310, 200);
            this.lblPassword.Text = "Contraseña";
            this.txtPassword.Location = new Point(310, 220);
            this.txtPassword.Size = new Size(250, 28);
            this.txtPassword.PasswordChar = '*';

            // Rol
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new Point(30, 260);
            this.lblRol.Text = "Rol";

            this.cmbRol.Location = new Point(30, 280);
            this.cmbRol.Size = new Size(250, 28);
            this.cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;

            // BOTONES
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new Point(310, 520);
            this.btnGuardar.Size = new Size(130, 40);

            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new Point(450, 520);
            this.btnCancelar.Size = new Size(130, 40);

            // EVENTOS
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // ADD CONTROLS
            this.pnlBody.Controls.AddRange(new Control[]
            {
                lblNombre, txtNombre,
                lblApellido, txtApellido,
                lblMatricula, txtMatricula,
                lblCurso, txtCurso,
                lblSeccion, txtSeccion,
                lblEmail, txtEmail,
                lblUsername, txtUsername,
                lblPassword, txtPassword,
                lblRol, cmbRol,
                btnGuardar, btnCancelar
            });

            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);

            this.ResumeLayout(false);
        }
    }
}