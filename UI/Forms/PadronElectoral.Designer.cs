using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    partial class PadronElectoral
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Panel pnlTop;

        private Label lblIcono;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Label lblVotacion;

        private ComboBox cmbVotacion;
        private Button btnAdd;
        private Button btnQuitar;
        private DataGridView dgv;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            pnlHeader = new Panel();
            pnlTop = new Panel();

            lblIcono = new Label();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            lblVotacion = new Label();

            cmbVotacion = new ComboBox();
            btnAdd = new Button();
            btnQuitar = new Button();
            dgv = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();

            BackColor = Color.FromArgb(245, 247, 252);
            Padding = new Padding(25);
            ClientSize = new Size(1100, 700);
            Text = "Padrón Electoral";
            AutoScroll = true;

            // HEADER
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 120;
            pnlHeader.BackColor = Color.White;

            lblIcono.Text = "●";
            lblIcono.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblIcono.ForeColor = Color.FromArgb(22, 97, 255);
            lblIcono.Location = new Point(20, 10);
            lblIcono.Size = new Size(40, 55);

            lblTitulo.Text = "Gestión del Padrón Electoral";
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 55, 150);
            lblTitulo.Location = new Point(60, 16);
            lblTitulo.Size = new Size(650, 42);

            lblSubtitulo.Text = "Administra los votantes registrados en cada votación";
            lblSubtitulo.Font = new Font("Segoe UI", 10.5F);
            lblSubtitulo.ForeColor = Color.FromArgb(80, 90, 115);
            lblSubtitulo.Location = new Point(25, 65);
            lblSubtitulo.Size = new Size(700, 28);

            pnlHeader.Controls.Add(lblIcono);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Controls.Add(lblSubtitulo);

            // TOP
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Height = 90;
            pnlTop.BackColor = Color.FromArgb(245, 247, 252);

            lblVotacion.Text = "Votación:";
            lblVotacion.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblVotacion.ForeColor = Color.FromArgb(10, 35, 90);
            lblVotacion.Location = new Point(0, 31);
            lblVotacion.Size = new Size(80, 25);

            cmbVotacion.Location = new Point(85, 26);
            cmbVotacion.Size = new Size(330, 30);
            cmbVotacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVotacion.Font = new Font("Segoe UI", 10F);
            cmbVotacion.SelectedIndexChanged += cmbVotacion_SelectedIndexChanged;

            btnAdd.Text = "+ Agregar al Padrón";
            btnAdd.Size = new Size(180, 42);
            btnAdd.Location = new Point(440, 20);
            btnAdd.BackColor = Color.FromArgb(22, 97, 255);
            btnAdd.ForeColor = Color.White;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.Click += btnAdd_Click;

            btnQuitar.Text = "Quitar";
            btnQuitar.Size = new Size(110, 42);
            btnQuitar.Location = new Point(635, 20);
            btnQuitar.BackColor = Color.FromArgb(230, 40, 45);
            btnQuitar.ForeColor = Color.White;
            btnQuitar.FlatStyle = FlatStyle.Flat;
            btnQuitar.FlatAppearance.BorderSize = 0;
            btnQuitar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnQuitar.Cursor = Cursors.Hand;
            btnQuitar.Click += btnQuitar_Click;

            pnlTop.Controls.Add(lblVotacion);
            pnlTop.Controls.Add(cmbVotacion);
            pnlTop.Controls.Add(btnAdd);
            pnlTop.Controls.Add(btnQuitar);

            // DATAGRID
            dgv.Dock = DockStyle.Fill;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ColumnHeadersHeight = 42;
            dgv.RowTemplate.Height = 36;
            dgv.Font = new Font("Segoe UI", 10F);

            Controls.Add(dgv);
            Controls.Add(pnlTop);
            Controls.Add(pnlHeader);

            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
        }
    }
}