using System.Drawing;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace SistemaVotacion.UI.Forms.ReportesFRM
{
    partial class Frmreportegeneralvotosadmincs
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
            // ── Instancias ────────────────────────────────────────────
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

            // ── panelTop (azul marino, altura 56) ─────────────────────
            this.panelTop.BackColor = Color.FromArgb(0, 55, 150);
            this.panelTop.Dock = DockStyle.Top;
            this.panelTop.Height = 56;
            this.panelTop.Controls.Add(this.lblTitulo);

            // ── lblTitulo ─────────────────────────────────────────────
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.Dock = DockStyle.Fill;
            this.lblTitulo.ForeColor = Color.White;
            this.lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            this.lblTitulo.Text = "📊   Reporte General de Votos";
            this.lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // ── panelFiltros (gris muy claro, altura 90) ──────────────
            this.panelFiltros.BackColor = Color.FromArgb(241, 243, 249);
            this.panelFiltros.Dock = DockStyle.Top;
            this.panelFiltros.Height = 90;
            this.panelFiltros.Controls.AddRange(new Control[]
            {
                this.lblDesde, this.dtpFechaInicio,
                this.lblHasta, this.dtpFechaFin,
                this.btnGenerar, this.btnHoy, this.btnTodo,
                this.lblResumen
            });

            // ── Fila de filtros  (y = 16) ─────────────────────────────
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new Point(14, 20);
            this.lblDesde.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblDesde.Text = "Desde:";

            this.dtpFechaInicio.Location = new Point(72, 16);
            this.dtpFechaInicio.Size = new Size(148, 26);
            this.dtpFechaInicio.Format = DateTimePickerFormat.Short;

            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new Point(234, 20);
            this.lblHasta.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblHasta.Text = "Hasta:";

            this.dtpFechaFin.Location = new Point(290, 16);
            this.dtpFechaFin.Size = new Size(148, 26);
            this.dtpFechaFin.Format = DateTimePickerFormat.Short;

            // btnGenerar
            this.btnGenerar.Size = new Size(120, 30);
            this.btnGenerar.Location = new Point(452, 14);
            this.btnGenerar.Text = "🔍  Generar";
            this.btnGenerar.BackColor = Color.FromArgb(22, 97, 255);
            this.btnGenerar.ForeColor = Color.White;
            this.btnGenerar.FlatStyle = FlatStyle.Flat;
            this.btnGenerar.FlatAppearance.BorderSize = 0;
            this.btnGenerar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnGenerar.Cursor = Cursors.Hand;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);

            // btnHoy
            this.btnHoy.Size = new Size(80, 30);
            this.btnHoy.Location = new Point(582, 14);
            this.btnHoy.Text = "Hoy";
            this.btnHoy.BackColor = Color.FromArgb(108, 117, 125);
            this.btnHoy.ForeColor = Color.White;
            this.btnHoy.FlatStyle = FlatStyle.Flat;
            this.btnHoy.FlatAppearance.BorderSize = 0;
            this.btnHoy.Font = new Font("Segoe UI", 9F);
            this.btnHoy.Cursor = Cursors.Hand;
            this.btnHoy.Click += new System.EventHandler(this.btnHoy_Click);

            // btnTodo
            this.btnTodo.Size = new Size(80, 30);
            this.btnTodo.Location = new Point(670, 14);
            this.btnTodo.Text = "Todo";
            this.btnTodo.BackColor = Color.FromArgb(108, 117, 125);
            this.btnTodo.ForeColor = Color.White;
            this.btnTodo.FlatStyle = FlatStyle.Flat;
            this.btnTodo.FlatAppearance.BorderSize = 0;
            this.btnTodo.Font = new Font("Segoe UI", 9F);
            this.btnTodo.Cursor = Cursors.Hand;
            this.btnTodo.Click += new System.EventHandler(this.btnTodo_Click);

            // ── lblResumen (segunda fila, y=54) ───────────────────────
            this.lblResumen.AutoSize = false;
            this.lblResumen.Location = new Point(14, 54);
            this.lblResumen.Size = new Size(1000, 22);
            this.lblResumen.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            this.lblResumen.ForeColor = Color.FromArgb(70, 70, 70);
            this.lblResumen.Text = "";

            // ── reportViewer (ocupa todo el espacio restante) ─────────
            this.reportViewer.Dock = DockStyle.Fill;
            this.reportViewer.ZoomMode = ZoomMode.PageWidth;
            this.reportViewer.ShowFindControls = true;
            this.reportViewer.ShowExportButton = true;
            this.reportViewer.ShowPrintButton = true;
            this.reportViewer.BackColor = Color.White;

            // ── panelBottom ───────────────────────────────────────────
            this.panelBottom.BackColor = Color.FromArgb(241, 243, 249);
            this.panelBottom.Dock = DockStyle.Bottom;
            this.panelBottom.Height = 44;
            this.panelBottom.Controls.Add(this.lblResultados);
            this.panelBottom.Controls.Add(this.btnCerrar);

            // lblResultados
            this.lblResultados.AutoSize = false;
            this.lblResultados.Location = new Point(14, 13);
            this.lblResultados.Size = new Size(750, 20);
            this.lblResultados.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            this.lblResultados.ForeColor = Color.FromArgb(100, 100, 100);
            this.lblResultados.Text = "";

            // btnCerrar
            this.btnCerrar.Size = new Size(110, 30);
            this.btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnCerrar.Location = new Point(960, 7);
            this.btnCerrar.Text = "✕   Cerrar";
            this.btnCerrar.BackColor = Color.FromArgb(220, 53, 69);
            this.btnCerrar.ForeColor = Color.White;
            this.btnCerrar.FlatStyle = FlatStyle.Flat;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnCerrar.Cursor = Cursors.Hand;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // ── Form ──────────────────────────────────────────────────
            this.ClientSize = new Size(1100, 720);
            this.MinimumSize = new Size(850, 520);
            this.StartPosition = FormStartPosition.CenterParent;
            this.WindowState = FormWindowState.Maximized;
            this.Icon = System.Drawing.SystemIcons.Information;
            this.Name = "Frmreportegeneralvotosadmincs";
            this.Text = "Reporte General de Votos";
            this.BackColor = Color.White;
            this.Load += new System.EventHandler(
                                       this.Frmreportegeneralvotosadmincs_Load);

            // Orden de controles (bottom → fill → top = correcto en WinForms)
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