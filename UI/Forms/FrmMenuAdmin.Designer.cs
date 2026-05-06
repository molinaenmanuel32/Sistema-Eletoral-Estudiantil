using System.Windows.Forms;
using System.Drawing;
using SistemaVotacion.Utils;

namespace SistemaVotacion.UI.Forms
{
    partial class FrmMenuAdmin
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlSidebar;
        private Panel pnlContent;
        private Panel pnlHeader;
        private Panel pnlMain;
        private FlowLayoutPanel pnlMenu;
        private Panel pnlBrand;
        private Label lblBrand;
        private Label lblTitle;
        private Label lblUser;
        private Button btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlSidebar = new Panel();
            pnlMenu = new FlowLayoutPanel();
            lblUser = new Label();
            btnLogout = new Button();
            pnlBrand = new Panel();
            lblBrand = new Label();

            pnlHeader = new Panel();
            lblTitle = new Label();

            pnlContent = new Panel();
            pnlMain = new Panel();

            SuspendLayout();

            // FORM
            Text = "Sistema de Votación Escolar – Menú Principal";
            Size = new Size(1280, 800);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(18, 18, 18); // fondo general oscuro

            // SIDEBAR
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Width = 230;
            pnlSidebar.BackColor = Color.FromArgb(30, 30, 30);

            // BRAND
            pnlBrand.Dock = DockStyle.Top;
            pnlBrand.Height = 80;
            pnlBrand.BackColor = Color.FromArgb(192, 0, 0); // rojo oscuro

            lblBrand.Text = "🗳️ VotaEscuela";
            lblBrand.Font = new Font("Segoe UI", 14f, FontStyle.Bold);
            lblBrand.ForeColor = Color.White;
            lblBrand.Dock = DockStyle.Fill;
            lblBrand.TextAlign = ContentAlignment.MiddleCenter;

            pnlBrand.Controls.Add(lblBrand);

            // USER
            lblUser.Dock = DockStyle.Top;
            lblUser.Height = 55;
            lblUser.TextAlign = ContentAlignment.MiddleCenter;
            lblUser.ForeColor = Color.LightGray;
            lblUser.BackColor = Color.FromArgb(35, 35, 35);
            lblUser.Padding = new Padding(5);

            // MENU
            pnlMenu.Dock = DockStyle.Fill;
            pnlMenu.FlowDirection = FlowDirection.TopDown;
            pnlMenu.WrapContents = false;
            pnlMenu.BackColor = Color.FromArgb(30, 30, 30);
            pnlMenu.Padding = new Padding(10, 5, 10, 5);

            // LOGOUT
            btnLogout.Text = "  🚪  Cerrar Sesión";
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.Height = 45;
            btnLogout.BackColor = Color.FromArgb(200, 40, 40);
            btnLogout.ForeColor = Color.White;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            btnLogout.Cursor = Cursors.Hand;

            btnLogout.MouseEnter += BtnLogout_MouseEnter;
            btnLogout.MouseLeave += BtnLogout_MouseLeave;

            btnLogout.Click += BtnLogout_Click;

            // SIDEBAR CONTROLS
            pnlSidebar.Controls.Add(pnlMenu);
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Controls.Add(lblUser);
            pnlSidebar.Controls.Add(pnlBrand);

            // HEADER
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 60;
            pnlHeader.BackColor = Color.FromArgb(25, 25, 25);
            pnlHeader.Padding = new Padding(20, 0, 20, 0);

            lblTitle.Text = "Dashboard";
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.ForeColor = Color.White;
            lblTitle.Font = new Font("Segoe UI", 16f, FontStyle.Bold);
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;

            pnlHeader.Controls.Add(lblTitle);

            // CONTENT
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.BackColor = Color.FromArgb(18, 18, 18);
            pnlContent.AutoScroll = true;
            pnlContent.Padding = new Padding(20);

            // MAIN
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(pnlContent);
            pnlMain.Controls.Add(pnlHeader);

            // ADD
            Controls.Add(pnlMain);
            Controls.Add(pnlSidebar);

            ResumeLayout(false);
        }
    }
}