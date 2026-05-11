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
<<<<<<< HEAD

        private System.Windows.Forms.Timer timerDashboard;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
=======
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
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
<<<<<<< HEAD
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
=======
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
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
        }
    }
}