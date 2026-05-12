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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.pnlStats = new FlowLayoutPanel();
            this.pnlTimer = new Panel();
            this.lblTiempoTitulo = new Label();
            this.lblTiempo = new Label();

            this.pnlParticipacion = new Panel();
            this.lblPorcentaje = new Label();
            this.pbParticipacion = new ProgressBar();

            this.pnlBarras = new Panel();
            this.lblTituloBarras = new Label();

            this.timerDashboard = new System.Windows.Forms.Timer(this.components);

            this.pnlTimer.SuspendLayout();
            this.pnlParticipacion.SuspendLayout();
            this.pnlBarras.SuspendLayout();

            this.SuspendLayout();

            // FORM
            this.AutoScaleMode = AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = Color.FromArgb(245, 247, 252);
            this.ClientSize = new Size(1100, 700);
            this.Padding = new Padding(25);
            this.Text = "Dashboard Partido";
            this.WindowState = FormWindowState.Maximized;

            // pnlStats
            this.pnlStats.Dock = DockStyle.Top;
            this.pnlStats.Location = new Point(25, 25);
            this.pnlStats.Margin = new Padding(0);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new Size(1050, 130);
            this.pnlStats.WrapContents = false;

            // pnlTimer
            this.pnlTimer.BackColor = Color.White;
            this.pnlTimer.Location = new Point(25, 170);
            this.pnlTimer.Name = "pnlTimer";
            this.pnlTimer.Size = new Size(390, 105);

            // lblTiempoTitulo
            this.lblTiempoTitulo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.lblTiempoTitulo.ForeColor = Color.FromArgb(10, 35, 90);
            this.lblTiempoTitulo.Location = new Point(20, 12);
            this.lblTiempoTitulo.Name = "lblTiempoTitulo";
            this.lblTiempoTitulo.Size = new Size(300, 25);
            this.lblTiempoTitulo.Text = "Tiempo restante";

            // lblTiempo
            this.lblTiempo.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            this.lblTiempo.ForeColor = Color.FromArgb(22, 97, 255);
            this.lblTiempo.Location = new Point(20, 38);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new Size(340, 55);
            this.lblTiempo.Text = "--:--:--";
            this.lblTiempo.TextAlign = ContentAlignment.MiddleCenter;

            this.pnlTimer.Controls.Add(this.lblTiempoTitulo);
            this.pnlTimer.Controls.Add(this.lblTiempo);

            // pnlParticipacion
            this.pnlParticipacion.BackColor = Color.White;
            this.pnlParticipacion.Location = new Point(435, 170);
            this.pnlParticipacion.Name = "pnlParticipacion";
            this.pnlParticipacion.Size = new Size(560, 105);

            // lblPorcentaje
            this.lblPorcentaje.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            this.lblPorcentaje.ForeColor = Color.FromArgb(10, 35, 90);
            this.lblPorcentaje.Location = new Point(20, 18);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new Size(500, 30);
            this.lblPorcentaje.Text = "Participación: 0%";

            // pbParticipacion
            this.pbParticipacion.Location = new Point(20, 60);
            this.pbParticipacion.Name = "pbParticipacion";
            this.pbParticipacion.Size = new Size(520, 25);
            this.pbParticipacion.Style = ProgressBarStyle.Continuous;

            this.pnlParticipacion.Controls.Add(this.lblPorcentaje);
            this.pnlParticipacion.Controls.Add(this.pbParticipacion);

            // pnlBarras
            this.pnlBarras.AutoScroll = true;
            this.pnlBarras.BackColor = Color.FromArgb(245, 247, 252);
            this.pnlBarras.Location = new Point(25, 300);
            this.pnlBarras.Name = "pnlBarras";
            this.pnlBarras.Size = new Size(970, 330);

            // lblTituloBarras
            this.lblTituloBarras.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTituloBarras.ForeColor = Color.FromArgb(10, 35, 90);
            this.lblTituloBarras.Location = new Point(25, 18);
            this.lblTituloBarras.Name = "lblTituloBarras";
            this.lblTituloBarras.Size = new Size(600, 45);
            this.lblTituloBarras.Text = "Resultados por Plancha";

            this.pnlBarras.Controls.Add(this.lblTituloBarras);

            // Controls
            this.Controls.Add(this.pnlBarras);
            this.Controls.Add(this.pnlParticipacion);
            this.Controls.Add(this.pnlTimer);
            this.Controls.Add(this.pnlStats);

            this.pnlTimer.ResumeLayout(false);
            this.pnlParticipacion.ResumeLayout(false);
            this.pnlBarras.ResumeLayout(false);

            this.ResumeLayout(false);
        }
    }
}