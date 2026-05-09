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
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            
            
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

            BackColor = Color.FromArgb(243, 245, 250);
            ClientSize = new Size(620, 620);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Nuevo Usuario";

            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 115;
            pnlHeader.BackColor = Color.White;

            lblTitulo.Text = "●  Nuevo Usuario";
            lblTitulo.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 60, 170);
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(35, 25);

            lblSubtitulo.Text = "Registra o modifica los datos del usuario.";
            lblSubtitulo.Font = new Font("Segoe UI", 10.5F);
            lblSubtitulo.ForeColor = Color.FromArgb(80, 85, 100);
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Location = new Point(40, 75);

            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Controls.Add(lblSubtitulo);

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
            lblRol.ForeColor = Color.FromArgb(0, 45, 110);
            lblRol.AutoSize = true;
            lblRol.Location = new Point(35, 330);

            cmbRol.Location = new Point(35, 355);
            cmbRol.Size = new Size(250, 32);
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.Font = new Font("Segoe UI", 10F);

            btnGuardar.Text = "Guardar";
            btnGuardar.Size = new Size(135, 42);
            btnGuardar.Location = new Point(315, 440);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.BackColor = Color.FromArgb(37, 99, 235);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;

            btnCancelar.Text = "Cancelar";
            btnCancelar.Size = new Size(135, 42);
            btnCancelar.Location = new Point(460, 440);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.BackColor = Color.FromArgb(235, 40, 50);
            btnCancelar.ForeColor = Color.White;
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

            Controls.Add(pnlBody);
            Controls.Add(pnlHeader);

            ResumeLayout(false);
        }

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


    }
}