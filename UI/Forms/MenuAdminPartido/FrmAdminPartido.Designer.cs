using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    partial class FrmMenuAdminPartido
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlSidebar;
        private Panel pnlContent;
        private Panel pnlHeader;
        private Panel pnlMain;
        private FlowLayoutPanel pnlMenu;
        private Panel pnlBrand;
        private Panel pnlUserBox;
        private Panel pnlLine;

        private Label lblBrand;
        private Label lblTitle;
        private Label lblUser;
        private Label lblSubTitle;

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
            pnlMenu = new FlowLayoutPanel();
            lblUser = new Label();
            btnLogout = new Button();
            pnlBrand = new Panel();
            lblBrand = new Label();
            pnlUserBox = new Panel();
            pnlLine = new Panel();
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblSubTitle = new Label();
            pnlContent = new Panel();
            pnlMain = new Panel();

            pnlSidebar.SuspendLayout();
            pnlBrand.SuspendLayout();
            pnlUserBox.SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlMain.SuspendLayout();
            SuspendLayout();

            AutoScaleMode = AutoScaleMode.None;
            Text = "Sistema de Votaciones - Panel AdminPartido";
            Size = new Size(1280, 800);
            MinimumSize = new Size(1100, 700);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(245, 247, 252);

            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Width = 260;
            pnlSidebar.BackColor = Color.FromArgb(0, 32, 96);

            pnlBrand.Dock = DockStyle.Top;
            pnlBrand.Height = 150;
            pnlBrand.BackColor = Color.FromArgb(0, 55, 150);
            pnlBrand.Padding = new Padding(10);

            lblBrand.Dock = DockStyle.Fill;
            lblBrand.Text = "☑\nVotaEscuela\nVotaciones";
            lblBrand.ForeColor = Color.White;
            lblBrand.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblBrand.TextAlign = ContentAlignment.MiddleCenter;

            pnlBrand.Controls.Add(lblBrand);

            pnlUserBox.Dock = DockStyle.Top;
            pnlUserBox.Height = 100;
            pnlUserBox.BackColor = Color.FromArgb(0, 42, 115);

            lblUser.Dock = DockStyle.Fill;
            lblUser.Text = "👤 Usuario\nAdminPartido";
            lblUser.ForeColor = Color.White;
            lblUser.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblUser.TextAlign = ContentAlignment.MiddleCenter;

            pnlUserBox.Controls.Add(lblUser);

            pnlLine.Dock = DockStyle.Top;
            pnlLine.Height = 5;
            pnlLine.BackColor = Color.FromArgb(235, 35, 45);

            pnlMenu.Dock = DockStyle.Fill;
            pnlMenu.BackColor = Color.FromArgb(0, 32, 96);
            pnlMenu.FlowDirection = FlowDirection.TopDown;
            pnlMenu.WrapContents = false;
            pnlMenu.Padding = new Padding(15, 20, 15, 10);
            pnlMenu.AutoScroll = true;

            btnLogout.Text = "Cerrar Sesión";
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.Height = 62;
            btnLogout.BackColor = Color.FromArgb(235, 35, 45);
            btnLogout.ForeColor = Color.White;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += BtnLogout_Click;
            btnLogout.MouseEnter += BtnLogout_MouseEnter;
            btnLogout.MouseLeave += BtnLogout_MouseLeave;

            pnlSidebar.Controls.Add(pnlMenu);
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Controls.Add(pnlLine);
            pnlSidebar.Controls.Add(pnlUserBox);
            pnlSidebar.Controls.Add(pnlBrand);

            pnlMain.Dock = DockStyle.Fill;
            pnlMain.BackColor = Color.FromArgb(245, 247, 252);

            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 100;
            pnlHeader.BackColor = Color.White;
            pnlHeader.Padding = new Padding(35, 15, 35, 10);

            lblTitle.Text = "Inicio";
            lblTitle.Location = new Point(35, 20);
            lblTitle.Size = new Size(600, 38);
            lblTitle.ForeColor = Color.FromArgb(0, 32, 96);
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;

            lblSubTitle.Text = "Panel administrativo para el Admin del Partido";
            lblSubTitle.Location = new Point(38, 62);
            lblSubTitle.Size = new Size(850, 28);
            lblSubTitle.ForeColor = Color.FromArgb(92, 105, 130);
            lblSubTitle.Font = new Font("Segoe UI", 10.5F);
            lblSubTitle.TextAlign = ContentAlignment.MiddleLeft;

            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubTitle);

            pnlContent.Dock = DockStyle.Fill;
            pnlContent.BackColor = Color.FromArgb(245, 247, 252);
            pnlContent.AutoScroll = true;
            pnlContent.Padding = new Padding(25);

            pnlMain.Controls.Add(pnlContent);
            pnlMain.Controls.Add(pnlHeader);

            Controls.Add(pnlMain);
            Controls.Add(pnlSidebar);

            pnlMain.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlUserBox.ResumeLayout(false);
            pnlBrand.ResumeLayout(false);
            pnlSidebar.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}