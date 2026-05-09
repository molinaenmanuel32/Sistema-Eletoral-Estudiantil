using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    partial class VotacionAdmin
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Panel pnlTop;

        private Label lblIcono;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Label lblEstado;

        private Button btnNueva;
        private Button btnActivar;
        private Button btnCerrar;

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
            lblEstado = new Label();

            btnNueva = new Button();
            btnActivar = new Button();
            btnCerrar = new Button();

            dgv = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();

            // FORM
            BackColor = Color.FromArgb(245, 247, 252);
            Padding = new Padding(25);
            ClientSize = new Size(1100, 700);
            Text = "Votación Admin";
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

            lblTitulo.Text = "Gestión de Votaciones";
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 55, 150);
            lblTitulo.Location = new Point(60, 16);
            lblTitulo.Size = new Size(600, 42);

            lblSubtitulo.Text = "Administra las votaciones del sistema electoral estudiantil";
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

            btnNueva.Text = "+ Nueva Votación";
            btnNueva.Size = new Size(180, 42);
            btnNueva.Location = new Point(0, 20);
            btnNueva.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnNueva.Cursor = Cursors.Hand;
            btnNueva.Click += btnNueva_Click;

            btnActivar.Text = "Activar";
            btnActivar.Size = new Size(120, 42);
            btnActivar.Location = new Point(195, 20);
            btnActivar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnActivar.Cursor = Cursors.Hand;
            btnActivar.Click += btnActivar_Click;

            btnCerrar.Text = "Cerrar";
            btnCerrar.Size = new Size(120, 42);
            btnCerrar.Location = new Point(330, 20);
            btnCerrar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.Click += btnCerrar_Click;

            lblEstado.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEstado.ForeColor = Color.FromArgb(0, 55, 150);
            lblEstado.Location = new Point(480, 30);
            lblEstado.Size = new Size(500, 25);
            lblEstado.Text = "Sin votación activa";

            pnlTop.Controls.Add(btnNueva);
            pnlTop.Controls.Add(btnActivar);
            pnlTop.Controls.Add(btnCerrar);
            pnlTop.Controls.Add(lblEstado);

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