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
        private Panel pnlPostVoto;
        private Panel pnlVotacionesActivas;
        private Panel pnlResultadosActivos;

        private Label lblLogo;
        private Label lblBienvenido;
        private Label lblTitulo;
        private Label lblTiempo;
        private Label lblEstado;
        private Label lblInstruccion;
        private Label lblPostTitulo;
        private Label lblPostSubtitulo;
        private Label lblVotacionesActivas;
        private Label lblResultadosActivos;

        private Panel pnlPlanchas;

        private Button btnVotarNulo;
        private Button btnSalir;
        private Button btnActualizarPost;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
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
            pnlInfo = new Panel();
            lblEstado = new Label();
            lblInstruccion = new Label();

            pnlPlanchasContainer = new Panel();
            pnlPlanchas = new Panel();

            pnlPostVoto = new Panel();
            lblPostTitulo = new Label();
            lblPostSubtitulo = new Label();
            lblVotacionesActivas = new Label();
            lblResultadosActivos = new Label();
            pnlVotacionesActivas = new Panel();
            pnlResultadosActivos = new Panel();
            btnActualizarPost = new Button();

            pnlFooter = new Panel();
            btnVotarNulo = new Button();
            btnSalir = new Button();

            pnlHeader.SuspendLayout();
            pnlBody.SuspendLayout();
            pnlInfo.SuspendLayout();
            pnlPlanchasContainer.SuspendLayout();
            pnlPostVoto.SuspendLayout();
            pnlFooter.SuspendLayout();

            SuspendLayout();

            pnlHeader.BackColor = Color.FromArgb(0, 55, 150);
            pnlHeader.Controls.Add(lblLogo);
            pnlHeader.Controls.Add(lblBienvenido);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Controls.Add(lblTiempo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Padding = new Padding(25, 15, 25, 15);
            pnlHeader.Size = new Size(1180, 110);

            lblLogo.BackColor = Color.White;
            lblLogo.Font = new Font("Segoe UI", 34F, FontStyle.Bold);
            lblLogo.ForeColor = Color.FromArgb(230, 40, 45);
            lblLogo.Location = new Point(26, 20);
            lblLogo.Size = new Size(70, 70);
            lblLogo.Text = "V";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;

            lblBienvenido.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblBienvenido.ForeColor = Color.WhiteSmoke;
            lblBienvenido.Location = new Point(115, 18);
            lblBienvenido.Size = new Size(650, 28);
            lblBienvenido.Text = "Bienvenido";

            lblTitulo.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(112, 42);
            lblTitulo.Size = new Size(650, 50);
            lblTitulo.Text = "Sistema de Votaciones Estudiantiles";

            lblTiempo.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTiempo.ForeColor = Color.FromArgb(255, 210, 60);
            lblTiempo.Location = new Point(840, 30);
            lblTiempo.Size = new Size(300, 55);
            lblTiempo.Text = "00:00:00";
            lblTiempo.TextAlign = ContentAlignment.MiddleRight;

            pnlTopBar.BackColor = Color.FromArgb(230, 40, 45);
            pnlTopBar.Dock = DockStyle.Top;
            pnlTopBar.Size = new Size(1180, 7);

            pnlBody.BackColor = Color.FromArgb(245, 247, 252);
            pnlBody.Controls.Add(pnlPostVoto);
            pnlBody.Controls.Add(pnlPlanchasContainer);
            pnlBody.Controls.Add(pnlFooter);
            pnlBody.Controls.Add(pnlInfo);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Padding = new Padding(35, 25, 35, 20);
            pnlBody.Size = new Size(1180, 603);

            pnlInfo.BackColor = Color.White;
            pnlInfo.Controls.Add(lblEstado);
            pnlInfo.Controls.Add(lblInstruccion);
            pnlInfo.Dock = DockStyle.Top;
            pnlInfo.Padding = new Padding(20, 10, 20, 10);
            pnlInfo.Size = new Size(1110, 90);

            lblEstado.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblEstado.ForeColor = Color.FromArgb(0, 120, 60);
            lblEstado.Location = new Point(20, 12);
            lblEstado.Size = new Size(1000, 30);
            lblEstado.Text = "Votación activa";

            lblInstruccion.Font = new Font("Segoe UI", 10F);
            lblInstruccion.ForeColor = Color.FromArgb(90, 100, 120);
            lblInstruccion.Location = new Point(20, 48);
            lblInstruccion.Size = new Size(1000, 28);
            lblInstruccion.Text = "Seleccione una plancha para emitir su voto. Revise bien antes de confirmar.";

            pnlPlanchasContainer.BackColor = Color.White;
            pnlPlanchasContainer.Controls.Add(pnlPlanchas);
            pnlPlanchasContainer.Dock = DockStyle.Fill;
            pnlPlanchasContainer.Padding = new Padding(18);
            pnlPlanchasContainer.Size = new Size(1110, 388);

            pnlPlanchas.AutoScroll = true;
            pnlPlanchas.BackColor = Color.FromArgb(250, 251, 255);
            pnlPlanchas.Dock = DockStyle.Fill;

            pnlPostVoto.BackColor = Color.White;
            pnlPostVoto.Dock = DockStyle.Fill;
            pnlPostVoto.Padding = new Padding(25);
            pnlPostVoto.Visible = false;

            lblPostTitulo.Text = "Voto finalizado";
            lblPostTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblPostTitulo.ForeColor = Color.FromArgb(0, 32, 96);
            lblPostTitulo.Location = new Point(25, 20);
            lblPostTitulo.Size = new Size(600, 45);

            lblPostSubtitulo.Text = "Puedes consultar otras votaciones activas y ver resultados.";
            lblPostSubtitulo.Font = new Font("Segoe UI", 11F);
            lblPostSubtitulo.ForeColor = Color.FromArgb(90, 100, 120);
            lblPostSubtitulo.Location = new Point(28, 65);
            lblPostSubtitulo.Size = new Size(700, 30);

            btnActualizarPost.Text = "Actualizar";
            btnActualizarPost.BackColor = Color.FromArgb(20, 110, 220);
            btnActualizarPost.ForeColor = Color.White;
            btnActualizarPost.FlatStyle = FlatStyle.Flat;
            btnActualizarPost.FlatAppearance.BorderSize = 0;
            btnActualizarPost.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnActualizarPost.Location = new Point(850, 35);
            btnActualizarPost.Size = new Size(180, 42);
            btnActualizarPost.Cursor = Cursors.Hand;
            btnActualizarPost.Click += btnActualizarPost_Click;

            lblVotacionesActivas.Text = "Votaciones activas";
            lblVotacionesActivas.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblVotacionesActivas.ForeColor = Color.FromArgb(0, 55, 150);
            lblVotacionesActivas.Location = new Point(25, 115);
            lblVotacionesActivas.Size = new Size(400, 35);

            pnlVotacionesActivas.Location = new Point(25, 155);
            pnlVotacionesActivas.Size = new Size(500, 260);
            pnlVotacionesActivas.BackColor = Color.FromArgb(245, 247, 252);
            pnlVotacionesActivas.AutoScroll = true;

            lblResultadosActivos.Text = "Resultados activos";
            lblResultadosActivos.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblResultadosActivos.ForeColor = Color.FromArgb(0, 55, 150);
            lblResultadosActivos.Location = new Point(555, 115);
            lblResultadosActivos.Size = new Size(400, 35);

            pnlResultadosActivos.Location = new Point(555, 155);
            pnlResultadosActivos.Size = new Size(520, 260);
            pnlResultadosActivos.BackColor = Color.FromArgb(245, 247, 252);
            pnlResultadosActivos.AutoScroll = true;

            pnlPostVoto.Controls.Add(lblPostTitulo);
            pnlPostVoto.Controls.Add(lblPostSubtitulo);
            pnlPostVoto.Controls.Add(btnActualizarPost);
            pnlPostVoto.Controls.Add(lblVotacionesActivas);
            pnlPostVoto.Controls.Add(pnlVotacionesActivas);
            pnlPostVoto.Controls.Add(lblResultadosActivos);
            pnlPostVoto.Controls.Add(pnlResultadosActivos);

            pnlFooter.BackColor = Color.FromArgb(245, 247, 252);
            pnlFooter.Controls.Add(btnVotarNulo);
            pnlFooter.Controls.Add(btnSalir);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Padding = new Padding(0, 15, 0, 15);
            pnlFooter.Size = new Size(1110, 80);

            btnVotarNulo.BackColor = Color.White;
            btnVotarNulo.Cursor = Cursors.Hand;
            btnVotarNulo.FlatAppearance.BorderColor = Color.FromArgb(0, 55, 150);
            btnVotarNulo.FlatAppearance.BorderSize = 2;
            btnVotarNulo.FlatStyle = FlatStyle.Flat;
            btnVotarNulo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnVotarNulo.ForeColor = Color.FromArgb(0, 55, 150);
            btnVotarNulo.Location = new Point(0, 15);
            btnVotarNulo.Size = new Size(250, 50);
            btnVotarNulo.Text = "Votar en BLANCO (Nulo)";
            btnVotarNulo.UseVisualStyleBackColor = false;
            btnVotarNulo.Click += BtnVotarNulo_Click;

            btnSalir.BackColor = Color.FromArgb(230, 40, 45);
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(910, 15);
            btnSalir.Size = new Size(200, 50);
            btnSalir.Text = "Cerrar Sesión";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += BtnSalir_Click;

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
            pnlInfo.ResumeLayout(false);
            pnlPlanchasContainer.ResumeLayout(false);
            pnlPostVoto.ResumeLayout(false);
            pnlFooter.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}