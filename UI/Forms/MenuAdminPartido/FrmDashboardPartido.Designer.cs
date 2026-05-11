using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    partial class FrmDashboardPartido
    {
        private System.ComponentModel.IContainer components = null;

        private FlowLayoutPanel pnlStats;
        private Panel pnlTimer;
        private Panel pnlParticipacion;
        private Panel pnlBarras;

        private Label lblTiempoTitulo;
        private Label lblTiempo;
        private Label lblPorcentaje;
        private ProgressBar pbParticipacion;
        private Label lblTituloBarras;
        private System.Windows.Forms.Timer timerDashboard;

        private static readonly Color Azul = Color.FromArgb(0, 55, 150);
        private static readonly Color AzulClaro = Color.FromArgb(22, 97, 255);
        private static readonly Color Rojo = Color.FromArgb(230, 40, 45);
        private static readonly Color Fondo = Color.FromArgb(245, 247, 252);
        private static readonly Color Card = Color.White;
        private static readonly Color Texto = Color.FromArgb(10, 35, 90);
        private static readonly Color TextoSuave = Color.FromArgb(80, 90, 115);

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            pnlStats = new FlowLayoutPanel();
            pnlTimer = new Panel();
            lblTiempoTitulo = new Label();
            lblTiempo = new Label();

            pnlParticipacion = new Panel();
            lblPorcentaje = new Label();
            pbParticipacion = new ProgressBar();

            pnlBarras = new Panel();
            lblTituloBarras = new Label();

            timerDashboard = new System.Windows.Forms.Timer(components);

            pnlTimer.SuspendLayout();
            pnlParticipacion.SuspendLayout();
            pnlBarras.SuspendLayout();

            SuspendLayout();

            AutoScroll = true;
            BackColor = Fondo;
            ClientSize = new Size(1100, 700);
            Padding = new Padding(25);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard Partido";
            WindowState = FormWindowState.Maximized;

            // STATS
            pnlStats.Dock = DockStyle.Top;
            pnlStats.Location = new Point(25, 25);
            pnlStats.Margin = new Padding(0);
            pnlStats.Name = "pnlStats";
            pnlStats.Size = new Size(1050, 130);
            pnlStats.TabIndex = 3;
            pnlStats.WrapContents = false;

            // TIMER
            pnlTimer.BackColor = Card;
            pnlTimer.Controls.Add(lblTiempoTitulo);
            pnlTimer.Controls.Add(lblTiempo);
            pnlTimer.Location = new Point(25, 170);
            pnlTimer.Name = "pnlTimer";
            pnlTimer.Size = new Size(390, 105);
            pnlTimer.TabIndex = 2;

            lblTiempoTitulo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTiempoTitulo.ForeColor = Texto;
            lblTiempoTitulo.Location = new Point(20, 12);
            lblTiempoTitulo.Name = "lblTiempoTitulo";
            lblTiempoTitulo.Size = new Size(300, 25);
            lblTiempoTitulo.TabIndex = 0;
            lblTiempoTitulo.Text = "⏱ Tiempo restante";

            lblTiempo.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            lblTiempo.ForeColor = AzulClaro;
            lblTiempo.Location = new Point(20, 38);
            lblTiempo.Name = "lblTiempo";
            lblTiempo.Size = new Size(340, 55);
            lblTiempo.TabIndex = 1;
            lblTiempo.Text = "--:--:--";
            lblTiempo.TextAlign = ContentAlignment.MiddleCenter;

            // PARTICIPACION
            pnlParticipacion.BackColor = Card;
            pnlParticipacion.Controls.Add(lblPorcentaje);
            pnlParticipacion.Controls.Add(pbParticipacion);
            pnlParticipacion.Location = new Point(435, 170);
            pnlParticipacion.Name = "pnlParticipacion";
            pnlParticipacion.Size = new Size(560, 105);
            pnlParticipacion.TabIndex = 1;

            lblPorcentaje.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblPorcentaje.ForeColor = Texto;
            lblPorcentaje.Location = new Point(20, 18);
            lblPorcentaje.Name = "lblPorcentaje";
            lblPorcentaje.Size = new Size(500, 30);
            lblPorcentaje.TabIndex = 0;
            lblPorcentaje.Text = "Participación: 0%";

            pbParticipacion.Location = new Point(20, 60);
            pbParticipacion.Name = "pbParticipacion";
            pbParticipacion.Size = new Size(520, 25);
            pbParticipacion.Style = ProgressBarStyle.Continuous;
            pbParticipacion.TabIndex = 1;

            // BARRAS
            pnlBarras.AutoScroll = true;
            pnlBarras.BackColor = Fondo;
            pnlBarras.Controls.Add(lblTituloBarras);
            pnlBarras.Location = new Point(25, 300);
            pnlBarras.Name = "pnlBarras";
            pnlBarras.Size = new Size(970, 330);
            pnlBarras.TabIndex = 0;

            lblTituloBarras.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTituloBarras.ForeColor = Texto;
            lblTituloBarras.Location = new Point(25, 18);
            lblTituloBarras.Name = "lblTituloBarras";
            lblTituloBarras.Size = new Size(600, 45);
            lblTituloBarras.TabIndex = 0;
            lblTituloBarras.Text = "▣ Resultados por Plancha";

            Controls.Add(pnlBarras);
            Controls.Add(pnlParticipacion);
            Controls.Add(pnlTimer);
            Controls.Add(pnlStats);

            pnlTimer.ResumeLayout(false);
            pnlParticipacion.ResumeLayout(false);
            pnlBarras.ResumeLayout(false);

            ResumeLayout(false);
        }

        private void AjustarTamanos()
        {
            int ancho = ClientSize.Width - Padding.Left - Padding.Right;
            if (ancho < 700) ancho = 700;

            pnlStats.Width = ancho;

            int cardWidth = (ancho - 45) / 4;

            foreach (Control c in pnlStats.Controls)
            {
                c.Width = cardWidth;
            }

            pnlTimer.Width = 390;
            pnlTimer.Location = new Point(25, 170);

            pnlParticipacion.Location = new Point(435, 170);
            pnlParticipacion.Width = ancho - 410;

            if (pnlParticipacion.Width < 300)
            {
                pnlParticipacion.Location = new Point(25, 290);
                pnlParticipacion.Width = ancho;
                pnlBarras.Location = new Point(25, 420);
            }
            else
            {
                pnlBarras.Location = new Point(25, 300);
            }

            lblPorcentaje.Width = pnlParticipacion.Width - 40;
            pbParticipacion.Width = pnlParticipacion.Width - 40;

            pnlBarras.Width = ancho;
            pnlBarras.Height = ClientSize.Height - pnlBarras.Top - 25;

            if (pnlBarras.Height < 280)
                pnlBarras.Height = 280;
        }
    }
}