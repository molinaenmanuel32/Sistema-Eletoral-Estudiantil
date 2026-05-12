using System.Drawing;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace SistemaVotacion.UI.Reportes
{
    partial class FrmReporteListadoParticipantes
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
            this.lblEstadoLbl = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.lblCursoLbl = new System.Windows.Forms.Label();
            this.cboCurso = new System.Windows.Forms.ComboBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnLimpiarFiltros = new System.Windows.Forms.Button();
            this.lblResumen = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblResultados = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();

            this.panelTop.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();

            // ── panelTop ─────────────────────────────────────────────
            this.panelTop.BackColor = Color.FromArgb(40, 167, 69);
            this.panelTop.Dock = DockStyle.Top;
            this.panelTop.Height = 50;
            this.panelTop.Controls.Add(this.lblTitulo);

            // ── lblTitulo ────────────────────────────────────────────
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.Dock = DockStyle.Fill;
            this.lblTitulo.ForeColor = Color.White;
            this.lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitulo.Text = "📋  Reporte – Listado de Participantes";
            this.lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // ── panelFiltros ─────────────────────────────────────────
            this.panelFiltros.BackColor = Color.FromArgb(236, 252, 240);
            this.panelFiltros.Dock = DockStyle.Top;
            this.panelFiltros.Height = 82;
            this.panelFiltros.Controls.AddRange(new Control[]
            {
                this.lblEstadoLbl, this.cboEstado,
                this.lblCursoLbl,  this.cboCurso,
                this.btnGenerar,   this.btnLimpiarFiltros,
                this.lblResumen
            });

            // ── lblEstadoLbl  (y=8 → y+4=12) ─────────────────────────
            this.lblEstadoLbl.AutoSize = true;
            this.lblEstadoLbl.Location = new Point(10, 12);
            this.lblEstadoLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblEstadoLbl.Text = "Estado:";

            // ── cboEstado  (y=8) ──────────────────────────────────────
            this.cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboEstado.Location = new Point(68, 8);
            this.cboEstado.Size = new Size(130, 26);
            this.cboEstado.Font = new Font("Segoe UI", 9F);
            this.cboEstado.Items.AddRange(new object[] { "Todos", "Votó", "Pendiente" });
            this.cboEstado.SelectedIndex = 0;

            // ── lblCursoLbl  (y+4=12) ────────────────────────────────
            this.lblCursoLbl.AutoSize = true;
            this.lblCursoLbl.Location = new Point(212, 12);
            this.lblCursoLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblCursoLbl.Text = "Curso:";

            // ── cboCurso  (y=8) ───────────────────────────────────────
            this.cboCurso.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboCurso.Location = new Point(258, 8);
            this.cboCurso.Size = new Size(200, 26);
            this.cboCurso.Font = new Font("Segoe UI", 9F);

            // ── btnGenerar  (y=8) ─────────────────────────────────────
            this.btnGenerar.Size = new Size(110, 28);
            this.btnGenerar.Location = new Point(472, 8);
            this.btnGenerar.Text = "🔍 Ver Reporte";
            this.btnGenerar.BackColor = Color.FromArgb(40, 167, 69);
            this.btnGenerar.ForeColor = Color.White;
            this.btnGenerar.FlatStyle = FlatStyle.Flat;
            this.btnGenerar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);

            // ── btnLimpiarFiltros  (y=8) ──────────────────────────────
            this.btnLimpiarFiltros.Size = new Size(120, 28);
            this.btnLimpiarFiltros.Location = new Point(592, 8);
            this.btnLimpiarFiltros.Text = "↩ Quitar filtros";
            this.btnLimpiarFiltros.BackColor = Color.FromArgb(108, 117, 125);
            this.btnLimpiarFiltros.ForeColor = Color.White;
            this.btnLimpiarFiltros.FlatStyle = FlatStyle.Flat;
            this.btnLimpiarFiltros.Font = new Font("Segoe UI", 9F);
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click);

            // ── lblResumen (fila 2) ───────────────────────────────────
            this.lblResumen.AutoSize = false;
            this.lblResumen.Location = new Point(10, 48);
            this.lblResumen.Size = new Size(900, 20);
            this.lblResumen.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            this.lblResumen.ForeColor = Color.FromArgb(50, 50, 50);
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
            this.lblResultados.Size = new Size(800, 20);
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
            this.Name = "FrmReporteListadoParticipantes";
            this.Load += new System.EventHandler(this.FrmReporteListadoParticipantes_Load);

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
        private System.Windows.Forms.Label lblEstadoLbl;
        private System.Windows.Forms.Label lblCursoLbl;
        private System.Windows.Forms.Label lblResumen;
        private System.Windows.Forms.Label lblResultados;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.ComboBox cboCurso;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.Button btnCerrar;
    }
}