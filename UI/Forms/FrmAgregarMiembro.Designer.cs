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
        private Label lblFoto;

        private ComboBox cmbUsuario;
        private ComboBox cmbPuesto;
        private NumericUpDown numOrden;
        private TextBox txtDescripcion;

        private PictureBox picFoto;
        private Button btnBuscarFoto;
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

            lblUsuario = new Label();
            lblPuesto = new Label();
            lblOrden = new Label();
            lblDescripcion = new Label();
            lblFoto = new Label();

            cmbUsuario = new ComboBox();
            cmbPuesto = new ComboBox();
            numOrden = new NumericUpDown();
            txtDescripcion = new TextBox();

            picFoto = new PictureBox();
            btnBuscarFoto = new Button();
            btnGuardar = new Button();
            btnCancelar = new Button();

            ((System.ComponentModel.ISupportInitialize)numOrden).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picFoto).BeginInit();

            SuspendLayout();

            BackColor = Color.FromArgb(243, 245, 250);
            ClientSize = new Size(640, 760);
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

            lblUsuario.Text = "Usuario";
            lblUsuario.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblUsuario.ForeColor = Color.FromArgb(0, 45, 110);
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(35, 25);

            cmbUsuario.Location = new Point(35, 53);
            cmbUsuario.Size = new Size(540, 30);
            cmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuario.Font = new Font("Segoe UI", 10F);

            lblPuesto.Text = "Cargo";
            lblPuesto.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblPuesto.ForeColor = Color.FromArgb(0, 45, 110);
            lblPuesto.AutoSize = true;
            lblPuesto.Location = new Point(35, 105);

            cmbPuesto.Location = new Point(35, 133);
            cmbPuesto.Size = new Size(260, 30);
            cmbPuesto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPuesto.Font = new Font("Segoe UI", 10F);

            lblOrden.Text = "Orden";
            lblOrden.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblOrden.ForeColor = Color.FromArgb(0, 45, 110);
            lblOrden.AutoSize = true;
            lblOrden.Location = new Point(315, 105);

            numOrden.Location = new Point(315, 133);
            numOrden.Size = new Size(120, 30);
            numOrden.Minimum = 1;
            numOrden.Maximum = 99;
            numOrden.Value = 1;
            numOrden.Font = new Font("Segoe UI", 10F);

            lblFoto.Text = "Foto representativa";
            lblFoto.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblFoto.ForeColor = Color.FromArgb(0, 45, 110);
            lblFoto.AutoSize = true;
            lblFoto.Location = new Point(35, 190);

            picFoto.Location = new Point(35, 220);
            picFoto.Size = new Size(140, 120);
            picFoto.BackColor = Color.White;
            picFoto.BorderStyle = BorderStyle.FixedSingle;
            picFoto.SizeMode = PictureBoxSizeMode.Zoom;

            btnBuscarFoto.Text = "Buscar Foto";
            btnBuscarFoto.Size = new Size(140, 38);
            btnBuscarFoto.Location = new Point(195, 262);
            btnBuscarFoto.FlatStyle = FlatStyle.Flat;
            btnBuscarFoto.FlatAppearance.BorderSize = 0;
            btnBuscarFoto.BackColor = Color.FromArgb(0, 60, 170);
            btnBuscarFoto.ForeColor = Color.White;
            btnBuscarFoto.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnBuscarFoto.Cursor = Cursors.Hand;
            btnBuscarFoto.Click += btnBuscarFoto_Click;

            lblDescripcion.Text = "Descripción";
            lblDescripcion.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblDescripcion.ForeColor = Color.FromArgb(0, 45, 110);
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(35, 375);

            txtDescripcion.Location = new Point(35, 405);
            txtDescripcion.Size = new Size(540, 100);
            txtDescripcion.Multiline = true;
            txtDescripcion.Font = new Font("Segoe UI", 10F);

            btnGuardar.Text = "Guardar";
            btnGuardar.Size = new Size(140, 42);
            btnGuardar.Location = new Point(280, 575);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.BackColor = Color.FromArgb(37, 99, 235);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.Click += btnGuardar_Click;

            btnCancelar.Text = "Cancelar";
            btnCancelar.Size = new Size(140, 42);
            btnCancelar.Location = new Point(435, 575);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.BackColor = Color.FromArgb(220, 38, 38);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Click += btnCancelar_Click;

            pnlBody.Controls.Add(lblUsuario);
            pnlBody.Controls.Add(cmbUsuario);
            pnlBody.Controls.Add(lblPuesto);
            pnlBody.Controls.Add(cmbPuesto);
            pnlBody.Controls.Add(lblOrden);
            pnlBody.Controls.Add(numOrden);
            pnlBody.Controls.Add(lblFoto);
            pnlBody.Controls.Add(picFoto);
            pnlBody.Controls.Add(btnBuscarFoto);
            pnlBody.Controls.Add(lblDescripcion);
            pnlBody.Controls.Add(txtDescripcion);
            pnlBody.Controls.Add(btnGuardar);
            pnlBody.Controls.Add(btnCancelar);

            Controls.Add(pnlBody);
            Controls.Add(pnlHeader);

            ((System.ComponentModel.ISupportInitialize)numOrden).EndInit();
            ((System.ComponentModel.ISupportInitialize)picFoto).EndInit();

            ResumeLayout(false);
        }
    }
}