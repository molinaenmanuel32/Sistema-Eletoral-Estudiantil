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
                    Height = 42,
                    Width = 200,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Tema.FondoPanel,
                    ForeColor = Tema.Texto,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Segoe UI", 10f),
                    Cursor = Cursors.Hand
                };

                btn.FlatAppearance.BorderSize = 0;

                // Hover
                btn.MouseEnter += (s, e) =>
                {
                    if (btn.BackColor != Tema.Primario)
                        btn.BackColor = Tema.FondoCard;
                };

                btn.MouseLeave += (s, e) =>
                {
                    if (btn.BackColor != Tema.Primario)
                        btn.BackColor = Tema.FondoPanel;
                };

                // Click
                btn.Click += (s, e) =>
                {
                    DesmarcarBotones();
                    btn.BackColor = Tema.Primario;
                    item.action();
                };

                pnlMenu.Controls.Add(btn);
            }
        }

        private void DesmarcarBotones()
        {
            foreach (Control c in pnlMenu.Controls)
                if (c is Button b)
                    b.BackColor = Tema.FondoPanel;
        }

        private void CambiarContenido(Control ctrl, string titulo)
        {
            lblTitle.Text = titulo;
            pnlContent.Controls.Clear();
            ctrl.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(ctrl);
        }

        // Navegación
        private void CargarDashboard() => CambiarContenido(new Controls.UcDashboard(), "Dashboard");
        private void CargarVotacion() => CambiarContenido(new Controls.UcVotacionAdmin(), "Votación");
        private void CargarPlanchas() => CambiarContenido(new Controls.UcPlanchas(), "Planchas");
        private void CargarUsuarios() => CambiarContenido(new Controls.UcUsuarios(), "Usuarios");
        private void CargarPadron() => CambiarContenido(new Controls.UcPadron(), "Padrón Electoral");
        private void CargarReportes() => CambiarContenido(new Controls.UcReportes(), "Reportes");
        private void CargarAuditoria() => CambiarContenido(new Controls.UcAuditoria(), "Auditoría");

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            if (!Helpers.Confirmar("¿Deseas cerrar la sesión?", "Cerrar Sesión")) return;

            _auth.Logout();
            new FrmL().Show(); // ← CORREGIDO
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