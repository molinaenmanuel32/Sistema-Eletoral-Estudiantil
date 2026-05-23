using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    partial class FrmReportesAdmin
    {
        private System.ComponentModel.IContainer components = null;

        // HEADER
        private Panel pnlHeader;
        private FlowLayoutPanel pnlBody;
        private Label lblTitulo;
        private Label lblSubtitulo;

        // GENERAL
        private Panel cardGeneral;
        private Label lblGeneralTitulo;
        private Label lblGeneralDesc;
        private Button btnVerGeneral;
        private Button btnPdfGeneral;

        // PADRON
        private Panel cardPadron;
        private Label lblPadronTitulo;
        private Label lblPadronDesc;
        private Button btnVerPadron;
        private Button btnPdfPadron;

        // GANADOR
        private Panel cardGanador;
        private Label lblGanadorTitulo;
        private Label lblGanadorDesc;
        private Button btnVerGanador;
        private Button btnPdfGanador;

        // INTEGRANTES
        private Panel cardIntegrantes;
        private Label lblIntegrantesTitulo;
        private Label lblIntegrantesDesc;
        private Button btnVerIntegrantes;
        private Button btnPdfIntegrantes;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // ─────────────────────────────────────
            // INSTANCIAS
            // ─────────────────────────────────────
            this.pnlHeader = new Panel();
            this.lblTitulo = new Label();
            this.lblSubtitulo = new Label();

            this.pnlBody = new FlowLayoutPanel();

            // GENERAL
            this.cardGeneral = new Panel();
            this.lblGeneralTitulo = new Label();
            this.lblGeneralDesc = new Label();
            this.btnVerGeneral = new Button();
            this.btnPdfGeneral = new Button();

            // PADRON
            this.cardPadron = new Panel();
            this.lblPadronTitulo = new Label();
            this.lblPadronDesc = new Label();
            this.btnVerPadron = new Button();
            this.btnPdfPadron = new Button();

            // GANADOR
            this.cardGanador = new Panel();
            this.lblGanadorTitulo = new Label();
            this.lblGanadorDesc = new Label();
            this.btnVerGanador = new Button();
            this.btnPdfGanador = new Button();

            // INTEGRANTES
            this.cardIntegrantes = new Panel();
            this.lblIntegrantesTitulo = new Label();
            this.lblIntegrantesDesc = new Label();
            this.btnVerIntegrantes = new Button();
            this.btnPdfIntegrantes = new Button();

            // ─────────────────────────────────────
            // HEADER
            // ─────────────────────────────────────
            this.pnlHeader.BackColor = Color.FromArgb(0, 55, 150);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Height = 80;

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font =
                new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.White;
            this.lblTitulo.Location = new Point(36, 12);
            this.lblTitulo.Text = "● Reportes del Sistema";

            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font =
                new Font("Segoe UI", 10F);
            this.lblSubtitulo.ForeColor =
                Color.FromArgb(200, 220, 255);
            this.lblSubtitulo.Location = new Point(40, 52);
            this.lblSubtitulo.Text =
                "Seleccione un reporte para visualizar o descargar en PDF.";

            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblSubtitulo);

            // ─────────────────────────────────────
            // BODY
            // ─────────────────────────────────────
            this.pnlBody.AutoScroll = true;
            this.pnlBody.BackColor =
                Color.FromArgb(243, 245, 250);

            this.pnlBody.Dock = DockStyle.Fill;
            this.pnlBody.FlowDirection =
                FlowDirection.TopDown;

            this.pnlBody.WrapContents = false;
            this.pnlBody.Padding =
                new Padding(36, 28, 36, 28);

            // AGREGAR CARDS
            this.pnlBody.Controls.Add(this.cardGeneral);
            this.pnlBody.Controls.Add(this.cardPadron);
            this.pnlBody.Controls.Add(this.cardGanador);
            this.pnlBody.Controls.Add(this.cardIntegrantes);

            // ─────────────────────────────────────
            // CARD GENERAL
            // ─────────────────────────────────────
            ConfigurarCard(
                this.cardGeneral,
                this.lblGeneralTitulo,
                "📊  Reporte General de Votos",
                this.lblGeneralDesc,
                "Resumen completo de todos los votos registrados.",
                this.btnVerGeneral,
                this.btnPdfGeneral,
                this.btnVerGeneral_Click,
                this.btnPdfGeneral_Click);

            // ─────────────────────────────────────
            // CARD PADRON
            // ─────────────────────────────────────
            ConfigurarCard(
                this.cardPadron,
                this.lblPadronTitulo,
                "🧾  Padrón Electoral",
                this.lblPadronDesc,
                "Lista de estudiantes habilitados para votar.",
                this.btnVerPadron,
                this.btnPdfPadron,
                this.btnVerPadron_Click,
                this.btnPdfPadron_Click);

            // ─────────────────────────────────────
            // CARD GANADOR
            // ─────────────────────────────────────
            ConfigurarCard(
                this.cardGanador,
                this.lblGanadorTitulo,
                "🏆  Plancha Ganadora",
                this.lblGanadorDesc,
                "Resultados finales y plancha ganadora.",
                this.btnVerGanador,
                this.btnPdfGanador,
                this.btnVerGanador_Click,
                this.btnPdfGanador_Click);

            // ─────────────────────────────────────
            // CARD INTEGRANTES
            // ─────────────────────────────────────
            ConfigurarCard(
                this.cardIntegrantes,
                this.lblIntegrantesTitulo,
                "👥  Integrantes de Plancha",
                this.lblIntegrantesDesc,
                "Listado completo de integrantes registrados.",
                this.btnVerIntegrantes,
                this.btnPdfIntegrantes,
                this.btnVerIntegrantes_Click,
                this.btnPdfIntegrantes_Click);

            // ─────────────────────────────────────
            // FORM
            // ─────────────────────────────────────
            this.BackColor =
                Color.FromArgb(243, 245, 250);

            this.ClientSize =
                new Size(1190, 768);

            this.FormBorderStyle =
                FormBorderStyle.None;

            this.Name = "FrmReportesAdmin";
            this.Text = "Reportes";

            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
        }

        // ═══════════════════════════════════════
        // CONFIGURAR CARD
        // ═══════════════════════════════════════
        private static void ConfigurarCard(
            Panel card,
            Label lblTitulo,
            string textoTitulo,
            Label lblDesc,
            string textoDesc,
            Button btnVer,
            Button btnPdf,
            System.EventHandler clickVer,
            System.EventHandler clickPdf)
        {
            // CARD
            card.BackColor = Color.White;
            card.Size = new Size(1080, 110);
            card.Margin = new Padding(0, 0, 0, 18);

            // BORDE IZQUIERDO
            Panel accent = new Panel();
            accent.BackColor =
                Color.FromArgb(0, 55, 150);

            accent.Size = new Size(5, 110);
            accent.Location = new Point(0, 0);

            card.Controls.Add(accent);

            // TITULO
            lblTitulo.AutoSize = true;
            lblTitulo.Font =
                new Font("Segoe UI", 14F, FontStyle.Bold);

            lblTitulo.ForeColor =
                Color.FromArgb(10, 35, 90);

            lblTitulo.Location =
                new Point(24, 20);

            lblTitulo.Text = textoTitulo;

            card.Controls.Add(lblTitulo);

            // DESCRIPCION
            lblDesc.AutoSize = true;
            lblDesc.Font =
                new Font("Segoe UI", 9.5F);

            lblDesc.ForeColor =
                Color.FromArgb(100, 110, 130);

            lblDesc.Location =
                new Point(24, 60);

            lblDesc.Text = textoDesc;

            card.Controls.Add(lblDesc);

            // BTN VER
            btnVer.Size = new Size(140, 38);
            btnVer.Location = new Point(740, 36);

            btnVer.Text = "👁  Ver reporte";

            btnVer.BackColor =
                Color.FromArgb(22, 97, 255);

            btnVer.ForeColor = Color.White;

            btnVer.FlatStyle = FlatStyle.Flat;
            btnVer.FlatAppearance.BorderSize = 0;

            btnVer.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);

            btnVer.Cursor = Cursors.Hand;

            btnVer.Click += clickVer;

            card.Controls.Add(btnVer);

            // BTN PDF
            btnPdf.Size = new Size(140, 38);
            btnPdf.Location = new Point(892, 36);

            btnPdf.Text = "📄  Descargar PDF";

            btnPdf.BackColor =
                Color.FromArgb(220, 53, 69);

            btnPdf.ForeColor = Color.White;

            btnPdf.FlatStyle = FlatStyle.Flat;
            btnPdf.FlatAppearance.BorderSize = 0;

            btnPdf.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);

            btnPdf.Cursor = Cursors.Hand;

            btnPdf.Click += clickPdf;

            card.Controls.Add(btnPdf);
        }
    }
}