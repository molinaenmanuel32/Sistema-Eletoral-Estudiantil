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
        private Form formularioActivo = null;

        public FrmMenuAdmin()
        {
            InitializeComponent();
            ConstruirMenu();
            CargarInicio();
        }

        private void ConstruirMenu()
        {
            var user = Sesion.UsuarioActual;

            lblUser.Text = user != null
                ? "👤 " + user.NombreCompleto + "\n" + user.RolNombre
                : "👤 Usuario\nAdministrador";

            var menuItems = new List<Tuple<string, string, Action>>
            {
                Tuple.Create("⌂", "Inicio",           (Action)CargarInicio),
                Tuple.Create("▣", "Dashboard",         (Action)CargarDashboard),
                Tuple.Create("✓", "Votación",          (Action)CargarVotacion),
                Tuple.Create("▤", "Planchas",          (Action)CargarPlanchas),
                Tuple.Create("👥", "Usuarios",          (Action)CargarUsuarios),
                Tuple.Create("▦", "Padrón Electoral",  (Action)CargarPadron),
                Tuple.Create("▧", "Reportes",          (Action)CargarReportes),
                Tuple.Create("🔒", "Auditoría",         (Action)CargarAuditoria)
            };

            pnlMenu.Controls.Clear();

            foreach (var item in menuItems)
            {
                Button btn = new Button();
                btn.Text      = "  " + item.Item1 + "   " + item.Item2;
                btn.Height    = 48;
                btn.Width     = 225;
                btn.FlatStyle = FlatStyle.Flat;
                btn.ForeColor = Color.White;
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.Font      = new Font("Segoe UI", 10.5F, FontStyle.Bold);
                btn.Cursor    = Cursors.Hand;
                btn.Margin    = new Padding(0, 0, 0, 8);
                btn.FlatAppearance.BorderSize = 0;

                btn.BackColor = (item.Item2 == "Inicio")
                    ? Color.FromArgb(235, 35, 45)
                    : Color.FromArgb(0, 32, 96);

                btn.Click += delegate
                {
                    DesmarcarBotones();
                    btn.BackColor = Color.FromArgb(235, 35, 45);
                    item.Item3();
                };

                pnlMenu.Controls.Add(btn);
            }
        }

        private void DesmarcarBotones()
        {
            foreach (Control c in pnlMenu.Controls)
            {
                if (c is Button)
                    c.BackColor = Color.FromArgb(0, 32, 96);
            }
        }

        private void CargarInicio()
        {
            lblTitle.Text    = "Inicio";
            lblSubTitle.Text = "Panel de administración del sistema";

            if (formularioActivo != null)
            {
                formularioActivo.Close();
                formularioActivo.Dispose();
                formularioActivo = null;
            }

            pnlContent.Controls.Clear();

            Panel contenedor = new Panel();
            contenedor.Dock       = DockStyle.Fill;
            contenedor.BackColor  = Color.FromArgb(245, 247, 252);
            contenedor.AutoScroll = true;

            var user = Sesion.UsuarioActual;

            Label lblBienvenido = new Label();
            lblBienvenido.Text      = "¡Bienvenido, " + (user != null ? user.NombreCompleto : "Administrador") + "!";
            lblBienvenido.Font      = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblBienvenido.ForeColor = Color.FromArgb(0, 32, 96);
            lblBienvenido.Location  = new Point(40, 40);
            lblBienvenido.Size      = new Size(750, 60);

            Label lblTexto = new Label();
            lblTexto.Text      = "Panel de Administración del Sistema de Votaciones";
            lblTexto.Font      = new Font("Segoe UI", 12F);
            lblTexto.ForeColor = Color.Gray;
            lblTexto.Location  = new Point(45, 105);
            lblTexto.Size      = new Size(600, 30);

            contenedor.Controls.Add(lblBienvenido);
            contenedor.Controls.Add(lblTexto);

            pnlContent.Controls.Add(contenedor);
        }

        private void AbrirFormulario(Form frm, string titulo)
        {
            lblTitle.Text    = titulo;
            lblSubTitle.Text = "Gestión de " + titulo.ToLower();

            if (formularioActivo != null)
            {
                formularioActivo.Close();
                formularioActivo.Dispose();
                formularioActivo = null;
            }

            pnlContent.Controls.Clear();

            frm.TopLevel        = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock            = DockStyle.Fill;

            formularioActivo = frm;

            pnlContent.Controls.Add(frm);
            frm.Show();
        }

        private void CargarDashboard()
        {
            AbrirFormulario(new FrmDashboard(), "Dashboard");
        }

        private void CargarVotacion()
        {
            AbrirFormulario(new VotacionAdmin(), "Votación");
        }

        private void CargarPlanchas()
        {
            AbrirFormulario(new Planchas(), "Planchas");
        }

        private void CargarUsuarios()
        {
            AbrirFormulario(new Usuarios(), "Usuarios");
        }

        private void CargarPadron()
        {
            AbrirFormulario(new PadronElectoral(), "Padrón Electoral");
        }

        private void CargarReportes()
        {
            AbrirFormulario(new Reportes(Sesion.UsuarioActual.UsuarioId), "Reportes");
        }

        private void CargarAuditoria()
        {
            AbrirFormulario(new Auditoria(), "Auditoría");
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            if (!Helpers.Confirmar("¿Deseas cerrar sesión?"))
                return;

            _auth.Logout();

            FrmL login = new FrmL();
            login.Show();

            Close();
        }

        private void BtnLogout_MouseEnter(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.FromArgb(220, 60, 60);
        }

        private void BtnLogout_MouseLeave(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.FromArgb(235, 35, 45);
        }
    }
}
