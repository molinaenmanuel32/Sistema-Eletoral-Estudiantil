using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    partial class FrmReportesPartido
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlCard;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Label lblInfo;
        private Button btnReporteMiembros;
        private Button btnReporteVotos;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlCard = new Panel();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            lblInfo = new Label();
            btnReporteMiembros = new Button();
            btnReporteVotos = new Button();

            SuspendLayout();

            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(242, 245, 251);
            ClientSize = new Size(950, 620);

            pnlCard.BackColor = Color.White;
            pnlCard.Location = new Point(35, 35);
            pnlCard.Size = new Size(870, 230);

            lblTitulo.Text = "Reportes de mi Plancha";
            lblTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 45, 120);
            lblTitulo.Location = new Point(35, 30);
            lblTitulo.Size = new Size(600, 45);

            lblSubtitulo.Text = "Consulta los reportes relacionados únicamente con tu plancha.";
            lblSubtitulo.Font = new Font("Segoe UI", 13F);
            lblSubtitulo.ForeColor = Color.FromArgb(70, 80, 110);
            lblSubtitulo.Location = new Point(38, 85);
            lblSubtitulo.Size = new Size(700, 30);

            lblInfo.Text = "Reportes disponibles para la plancha";
            lblInfo.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            lblInfo.ForeColor = Color.FromArgb(20, 110, 220);
            lblInfo.Location = new Point(38, 120);
            lblInfo.Size = new Size(700, 28);

            btnReporteMiembros.Text = "Reporte de Miembros";
            btnReporteMiembros.BackColor = Color.FromArgb(20, 110, 220);
            btnReporteMiembros.ForeColor = Color.White;
            btnReporteMiembros.FlatStyle = FlatStyle.Flat;
            btnReporteMiembros.FlatAppearance.BorderSize = 0;
            btnReporteMiembros.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnReporteMiembros.Location = new Point(40, 165);
            btnReporteMiembros.Size = new Size(210, 42);
            btnReporteMiembros.Cursor = Cursors.Hand;

            btnReporteVotos.Text = "Reporte de Votos";
            btnReporteVotos.BackColor = Color.FromArgb(8, 48, 112);
            btnReporteVotos.ForeColor = Color.White;
            btnReporteVotos.FlatStyle = FlatStyle.Flat;
            btnReporteVotos.FlatAppearance.BorderSize = 0;
            btnReporteVotos.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnReporteVotos.Location = new Point(270, 165);
            btnReporteVotos.Size = new Size(210, 42);
            btnReporteVotos.Cursor = Cursors.Hand;

            pnlCard.Controls.Add(lblTitulo);
            pnlCard.Controls.Add(lblSubtitulo);
            pnlCard.Controls.Add(lblInfo);
            pnlCard.Controls.Add(btnReporteMiembros);
            pnlCard.Controls.Add(btnReporteVotos);

            Controls.Add(pnlCard);

            ResumeLayout(false);
        }
    }
}