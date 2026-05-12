using System.Drawing;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace SistemaVotacion.UI.Reportes
{
    partial class FrmReporteGeneralVotos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnHoy = new System.Windows.Forms.Button();
            this.btnTodo = new System.Windows.Forms.Button();
            this.lblResumen = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblResultados = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();

            this.panelTop.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();

            // ── panelTop ─────────────────────────────────────────────
            this.panelTop.BackColor = Color.FromArgb(23, 162, 184);
            this.panelTop.Dock = DockStyle.Top;
            this.panelTop.Height = 50;
            this.panelTop.Controls.Add(this.lblTitulo);

            // ── lblTitulo ────────────────────────────────────────────
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.Dock = DockStyle.Fill;
            this.lblTitulo.ForeColor = Color.White;
            this.lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitulo.Text = "📊  Reporte General de Votos";
            this.lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // ── panelFiltros ─────────────────────────────────────────
            this.panelFiltros.BackColor = Color.FromArgb(232, 248, 252);
            this.panelFiltros.Dock = DockStyle.Top;
            this.panelFiltros.Height = 80;
            this.panelFiltros.Controls.AddRange(new Control[]
            {
                this.lblDesde, this.dtpFechaInicio,
                this.lblHasta, this.dtpFechaFin,
                this.btnGenerar, this.btnHoy, this.btnTodo,
                this.lblResumen
            });

            // ── lblDesde  (x=10, y+4=12) ─────────────────────────────
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new Point(10, 12);
            this.lblDesde.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblDesde.Text = "Desde:";

            // ── dtpFechaInicio  (x+56=66, y=8) ───────────────────────
            this.dtpFechaInicio.Location = new Point(66, 8);
            this.dtpFechaInicio.Size = new Size(140, 26);
            this.dtpFechaInicio.Format = DateTimePickerFormat.Short;

            // ── lblHasta  (x+210=220, y+4=12) ────────────────────────
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new Point(220, 12);
            this.lblHasta.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblHasta.Text = "Hasta:";

            // ── dtpFechaFin  (x+263=273, y=8) ────────────────────────
            this.dtpFechaFin.Location = new Point(273, 8);
            this.dtpFechaFin.Size = new Size(140, 26);
            this.dtpFechaFin.Format = DateTimePickerFormat.Short;

            // ── btnGenerar  (x+415=425, y=8) ─────────────────────────
            this.btnGenerar.Size = new Size(110, 28);
            this.btnGenerar.Location = new Point(425, 8);
            this.btnGenerar.Text = "🔍 Generar";
            this.btnGenerar.BackColor = Color.FromArgb(23, 162, 184);
            this.btnGenerar.ForeColor = Color.White;
            this.btnGenerar.FlatStyle = FlatStyle.Flat;
            this.btnGenerar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);

            // ── btnHoy  (x+535=545, y=8) ─────────────────────────────
            this.btnHoy.Size = new Size(80, 28);
            this.btnHoy.Location = new Point(545, 8);
            this.btnHoy.Text = "Hoy";
            this.btnHoy.BackColor = Color.FromArgb(108, 117, 125);
            this.btnHoy.ForeColor = Color.White;
            this.btnHoy.FlatStyle = FlatStyle.Flat;
            this.btnHoy.Font = new Font("Segoe UI", 9F);
            this.btnHoy.Click += new System.EventHandler(this.btnHoy_Click);

            // ── btnTodo  (x+625=635, y=8) ────────────────────────────
            this.btnTodo.Size = new Size(80, 28);
            this.btnTodo.Location = new Point(635, 8);
            this.btnTodo.Text = "Todo";
            this.btnTodo.BackColor = Color.FromArgb(108, 117, 125);
            this.btnTodo.ForeColor = Color.White;
            this.btnTodo.FlatStyle = FlatStyle.Flat;
            this.btnTodo.Font = new Font("Segoe UI", 9F);
            this.btnTodo.Click += new System.EventHandler(this.btnTodo_Click);

            // ── lblResumen ────────────────────────────────────────────
            this.lblResumen.AutoSize = false;
            this.lblResumen.Location = new Point(10, 45);
            this.lblResumen.Size = new Size(900, 20);
            this.lblResumen.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            this.lblResumen.ForeColor = Color.FromArgb(60, 60, 60);
            this.lblResumen.Text = "";

            // ── reportViewer ─────────────────────────────────────────
            this.reportViewer.Dock = DockStyle.Fill;
            this.reportViewer.ZoomMode = ZoomMode.PageWidth;
            this.reportViewer.ShowFindControls = true;
            this.reportViewer.ShowExportButton = true;
            this.reportViewer.ShowPrintButton = true;

            // ── panelBottom ──────────────────────────────────────────
            this.panelBottom.BackColor = Color.WhiteSmoke;
            this.panelBottom.Dock = DockStyle.Bottom;
            this.panelBottom.Height = 40;
            this.panelBottom.Controls.Add(this.lblResultados);
            this.panelBottom.Controls.Add(this.btnCerrar);

            // ── lblResultados ────────────────────────────────────────
            this.lblResultados.AutoSize = false;
            this.lblResultados.Location = new Point(10, 10);
            this.lblResultados.Size = new Size(700, 20);
            this.lblResultados.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            this.lblResultados.ForeColor = Color.Gray;
            this.lblResultados.Text = "";

            // ── btnCerrar ────────────────────────────────────────────
            this.btnCerrar.Size = new Size(100, 28);
            this.btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnCerrar.Location = new Point(935, 6);
            this.btnCerrar.Text = "✕  Cerrar";
            this.btnCerrar.BackColor = Color.FromArgb(220, 53, 69);
            this.btnCerrar.ForeColor = Color.White;
            this.btnCerrar.FlatStyle = FlatStyle.Flat;
            this.btnCerrar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // ── Form ─────────────────────────────────────────────────
            this.ClientSize = new Size(1050, 700);
            this.MinimumSize = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.WindowState = FormWindowState.Maximized;
            this.Icon = System.Drawing.SystemIcons.Information;
            this.Name = "FrmReporteGeneralVotos";
            this.Load += new System.EventHandler(this.FrmReporteGeneralVotos_Load);

            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);

            this.panelTop.ResumeLayout(false);
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        // ── Declaración de controles ──────────────────────────────────
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.Label lblResumen;
        private System.Windows.Forms.Label lblResultados;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnHoy;
        private System.Windows.Forms.Button btnTodo;
        private System.Windows.Forms.Button btnCerrar;
    }
}