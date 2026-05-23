using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    partial class Usuarios
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Panel pnlTop;

        private Label lblTitulo;
        private Label lblSubtitulo;
        private Label lblBuscar;

        private Button btnNuevo;
        private Button btnEditar;
        private Button btnEliminar;
        private Label lblIcono;
        private TextBox txtBuscar;

        private DataGridView dgv;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            lblIcono = new Label();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            pnlTop = new Panel();
            btnNuevo = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            dgv = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            pnlHeader.SuspendLayout();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblIcono);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Controls.Add(lblSubtitulo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(25, 25);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(25, 15, 25, 15);
            pnlHeader.Size = new Size(1050, 120);
            pnlHeader.TabIndex = 2;
            // 
            // lblIcono
            // 
            lblIcono.Text = "●";
            lblIcono.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblIcono.ForeColor = Color.FromArgb(22, 97, 255);   // AzulClaro
            lblIcono.Location = new Point(20, 10);
            lblIcono.Name = "lblIcono";
            lblIcono.Size = new Size(40, 55);
            lblIcono.TabIndex = 0;

            // 
            // lblTitulo
            // 
            lblTitulo.Text = "Gestión de Usuarios";
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 55, 150);   // Azul
            lblTitulo.Location = new Point(65, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(500, 42);
            lblTitulo.TabIndex = 1;

            // 
            // lblSubtitulo
            // 
            lblSubtitulo.Text = "Administra los usuarios del sistema electoral estudiantil";
            lblSubtitulo.Font = new Font("Segoe UI", 10.5F);
            lblSubtitulo.ForeColor = Color.FromArgb(80, 90, 115);   // TextoSuave
            lblSubtitulo.Location = new Point(30, 65);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(700, 28);
            lblSubtitulo.TabIndex = 2;
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(btnNuevo);
            pnlTop.Controls.Add(btnEditar);
            pnlTop.Controls.Add(btnEliminar);
            pnlTop.Controls.Add(lblBuscar);
            pnlTop.Controls.Add(txtBuscar);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(25, 145);
            pnlTop.Name = "pnlTop";
            pnlTop.Padding = new Padding(0, 15, 0, 15);
            pnlTop.Size = new Size(1050, 82);
            pnlTop.TabIndex = 1;
            // 
            // btnNuevo
            // 
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(0, 18);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(160, 42);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "+ Nuevo Usuario";
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnEditar
            // 
            btnEditar.Cursor = Cursors.Hand;
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(175, 18);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(100, 42);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "Editar";
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(290, 18);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(120, 42);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Desactivar";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // lblBuscar
            // 
            lblBuscar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblBuscar.Location = new Point(462, 28);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(70, 25);
            lblBuscar.TabIndex = 3;
            lblBuscar.Text = "Buscar:";
            // txtBuscar
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Font = new Font("Segoe UI", 10F);
            txtBuscar.Location = new Point(538, 23);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(280, 30);
            txtBuscar.TabIndex = 4;

            // dgv
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;

            dgv.BackgroundColor = Color.White;
            dgv.GridColor = Color.FromArgb(220, 225, 235);

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight = 50;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgv.RowHeadersVisible = false;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv.Font = new Font("Segoe UI", 10F);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10F);

            dgv.Location = new Point(25, 227);
            dgv.Name = "dgv";
            dgv.Size = new Size(1050, 448);
            dgv.Dock = DockStyle.Fill;

            //
            // HEADER STYLE
            //
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(22, 97, 255);     // AzulClaro
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(22, 97, 255);    // AzulClaro
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;

            dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;

            //
            // FILAS NORMALES
            //
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(10, 35, 90);      // Texto
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(230, 240, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(10, 35, 90);     // Texto
            dataGridViewCellStyle3.Padding = new Padding(5, 0, 5, 0);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);

            dgv.DefaultCellStyle = dataGridViewCellStyle3;

            //
            // FILAS ALTERNAS
            //
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 255);

            dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;

            //
            // ROW STYLE
            //
            dgv.RowsDefaultCellStyle.BackColor = Color.White;
            dgv.RowsDefaultCellStyle.ForeColor = Color.FromArgb(10, 35, 90);    // Texto
            dgv.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 240, 255);
            dgv.RowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(10, 35, 90);   // Texto

            dgv.RowTemplate.Height = 40;

            //
            // COLUMNAS
            //
            dgv.Columns.AddRange(new DataGridViewColumn[]
            {
                dataGridViewTextBoxColumn1,
                dataGridViewTextBoxColumn2,
                dataGridViewTextBoxColumn3,
                dataGridViewTextBoxColumn4,
                dataGridViewTextBoxColumn5,
                dataGridViewTextBoxColumn6,
                dataGridViewTextBoxColumn7,
                dataGridViewTextBoxColumn8,
                dataGridViewCheckBoxColumn1
            });
            // 
            // Usuarios
            // 
            AutoScroll = true;
            ClientSize = new Size(1100, 700);
            Controls.Add(dgv);
            Controls.Add(pnlTop);
            Controls.Add(pnlHeader);
            Name = "Usuarios";
            Padding = new Padding(25);
            Text = "Usuarios";
            pnlHeader.ResumeLayout(false);
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
        }

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
    }
}