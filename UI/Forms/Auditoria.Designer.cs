// ============================
// Auditoria.Designer.cs
// ============================

using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    partial class Auditoria
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Panel pnlBody;
        private Panel pnlCard;
        private Panel pnlTop;

        private Label lblTitulo;
        private Label lblSubtitulo;
        private Label lblTotal;
        private Label lblBuscar;

        private TextBox txtBuscar;

        private Button btnActualizar;

        private DataGridView dgvAuditoria;

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

            this.pnlHeader = new Panel();
            this.lblTitulo = new Label();
            this.lblSubtitulo = new Label();

            this.pnlBody = new Panel();
            this.pnlCard = new Panel();

            this.dgvAuditoria = new DataGridView();

            this.pnlTop = new Panel();
            this.lblTotal = new Label();
            this.lblBuscar = new Label();

            this.txtBuscar = new TextBox();

            this.btnActualizar = new Button();

            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoria)).BeginInit();
            this.pnlTop.SuspendLayout();

            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = Color.White;
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new Padding(25);
            this.pnlHeader.Size = new Size(1190, 120);

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.FromArgb(0, 60, 170);
            this.lblTitulo.Location = new Point(32, 22);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(237, 54);
            this.lblTitulo.Text = "●  Auditoría";

            // lblSubtitulo
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new Font("Segoe UI", 11F);
            this.lblSubtitulo.ForeColor = Color.FromArgb(80, 85, 100);
            this.lblSubtitulo.Location = new Point(38, 74);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new Size(626, 25);
            this.lblSubtitulo.Text = "Supervisa accesos, movimientos y acciones realizadas dentro del sistema.";

            // pnlBody
            this.pnlBody.BackColor = Color.FromArgb(243, 245, 250);
            this.pnlBody.Controls.Add(this.pnlCard);
            this.pnlBody.Dock = DockStyle.Fill;
            this.pnlBody.Location = new Point(0, 120);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new Padding(25);
            this.pnlBody.Size = new Size(1190, 648);

            // pnlCard
            this.pnlCard.BackColor = Color.White;
            this.pnlCard.Controls.Add(this.dgvAuditoria);
            this.pnlCard.Controls.Add(this.pnlTop);
            this.pnlCard.Dock = DockStyle.Fill;
            this.pnlCard.Location = new Point(25, 25);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new Size(1140, 598);

            // dgvAuditoria
            this.dgvAuditoria.AllowUserToAddRows = false;
            this.dgvAuditoria.AllowUserToDeleteRows = false;

            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 255);
            this.dgvAuditoria.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;

            this.dgvAuditoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAuditoria.BackgroundColor = Color.White;
            this.dgvAuditoria.BorderStyle = BorderStyle.None;

            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(0, 51, 153);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;

            this.dgvAuditoria.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAuditoria.ColumnHeadersHeight = 42;

            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(35, 40, 55);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(37, 99, 235);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;

            this.dgvAuditoria.DefaultCellStyle = dataGridViewCellStyle3;

            this.dgvAuditoria.Dock = DockStyle.Fill;
            this.dgvAuditoria.EnableHeadersVisualStyles = false;
            this.dgvAuditoria.Font = new Font("Segoe UI", 10F);
            this.dgvAuditoria.GridColor = Color.FromArgb(225, 230, 240);
            this.dgvAuditoria.Location = new Point(0, 110);
            this.dgvAuditoria.MultiSelect = false;
            this.dgvAuditoria.Name = "dgvAuditoria";
            this.dgvAuditoria.ReadOnly = true;
            this.dgvAuditoria.RowHeadersVisible = false;
            this.dgvAuditoria.RowTemplate.Height = 36;
            this.dgvAuditoria.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvAuditoria.Size = new Size(1140, 488);

            // pnlTop
            this.pnlTop.BackColor = Color.FromArgb(0, 51, 153);
            this.pnlTop.Controls.Add(this.lblTotal);
            this.pnlTop.Controls.Add(this.lblBuscar);
            this.pnlTop.Controls.Add(this.txtBuscar);
            this.pnlTop.Controls.Add(this.btnActualizar);
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Location = new Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new Size(1140, 110);

            // lblTotal
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            this.lblTotal.ForeColor = Color.White;
            this.lblTotal.Location = new Point(28, 18);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new Size(286, 41);
            this.lblTotal.Text = "Total de registros: 0";

            // lblBuscar
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.lblBuscar.ForeColor = Color.White;
            this.lblBuscar.Location = new Point(32, 72);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new Size(65, 23);
            this.lblBuscar.Text = "Buscar:";

            // txtBuscar
            this.txtBuscar.BackColor = Color.White;
            this.txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            this.txtBuscar.Font = new Font("Segoe UI", 10F);
            this.txtBuscar.Location = new Point(102, 66);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new Size(320, 30);

            // btnActualizar
            this.btnActualizar.BackColor = Color.FromArgb(37, 99, 235);
            this.btnActualizar.Cursor = Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = FlatStyle.Flat;
            this.btnActualizar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.btnActualizar.ForeColor = Color.White;
            this.btnActualizar.Location = new Point(760, 30);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new Size(140, 42);
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

            // Auditoria
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(243, 245, 250);
            this.ClientSize = new Size(1190, 768);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "Auditoria";
            this.Text = "Auditoría";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();

            this.pnlBody.ResumeLayout(false);

            this.pnlCard.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoria)).EndInit();

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();

            this.ResumeLayout(false);
        }
    }
}