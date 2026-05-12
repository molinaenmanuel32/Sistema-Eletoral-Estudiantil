namespace SistemaVotacion.UI.Reportes
{
    partial class FrmReporteIntegrantesPlancha
    {
        private System.ComponentModel.IContainer components = null;

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelBtnCerrar;

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblPlancha;
        private System.Windows.Forms.Label lblInfo;

        private System.Windows.Forms.ComboBox cboPlanchas;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnVolver;

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
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelBtnCerrar = new System.Windows.Forms.Panel();

            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblPlancha = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();

            this.cboPlanchas = new System.Windows.Forms.ComboBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();

            this.panelTop.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelBtnCerrar.SuspendLayout();
            this.SuspendLayout();

            // FORM
            this.ClientSize = new System.Drawing.Size(1050, 700);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Text = "Reporte – Integrantes de Plancha";
            this.Load += new System.EventHandler(this.FrmReporteIntegrantesPlancha_Load);

            // TOP
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 50;
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(111, 66, 193);

            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Text = "👥 Reporte – Integrantes de Plancha";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.panelTop.Controls.Add(this.lblTitulo);

            // FILTROS
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltros.Height = 55;

            this.lblPlancha.Text = "Plancha:";
            this.lblPlancha.Location = new System.Drawing.Point(12, 18);

            this.cboPlanchas.Location = new System.Drawing.Point(80, 14);
            this.cboPlanchas.Size = new System.Drawing.Size(280, 25);
            this.cboPlanchas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlanchas.SelectedIndexChanged += new System.EventHandler(this.cboPlanchas_SelectedIndexChanged);

            this.btnActualizar.Text = "↺ Ver Reporte";
            this.btnActualizar.Location = new System.Drawing.Point(380, 12);
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

            this.panelFiltros.Controls.Add(this.lblPlancha);
            this.panelFiltros.Controls.Add(this.cboPlanchas);
            this.panelFiltros.Controls.Add(this.btnActualizar);

            // REPORT VIEWER
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;

            // BOTTOM
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Height = 45;

            this.lblInfo.Location = new System.Drawing.Point(10, 12);
            this.lblInfo.Size = new System.Drawing.Size(600, 20);

            this.panelBtnCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelBtnCerrar.Width = 260;

            // VOLVER
            this.btnVolver.Text = "↩ Volver";
            this.btnVolver.Size = new System.Drawing.Size(90, 32);
            this.btnVolver.Location = new System.Drawing.Point(0, 6);
            this.btnVolver.BackColor = System.Drawing.Color.Gray;
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);

            // CERRAR
            this.btnCerrar.Text = "✕ Cerrar";
            this.btnCerrar.Size = new System.Drawing.Size(90, 32);
            this.btnCerrar.Location = new System.Drawing.Point(100, 6);
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            this.panelBtnCerrar.Controls.Add(this.btnVolver);
            this.panelBtnCerrar.Controls.Add(this.btnCerrar);

            this.panelBottom.Controls.Add(this.lblInfo);
            this.panelBottom.Controls.Add(this.panelBtnCerrar);

            // ADD CONTROLS
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);

            this.panelTop.ResumeLayout(false);
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBtnCerrar.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}