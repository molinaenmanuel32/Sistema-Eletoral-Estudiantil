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

<<<<<<< HEAD
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
=======


        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
<<<<<<< HEAD
=======
            
            
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
            pnlHeader = new Panel();
            pnlBody = new Panel();

            lblTitulo = new Label();
            lblSubtitulo = new Label();

            lblNombre = new Label();
            lblApellido = new Label();
            lblMatricula = new Label();
            lblCurso = new Label();
            lblSeccion = new Label();
            lblEmail = new Label();
            lblUsername = new Label();
            lblPassword = new Label();
            lblRol = new Label();

            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtMatricula = new TextBox();
            txtCurso = new TextBox();
            txtSeccion = new TextBox();
            txtEmail = new TextBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();

            cmbRol = new ComboBox();

            btnGuardar = new Button();
            btnCancelar = new Button();

            SuspendLayout();

<<<<<<< HEAD
            // FORM
=======
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
            BackColor = Color.FromArgb(243, 245, 250);
            ClientSize = new Size(620, 620);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Nuevo Usuario";

<<<<<<< HEAD
            // HEADER
=======
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 115;
            pnlHeader.BackColor = Color.White;

<<<<<<< HEAD
            // TITULO
            lblTitulo.Text = "● Nuevo Usuario";
            lblTitulo.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
=======
            lblTitulo.Text = "●  Nuevo Usuario";
            lblTitulo.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
            lblTitulo.ForeColor = Color.FromArgb(0, 60, 170);
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(35, 25);

<<<<<<< HEAD
            // SUBTITULO
=======
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
            lblSubtitulo.Text = "Registra o modifica los datos del usuario.";
            lblSubtitulo.Font = new Font("Segoe UI", 10.5F);
            lblSubtitulo.ForeColor = Color.FromArgb(80, 85, 100);
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Location = new Point(40, 75);

            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Controls.Add(lblSubtitulo);

<<<<<<< HEAD
            // BODY
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.BackColor = Color.FromArgb(243, 245, 250);

            // NOMBRE
            lblNombre.Text = "Nombre";
            lblNombre.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(0, 45, 110);
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(35, 30);

            txtNombre.Location = new Point(35, 55);
            txtNombre.Size = new Size(250, 30);
            txtNombre.Font = new Font("Segoe UI", 10F);

            // APELLIDO
            lblApellido.Text = "Apellido";
            lblApellido.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblApellido.ForeColor = Color.FromArgb(0, 45, 110);
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(315, 30);

            txtApellido.Location = new Point(315, 55);
            txtApellido.Size = new Size(250, 30);
            txtApellido.Font = new Font("Segoe UI", 10F);

            // MATRICULA
            lblMatricula.Text = "Matrícula";
            lblMatricula.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblMatricula.ForeColor = Color.FromArgb(0, 45, 110);
            lblMatricula.AutoSize = true;
            lblMatricula.Location = new Point(35, 105);

            txtMatricula.Location = new Point(35, 130);
            txtMatricula.Size = new Size(250, 30);
            txtMatricula.Font = new Font("Segoe UI", 10F);

            // CURSO
            lblCurso.Text = "Curso";
            lblCurso.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblCurso.ForeColor = Color.FromArgb(0, 45, 110);
            lblCurso.AutoSize = true;
            lblCurso.Location = new Point(315, 105);

            txtCurso.Location = new Point(315, 130);
            txtCurso.Size = new Size(250, 30);
            txtCurso.Font = new Font("Segoe UI", 10F);

            // SECCION
            lblSeccion.Text = "Sección";
            lblSeccion.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSeccion.ForeColor = Color.FromArgb(0, 45, 110);
            lblSeccion.AutoSize = true;
            lblSeccion.Location = new Point(35, 180);

            txtSeccion.Location = new Point(35, 205);
            txtSeccion.Size = new Size(250, 30);
            txtSeccion.Font = new Font("Segoe UI", 10F);

            // EMAIL
            lblEmail.Text = "Email";
            lblEmail.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(0, 45, 110);
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(315, 180);

            txtEmail.Location = new Point(315, 205);
            txtEmail.Size = new Size(250, 30);
            txtEmail.Font = new Font("Segoe UI", 10F);

            // USERNAME
            lblUsername.Text = "Usuario";
            lblUsername.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(0, 45, 110);
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(35, 255);

            txtUsername.Location = new Point(35, 280);
            txtUsername.Size = new Size(250, 30);
            txtUsername.Font = new Font("Segoe UI", 10F);

            // PASSWORD
            lblPassword.Text = "Contraseña";
            lblPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(0, 45, 110);
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(315, 255);

            txtPassword.Location = new Point(315, 280);
            txtPassword.Size = new Size(250, 30);
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.PasswordChar = '*';

            // ROL
            lblRol.Text = "Rol";
            lblRol.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
=======
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.BackColor = Color.FromArgb(243, 245, 250);
            pnlBody.Padding = new Padding(35);

            CrearCampo(lblNombre, txtNombre, "Nombre", 35, 30);
            CrearCampo(lblApellido, txtApellido, "Apellido", 315, 30);

            CrearCampo(lblMatricula, txtMatricula, "Matrícula", 35, 105);
            CrearCampo(lblCurso, txtCurso, "Curso", 315, 105);

            CrearCampo(lblSeccion, txtSeccion, "Sección", 35, 180);
            CrearCampo(lblEmail, txtEmail, "Email", 315, 180);

            CrearCampo(lblUsername, txtUsername, "Usuario", 35, 255);
            CrearCampo(lblPassword, txtPassword, "Contraseña", 315, 255);
            txtPassword.PasswordChar = '*';

            lblRol.Text = "Rol";
            lblRol.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
            lblRol.ForeColor = Color.FromArgb(0, 45, 110);
            lblRol.AutoSize = true;
            lblRol.Location = new Point(35, 330);

            cmbRol.Location = new Point(35, 355);
<<<<<<< HEAD
            cmbRol.Size = new Size(250, 30);
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.Font = new Font("Segoe UI", 10F);

            // GUARDAR
=======
            cmbRol.Size = new Size(250, 32);
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.Font = new Font("Segoe UI", 10F);

>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
            btnGuardar.Text = "Guardar";
            btnGuardar.Size = new Size(135, 42);
            btnGuardar.Location = new Point(315, 440);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.BackColor = Color.FromArgb(37, 99, 235);
            btnGuardar.ForeColor = Color.White;
<<<<<<< HEAD
            btnGuardar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;

            // CANCELAR
=======
            btnGuardar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;

>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
            btnCancelar.Text = "Cancelar";
            btnCancelar.Size = new Size(135, 42);
            btnCancelar.Location = new Point(460, 440);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.BackColor = Color.FromArgb(235, 40, 50);
            btnCancelar.ForeColor = Color.White;
<<<<<<< HEAD
            btnCancelar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;

            // AGREGAR CONTROLES
            pnlBody.Controls.Add(lblNombre);
            pnlBody.Controls.Add(txtNombre);

            pnlBody.Controls.Add(lblApellido);
            pnlBody.Controls.Add(txtApellido);

            pnlBody.Controls.Add(lblMatricula);
            pnlBody.Controls.Add(txtMatricula);

            pnlBody.Controls.Add(lblCurso);
            pnlBody.Controls.Add(txtCurso);

            pnlBody.Controls.Add(lblSeccion);
            pnlBody.Controls.Add(txtSeccion);

            pnlBody.Controls.Add(lblEmail);
            pnlBody.Controls.Add(txtEmail);

            pnlBody.Controls.Add(lblUsername);
            pnlBody.Controls.Add(txtUsername);

            pnlBody.Controls.Add(lblPassword);
            pnlBody.Controls.Add(txtPassword);

            pnlBody.Controls.Add(lblRol);
            pnlBody.Controls.Add(cmbRol);

            pnlBody.Controls.Add(btnGuardar);
            pnlBody.Controls.Add(btnCancelar);
=======
            btnCancelar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;

            cmbRol.SelectedIndexChanged += (s, e) =>
            {
                if (_usuario == null)
                {
                    string rol = cmbRol.SelectedItem?.ToString() ?? "Votante";
                    txtMatricula.Text = GenerarMatriculaPorRol(rol);
                }
            };

            if (_usuario == null)
            {
                txtMatricula.Text = GenerarMatriculaPorRol("Votante");
            }

            pnlBody.Controls.AddRange(new Control[]
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
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

            Controls.Add(pnlBody);
            Controls.Add(pnlHeader);

            ResumeLayout(false);
        }
<<<<<<< HEAD
=======

        private void CrearCampo(Label lbl, TextBox txt, string texto, int x, int y)
        {
            lbl.Text = texto;
            lbl.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(0, 45, 110);
            lbl.AutoSize = true;
            lbl.Location = new Point(x, y);

            txt.Location = new Point(x, y + 25);
            txt.Size = new Size(250, 32);
            txt.Font = new Font("Segoe UI", 10F);
            txt.BorderStyle = BorderStyle.FixedSingle;
        }


>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
    }
}