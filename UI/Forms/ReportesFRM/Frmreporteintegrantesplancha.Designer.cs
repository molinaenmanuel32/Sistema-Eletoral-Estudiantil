using System.Drawing;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace SistemaVotacion.UI.Reportes
{
    partial class FrmReporteIntegrantesPlancha
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
            this.lblPlancha = new System.Windows.Forms.Label();
            this.cboPlanchas = new System.Windows.Forms.ComboBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();

            this.panelTop.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();

            // ── panelTop ─────────────────────────────────────────────
            this.panelTop.BackColor = Color.FromArgb(111, 66, 193);
            this.panelTop.Dock = DockStyle.Top;
            this.panelTop.Height = 50;
            this.panelTop.Controls.Add(this.lblTitulo);

            // ── lblTitulo ────────────────────────────────────────────
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.Dock = DockStyle.Fill;
            this.lblTitulo.ForeColor = Color.White;
            this.lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitulo.Text = "👥  Reporte – Integrantes de Plancha";
            this.lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // ── panelFiltros ─────────────────────────────────────────
            this.panelFiltros.BackColor = Color.FromArgb(240, 240, 240);
            this.panelFiltros.Dock = DockStyle.Top;
            this.panelFiltros.Height = 55;
            this.panelFiltros.Controls.Add(this.btnActualizar);
            this.panelFiltros.Controls.Add(this.cboPlanchas);
            this.panelFiltros.Controls.Add(this.lblPlancha);

            // ── lblPlancha ───────────────────────────────────────────
            this.lblPlancha.AutoSize = true;
            this.lblPlancha.Location = new Point(12, 18);
            this.lblPlancha.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblPlancha.Text = "Plancha:";

            // ── cboPlanchas ──────────────────────────────────────────
            this.cboPlanchas.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboPlanchas.Location = new Point(80, 14);
            this.cboPlanchas.Size = new Size(280, 26);
            this.cboPlanchas.Font = new Font("Segoe UI", 9F);
            this.cboPlanchas.SelectedIndexChanged += new System.EventHandler(this.cboPlanchas_SelectedIndexChanged);

            // ── btnActualizar ────────────────────────────────────────
            this.btnActualizar.Size = new Size(120, 30);
            this.btnActualizar.Location = new Point(375, 12);
            this.btnActualizar.Text = "↺  Ver Reporte";
            this.btnActualizar.BackColor = Color.FromArgb(111, 66, 193);
            this.btnActualizar.ForeColor = Color.White;
            this.btnActualizar.FlatStyle = FlatStyle.Flat;
            this.btnActualizar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

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
            this.panelBottom.Controls.Add(this.btnCerrar);
            this.panelBottom.Controls.Add(this.lblInfo);

            // ── lblInfo ──────────────────────────────────────────────
            this.lblInfo.AutoSize = false;
            this.lblInfo.Location = new Point(10, 10);
            this.lblInfo.Size = new Size(700, 20);
            this.lblInfo.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            this.lblInfo.ForeColor = Color.Gray;
            this.lblInfo.Text = "";

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
            this.Name = "FrmReporteIntegrantesPlancha";
            this.Load += new System.EventHandler(this.FrmReporteIntegrantesPlancha_Load);

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
        private System.Windows.Forms.Label lblPlancha;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ComboBox cboPlanchas;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnCerrar;
    }
}