using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    partial class FrmVotacion
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Panel pnlTopBar;
        private Panel pnlBody;
        private Panel pnlInfo;
        private Panel pnlPlanchasContainer;
        private Panel pnlFooter;

        private Label lblLogo;
        private Label lblBienvenido;
        private Label lblTitulo;
        private Label lblTiempo;
        private Label lblEstado;
        private Label lblInstruccion;

        private Panel pnlPlanchas;

        private Button btnVotarNulo;
        private Button btnSalir;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblLogo = new Label();
            lblBienvenido = new Label();
            lblTitulo = new Label();
            lblTiempo = new Label();
            pnlTopBar = new Panel();
            pnlBody = new Panel();
            pnlPlanchasContainer = new Panel();
            pnlPlanchas = new Panel();
            pnlFooter = new Panel();
            btnVotarNulo = new Button();
            btnSalir = new Button();
            pnlInfo = new Panel();
            lblEstado = new Label();
            lblInstruccion = new Label();
            pnlHeader.SuspendLayout();
            pnlBody.SuspendLayout();
            pnlPlanchasContainer.SuspendLayout();
            pnlFooter.SuspendLayout();
            pnlInfo.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(0, 55, 150);
            pnlHeader.BackgroundImage = Properties.Resources.login_fondo1;
            pnlHeader.Controls.Add(lblLogo);
            pnlHeader.Controls.Add(lblBienvenido);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Controls.Add(lblTiempo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(25, 15, 25, 15);
            pnlHeader.Size = new Size(1180, 110);
            pnlHeader.TabIndex = 2;
            // 
            // lblLogo
            // 
            lblLogo.BackColor = Color.Transparent;
            lblLogo.Font = new Font("Segoe UI Emoji", 34F);
            lblLogo.ForeColor = Color.Red;
            lblLogo.Location = new Point(26, 15);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(70, 80);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "🗳️";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBienvenido
            // 
            lblBienvenido.BackColor = Color.Transparent;
            lblBienvenido.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblBienvenido.ForeColor = Color.WhiteSmoke;
            lblBienvenido.Location = new Point(105, 18);
            lblBienvenido.Name = "lblBienvenido";
            lblBienvenido.Size = new Size(650, 28);
            lblBienvenido.TabIndex = 1;
            lblBienvenido.Text = "Bienvenido";
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(102, 42);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(650, 50);
            lblTitulo.TabIndex = 2;
            lblTitulo.Text = "Sistema de Votaciones Estudiantiles";
            // 
            // lblTiempo
            // 
            lblTiempo.BackColor = Color.Transparent;
            lblTiempo.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTiempo.ForeColor = Color.FromArgb(255, 210, 60);
            lblTiempo.Location = new Point(840, 30);
            lblTiempo.Name = "lblTiempo";
            lblTiempo.Size = new Size(300, 55);
            lblTiempo.TabIndex = 3;
            lblTiempo.Text = "00:00:00";
            lblTiempo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlTopBar
            // 
            pnlTopBar.BackColor = Color.FromArgb(230, 40, 45);
            pnlTopBar.Dock = DockStyle.Top;
            pnlTopBar.Location = new Point(0, 110);
            pnlTopBar.Name = "pnlTopBar";
            pnlTopBar.Size = new Size(1180, 7);
            pnlTopBar.TabIndex = 1;
            // 
            // pnlBody
            // 
            pnlBody.BackColor = Color.FromArgb(245, 247, 252);
            pnlBody.Controls.Add(pnlPlanchasContainer);
            pnlBody.Controls.Add(pnlFooter);
            pnlBody.Controls.Add(pnlInfo);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 117);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(35, 25, 35, 20);
            pnlBody.Size = new Size(1180, 603);
            pnlBody.TabIndex = 0;
            // 
            // pnlPlanchasContainer
            // 
            pnlPlanchasContainer.BackColor = Color.White;
            pnlPlanchasContainer.Controls.Add(pnlPlanchas);
            pnlPlanchasContainer.Dock = DockStyle.Fill;
            pnlPlanchasContainer.Location = new Point(35, 115);
            pnlPlanchasContainer.Margin = new Padding(0, 15, 0, 15);
            pnlPlanchasContainer.Name = "pnlPlanchasContainer";
            pnlPlanchasContainer.Padding = new Padding(18);
            pnlPlanchasContainer.Size = new Size(1110, 388);
            pnlPlanchasContainer.TabIndex = 0;
            // 
            // pnlPlanchas
            // 
            pnlPlanchas.AutoScroll = true;
            pnlPlanchas.BackColor = Color.FromArgb(250, 251, 255);
            pnlPlanchas.Dock = DockStyle.Fill;
            pnlPlanchas.Location = new Point(18, 18);
            pnlPlanchas.Name = "pnlPlanchas";
            pnlPlanchas.Size = new Size(1074, 352);
            pnlPlanchas.TabIndex = 0;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(245, 247, 252);
            pnlFooter.Controls.Add(btnVotarNulo);
            pnlFooter.Controls.Add(btnSalir);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(35, 503);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Padding = new Padding(0, 15, 0, 15);
            pnlFooter.Size = new Size(1110, 80);
            pnlFooter.TabIndex = 1;
            // 
            // btnVotarNulo
            // 
            btnVotarNulo.BackColor = Color.White;
            btnVotarNulo.Cursor = Cursors.Hand;
            btnVotarNulo.FlatAppearance.BorderColor = Color.FromArgb(0, 55, 150);
            btnVotarNulo.FlatAppearance.BorderSize = 2;
            btnVotarNulo.FlatStyle = FlatStyle.Flat;
            btnVotarNulo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnVotarNulo.ForeColor = Color.FromArgb(0, 55, 150);
            btnVotarNulo.Location = new Point(0, 15);
            btnVotarNulo.Name = "btnVotarNulo";
            btnVotarNulo.Size = new Size(250, 50);
            btnVotarNulo.TabIndex = 0;
            btnVotarNulo.Text = "Votar en BLANCO (Nulo)";
            btnVotarNulo.UseVisualStyleBackColor = false;
            btnVotarNulo.Click += BtnVotarNulo_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(230, 40, 45);
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(910, 15);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(200, 50);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "Cerrar Sesión";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += BtnSalir_Click;
            // 
            // pnlInfo
            // 
            pnlInfo.BackColor = Color.White;
            pnlInfo.Controls.Add(lblEstado);
            pnlInfo.Controls.Add(lblInstruccion);
            pnlInfo.Dock = DockStyle.Top;
            pnlInfo.Location = new Point(35, 25);
            pnlInfo.Name = "pnlInfo";
            pnlInfo.Padding = new Padding(20, 10, 20, 10);
            pnlInfo.Size = new Size(1110, 90);
            pnlInfo.TabIndex = 2;
            // 
            // lblEstado
            // 
            lblEstado.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblEstado.ForeColor = Color.FromArgb(0, 120, 60);
            lblEstado.Location = new Point(20, 12);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(1000, 30);
            lblEstado.TabIndex = 0;
            lblEstado.Text = "Votación activa";
            // 
            // lblInstruccion
            // 
            lblInstruccion.Font = new Font("Segoe UI", 10F);
            lblInstruccion.ForeColor = Color.FromArgb(90, 100, 120);
            lblInstruccion.Location = new Point(20, 48);
            lblInstruccion.Name = "lblInstruccion";
            lblInstruccion.Size = new Size(1000, 28);
            lblInstruccion.TabIndex = 1;
            lblInstruccion.Text = "Seleccione una plancha para emitir su voto. Revise bien antes de confirmar.";
            // 
            // FrmVotacion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 252);
            ClientSize = new Size(1180, 720);
            Controls.Add(pnlBody);
            Controls.Add(pnlTopBar);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmVotacion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Votaciones";
            pnlHeader.ResumeLayout(false);
            pnlBody.ResumeLayout(false);
            pnlPlanchasContainer.ResumeLayout(false);
            pnlFooter.ResumeLayout(false);
            pnlInfo.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}