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

        private Panel pnlPlanchas;

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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlPostVoto = new System.Windows.Forms.Panel();
            this.pnlTopVotaciones = new System.Windows.Forms.Panel();
            this.pnlVotacionesActivas = new System.Windows.Forms.Panel();
            this.lblVotacionesActivas = new System.Windows.Forms.Label();
            this.pnlBottomResultados = new System.Windows.Forms.Panel();
            this.pnlResultadosActivos = new System.Windows.Forms.Panel();
            this.lblResultadosActivos = new System.Windows.Forms.Label();
            this.btnActualizarPost = new System.Windows.Forms.Button();
            this.lblPostSubtitulo = new System.Windows.Forms.Label();
            this.lblPostTitulo = new System.Windows.Forms.Label();
            this.pnlPlanchasContainer = new System.Windows.Forms.Panel();
            this.pnlPlanchas = new System.Windows.Forms.Panel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnVotarNulo = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblInstruccion = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlPostVoto.SuspendLayout();
            this.pnlTopVotaciones.SuspendLayout();
            this.pnlBottomResultados.SuspendLayout();
            this.pnlPlanchasContainer.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(55)))), ((int)(((byte)(150)))));
            this.pnlHeader.Controls.Add(this.lblLogo);
            this.pnlHeader.Controls.Add(this.lblBienvenido);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblTiempo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1382, 140);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblLogo
            // 
            this.lblLogo.BackColor = System.Drawing.Color.White;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 34F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.lblLogo.Location = new System.Drawing.Point(25, 30);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(75, 75);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "V";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBienvenido.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblBienvenido.Location = new System.Drawing.Point(120, 20);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(700, 30);
            this.lblBienvenido.TabIndex = 1;
            this.lblBienvenido.Text = "Bienvenido";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(115, 55);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(800, 55);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Sistema de Votaciones";
            // 
            // lblTiempo
            // 
            this.lblTiempo.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTiempo.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblTiempo.ForeColor = System.Drawing.Color.Gold;
            this.lblTiempo.Location = new System.Drawing.Point(1032, 0);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(350, 140);
            this.lblTiempo.TabIndex = 3;
            this.lblTiempo.Text = "00:00:00";
            this.lblTiempo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 140);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1382, 7);
            this.pnlTopBar.TabIndex = 1;
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.pnlBody.Controls.Add(this.pnlPostVoto);
            this.pnlBody.Controls.Add(this.pnlPlanchasContainer);
            this.pnlBody.Controls.Add(this.pnlFooter);
            this.pnlBody.Controls.Add(this.pnlInfo);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 147);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(30);
            this.pnlBody.Size = new System.Drawing.Size(1382, 706);
            this.pnlBody.TabIndex = 0;
            // 
            // pnlPostVoto
            // 
            this.pnlPostVoto.BackColor = System.Drawing.Color.White;
            this.pnlPostVoto.Controls.Add(this.pnlTopVotaciones);
            this.pnlPostVoto.Controls.Add(this.pnlBottomResultados);
            this.pnlPostVoto.Controls.Add(this.btnActualizarPost);
            this.pnlPostVoto.Controls.Add(this.lblPostSubtitulo);
            this.pnlPostVoto.Controls.Add(this.lblPostTitulo);
            this.pnlPostVoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPostVoto.Location = new System.Drawing.Point(30, 130);
            this.pnlPostVoto.Name = "pnlPostVoto";
            this.pnlPostVoto.Padding = new System.Windows.Forms.Padding(25);
            this.pnlPostVoto.Size = new System.Drawing.Size(1322, 456);
            this.pnlPostVoto.TabIndex = 0;
            this.pnlPostVoto.Visible = false;
            // 
            // pnlTopVotaciones
            // 
            this.pnlTopVotaciones.Controls.Add(this.pnlVotacionesActivas);
            this.pnlTopVotaciones.Controls.Add(this.lblVotacionesActivas);
            this.pnlTopVotaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTopVotaciones.Location = new System.Drawing.Point(25, 165);
            this.pnlTopVotaciones.Name = "pnlTopVotaciones";
            this.pnlTopVotaciones.Padding = new System.Windows.Forms.Padding(0, 20, 0, 10);
            this.pnlTopVotaciones.Size = new System.Drawing.Size(1272, 0);
            this.pnlTopVotaciones.TabIndex = 0;
            // 
            // pnlVotacionesActivas
            // 
            this.pnlVotacionesActivas.AutoScroll = true;
            this.pnlVotacionesActivas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.pnlVotacionesActivas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlVotacionesActivas.Location = new System.Drawing.Point(0, 60);
            this.pnlVotacionesActivas.Name = "pnlVotacionesActivas";
            this.pnlVotacionesActivas.Size = new System.Drawing.Size(1272, 0);
            this.pnlVotacionesActivas.TabIndex = 0;
            // 
            // lblVotacionesActivas
            // 
            this.lblVotacionesActivas.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblVotacionesActivas.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblVotacionesActivas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(55)))), ((int)(((byte)(150)))));
            this.lblVotacionesActivas.Location = new System.Drawing.Point(0, 20);
            this.lblVotacionesActivas.Name = "lblVotacionesActivas";
            this.lblVotacionesActivas.Size = new System.Drawing.Size(1272, 40);
            this.lblVotacionesActivas.TabIndex = 1;
            this.lblVotacionesActivas.Text = "Votaciones activas";
            // 
            // pnlBottomResultados
            // 
            this.pnlBottomResultados.Controls.Add(this.pnlResultadosActivos);
            this.pnlBottomResultados.Controls.Add(this.lblResultadosActivos);
            this.pnlBottomResultados.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomResultados.Location = new System.Drawing.Point(25, 111);
            this.pnlBottomResultados.Name = "pnlBottomResultados";
            this.pnlBottomResultados.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlBottomResultados.Size = new System.Drawing.Size(1272, 320);
            this.pnlBottomResultados.TabIndex = 1;
            // 
            // pnlResultadosActivos
            // 
            this.pnlResultadosActivos.AutoScroll = true;
            this.pnlResultadosActivos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.pnlResultadosActivos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResultadosActivos.Location = new System.Drawing.Point(0, 50);
            this.pnlResultadosActivos.Name = "pnlResultadosActivos";
            this.pnlResultadosActivos.Size = new System.Drawing.Size(1272, 270);
            this.pnlResultadosActivos.TabIndex = 0;
            // 
            // lblResultadosActivos
            // 
            this.lblResultadosActivos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblResultadosActivos.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblResultadosActivos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(55)))), ((int)(((byte)(150)))));
            this.lblResultadosActivos.Location = new System.Drawing.Point(0, 10);
            this.lblResultadosActivos.Name = "lblResultadosActivos";
            this.lblResultadosActivos.Size = new System.Drawing.Size(1272, 40);
            this.lblResultadosActivos.TabIndex = 1;
            this.lblResultadosActivos.Text = "Resultados";
            // 
            // btnActualizarPost
            // 
            this.btnActualizarPost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(97)))), ((int)(((byte)(255)))));
            this.btnActualizarPost.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnActualizarPost.FlatAppearance.BorderSize = 0;
            this.btnActualizarPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarPost.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnActualizarPost.ForeColor = System.Drawing.Color.White;
            this.btnActualizarPost.Location = new System.Drawing.Point(25, 120);
            this.btnActualizarPost.Name = "btnActualizarPost";
            this.btnActualizarPost.Size = new System.Drawing.Size(1272, 45);
            this.btnActualizarPost.TabIndex = 2;
            this.btnActualizarPost.Text = "Actualizar";
            this.btnActualizarPost.UseVisualStyleBackColor = false;
            // 
            // lblPostSubtitulo
            // 
            this.lblPostSubtitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPostSubtitulo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblPostSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.lblPostSubtitulo.Location = new System.Drawing.Point(25, 80);
            this.lblPostSubtitulo.Name = "lblPostSubtitulo";
            this.lblPostSubtitulo.Size = new System.Drawing.Size(1272, 40);
            this.lblPostSubtitulo.TabIndex = 3;
            this.lblPostSubtitulo.Text = "Puedes consultar otras votaciones activas y revisar resultados.";
            // 
            // lblPostTitulo
            // 
            this.lblPostTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPostTitulo.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblPostTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(32)))), ((int)(((byte)(96)))));
            this.lblPostTitulo.Location = new System.Drawing.Point(25, 25);
            this.lblPostTitulo.Name = "lblPostTitulo";
            this.lblPostTitulo.Size = new System.Drawing.Size(1272, 55);
            this.lblPostTitulo.TabIndex = 4;
            this.lblPostTitulo.Text = "Voto finalizado";
            // 
            // pnlPlanchasContainer
            // 
            this.pnlPlanchasContainer.BackColor = System.Drawing.Color.White;
            this.pnlPlanchasContainer.Controls.Add(this.pnlPlanchas);
            this.pnlPlanchasContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPlanchasContainer.Location = new System.Drawing.Point(30, 130);
            this.pnlPlanchasContainer.Name = "pnlPlanchasContainer";
            this.pnlPlanchasContainer.Padding = new System.Windows.Forms.Padding(20);
            this.pnlPlanchasContainer.Size = new System.Drawing.Size(1322, 456);
            this.pnlPlanchasContainer.TabIndex = 1;
            // 
            // pnlPlanchas
            // 
            this.pnlPlanchas.AutoScroll = true;
            this.pnlPlanchas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.pnlPlanchas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPlanchas.Location = new System.Drawing.Point(20, 20);
            this.pnlPlanchas.Name = "pnlPlanchas";
            this.pnlPlanchas.Size = new System.Drawing.Size(1282, 416);
            this.pnlPlanchas.TabIndex = 0;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.pnlFooter.Controls.Add(this.btnVotarNulo);
            this.pnlFooter.Controls.Add(this.btnSalir);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(30, 586);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1322, 90);
            this.pnlFooter.TabIndex = 2;
            // 
            // btnVotarNulo
            // 
            this.btnVotarNulo.BackColor = System.Drawing.Color.White;
            this.btnVotarNulo.FlatAppearance.BorderSize = 2;
            this.btnVotarNulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVotarNulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnVotarNulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(55)))), ((int)(((byte)(150)))));
            this.btnVotarNulo.Location = new System.Drawing.Point(0, 20);
            this.btnVotarNulo.Name = "btnVotarNulo";
            this.btnVotarNulo.Size = new System.Drawing.Size(250, 50);
            this.btnVotarNulo.TabIndex = 0;
            this.btnVotarNulo.Text = "Votar en Blanco";
            this.btnVotarNulo.UseVisualStyleBackColor = false;
            this.btnVotarNulo.Click += new System.EventHandler(this.BtnVotarNulo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(2302, 20);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(220, 50);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Cerrar Sesión";
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.White;
            this.pnlInfo.Controls.Add(this.lblEstado);
            this.pnlInfo.Controls.Add(this.lblInstruccion);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Location = new System.Drawing.Point(30, 30);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.pnlInfo.Size = new System.Drawing.Size(1322, 100);
            this.pnlInfo.TabIndex = 3;
            // 
            // lblEstado
            // 
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(60)))));
            this.lblEstado.Location = new System.Drawing.Point(20, 15);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(1000, 30);
            this.lblEstado.TabIndex = 0;
            this.lblEstado.Text = "Votación activa";
            // 
            // lblInstruccion
            // 
            this.lblInstruccion.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblInstruccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.lblInstruccion.Location = new System.Drawing.Point(20, 55);
            this.lblInstruccion.Name = "lblInstruccion";
            this.lblInstruccion.Size = new System.Drawing.Size(1100, 30);
            this.lblInstruccion.TabIndex = 1;
            this.lblInstruccion.Text = "Seleccione una plancha para emitir su voto.";
            // 
            // FrmVotacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1382, 853);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize = new System.Drawing.Size(1400, 900);
            this.Name = "FrmVotacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Votaciones";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlHeader.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlPostVoto.ResumeLayout(false);
            this.pnlTopVotaciones.ResumeLayout(false);
            this.pnlBottomResultados.ResumeLayout(false);
            this.pnlPlanchasContainer.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private Panel pnlTopVotaciones;
        private Panel pnlBottomResultados;
    }
}