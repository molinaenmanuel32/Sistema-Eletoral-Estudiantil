using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    partial class FrmEditarPlancha
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Panel pnlBody;
        private Label lblLogo;
        private Label lblLogoTexto;
        private PictureBox picLogo;
        private Button btnSeleccionarLogo;
        private Label lblTitulo;
        private Label lblSubtitulo;

        private Label lblNombre;
        private Label lblDescripcion;
        private Label lblMision;
        private Label lblColor;

        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private TextBox txtMision;
        private TextBox txtColor;

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
            pnlHeader = new Panel();
            pnlBody = new Panel();
            lblLogo = new Label();
            lblLogoTexto = new Label();
            picLogo = new PictureBox();
            btnSeleccionarLogo = new Button();
            lblTitulo = new Label();
            lblSubtitulo = new Label();

            lblNombre = new Label();
            lblDescripcion = new Label();
            lblMision = new Label();
            lblColor = new Label();

            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            txtMision = new TextBox();
            txtColor = new TextBox();

            btnGuardar = new Button();
            btnCancelar = new Button();

            SuspendLayout();

            BackColor = Color.FromArgb(243, 245, 250);
            ClientSize = new Size(620, 820);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            Text = "Nueva Plancha";

            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 115;
            pnlHeader.BackColor = Color.White;

            lblTitulo.Text = "●  Nueva Plancha";
            lblTitulo.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 60, 170);
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(35, 25);

            lblSubtitulo.Text = "Registra los datos principales de la plancha electoral.";
            lblSubtitulo.Font = new Font("Segoe UI", 10.5F);
            lblSubtitulo.ForeColor = Color.FromArgb(80, 85, 100);
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Location = new Point(40, 75);

            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Controls.Add(lblSubtitulo);

            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Padding = new Padding(35);
            pnlBody.BackColor = Color.FromArgb(243, 245, 250);

            // Nombre
            lblNombre.Text = "Nombre de la plancha";
            lblNombre.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(0, 45, 110);
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(35, 30);

            txtNombre.Location = new Point(35, 58);
            txtNombre.Size = new Size(530, 30);
            txtNombre.Font = new Font("Segoe UI", 10F);

            // Descripción
            lblDescripcion.Text = "Descripción";
            lblDescripcion.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblDescripcion.ForeColor = Color.FromArgb(0, 45, 110);
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(35, 110);

            txtDescripcion.Location = new Point(35, 138);
            txtDescripcion.Size = new Size(530, 80);
            txtDescripcion.Multiline = true;
            txtDescripcion.Font = new Font("Segoe UI", 10F);

            // Misión
            lblMision.Text = "Misión";
            lblMision.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblMision.ForeColor = Color.FromArgb(0, 45, 110);
            lblMision.AutoSize = true;
            lblMision.Location = new Point(35, 250);

            txtMision.Location = new Point(35, 278);
            txtMision.Size = new Size(530, 80);
            txtMision.Multiline = true;
            txtMision.Font = new Font("Segoe UI", 10F);

            // Color
            lblColor.Text = "Color HEX";
            lblColor.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblColor.ForeColor = Color.FromArgb(0, 45, 110);
            lblColor.AutoSize = true;
            lblColor.Location = new Point(35, 390);

            txtColor.Location = new Point(35, 418);
            txtColor.Size = new Size(250, 30);
            txtColor.Font = new Font("Segoe UI", 10F);

            // Logo
            lblLogo.Text = "Logo de la plancha";
            lblLogo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblLogo.ForeColor = Color.FromArgb(0, 45, 110);
            lblLogo.AutoSize = true;
            lblLogo.Location = new Point(35, 465);

            picLogo.Location = new Point(35, 495);
            picLogo.Size = new Size(90, 90);
            picLogo.BackColor = Color.White;
            picLogo.BorderStyle = BorderStyle.FixedSingle;
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;

            btnSeleccionarLogo.Text = "Seleccionar Logo";
            btnSeleccionarLogo.Size = new Size(170, 38);
            btnSeleccionarLogo.Location = new Point(145, 500);
            btnSeleccionarLogo.FlatStyle = FlatStyle.Flat;
            btnSeleccionarLogo.FlatAppearance.BorderSize = 0;
            btnSeleccionarLogo.BackColor = Color.FromArgb(37, 99, 235);
            btnSeleccionarLogo.ForeColor = Color.White;
            btnSeleccionarLogo.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnSeleccionarLogo.Cursor = Cursors.Hand;
            btnSeleccionarLogo.Click += btnSeleccionarLogo_Click;

            lblLogoTexto.Text = "Sin logo seleccionado";
            lblLogoTexto.Font = new Font("Segoe UI", 9F);
            lblLogoTexto.ForeColor = Color.FromArgb(80, 85, 100);
            lblLogoTexto.AutoSize = false;
            lblLogoTexto.Location = new Point(145, 545);
            lblLogoTexto.Size = new Size(390, 35);

            // Guardar
            btnGuardar.Text = "Guardar";
            btnGuardar.Size = new Size(140, 42);
            btnGuardar.Location = new Point(270, 650);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.BackColor = Color.FromArgb(37, 99, 235);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.Click += btnGuardar_Click;

            // Cancelar
            btnCancelar.Text = "Cancelar";
            btnCancelar.Size = new Size(140, 42);
            btnCancelar.Location = new Point(425, 650);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.BackColor = Color.FromArgb(220, 38, 38);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Click += btnCancelar_Click;

            pnlBody.Controls.AddRange(new Control[]
            {
                lblNombre, txtNombre,
                lblDescripcion, txtDescripcion,
                lblMision, txtMision,
                lblColor, txtColor,
                lblLogo, picLogo, btnSeleccionarLogo, lblLogoTexto,
                btnGuardar, btnCancelar
            });

            Controls.Add(pnlBody);
            Controls.Add(pnlHeader);

            ResumeLayout(false);
        }
    }
}