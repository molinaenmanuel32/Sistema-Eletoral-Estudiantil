using System.Drawing;
using System.Windows.Forms;


namespace SistemaVotacion.UI.Forms
{
    partial class FrmMenuAdminPartido
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlSidebar;
        private Panel pnlBrand;
        private Panel pnlUser;
        private FlowLayoutPanel pnlMenu;
        private Panel pnlHeader;
        private Panel pnlContent;

        private Label lblLogo;
        private Label lblBrand;
        private Label lblUser;
        private Label lblTitle;
        private Label lblSubtitle;

        private Button btnDashboard;
        private Button btnMiPlancha;
        private Button btnMiembros;
        private Button btnReportes;
        private Button btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlSidebar = new Panel();
            pnlBrand = new Panel();
            lblLogo = new Label();
            lblBrand = new Label();
            pnlUser = new Panel();
            lblUser = new Label();
            pnlMenu = new FlowLayoutPanel();

            btnDashboard = new Button();
            btnMiPlancha = new Button();
            btnMiembros = new Button();
            btnReportes = new Button();
            btnLogout = new Button();

            pnlHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            pnlContent = new Panel();

            SuspendLayout();

            // FORM
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1260, 790);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Votaciones - Admin Partido";
            BackColor = Color.FromArgb(242, 245, 251);

            // SIDEBAR
            pnlSidebar.BackColor = Color.FromArgb(8, 48, 112);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Width = 250;

            // BRAND
            pnlBrand.Dock = DockStyle.Top;
            pnlBrand.Height = 150;
            pnlBrand.BackColor = Color.FromArgb(12, 72, 160);

            lblLogo.Text = "▣";
            lblLogo.Font = new Font("Segoe UI", 34F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            lblLogo.Dock = DockStyle.Top;
            lblLogo.Height = 70;

            lblBrand.Text = "VotaEscuela";
            lblBrand.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblBrand.ForeColor = Color.White;
            lblBrand.TextAlign = ContentAlignment.TopCenter;
            lblBrand.Dock = DockStyle.Fill;

            pnlBrand.Controls.Add(lblBrand);
            pnlBrand.Controls.Add(lblLogo);

            // USER
            pnlUser.Dock = DockStyle.Top;
            pnlUser.Height = 100;
            pnlUser.BackColor = Color.FromArgb(6, 42, 99);

            lblUser.Text = "Usuario\nAdminPartido";
            lblUser.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblUser.ForeColor = Color.White;
            lblUser.Location = new Point(35, 25);
            lblUser.Size = new Size(190, 60);

            pnlUser.Controls.Add(lblUser);

            // MENU
            pnlMenu.Dock = DockStyle.Top;
            pnlMenu.Height = 330;
            pnlMenu.Padding = new Padding(15, 25, 15, 0);
            pnlMenu.BackColor = Color.FromArgb(8, 48, 112);
            pnlMenu.FlowDirection = FlowDirection.TopDown;
            pnlMenu.WrapContents = false;

            ConfigButton(btnDashboard, "⌂   Dashboard");
            ConfigButton(btnMiPlancha, "✎   Editar mi plancha");
            ConfigButton(btnMiembros, "＋   Miembros");
            ConfigButton(btnReportes, "▣   Reportes");

            btnDashboard.Click += btnDashboard_Click;
            btnMiPlancha.Click += btnMiPlancha_Click;
            btnMiembros.Click += btnMiembros_Click;
            btnReportes.Click += btnReportes_Click;

            pnlMenu.Controls.Add(btnDashboard);
            pnlMenu.Controls.Add(btnMiPlancha);
            pnlMenu.Controls.Add(btnMiembros);
            pnlMenu.Controls.Add(btnReportes);

            // LOGOUT
            btnLogout.Text = "⎋  Cerrar Sesión";
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.Height = 65;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.BackColor = Color.FromArgb(237, 35, 45);
            btnLogout.ForeColor = Color.White;
            btnLogout.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.Click += btnLogout_Click;

            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Controls.Add(pnlMenu);
            pnlSidebar.Controls.Add(pnlUser);
            pnlSidebar.Controls.Add(pnlBrand);

            // HEADER
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 125;
            pnlHeader.BackColor = Color.White;

            lblTitle.Text = "Panel Admin Partido";
            lblTitle.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 45, 120);
            lblTitle.Location = new Point(35, 25);
            lblTitle.Size = new Size(600, 45);

            lblSubtitle.Text = "Gestiona tu plancha, miembros y reportes electorales";
            lblSubtitle.Font = new Font("Segoe UI", 12F);
            lblSubtitle.ForeColor = Color.FromArgb(78, 91, 125);
            lblSubtitle.Location = new Point(38, 75);
            lblSubtitle.Size = new Size(600, 25);

            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);

            // CONTENT
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.BackColor = Color.FromArgb(242, 245, 251);
            pnlContent.Padding = new Padding(25);

            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            Controls.Add(pnlSidebar);

            ResumeLayout(false);
        }

        private void ConfigButton(Button btn, string text)
        {
            btn.Text = text;
            btn.Width = 220;
            btn.Height = 55;
            btn.Margin = new Padding(0, 0, 0, 12);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.FromArgb(8, 48, 112);
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(18, 0, 0, 0);
            btn.Cursor = Cursors.Hand;
        }
    }
}