using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    partial class FrmReportes
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.FlowLayoutPanel();
            this.cardGeneral = new System.Windows.Forms.Panel();
            this.lblGeneralTitulo = new System.Windows.Forms.Label();
            this.lblGeneralDesc = new System.Windows.Forms.Label();
            this.btnVerGeneral = new System.Windows.Forms.Button();
            this.btnPdfGeneral = new System.Windows.Forms.Button();
            this.cardPadron = new System.Windows.Forms.Panel();
            this.lblPadronTitulo = new System.Windows.Forms.Label();
            this.lblPadronDesc = new System.Windows.Forms.Label();
            this.btnVerPadron = new System.Windows.Forms.Button();
            this.btnPdfPadron = new System.Windows.Forms.Button();
            this.cardGanador = new System.Windows.Forms.Panel();
            this.lblGanadorTitulo = new System.Windows.Forms.Label();
            this.lblGanadorDesc = new System.Windows.Forms.Label();
            this.btnVerGanador = new System.Windows.Forms.Button();
            this.btnPdfGanador = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.cardGeneral.SuspendLayout();
            this.cardPadron.SuspendLayout();
            this.cardGanador.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1190, 120);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(170)))));
            this.lblTitulo.Location = new System.Drawing.Point(40, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(447, 54);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "●  Reportes del Sistema";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(85)))), ((int)(((byte)(100)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(45, 78);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(527, 25);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Seleccione un reporte para visualizarlo o descargarlo en PDF.";
            // 
            // pnlBody
            // 
            this.pnlBody.AutoScroll = true;
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.pnlBody.Controls.Add(this.cardGeneral);
            this.pnlBody.Controls.Add(this.cardPadron);
            this.pnlBody.Controls.Add(this.cardGanador);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlBody.Location = new System.Drawing.Point(0, 120);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(35, 30, 35, 35);
            this.pnlBody.Size = new System.Drawing.Size(1190, 648);
            this.pnlBody.TabIndex = 0;
            this.pnlBody.WrapContents = false;
            // 
            // cardGeneral
            // 
            this.cardGeneral.BackColor = System.Drawing.Color.White;
            this.cardGeneral.Controls.Add(this.lblGeneralTitulo);
            this.cardGeneral.Controls.Add(this.lblGeneralDesc);
            this.cardGeneral.Controls.Add(this.btnVerGeneral);
            this.cardGeneral.Controls.Add(this.btnPdfGeneral);
            this.cardGeneral.Location = new System.Drawing.Point(35, 30);
            this.cardGeneral.Margin = new System.Windows.Forms.Padding(0, 0, 0, 22);
            this.cardGeneral.Name = "cardGeneral";
            this.cardGeneral.Size = new System.Drawing.Size(890, 120);
            this.cardGeneral.TabIndex = 0;
            // 
            // lblGeneralTitulo
            // 
            this.lblGeneralTitulo.AutoSize = true;
            this.lblGeneralTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.lblGeneralTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(170)))));
            this.lblGeneralTitulo.Location = new System.Drawing.Point(30, 25);
            this.lblGeneralTitulo.Name = "lblGeneralTitulo";
            this.lblGeneralTitulo.Size = new System.Drawing.Size(347, 35);
            this.lblGeneralTitulo.TabIndex = 0;
            this.lblGeneralTitulo.Text = "📊 Reporte General de Votos";
            // 
            // lblGeneralDesc
            // 
            this.lblGeneralDesc.AutoSize = true;
            this.lblGeneralDesc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGeneralDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(85)))), ((int)(((byte)(100)))));
            this.lblGeneralDesc.Location = new System.Drawing.Point(33, 68);
            this.lblGeneralDesc.Name = "lblGeneralDesc";
            this.lblGeneralDesc.Size = new System.Drawing.Size(412, 23);
            this.lblGeneralDesc.TabIndex = 1;
            this.lblGeneralDesc.Text = "Muestra el resumen general de los votos registrados.";
            // 
            // btnVerGeneral
            // 
            this.btnVerGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnVerGeneral.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerGeneral.FlatAppearance.BorderSize = 0;
            this.btnVerGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerGeneral.ForeColor = System.Drawing.Color.White;
            this.btnVerGeneral.Location = new System.Drawing.Point(560, 38);
            this.btnVerGeneral.Name = "btnVerGeneral";
            this.btnVerGeneral.Size = new System.Drawing.Size(130, 42);
            this.btnVerGeneral.TabIndex = 2;
            this.btnVerGeneral.Text = "Ver reporte";
            this.btnVerGeneral.UseVisualStyleBackColor = false;
            this.btnVerGeneral.Click += new System.EventHandler(this.btnVerGeneral_Click_1);
            // 
            // btnPdfGeneral
            // 
            this.btnPdfGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.btnPdfGeneral.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPdfGeneral.FlatAppearance.BorderSize = 0;
            this.btnPdfGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPdfGeneral.ForeColor = System.Drawing.Color.White;
            this.btnPdfGeneral.Location = new System.Drawing.Point(705, 38);
            this.btnPdfGeneral.Name = "btnPdfGeneral";
            this.btnPdfGeneral.Size = new System.Drawing.Size(145, 42);
            this.btnPdfGeneral.TabIndex = 3;
            this.btnPdfGeneral.Text = "Descargar PDF";
            this.btnPdfGeneral.UseVisualStyleBackColor = false;
            // 
            // cardPadron
            // 
            this.cardPadron.BackColor = System.Drawing.Color.White;
            this.cardPadron.Controls.Add(this.lblPadronTitulo);
            this.cardPadron.Controls.Add(this.lblPadronDesc);
            this.cardPadron.Controls.Add(this.btnVerPadron);
            this.cardPadron.Controls.Add(this.btnPdfPadron);
            this.cardPadron.Location = new System.Drawing.Point(35, 172);
            this.cardPadron.Margin = new System.Windows.Forms.Padding(0, 0, 0, 22);
            this.cardPadron.Name = "cardPadron";
            this.cardPadron.Size = new System.Drawing.Size(890, 120);
            this.cardPadron.TabIndex = 1;
            // 
            // lblPadronTitulo
            // 
            this.lblPadronTitulo.AutoSize = true;
            this.lblPadronTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.lblPadronTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(170)))));
            this.lblPadronTitulo.Location = new System.Drawing.Point(30, 25);
            this.lblPadronTitulo.Name = "lblPadronTitulo";
            this.lblPadronTitulo.Size = new System.Drawing.Size(375, 35);
            this.lblPadronTitulo.TabIndex = 0;
            this.lblPadronTitulo.Text = "🧾 Reporte de Padrón Electoral";
            // 
            // lblPadronDesc
            // 
            this.lblPadronDesc.AutoSize = true;
            this.lblPadronDesc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPadronDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(85)))), ((int)(((byte)(100)))));
            this.lblPadronDesc.Location = new System.Drawing.Point(33, 68);
            this.lblPadronDesc.Name = "lblPadronDesc";
            this.lblPadronDesc.Size = new System.Drawing.Size(337, 23);
            this.lblPadronDesc.TabIndex = 1;
            this.lblPadronDesc.Text = "Lista los estudiantes habilitados para votar.";
            // 
            // btnVerPadron
            // 
            this.btnVerPadron.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnVerPadron.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerPadron.FlatAppearance.BorderSize = 0;
            this.btnVerPadron.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerPadron.ForeColor = System.Drawing.Color.White;
            this.btnVerPadron.Location = new System.Drawing.Point(560, 38);
            this.btnVerPadron.Name = "btnVerPadron";
            this.btnVerPadron.Size = new System.Drawing.Size(130, 42);
            this.btnVerPadron.TabIndex = 2;
            this.btnVerPadron.Text = "Ver reporte";
            this.btnVerPadron.UseVisualStyleBackColor = false;
            this.btnVerPadron.Click += new System.EventHandler(this.btnVerPadron_Click_1);
            // 
            // btnPdfPadron
            // 
            this.btnPdfPadron.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.btnPdfPadron.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPdfPadron.FlatAppearance.BorderSize = 0;
            this.btnPdfPadron.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPdfPadron.ForeColor = System.Drawing.Color.White;
            this.btnPdfPadron.Location = new System.Drawing.Point(705, 38);
            this.btnPdfPadron.Name = "btnPdfPadron";
            this.btnPdfPadron.Size = new System.Drawing.Size(145, 42);
            this.btnPdfPadron.TabIndex = 3;
            this.btnPdfPadron.Text = "Descargar PDF";
            this.btnPdfPadron.UseVisualStyleBackColor = false;
            // 
            // cardGanador
            // 
            this.cardGanador.BackColor = System.Drawing.Color.White;
            this.cardGanador.Controls.Add(this.lblGanadorTitulo);
            this.cardGanador.Controls.Add(this.lblGanadorDesc);
            this.cardGanador.Controls.Add(this.btnVerGanador);
            this.cardGanador.Controls.Add(this.btnPdfGanador);
            this.cardGanador.Location = new System.Drawing.Point(38, 317);
            this.cardGanador.Name = "cardGanador";
            this.cardGanador.Size = new System.Drawing.Size(890, 120);
            this.cardGanador.TabIndex = 2;
            // 
            // lblGanadorTitulo
            // 
            this.lblGanadorTitulo.AutoSize = true;
            this.lblGanadorTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.lblGanadorTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(170)))));
            this.lblGanadorTitulo.Location = new System.Drawing.Point(30, 25);
            this.lblGanadorTitulo.Name = "lblGanadorTitulo";
            this.lblGanadorTitulo.Size = new System.Drawing.Size(396, 35);
            this.lblGanadorTitulo.TabIndex = 0;
            this.lblGanadorTitulo.Text = "🏆 Reporte de Plancha Ganadora";
            // 
            // lblGanadorDesc
            // 
            this.lblGanadorDesc.AutoSize = true;
            this.lblGanadorDesc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGanadorDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(85)))), ((int)(((byte)(100)))));
            this.lblGanadorDesc.Location = new System.Drawing.Point(33, 68);
            this.lblGanadorDesc.Name = "lblGanadorDesc";
            this.lblGanadorDesc.Size = new System.Drawing.Size(390, 23);
            this.lblGanadorDesc.TabIndex = 1;
            this.lblGanadorDesc.Text = "Presenta la plancha ganadora y resultados finales.";
            // 
            // btnVerGanador
            // 
            this.btnVerGanador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnVerGanador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerGanador.FlatAppearance.BorderSize = 0;
            this.btnVerGanador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerGanador.ForeColor = System.Drawing.Color.White;
            this.btnVerGanador.Location = new System.Drawing.Point(560, 38);
            this.btnVerGanador.Name = "btnVerGanador";
            this.btnVerGanador.Size = new System.Drawing.Size(130, 42);
            this.btnVerGanador.TabIndex = 2;
            this.btnVerGanador.Text = "Ver reporte";
            this.btnVerGanador.UseVisualStyleBackColor = false;
            this.btnVerGanador.Click += new System.EventHandler(this.btnVerGanador_Click_1);
            // 
            // btnPdfGanador
            // 
            this.btnPdfGanador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.btnPdfGanador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPdfGanador.FlatAppearance.BorderSize = 0;
            this.btnPdfGanador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPdfGanador.ForeColor = System.Drawing.Color.White;
            this.btnPdfGanador.Location = new System.Drawing.Point(705, 38);
            this.btnPdfGanador.Name = "btnPdfGanador";
            this.btnPdfGanador.Size = new System.Drawing.Size(145, 42);
            this.btnPdfGanador.TabIndex = 3;
            this.btnPdfGanador.Text = "Descargar PDF";
            this.btnPdfGanador.UseVisualStyleBackColor = false;
            // 
            // FrmReportes
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1190, 768);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmReportes";
            this.Text = "Reportes";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.cardGeneral.ResumeLayout(false);
            this.cardGeneral.PerformLayout();
            this.cardPadron.ResumeLayout(false);
            this.cardPadron.PerformLayout();
            this.cardGanador.ResumeLayout(false);
            this.cardGanador.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}