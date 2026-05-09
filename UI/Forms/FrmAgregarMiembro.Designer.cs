using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    partial class FrmAgregarMiembro
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Panel pnlBody;

        private Label lblTitulo;
        private Label lblSubtitulo;

        private Label lblUsuario;
        private Label lblPuesto;
        private Label lblOrden;
        private Label lblDescripcion;

        private ComboBox cmbUsuario;
        private TextBox txtPuesto;
        private NumericUpDown numOrden;
        private TextBox txtDescripcion;

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

            lblTitulo = new Label();
            lblSubtitulo = new Label();

            lblUsuario = new Label();
            lblPuesto = new Label();
            lblOrden = new Label();
            lblDescripcion = new Label();

            cmbUsuario = new ComboBox();
            txtPuesto = new TextBox();
            numOrden = new NumericUpDown();
            txtDescripcion = new TextBox();

            btnGuardar = new Button();
            btnCancelar = new Button();

            SuspendLayout();

            BackColor = Color.FromArgb(243, 245, 250);
            ClientSize = new Size(620, 720);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            Text = "Agregar Miembro";

            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 110;
            pnlHeader.BackColor = Color.White;

            lblTitulo.Text = "●  Agregar Miembro";
            lblTitulo.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 60, 170);
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(35, 25);

            lblSubtitulo.Text = "Agrega un miembro a la plancha electoral.";
            lblSubtitulo.Font = new Font("Segoe UI", 10.5F);
            lblSubtitulo.ForeColor = Color.FromArgb(80, 85, 100);
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Location = new Point(40, 75);

            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Controls.Add(lblSubtitulo);

            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Padding = new Padding(35);
            pnlBody.BackColor = Color.FromArgb(243, 245, 250);

            // Usuario
            lblUsuario.Text = "Usuario";
            lblUsuario.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblUsuario.ForeColor = Color.FromArgb(0, 45, 110);
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(35, 30);

            cmbUsuario.Location = new Point(35, 58);
            cmbUsuario.Size = new Size(520, 30);
            cmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuario.Font = new Font("Segoe UI", 10F);

            // Puesto
            lblPuesto.Text = "Puesto";
            lblPuesto.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblPuesto.ForeColor = Color.FromArgb(0, 45, 110);
            lblPuesto.AutoSize = true;
            lblPuesto.Location = new Point(35, 120);

            txtPuesto.Location = new Point(35, 148);
            txtPuesto.Size = new Size(520, 30);
            txtPuesto.Font = new Font("Segoe UI", 10F);

            // Orden
            lblOrden.Text = "Orden";
            lblOrden.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblOrden.ForeColor = Color.FromArgb(0, 45, 110);
            lblOrden.AutoSize = true;
            lblOrden.Location = new Point(35, 210);

            numOrden.Location = new Point(35, 238);
            numOrden.Size = new Size(150, 30);
            numOrden.Minimum = 1;
            numOrden.Maximum = 99;
            numOrden.Font = new Font("Segoe UI", 10F);

            // Descripción
            lblDescripcion.Text = "Descripción";
            lblDescripcion.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblDescripcion.ForeColor = Color.FromArgb(0, 45, 110);
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(35, 300);

            txtDescripcion.Location = new Point(35, 328);
            txtDescripcion.Size = new Size(520, 90);
            txtDescripcion.Multiline = true;
            txtDescripcion.Font = new Font("Segoe UI", 10F);

            // Guardar
            btnGuardar.Text = "Guardar";
            btnGuardar.Size = new Size(140, 42);
            btnGuardar.Location = new Point(270, 560);
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
            btnCancelar.Location = new Point(425, 560);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.BackColor = Color.FromArgb(220, 38, 38);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Click += btnCancelar_Click;

            pnlBody.Controls.AddRange(new Control[]
            {
                lblUsuario, cmbUsuario,
                lblPuesto, txtPuesto,
                lblOrden, numOrden,
                lblDescripcion, txtDescripcion,
                btnGuardar, btnCancelar
            });

            Controls.Add(pnlBody);
            Controls.Add(pnlHeader);

            ResumeLayout(false);
        }
    }
}