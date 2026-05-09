using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    partial class Planchas
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Panel pnlTop;
        private Panel pnlMain;
        private Panel pnlLeft;
        private Panel pnlRight;
        private Panel pnlMiembrosBotones;

        private Label lblIcono;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Label lblLeft;
        private Label lblPlancha;

        private Button btnNueva;
        private Button btnEditar;
        private Button btnAddMiembro;
        private Button btnQuitarMiembro;

        private DataGridView dgvPlanchas;
        private DataGridView dgvMiembros;

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
            pnlMain = new Panel();
            pnlLeft = new Panel();
            pnlRight = new Panel();
            pnlMiembrosBotones = new Panel();

            lblIcono = new Label();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            lblLeft = new Label();
            lblPlancha = new Label();

            btnNueva = new Button();
            btnEditar = new Button();
            btnAddMiembro = new Button();
            btnQuitarMiembro = new Button();

            dgvPlanchas = new DataGridView();
            dgvMiembros = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)dgvPlanchas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMiembros).BeginInit();

            SuspendLayout();

            BackColor = Color.FromArgb(245, 247, 252);
            Padding = new Padding(25);
            ClientSize = new Size(1100, 700);
            Text = "Planchas";
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

            lblTitulo.Text = "Gestión de Planchas";
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 55, 150);
            lblTitulo.Location = new Point(60, 16);
            lblTitulo.Size = new Size(600, 42);

            lblSubtitulo.Text = "Administra las planchas y sus miembros del sistema electoral estudiantil";
            lblSubtitulo.Font = new Font("Segoe UI", 10.5F);
            lblSubtitulo.ForeColor = Color.FromArgb(80, 90, 115);
            lblSubtitulo.Location = new Point(25, 65);
            lblSubtitulo.Size = new Size(800, 28);

            pnlHeader.Controls.Add(lblIcono);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Controls.Add(lblSubtitulo);

            // TOP
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Height = 90;
            pnlTop.BackColor = Color.FromArgb(245, 247, 252);

            btnNueva.Text = "+ Nueva Plancha";
            btnNueva.Size = new Size(180, 42);
            btnNueva.Location = new Point(0, 20);
            btnNueva.BackColor = Color.FromArgb(22, 97, 255);
            btnNueva.ForeColor = Color.White;
            btnNueva.FlatStyle = FlatStyle.Flat;
            btnNueva.FlatAppearance.BorderSize = 0;
            btnNueva.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnNueva.Cursor = Cursors.Hand;
            btnNueva.Click += btnNueva_Click;

            btnEditar.Text = "Editar";
            btnEditar.Size = new Size(120, 42);
            btnEditar.Location = new Point(195, 20);
            btnEditar.BackColor = Color.FromArgb(0, 55, 150);
            btnEditar.ForeColor = Color.White;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnEditar.Cursor = Cursors.Hand;
            btnEditar.Click += btnEditar_Click;

            pnlTop.Controls.Add(btnNueva);
            pnlTop.Controls.Add(btnEditar);

            // MAIN
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.BackColor = Color.FromArgb(245, 247, 252);

            // LEFT CARD
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Width = 610;
            pnlLeft.BackColor = Color.White;
            pnlLeft.Padding = new Padding(15);

            lblLeft.Text = "Planchas Registradas";
            lblLeft.Dock = DockStyle.Top;
            lblLeft.Height = 45;
            lblLeft.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblLeft.ForeColor = Color.FromArgb(0, 55, 150);

            dgvPlanchas.Dock = DockStyle.Fill;
            dgvPlanchas.SelectionChanged += dgvPlanchas_SelectionChanged;

            pnlLeft.Controls.Add(dgvPlanchas);
            pnlLeft.Controls.Add(lblLeft);

            // RIGHT CARD
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.BackColor = Color.White;
            pnlRight.Padding = new Padding(15);
            pnlRight.Margin = new Padding(15, 0, 0, 0);

            lblPlancha.Text = "Seleccione una plancha";
            lblPlancha.Dock = DockStyle.Top;
            lblPlancha.Height = 45;
            lblPlancha.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblPlancha.ForeColor = Color.FromArgb(0, 55, 150);

            pnlMiembrosBotones.Dock = DockStyle.Top;
            pnlMiembrosBotones.Height = 60;
            pnlMiembrosBotones.BackColor = Color.White;

            btnAddMiembro.Text = "+ Agregar";
            btnAddMiembro.Size = new Size(130, 38);
            btnAddMiembro.Location = new Point(0, 10);
            btnAddMiembro.BackColor = Color.FromArgb(22, 97, 255);
            btnAddMiembro.ForeColor = Color.White;
            btnAddMiembro.FlatStyle = FlatStyle.Flat;
            btnAddMiembro.FlatAppearance.BorderSize = 0;
            btnAddMiembro.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnAddMiembro.Cursor = Cursors.Hand;
            btnAddMiembro.Click += btnAddMiembro_Click;

            btnQuitarMiembro.Text = "Quitar";
            btnQuitarMiembro.Size = new Size(110, 38);
            btnQuitarMiembro.Location = new Point(145, 10);
            btnQuitarMiembro.BackColor = Color.FromArgb(230, 40, 45);
            btnQuitarMiembro.ForeColor = Color.White;
            btnQuitarMiembro.FlatStyle = FlatStyle.Flat;
            btnQuitarMiembro.FlatAppearance.BorderSize = 0;
            btnQuitarMiembro.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnQuitarMiembro.Cursor = Cursors.Hand;
            btnQuitarMiembro.Click += btnQuitarMiembro_Click;

            pnlMiembrosBotones.Controls.Add(btnAddMiembro);
            pnlMiembrosBotones.Controls.Add(btnQuitarMiembro);

            dgvMiembros.Dock = DockStyle.Fill;

            pnlRight.Controls.Add(dgvMiembros);
            pnlRight.Controls.Add(pnlMiembrosBotones);
            pnlRight.Controls.Add(lblPlancha);

            pnlMain.Controls.Add(pnlRight);
            pnlMain.Controls.Add(pnlLeft);

            Controls.Add(pnlMain);
            Controls.Add(pnlTop);
            Controls.Add(pnlHeader);

            ((System.ComponentModel.ISupportInitialize)dgvPlanchas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMiembros).EndInit();

            ResumeLayout(false);
        }
    }
}