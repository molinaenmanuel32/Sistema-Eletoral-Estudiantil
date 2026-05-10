using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    partial class FrmDashboardPartido
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlCard;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Label lblInfo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlCard = new Panel();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            lblInfo = new Label();

            SuspendLayout();

            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(242, 245, 251);
            ClientSize = new Size(950, 620);

            pnlCard.BackColor = Color.White;
            pnlCard.Location = new Point(35, 35);
            pnlCard.Size = new Size(870, 190);

            lblTitulo.Text = "Dashboard Admin Partido";
            lblTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 45, 120);
            lblTitulo.Location = new Point(35, 30);
            lblTitulo.Size = new Size(600, 45);

            lblSubtitulo.Text = "Desde aquí puedes gestionar tu plancha, miembros y reportes.";
            lblSubtitulo.Font = new Font("Segoe UI", 13F);
            lblSubtitulo.ForeColor = Color.FromArgb(70, 80, 110);
            lblSubtitulo.Location = new Point(38, 85);
            lblSubtitulo.Size = new Size(700, 30);

            lblInfo.Text = "Panel exclusivo para la plancha";
            lblInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblInfo.ForeColor = Color.FromArgb(20, 110, 220);
            lblInfo.Location = new Point(38, 130);
            lblInfo.Size = new Size(700, 30);

            pnlCard.Controls.Add(lblTitulo);
            pnlCard.Controls.Add(lblSubtitulo);
            pnlCard.Controls.Add(lblInfo);

            Controls.Add(pnlCard);

            ResumeLayout(false);
        }
    }
}