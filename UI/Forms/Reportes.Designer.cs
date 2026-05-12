using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    partial class Reportes
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private FlowLayoutPanel pnlBody;

        private Label lblTitulo;
        private Label lblSubtitulo;

        private Panel cardGeneral;
        private Panel cardPadron;
        private Panel cardGanador;

        private Label lblGeneralTitulo;
        private Label lblGeneralDesc;
        private Button btnVerGeneral;
        private Button btnPdfGeneral;

        private Label lblPadronTitulo;
        private Label lblPadronDesc;
        private Button btnVerPadron;
        private Button btnPdfPadron;

        private Label lblGanadorTitulo;
        private Label lblGanadorDesc;
        private Button btnVerGanador;
        private Button btnPdfGanador;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            pnlBody = new FlowLayoutPanel();

            lblTitulo = new Label();
            lblSubtitulo = new Label();

            cardGeneral = new Panel();
            cardPadron = new Panel();
            cardGanador = new Panel();

            lblGeneralTitulo = new Label();
            lblGeneralDesc = new Label();

            lblPadronTitulo = new Label();
            lblPadronDesc = new Label();

            lblGanadorTitulo = new Label();
            lblGanadorDesc = new Label();

            btnVerGeneral = new Button();
            btnPdfGeneral = new Button();

            btnVerPadron = new Button();
            btnPdfPadron = new Button();

            btnVerGanador = new Button();
            btnPdfGanador = new Button();

            SuspendLayout();

            // ================= FORM =================
            BackColor = Color.FromArgb(243, 245, 250);
            FormBorderStyle = FormBorderStyle.None;
            ClientSize = new Size(1190, 768);
            Text = "Reportes";

            // ================= HEADER =================
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 120;
            pnlHeader.BackColor = Color.White;

            lblTitulo.Text = "● Reportes del Sistema";
            lblTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 60, 170);
            lblTitulo.Location = new Point(40, 25);
            lblTitulo.AutoSize = true;

            lblSubtitulo.Text = "Seleccione un reporte para visualizar o descargar.";
            lblSubtitulo.Font = new Font("Segoe UI", 11F);
            lblSubtitulo.ForeColor = Color.Gray;
            lblSubtitulo.Location = new Point(45, 78);
            lblSubtitulo.AutoSize = true;

            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Controls.Add(lblSubtitulo);

            // ================= BODY =================
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Padding = new Padding(35);
            pnlBody.FlowDirection = FlowDirection.TopDown;
            pnlBody.AutoScroll = true;

            // ================= CARD GENERAL =================
            cardGeneral.Size = new Size(890, 120);
            cardGeneral.BackColor = Color.White;
            cardGeneral.Margin = new Padding(0, 0, 0, 20);

            lblGeneralTitulo.Text = "📊 Reporte General de Votos";
            lblGeneralTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblGeneralTitulo.Location = new Point(30, 25);
            lblGeneralTitulo.AutoSize = true;

            lblGeneralDesc.Text = "Resumen general de votos registrados.";
            lblGeneralDesc.Location = new Point(30, 65);
            lblGeneralDesc.AutoSize = true;

            btnVerGeneral.Text = "Ver reporte";
            btnVerGeneral.Size = new Size(130, 40);
            btnVerGeneral.Location = new Point(560, 40);
            btnVerGeneral.BackColor = Color.RoyalBlue;
            btnVerGeneral.ForeColor = Color.White;

            btnPdfGeneral.Text = "PDF";
            btnPdfGeneral.Size = new Size(130, 40);
            btnPdfGeneral.Location = new Point(700, 40);
            btnPdfGeneral.BackColor = Color.Crimson;
            btnPdfGeneral.ForeColor = Color.White;

            cardGeneral.Controls.Add(lblGeneralTitulo);
            cardGeneral.Controls.Add(lblGeneralDesc);
            cardGeneral.Controls.Add(btnVerGeneral);
            cardGeneral.Controls.Add(btnPdfGeneral);

            // ================= CARD PADRON =================
            cardPadron.Size = new Size(890, 120);
            cardPadron.BackColor = Color.White;
            cardPadron.Margin = new Padding(0, 0, 0, 20);

            lblPadronTitulo.Text = "🧾 Padrón Electoral";
            lblPadronTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblPadronTitulo.Location = new Point(30, 25);
            lblPadronTitulo.AutoSize = true;

            lblPadronDesc.Text = "Lista de estudiantes habilitados.";
            lblPadronDesc.Location = new Point(30, 65);
            lblPadronDesc.AutoSize = true;

            btnVerPadron.Text = "Ver reporte";
            btnVerPadron.Size = new Size(130, 40);
            btnVerPadron.Location = new Point(560, 40);
            btnVerPadron.BackColor = Color.RoyalBlue;
            btnVerPadron.ForeColor = Color.White;

            btnPdfPadron.Text = "PDF";
            btnPdfPadron.Size = new Size(130, 40);
            btnPdfPadron.Location = new Point(700, 40);
            btnPdfPadron.BackColor = Color.Crimson;
            btnPdfPadron.ForeColor = Color.White;

            cardPadron.Controls.Add(lblPadronTitulo);
            cardPadron.Controls.Add(lblPadronDesc);
            cardPadron.Controls.Add(btnVerPadron);
            cardPadron.Controls.Add(btnPdfPadron);

            // ================= CARD GANADOR =================
            cardGanador.Size = new Size(890, 120);
            cardGanador.BackColor = Color.White;

            lblGanadorTitulo.Text = "🏆 Plancha Ganadora";
            lblGanadorTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblGanadorTitulo.Location = new Point(30, 25);
            lblGanadorTitulo.AutoSize = true;

            lblGanadorDesc.Text = "Resultados finales de la votación.";
            lblGanadorDesc.Location = new Point(30, 65);
            lblGanadorDesc.AutoSize = true;

            btnVerGanador.Text = "Ver reporte";
            btnVerGanador.Size = new Size(130, 40);
            btnVerGanador.Location = new Point(560, 40);
            btnVerGanador.BackColor = Color.RoyalBlue;
            btnVerGanador.ForeColor = Color.White;

            btnPdfGanador.Text = "PDF";
            btnPdfGanador.Size = new Size(130, 40);
            btnPdfGanador.Location = new Point(700, 40);
            btnPdfGanador.BackColor = Color.Crimson;
            btnPdfGanador.ForeColor = Color.White;

            cardGanador.Controls.Add(lblGanadorTitulo);
            cardGanador.Controls.Add(lblGanadorDesc);
            cardGanador.Controls.Add(btnVerGanador);
            cardGanador.Controls.Add(btnPdfGanador);

            // ================= ADD =================
            pnlBody.Controls.Add(cardGeneral);
            pnlBody.Controls.Add(cardPadron);
            pnlBody.Controls.Add(cardGanador);

            Controls.Add(pnlBody);
            Controls.Add(pnlHeader);

            ResumeLayout(false);
        }
    }
}