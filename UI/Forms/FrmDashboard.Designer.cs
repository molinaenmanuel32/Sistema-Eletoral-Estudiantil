using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    partial class FrmDashboard
    {
        private IContainer components = null;

        private FlowLayoutPanel pnlStats;
        private Panel pnlTimer;
        private Panel pnlParticipacion;
        private Panel pnlBarras;

        private Label lblTiempoTitulo;
        private Label lblTiempo;

        private Label lblPorcentaje;
        private ProgressBar pbParticipacion;

        private Label lblTituloBarras;
        private Timer timerDashboard;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();

            pnlStats = new FlowLayoutPanel();
            pnlTimer = new Panel();
            pnlParticipacion = new Panel();
            pnlBarras = new Panel();

            lblTiempoTitulo = new Label();
            lblTiempo = new Label();

            lblPorcentaje = new Label();
            pbParticipacion = new ProgressBar();

            lblTituloBarras = new Label();
            timerDashboard = new Timer(components);

            // 
            // pnlStats
            // 
            pnlStats.Dock = DockStyle.Top;
            pnlStats.Location = new Point(25, 25);
            pnlStats.Name = "pnlStats";
            pnlStats.Size = new Size(1050, 130);
            pnlStats.WrapContents = false;

            // 
            // pnlTimer
            // 
            pnlTimer.Location = new Point(25, 170);
            pnlTimer.Name = "pnlTimer";
            pnlTimer.Size = new Size(390, 105);
            pnlTimer.Controls.Add(lblTiempoTitulo);
            pnlTimer.Controls.Add(lblTiempo);

            // 
            // lblTiempoTitulo
            // 
            lblTiempoTitulo.Location = new Point(20, 12);
            lblTiempoTitulo.Name = "lblTiempoTitulo";
            lblTiempoTitulo.Size = new Size(300, 25);
            lblTiempoTitulo.Text = "Tiempo restante";

            // 
            // lblTiempo
            // 
            lblTiempo.Location = new Point(20, 38);
            lblTiempo.Name = "lblTiempo";
            lblTiempo.Size = new Size(340, 55);
            lblTiempo.Text = "--:--:--";
            lblTiempo.TextAlign = ContentAlignment.MiddleCenter;
            lblTiempo.Font = new Font("Segoe UI", 30F, FontStyle.Bold);

            // 
            // pnlParticipacion
            // 
            pnlParticipacion.Location = new Point(435, 170);
            pnlParticipacion.Name = "pnlParticipacion";
            pnlParticipacion.Size = new Size(560, 105);
            pnlParticipacion.Controls.Add(lblPorcentaje);
            pnlParticipacion.Controls.Add(pbParticipacion);

            // 
            // lblPorcentaje
            // 
            lblPorcentaje.Location = new Point(20, 18);
            lblPorcentaje.Name = "lblPorcentaje";
            lblPorcentaje.Size = new Size(500, 30);
            lblPorcentaje.Text = "Participación: 0%";

            // 
            // pbParticipacion
            // 
            pbParticipacion.Location = new Point(20, 60);
            pbParticipacion.Name = "pbParticipacion";
            pbParticipacion.Size = new Size(520, 25);

            // 
            // pnlBarras
            // 
            pnlBarras.AutoScroll = true;
            pnlBarras.Location = new Point(25, 300);
            pnlBarras.Name = "pnlBarras";
            pnlBarras.Size = new Size(970, 330);
            pnlBarras.Controls.Add(lblTituloBarras);

            // 
            // lblTituloBarras
            // 
            lblTituloBarras.Location = new Point(25, 18);
            lblTituloBarras.Name = "lblTituloBarras";
            lblTituloBarras.Size = new Size(600, 45);
            lblTituloBarras.Text = "Resultados por Plancha";
            lblTituloBarras.Font = new Font("Segoe UI", 18F, FontStyle.Bold);

            // 
            // FrmDashboard
            // 
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 700);
            Controls.Add(pnlBarras);
            Controls.Add(pnlParticipacion);
            Controls.Add(pnlTimer);
            Controls.Add(pnlStats);
            Name = "FrmDashboard";
            Padding = new Padding(25);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            WindowState = FormWindowState.Maximized;
        }
    }
}