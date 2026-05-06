using System.Windows.Forms;
using System.Drawing;

namespace SistemaVotacion.UI.Forms
{
    partial class FrmVotacion
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Label lblBienvenido;
        private Label lblTitulo;
        private Label lblTiempo;
        private Label lblEstado;
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
            lblBienvenido = new Label();
            lblTitulo = new Label();
            lblTiempo = new Label();
            lblEstado = new Label();
            pnlPlanchas = new Panel();
            btnVotarNulo = new Button();
            btnSalir = new Button();

            SuspendLayout();

            // FORM
            Text = "Sistema de Votacion Escolar – Votar";
            Size = new Size(1100, 720);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(18, 18, 18);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            // HEADER
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 90;
            pnlHeader.BackColor = Color.FromArgb(192, 0, 0);

            // lblBienvenido
            lblBienvenido.AutoSize = true;
            lblBienvenido.Location = new Point(20, 15);
            lblBienvenido.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            lblBienvenido.ForeColor = Color.White;

            // lblTitulo
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(20, 42);
            lblTitulo.Font = new Font("Segoe UI", 16f, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;

            // lblTiempo
            lblTiempo.AutoSize = true;
            lblTiempo.Location = new Point(900, 30);
            lblTiempo.Font = new Font("Segoe UI", 20f, FontStyle.Bold);
            lblTiempo.ForeColor = Color.Gold;

            pnlHeader.Controls.Add(lblBienvenido);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Controls.Add(lblTiempo);

            // lblEstado
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(30, 110);
            lblEstado.Font = new Font("Segoe UI", 13f, FontStyle.Bold);
            lblEstado.ForeColor = Color.LightGreen;

            // pnlPlanchas
            pnlPlanchas.Location = new Point(20, 110);
            pnlPlanchas.Size = new Size(1040, 480);
            pnlPlanchas.BackColor = Color.FromArgb(18, 18, 18);
            pnlPlanchas.AutoScroll = true;

            // btnVotarNulo
            btnVotarNulo.Text = "Votar en BLANCO (Nulo)";
            btnVotarNulo.Location = new Point(20, 605);
            btnVotarNulo.Size = new Size(240, 48);
            btnVotarNulo.Click += BtnVotarNulo_Click;

            // btnSalir
            btnSalir.Text = "Cerrar Sesion";
            btnSalir.Location = new Point(940, 605);
            btnSalir.Size = new Size(140, 48);
            btnSalir.Click += BtnSalir_Click;

            // ADD
            Controls.Add(pnlHeader);
            Controls.Add(lblEstado);
            Controls.Add(pnlPlanchas);
            Controls.Add(btnVotarNulo);
            Controls.Add(btnSalir);

            ResumeLayout(false);
            PerformLayout();
        }
    }
}