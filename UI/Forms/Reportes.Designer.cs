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
        private Panel panel1;

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

        private Label label1;
        private Label label2;

        // NUEVO BOTÓN
        private Button btnPdfPlanchas;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPdfInte = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPdfPlanchas = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.cardGeneral.SuspendLayout();
            this.cardPadron.SuspendLayout();
            this.cardGanador.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(170)))));
            this.lblTitulo.Location = new System.Drawing.Point(40, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(455, 54);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "● Reportes del Sistema";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitulo.Location = new System.Drawing.Point(45, 78);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(431, 25);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Seleccione un reporte para visualizar o descargar.";
            // 
            // pnlBody
            // 
            this.pnlBody.AutoScroll = true;
            this.pnlBody.Controls.Add(this.cardGeneral);
            this.pnlBody.Controls.Add(this.cardPadron);
            this.pnlBody.Controls.Add(this.cardGanador);
            this.pnlBody.Controls.Add(this.panel1);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlBody.Location = new System.Drawing.Point(0, 120);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(35);
            this.pnlBody.Size = new System.Drawing.Size(1190, 648);
            this.pnlBody.TabIndex = 0;
            // 
            // cardGeneral
            // 
            this.cardGeneral.BackColor = System.Drawing.Color.White;
            this.cardGeneral.Controls.Add(this.lblGeneralTitulo);
            this.cardGeneral.Controls.Add(this.lblGeneralDesc);
            this.cardGeneral.Controls.Add(this.btnVerGeneral);
            this.cardGeneral.Controls.Add(this.btnPdfGeneral);
            this.cardGeneral.Location = new System.Drawing.Point(35, 35);
            this.cardGeneral.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.cardGeneral.Name = "cardGeneral";
            this.cardGeneral.Size = new System.Drawing.Size(890, 120);
            this.cardGeneral.TabIndex = 0;
            // 
            // lblGeneralTitulo
            // 
            this.lblGeneralTitulo.AutoSize = true;
            this.lblGeneralTitulo.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblGeneralTitulo.Location = new System.Drawing.Point(30, 25);
            this.lblGeneralTitulo.Name = "lblGeneralTitulo";
            this.lblGeneralTitulo.Size = new System.Drawing.Size(359, 35);
            this.lblGeneralTitulo.TabIndex = 0;
            this.lblGeneralTitulo.Text = "📊 Reporte General de Votos";
            // 
            // lblGeneralDesc
            // 
            this.lblGeneralDesc.AutoSize = true;
            this.lblGeneralDesc.Location = new System.Drawing.Point(30, 65);
            this.lblGeneralDesc.Name = "lblGeneralDesc";
            this.lblGeneralDesc.Size = new System.Drawing.Size(243, 16);
            this.lblGeneralDesc.TabIndex = 1;
            this.lblGeneralDesc.Text = "Resumen general de votos registrados.";
            // 
            // btnVerGeneral
            // 
            this.btnVerGeneral.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnVerGeneral.ForeColor = System.Drawing.Color.White;
            this.btnVerGeneral.Location = new System.Drawing.Point(560, 40);
            this.btnVerGeneral.Name = "btnVerGeneral";
            this.btnVerGeneral.Size = new System.Drawing.Size(130, 40);
            this.btnVerGeneral.TabIndex = 2;
            this.btnVerGeneral.Text = "Ver reporte";
            this.btnVerGeneral.UseVisualStyleBackColor = false;
            this.btnVerGeneral.Click += new System.EventHandler(this.btnVerGeneral_Click);
            // 
            // btnPdfGeneral
            // 
            this.btnPdfGeneral.BackColor = System.Drawing.Color.Crimson;
            this.btnPdfGeneral.ForeColor = System.Drawing.Color.White;
            this.btnPdfGeneral.Location = new System.Drawing.Point(700, 40);
            this.btnPdfGeneral.Name = "btnPdfGeneral";
            this.btnPdfGeneral.Size = new System.Drawing.Size(130, 40);
            this.btnPdfGeneral.TabIndex = 3;
            this.btnPdfGeneral.Text = "PDF";
            this.btnPdfGeneral.UseVisualStyleBackColor = false;
            this.btnPdfGeneral.Click += new System.EventHandler(this.btnPdfGeneral_Click);
            // 
            // cardPadron
            // 
            this.cardPadron.BackColor = System.Drawing.Color.White;
            this.cardPadron.Controls.Add(this.lblPadronTitulo);
            this.cardPadron.Controls.Add(this.lblPadronDesc);
            this.cardPadron.Controls.Add(this.btnVerPadron);
            this.cardPadron.Controls.Add(this.btnPdfPadron);
            this.cardPadron.Location = new System.Drawing.Point(35, 175);
            this.cardPadron.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.cardPadron.Name = "cardPadron";
            this.cardPadron.Size = new System.Drawing.Size(890, 120);
            this.cardPadron.TabIndex = 1;
            // 
            // lblPadronTitulo
            // 
            this.lblPadronTitulo.AutoSize = true;
            this.lblPadronTitulo.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblPadronTitulo.Location = new System.Drawing.Point(30, 25);
            this.lblPadronTitulo.Name = "lblPadronTitulo";
            this.lblPadronTitulo.Size = new System.Drawing.Size(247, 35);
            this.lblPadronTitulo.TabIndex = 0;
            this.lblPadronTitulo.Text = "🧾 Padrón Electoral";
            // 
            // lblPadronDesc
            // 
            this.lblPadronDesc.AutoSize = true;
            this.lblPadronDesc.Location = new System.Drawing.Point(30, 65);
            this.lblPadronDesc.Name = "lblPadronDesc";
            this.lblPadronDesc.Size = new System.Drawing.Size(198, 16);
            this.lblPadronDesc.TabIndex = 1;
            this.lblPadronDesc.Text = "Lista de estudiantes habilitados.";
            // 
            // btnVerPadron
            // 
            this.btnVerPadron.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnVerPadron.ForeColor = System.Drawing.Color.White;
            this.btnVerPadron.Location = new System.Drawing.Point(560, 40);
            this.btnVerPadron.Name = "btnVerPadron";
            this.btnVerPadron.Size = new System.Drawing.Size(130, 40);
            this.btnVerPadron.TabIndex = 2;
            this.btnVerPadron.Text = "Ver reporte";
            this.btnVerPadron.UseVisualStyleBackColor = false;
            this.btnVerPadron.Click += new System.EventHandler(this.btnVerPadron_Click);
            // 
            // btnPdfPadron
            // 
            this.btnPdfPadron.BackColor = System.Drawing.Color.Crimson;
            this.btnPdfPadron.ForeColor = System.Drawing.Color.White;
            this.btnPdfPadron.Location = new System.Drawing.Point(700, 40);
            this.btnPdfPadron.Name = "btnPdfPadron";
            this.btnPdfPadron.Size = new System.Drawing.Size(130, 40);
            this.btnPdfPadron.TabIndex = 3;
            this.btnPdfPadron.Text = "PDF";
            this.btnPdfPadron.UseVisualStyleBackColor = false;
            this.btnPdfPadron.Click += new System.EventHandler(this.btnPdfPadron_Click);
            // 
            // cardGanador
            // 
            this.cardGanador.BackColor = System.Drawing.Color.White;
            this.cardGanador.Controls.Add(this.lblGanadorTitulo);
            this.cardGanador.Controls.Add(this.lblGanadorDesc);
            this.cardGanador.Controls.Add(this.btnVerGanador);
            this.cardGanador.Controls.Add(this.btnPdfGanador);
            this.cardGanador.Location = new System.Drawing.Point(35, 315);
            this.cardGanador.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.cardGanador.Name = "cardGanador";
            this.cardGanador.Size = new System.Drawing.Size(890, 120);
            this.cardGanador.TabIndex = 2;
            // 
            // lblGanadorTitulo
            // 
            this.lblGanadorTitulo.AutoSize = true;
            this.lblGanadorTitulo.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblGanadorTitulo.Location = new System.Drawing.Point(30, 25);
            this.lblGanadorTitulo.Name = "lblGanadorTitulo";
            this.lblGanadorTitulo.Size = new System.Drawing.Size(266, 35);
            this.lblGanadorTitulo.TabIndex = 0;
            this.lblGanadorTitulo.Text = "🏆 Plancha Ganadora";
            // 
            // lblGanadorDesc
            // 
            this.lblGanadorDesc.AutoSize = true;
            this.lblGanadorDesc.Location = new System.Drawing.Point(30, 65);
            this.lblGanadorDesc.Name = "lblGanadorDesc";
            this.lblGanadorDesc.Size = new System.Drawing.Size(208, 16);
            this.lblGanadorDesc.TabIndex = 1;
            this.lblGanadorDesc.Text = "Resultados finales de la votación.";
            // 
            // btnVerGanador
            // 
            this.btnVerGanador.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnVerGanador.ForeColor = System.Drawing.Color.White;
            this.btnVerGanador.Location = new System.Drawing.Point(560, 40);
            this.btnVerGanador.Name = "btnVerGanador";
            this.btnVerGanador.Size = new System.Drawing.Size(130, 40);
            this.btnVerGanador.TabIndex = 2;
            this.btnVerGanador.Text = "Ver reporte";
            this.btnVerGanador.UseVisualStyleBackColor = false;
            this.btnVerGanador.Click += new System.EventHandler(this.btnVerGanador_Click);
            // 
            // btnPdfGanador
            // 
            this.btnPdfGanador.BackColor = System.Drawing.Color.Crimson;
            this.btnPdfGanador.ForeColor = System.Drawing.Color.White;
            this.btnPdfGanador.Location = new System.Drawing.Point(700, 40);
            this.btnPdfGanador.Name = "btnPdfGanador";
            this.btnPdfGanador.Size = new System.Drawing.Size(130, 40);
            this.btnPdfGanador.TabIndex = 3;
            this.btnPdfGanador.Text = "PDF";
            this.btnPdfGanador.UseVisualStyleBackColor = false;
            this.btnPdfGanador.Click += new System.EventHandler(this.btnPdfGanador_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnPdfInte);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnPdfPlanchas);
            this.panel1.Location = new System.Drawing.Point(38, 458);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(890, 120);
            this.panel1.TabIndex = 3;
            // 
            // btnPdfInte
            // 
            this.btnPdfInte.BackColor = System.Drawing.Color.Crimson;
            this.btnPdfInte.ForeColor = System.Drawing.Color.White;
            this.btnPdfInte.Location = new System.Drawing.Point(697, 41);
            this.btnPdfInte.Name = "btnPdfInte";
            this.btnPdfInte.Size = new System.Drawing.Size(130, 40);
            this.btnPdfInte.TabIndex = 4;
            this.btnPdfInte.Text = "PDF";
            this.btnPdfInte.UseVisualStyleBackColor = false;
            this.btnPdfInte.Click += new System.EventHandler(this.btnPdfInte_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(30, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "👥 Integrantes de Planchas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(286, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Visualizar y descargar integrantes por plancha.";
            // 
            // btnPdfPlanchas
            // 
            this.btnPdfPlanchas.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnPdfPlanchas.ForeColor = System.Drawing.Color.White;
            this.btnPdfPlanchas.Location = new System.Drawing.Point(557, 41);
            this.btnPdfPlanchas.Name = "btnPdfPlanchas";
            this.btnPdfPlanchas.Size = new System.Drawing.Size(130, 40);
            this.btnPdfPlanchas.TabIndex = 5;
            this.btnPdfPlanchas.Text = "Ver reporte";
            this.btnPdfPlanchas.UseVisualStyleBackColor = false;
            this.btnPdfPlanchas.Click += new System.EventHandler(this.btnPdfPlanchas_Click);
            // 
            // Reportes
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1190, 768);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Reportes";
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private Button btnPdfInte;

    }
}