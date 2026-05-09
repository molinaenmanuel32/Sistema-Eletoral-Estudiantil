using SistemaVotacion.BLL;
using SistemaVotacion.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    public partial class FrmMenuAdmin : Form
    {
        private readonly AuthService _auth = new AuthService();

        public FrmMenuAdmin()
        {
            InitializeComponent();

            // Eventos fuera del Designer
            btnLogout.MouseEnter += BtnLogout_MouseEnter;
            btnLogout.MouseLeave += BtnLogout_MouseLeave;

            CargarDashboard();
            ConstruirMenu();
        }

        private void ConstruirMenu()
        {
            // Validación usuario
            var user = Sesion.UsuarioActual;
            lblUser.Text = user != null
                ? $"👤 {user.NombreCompleto}\n{user.RolNombre}"
                : "Usuario no identificado";

            var menuItems = new List<(string icon, string text, Action action)>
            {
                ("📊", "Dashboard", () => CargarDashboard()),
                ("🗳️", "Votación", () => CargarVotacion()),
                ("📋", "Planchas", () => CargarPlanchas()),
                ("👥", "Usuarios", () => CargarUsuarios()),
                ("📜", "Padrón Electoral", () => CargarPadron()),
                ("📈", "Reportes", () => CargarReportes()),
                ("🔒", "Auditoría", () => CargarAuditoria()),
            };

            // Filtrado por rol
            if (Sesion.EsAdminPartido)
                menuItems = menuItems
                    .Where(x => new[] { "📊", "📋", "📈" }.Contains(x.icon))
                    .ToList();

            pnlMenu.Controls.Clear();

            foreach (var item in menuItems)
            {
                var btn = new Button
                {
                    Text = $"  {item.icon}  {item.text}",
                    Height = 48,
                    Width = 215,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(0, 36, 105),
                    ForeColor = Color.White,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Segoe UI", 10.5f, FontStyle.Bold),
                    Cursor = Cursors.Hand,
                    Margin = new Padding(0, 0, 0, 8),
                    UseVisualStyleBackColor = false
                };

                btn.FlatAppearance.BorderSize = 0;

                btn.MouseEnter += (s, e) =>
                {
                    if (btn.BackColor != Color.FromArgb(0, 95, 220))
                        btn.BackColor = Color.FromArgb(0, 55, 150);
                };

                btn.MouseLeave += (s, e) =>
                {
                    if (btn.BackColor != Color.FromArgb(0, 95, 220))
                        btn.BackColor = Color.FromArgb(0, 36, 105);
                };

                btn.Click += (s, e) =>
                {
                    DesmarcarBotones();
                    btn.BackColor = Color.FromArgb(0, 95, 220);
                    item.action();
                };

                pnlMenu.Controls.Add(btn);
            }
        }

        private void DesmarcarBotones()
        {
            foreach (Control c in pnlMenu.Controls)
                if (c is Button b)
                    b.BackColor = Color.FromArgb(0, 36, 105);
        }

        private void CambiarContenido(Control ctrl, string titulo)
        {
            lblTitle.Text = titulo;
            pnlContent.Controls.Clear();
            ctrl.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(ctrl);
        }

        // Navegación
        private void CargarDashboard()
        {
            lblTitle.Text = "Dashboard";

            pnlContent.Controls.Clear();

            FrmDashboard frm = new FrmDashboard();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            pnlContent.Controls.Add(frm);

            frm.Show();
        }

        private void CargarVotacion()
        {
            lblTitle.Text = "Votación";

            pnlContent.Controls.Clear();

            VotacionAdmin frm = new VotacionAdmin
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            pnlContent.Controls.Add(frm);
            frm.Show();
        }

        private void CargarPlanchas()
        {
            lblTitle.Text = "Planchas";

            pnlContent.Controls.Clear();

            Planchas frm = new Planchas
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            pnlContent.Controls.Add(frm);
            frm.Show();
        }
        private void CargarUsuarios()
        {
            lblTitle.Text = "Usuarios";

            pnlContent.Controls.Clear();

            Usuarios frm = new Usuarios
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            pnlContent.Controls.Add(frm);
            frm.Show();
        }
        private void CargarPadron() => CambiarContenido(new Controls.UcPadron(), "Padrón Electoral");
        private void CargarReportes() => CambiarContenido(new Controls.UcReportes(), "Reportes");
        private void CargarAuditoria() => CambiarContenido(new Controls.UcAuditoria(), "Auditoría");

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            if (!Helpers.Confirmar("¿Deseas cerrar la sesión?", "Cerrar Sesión")) return;

            _auth.Logout();

            FrmL login = new FrmL();
            login.Show();

            this.Close();
        }

        private void BtnLogout_MouseEnter(object? sender, EventArgs e)
        {
            btnLogout.BackColor = Color.FromArgb(220, 60, 60);
        }

        private void BtnLogout_MouseLeave(object? sender, EventArgs e)
        {
            btnLogout.BackColor = Color.FromArgb(200, 40, 40);
        }
    }
}