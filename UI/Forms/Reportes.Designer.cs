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
            if (disposing && components != null)
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
            btnVerGeneral = new Button();
            btnPdfGeneral = new Button();

            lblPadronTitulo = new Label();
            lblPadronDesc = new Label();
            btnVerPadron = new Button();
            btnPdfPadron = new Button();

            lblGanadorTitulo = new Label();
            lblGanadorDesc = new Label();
            btnVerGanador = new Button();
            btnPdfGanador = new Button();

            SuspendLayout();

            // ======================================================
            // FORM
            // ======================================================
            BackColor = Color.FromArgb(243, 245, 250);
            FormBorderStyle = FormBorderStyle.None;
            ClientSize = new Size(1190, 768);

            // ======================================================
            // HEADER
            // ======================================================
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 120;
            pnlHeader.BackColor = Color.White;

            lblTitulo.Text = "●  Reportes del Sistema";
            lblTitulo.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 60, 170);
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(40, 25);

            lblSubtitulo.Text = "Seleccione un reporte para visualizarlo o descargarlo en PDF.";
            lblSubtitulo.Font = new Font("Segoe UI", 11F);
            lblSubtitulo.ForeColor = Color.FromArgb(80, 85, 100);
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Location = new Point(45, 78);

            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Controls.Add(lblSubtitulo);

            // ======================================================
            // BODY
            // ======================================================
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.BackColor = Color.FromArgb(243, 245, 250);
            pnlBody.Padding = new Padding(35, 30, 35, 35);
            pnlBody.FlowDirection = FlowDirection.TopDown;
            pnlBody.WrapContents = false;
            pnlBody.AutoScroll = true;

            // ======================================================
            // CARD GENERAL
            // ======================================================
            CrearCard(cardGeneral);

            CrearTitulo(lblGeneralTitulo, "📊 Reporte General de Votos");

            CrearDescripcion(
                lblGeneralDesc,
                "Muestra el resumen general de los votos registrados en la votación."
            );

            CrearBotonAzul(
                btnVerGeneral,
                "Ver reporte",
                new Point(560, 38)
            );

            CrearBotonRojo(
                btnPdfGeneral,
                "Descargar PDF",
                new Point(705, 38)
            );

            btnVerGeneral.Click += btnVerGeneral_Click;
            btnPdfGeneral.Click += btnPdfGeneral_Click;

            cardGeneral.Controls.Add(lblGeneralTitulo);
            cardGeneral.Controls.Add(lblGeneralDesc);
            cardGeneral.Controls.Add(btnVerGeneral);
            cardGeneral.Controls.Add(btnPdfGeneral);

            // ======================================================
            // CARD PADRON
            // ======================================================
            CrearCard(cardPadron);

            CrearTitulo(
                lblPadronTitulo,
                "🧾 Reporte de Padrón Electoral"
            );

            CrearDescripcion(
                lblPadronDesc,
                "Lista los estudiantes habilitados para participar en la votación."
            );

            CrearBotonAzul(
                btnVerPadron,
                "Ver reporte",
                new Point(560, 38)
            );

            CrearBotonRojo(
                btnPdfPadron,
                "Descargar PDF",
                new Point(705, 38)
            );

            btnVerPadron.Click += btnVerPadron_Click;
            btnPdfPadron.Click += btnPdfPadron_Click;

            cardPadron.Controls.Add(lblPadronTitulo);
            cardPadron.Controls.Add(lblPadronDesc);
            cardPadron.Controls.Add(btnVerPadron);
            cardPadron.Controls.Add(btnPdfPadron);

            // ======================================================
            // CARD GANADOR
            // ======================================================
            CrearCard(cardGanador);

            CrearTitulo(
                lblGanadorTitulo,
                "🏆 Reporte de Plancha Ganadora"
            );

            CrearDescripcion(
                lblGanadorDesc,
                "Presenta la plancha ganadora y los resultados finales."
            );

            CrearBotonAzul(
                btnVerGanador,
                "Ver reporte",
                new Point(560, 38)
            );

            CrearBotonRojo(
                btnPdfGanador,
                "Descargar PDF",
                new Point(705, 38)
            );

            btnVerGanador.Click += btnVerGanador_Click;
            btnPdfGanador.Click += btnPdfGanador_Click;

            cardGanador.Controls.Add(lblGanadorTitulo);
            cardGanador.Controls.Add(lblGanadorDesc);
            cardGanador.Controls.Add(btnVerGanador);
            cardGanador.Controls.Add(btnPdfGanador);

            // ======================================================
            // ADD CONTROLS
            // ======================================================
            pnlBody.Controls.Add(cardGeneral);
            pnlBody.Controls.Add(cardPadron);
            pnlBody.Controls.Add(cardGanador);

            Controls.Add(pnlBody);
            Controls.Add(pnlHeader);

            Name = "Reportes";
            Text = "Reportes";

            ResumeLayout(false);
        }

        private void CrearCard(Panel card)
        {
            card.Size = new Size(890, 120);
            card.BackColor = Color.White;
            card.Margin = new Padding(0, 0, 0, 22);
        }

        private void CrearTitulo(Label label, string texto)
        {
            label.Text = texto;
            label.Location = new Point(30, 25);
            label.AutoSize = true;
            label.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(0, 60, 170);
        }

        private void CrearDescripcion(Label label, string texto)
        {
            label.Text = texto;
            label.Location = new Point(33, 68);
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 10F);
            label.ForeColor = Color.FromArgb(80, 85, 100);
        }

        private void CrearBotonAzul(Button btn, string texto, Point location)
        {
            btn.Text = texto;
            btn.Location = location;
            btn.Size = new Size(130, 42);

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;

            btn.BackColor = Color.FromArgb(37, 99, 235);
            btn.ForeColor = Color.White;

            btn.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);

            btn.Cursor = Cursors.Hand;
            btn.UseVisualStyleBackColor = false;
        }

        private void CrearBotonRojo(Button btn, string texto, Point location)
        {
            btn.Text = texto;
            btn.Location = location;
            btn.Size = new Size(145, 42);

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;

            btn.BackColor = Color.FromArgb(235, 40, 50);
            btn.ForeColor = Color.White;

            btn.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);

            btn.Cursor = Cursors.Hand;
            btn.UseVisualStyleBackColor = false;
        }
    }
}