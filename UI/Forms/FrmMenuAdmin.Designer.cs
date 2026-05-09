using System.Drawing;
using System.Windows.Forms;

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

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Text = "Sistema de Votaciones - Panel Administrativo";
            Size = new Size(1280, 800);
            MinimumSize = new Size(1100, 700);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(245, 247, 252);

            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Width = 250;
            pnlSidebar.BackColor = Color.FromArgb(0, 36, 105);
            pnlSidebar.Padding = new Padding(0);

            pnlBrand.Dock = DockStyle.Top;
            pnlBrand.Height = 120;
            pnlBrand.BackColor = Color.FromArgb(0, 55, 150);
            pnlBrand.Padding = new Padding(15, 10, 15, 10);

            lblBrand.Text = "🗳️\nVotaEscuela";
            lblBrand.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblBrand.ForeColor = Color.White;
            lblBrand.Dock = DockStyle.Fill;
            lblBrand.TextAlign = ContentAlignment.MiddleCenter;

            pnlBrand.Controls.Add(lblBrand);

            pnlUserBox.Dock = DockStyle.Top;
            pnlUserBox.Height = 95;
            pnlUserBox.BackColor = Color.FromArgb(0, 42, 115);
            pnlUserBox.Padding = new Padding(15, 12, 15, 12);

            lblUser.Dock = DockStyle.Fill;
            lblUser.TextAlign = ContentAlignment.MiddleCenter;
            lblUser.ForeColor = Color.White;
            lblUser.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblUser.BackColor = Color.Transparent;
            lblUser.Padding = new Padding(5);
            lblUser.Text = "👤 Usuario\nAdministrador";

            pnlUserBox.Controls.Add(lblUser);

            pnlLine.Dock = DockStyle.Top;
            pnlLine.Height = 5;
            pnlLine.BackColor = Color.FromArgb(230, 40, 45);

            pnlMenu.Dock = DockStyle.Fill;
            pnlMenu.FlowDirection = FlowDirection.TopDown;
            pnlMenu.WrapContents = false;
            pnlMenu.BackColor = Color.FromArgb(0, 36, 105);
            pnlMenu.Padding = new Padding(16, 20, 16, 10);
            pnlMenu.AutoScroll = true;

            btnLogout.Text = "🚪  Cerrar Sesión";
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.Height = 62;
            btnLogout.BackColor = Color.FromArgb(230, 40, 45);
            btnLogout.ForeColor = Color.White;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.TextAlign = ContentAlignment.MiddleCenter;
            btnLogout.Click += BtnLogout_Click;
            btnLogout.MouseEnter += BtnLogout_MouseEnter;
            btnLogout.MouseLeave += BtnLogout_MouseLeave;

            pnlSidebar.Controls.Add(pnlMenu);
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Controls.Add(pnlLine);
            pnlSidebar.Controls.Add(pnlUserBox);
            pnlSidebar.Controls.Add(pnlBrand);

            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 90;
            pnlHeader.BackColor = Color.White;
            pnlHeader.Padding = new Padding(28, 12, 28, 10);

            lblTitle.Text = "Inicio";
            lblTitle.AutoSize = false;
            lblTitle.Location = new Point(28, 15);
            lblTitle.Size = new Size(700, 38);
            lblTitle.ForeColor = Color.FromArgb(0, 36, 105);
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;

            lblSubTitle.Text = "Panel administrativo del sistema de votaciones estudiantiles";
            lblSubTitle.AutoSize = false;
            lblSubTitle.Location = new Point(31, 55);
            lblSubTitle.Size = new Size(800, 25);
            lblSubTitle.ForeColor = Color.FromArgb(95, 105, 125);
            lblSubTitle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblSubTitle.TextAlign = ContentAlignment.MiddleLeft;

            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubTitle);

            pnlContent.Dock = DockStyle.Fill;
            pnlContent.BackColor = Color.FromArgb(245, 247, 252);
            pnlContent.AutoScroll = true;
            pnlContent.Padding = new Padding(25);

            pnlMain.Dock = DockStyle.Fill;
            pnlMain.BackColor = Color.FromArgb(245, 247, 252);
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