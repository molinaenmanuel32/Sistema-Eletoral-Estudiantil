using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace SistemaVotacion.UI.Reportes
{
    partial class FrmReportePlanchaGanadora
    {
        private ReportViewer reportViewer;
        private Panel panelTop;
        private Panel panelBottom;
        private Label lblTitulo;
        private Button btnActualizar;
        private Button btnCerrar;

        private void InitializeComponent()
        {
            this.reportViewer = new ReportViewer();
            this.panelTop = new Panel();
            this.panelBottom = new Panel();
            this.lblTitulo = new Label();
            this.btnActualizar = new Button();
            this.btnCerrar = new Button();

            // ── panelTop ─────────────────────────────
            this.panelTop.BackColor = Color.FromArgb(0, 123, 255);
            this.panelTop.Dock = DockStyle.Top;
            this.panelTop.Height = 50;

            // ── lblTitulo ────────────────────────────
            this.lblTitulo.Dock = DockStyle.Fill;
            this.lblTitulo.ForeColor = Color.White;
            this.lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitulo.Text = "🏆 Reporte – Plancha Ganadora";
            this.lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            this.panelTop.Controls.Add(this.lblTitulo);

            // ── reportViewer ─────────────────────────
            this.reportViewer.Dock = DockStyle.Fill;
            this.reportViewer.ZoomMode = ZoomMode.PageWidth;
            this.reportViewer.ShowFindControls = true;
            this.reportViewer.ShowExportButton = true;
            this.reportViewer.ShowPrintButton = true;

            // ── panelBottom ──────────────────────────
            this.panelBottom.BackColor = Color.WhiteSmoke;
            this.panelBottom.Dock = DockStyle.Bottom;
            this.panelBottom.Height = 50;

            // ── btnActualizar ────────────────────────
            this.btnActualizar.Text = "↺ Actualizar";
            this.btnActualizar.Size = new Size(130, 32);
            this.btnActualizar.Location = new Point(10, 9);
            this.btnActualizar.BackColor = Color.FromArgb(40, 167, 69);
            this.btnActualizar.ForeColor = Color.White;
            this.btnActualizar.FlatStyle = FlatStyle.Flat;
            this.btnActualizar.Click += new EventHandler(this.btnActualizar_Click);

            // ── btnCerrar ────────────────────────────
            this.btnCerrar.Text = "✕ Cerrar";
            this.btnCerrar.Size = new Size(100, 32);
            this.btnCerrar.Location = new Point(150, 9);
            this.btnCerrar.BackColor = Color.FromArgb(220, 53, 69);
            this.btnCerrar.ForeColor = Color.White;
            this.btnCerrar.FlatStyle = FlatStyle.Flat;
            this.btnCerrar.Click += new EventHandler(this.btnCerrar_Click);

            this.panelBottom.Controls.Add(this.btnActualizar);
            this.panelBottom.Controls.Add(this.btnCerrar);

            // ── Form ────────────────────────────────
            this.ClientSize = new Size(1050, 700);
            this.StartPosition = FormStartPosition.CenterParent;
            this.WindowState = FormWindowState.Maximized;
            this.Icon = SystemIcons.Information;
            this.Text = "Reporte – Plancha Ganadora";

            this.Load += new EventHandler(this.FrmReportePlanchaGanadora_Load);

            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
        }
    }
}