namespace SistemaVotacion.UI.Reportes
{
    partial class FrmReportePlanchaGanadora
    {
        private System.ComponentModel.IContainer components = null;

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnVolver; // 🔥 NUEVO

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();

            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();

            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();

            // FORM
            this.ClientSize = new System.Drawing.Size(1050, 700);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Text = "Reporte – Plancha Ganadora";
            this.Load += new System.EventHandler(this.FrmReportePlanchaGanadora_Load);

            // REPORT VIEWER
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;

            // TOP
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 50;
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.panelTop.Controls.Add(this.lblTitulo);

            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Text = "🏆 Reporte – Plancha Ganadora";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // BOTTOM
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Height = 50;

            // ACTUALIZAR
            this.btnActualizar.Text = "↺ Actualizar";
            this.btnActualizar.Size = new System.Drawing.Size(120, 32);
            this.btnActualizar.Location = new System.Drawing.Point(10, 9);
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

            // VOLVER
            this.btnVolver.Text = "↩ Volver";
            this.btnVolver.Size = new System.Drawing.Size(100, 32);
            this.btnVolver.Location = new System.Drawing.Point(140, 9);
            this.btnVolver.BackColor = System.Drawing.Color.Gray;
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);

            // CERRAR
            this.btnCerrar.Text = "✕ Cerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 32);
            this.btnCerrar.Location = new System.Drawing.Point(250, 9);
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            this.panelBottom.Controls.Add(this.btnActualizar);
            this.panelBottom.Controls.Add(this.btnVolver);
            this.panelBottom.Controls.Add(this.btnCerrar);

            // ADD CONTROLS
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);

            this.panelTop.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}