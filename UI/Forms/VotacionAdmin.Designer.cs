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
<<<<<<< HEAD
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblIcono = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnNueva = new System.Windows.Forms.Button();
            this.btnActivar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblIcono);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(25, 25);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1050, 120);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblIcono
            // 
            this.lblIcono.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblIcono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(97)))), ((int)(((byte)(255)))));
            this.lblIcono.Location = new System.Drawing.Point(20, 10);
            this.lblIcono.Name = "lblIcono";
            this.lblIcono.Size = new System.Drawing.Size(40, 55);
            this.lblIcono.TabIndex = 0;
            this.lblIcono.Text = "●";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(55)))), ((int)(((byte)(150)))));
            this.lblTitulo.Location = new System.Drawing.Point(60, 16);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(600, 42);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Gestión de Votaciones";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(90)))), ((int)(((byte)(115)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(25, 65);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(700, 28);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Administra las votaciones del sistema electoral estudiantil";
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.pnlTop.Controls.Add(this.btnNueva);
            this.pnlTop.Controls.Add(this.btnActivar);
            this.pnlTop.Controls.Add(this.btnCerrar);
            this.pnlTop.Controls.Add(this.lblEstado);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(25, 145);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1050, 90);
            this.pnlTop.TabIndex = 1;
            // 
            // btnNueva
            // 
            this.btnNueva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNueva.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnNueva.Location = new System.Drawing.Point(0, 20);
            this.btnNueva.Name = "btnNueva";
            this.btnNueva.Size = new System.Drawing.Size(180, 42);
            this.btnNueva.TabIndex = 0;
            this.btnNueva.Text = "+ Nueva Votación";
            // 
            // btnActivar
            // 
            this.btnActivar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActivar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnActivar.Location = new System.Drawing.Point(195, 20);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.Size = new System.Drawing.Size(120, 42);
            this.btnActivar.TabIndex = 1;
            this.btnActivar.Text = "Activar";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.Location = new System.Drawing.Point(330, 20);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(120, 42);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            // 
            // lblEstado
            // 
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(55)))), ((int)(((byte)(150)))));
            this.lblEstado.Location = new System.Drawing.Point(480, 30);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(500, 25);
            this.lblEstado.TabIndex = 3;
            this.lblEstado.Text = "Sin votación activa";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeight = 42;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgv.Location = new System.Drawing.Point(25, 235);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 36;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1050, 440);
            this.dgv.TabIndex = 0;
            // 
            // VotacionAdmin
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlHeader);
            this.Name = "VotacionAdmin";
            this.Padding = new System.Windows.Forms.Padding(25);
            this.Text = "Votación Admin";
            this.Load += new System.EventHandler(this.VotacionAdmin_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

=======
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
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
        }
    }
}