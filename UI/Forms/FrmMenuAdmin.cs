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
        private Form? formularioActivo = null;

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
                ? $"👤 {user.NombreCompleto}\n{user.RolNombre}"
                : "👤 Usuario\nAdministrador";

            var menuItems = new List<(string icon, string text, Action action)>
            {
                ("⌂", "Inicio", new Action(CargarInicio)),
                ("▣", "Dashboard", new Action(CargarDashboard)),
                ("✓", "Votación", new Action(CargarVotacion)),
                ("▤", "Planchas", new Action(CargarPlanchas)),
                ("👥", "Usuarios", new Action(CargarUsuarios)),
                ("▦", "Padrón Electoral", new Action(CargarPadron)),
                ("▧", "Reportes", new Action(CargarReportes)),
                ("🔒", "Auditoría", new Action(CargarAuditoria)),
            };

            if (Sesion.EsAdminPartido)
            {
                menuItems = menuItems
                    .Where(x => new[] { "⌂", "▤", "▧" }.Contains(x.icon))
                    .ToList();
            }

            pnlMenu.Controls.Clear();

            foreach (var item in menuItems)
            {
                var btn = new Button
                {
                    Text = $"  {item.icon}   {item.text}",
                    Height = 48,
                    Width = 225,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = item.text == "Inicio"
                        ? Color.FromArgb(235, 35, 45)
                        : Color.FromArgb(0, 32, 96),
                    ForeColor = Color.White,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                    Cursor = Cursors.Hand,
                    Margin = new Padding(0, 0, 0, 8),
                    UseVisualStyleBackColor = false
                };

                btn.FlatAppearance.BorderSize = 0;

                btn.MouseEnter += (s, e) =>
                {
                    if (btn.BackColor != Color.FromArgb(235, 35, 45))
                        btn.BackColor = Color.FromArgb(0, 55, 150);
                };

                btn.MouseLeave += (s, e) =>
                {
                    if (btn.BackColor != Color.FromArgb(235, 35, 45))
                        btn.BackColor = Color.FromArgb(0, 32, 96);
                };

                btn.Click += (s, e) =>
                {
                    DesmarcarBotones();
                    btn.BackColor = Color.FromArgb(235, 35, 45);
                    item.action();
                };

                pnlMenu.Controls.Add(btn);
            }
        }

        private void DesmarcarBotones()
        {
            foreach (Control c in pnlMenu.Controls)
            {
                if (c is Button b)
                    b.BackColor = Color.FromArgb(0, 32, 96);
            }
        }

        private void CargarInicio()
        {
            lblTitle.Text = "Inicio";
            lblSubTitle.Text = "Panel administrativo del sistema de votaciones estudiantiles";

            if (formularioActivo != null)
            {
                formularioActivo.Close();
                formularioActivo.Dispose();
                formularioActivo = null;
            }

            pnlContent.Controls.Clear();

            var contenedor = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 247, 252),
                AutoScroll = true
            };

            var hero = new Panel
            {
                Location = new Point(35, 25),
                Size = new Size(900, 190),
                BackColor = Color.FromArgb(232, 241, 255)
            };

            var lblIconoHero = new Label
            {
                Text = "✓",
                Font = new Font("Segoe UI", 46F, FontStyle.Bold),
                ForeColor = Color.FromArgb(235, 35, 45),
                BackColor = Color.White,
                Location = new Point(35, 38),
                Size = new Size(120, 110),
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblBienvenido = new Label
            {
                Text = "¡Bienvenido!",
                Font = new Font("Segoe UI Semibold", 30F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 32, 96),
                Location = new Point(185, 45),
                Size = new Size(430, 55)
            };

            var lblDesc = new Label
            {
                Text = "Sistema de Votaciones Estudiantiles",
                Font = new Font("Segoe UI", 15F),
                ForeColor = Color.FromArgb(65, 82, 115),
                Location = new Point(190, 102),
                Size = new Size(500, 32)
            };

            var lblTexto = new Label
            {
                Text = "Selecciona una opción del menú para comenzar.",
                Font = new Font("Segoe UI", 10.5F),
                ForeColor = Color.FromArgb(95, 105, 125),
                Location = new Point(192, 137),
                Size = new Size(500, 28)
            };

            var lblEscuela = new Label
            {
                Text = "🏫",
                Font = new Font("Segoe UI Emoji", 72F),
                Location = new Point(700, 35),
                Size = new Size(150, 130),
                TextAlign = ContentAlignment.MiddleCenter
            };

            hero.Controls.Add(lblIconoHero);
            hero.Controls.Add(lblBienvenido);
            hero.Controls.Add(lblDesc);
            hero.Controls.Add(lblTexto);
            hero.Controls.Add(lblEscuela);

            contenedor.Controls.Add(hero);

            var grid = new TableLayoutPanel
            {
                Location = new Point(35, 245),
                Size = new Size(900, 310),
                ColumnCount = 3,
                RowCount = 2,
                BackColor = Color.Transparent
            };

            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));

            grid.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            grid.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            grid.Controls.Add(CrearTarjeta("✓", "Votación", "Gestiona y controla las\nvotaciones disponibles.", Color.FromArgb(111, 76, 255), CargarVotacion), 0, 0);
            grid.Controls.Add(CrearTarjeta("▤", "Planchas", "Administra las planchas\nelectorales del sistema.", Color.FromArgb(34, 197, 94), CargarPlanchas), 1, 0);
            grid.Controls.Add(CrearTarjeta("👥", "Usuarios", "Gestiona usuarios, roles\ny accesos del sistema.", Color.FromArgb(37, 99, 235), CargarUsuarios), 2, 0);

            grid.Controls.Add(CrearTarjeta("▦", "Padrón", "Administra el padrón\nelectoral estudiantil.", Color.FromArgb(245, 158, 11), CargarPadron), 0, 1);
            grid.Controls.Add(CrearTarjeta("▧", "Reportes", "Visualiza y descarga\nreportes del sistema.", Color.FromArgb(236, 72, 153), CargarReportes), 1, 1);
            grid.Controls.Add(CrearTarjeta("🔒", "Auditoría", "Consulta movimientos y\naccesos del sistema.", Color.FromArgb(100, 116, 139), CargarAuditoria), 2, 1);

            contenedor.Controls.Add(grid);

            pnlContent.Controls.Add(contenedor);
        }

        private Panel CrearTarjeta(string icono, string titulo, string descripcion, Color color, Action accion)
        {
            var card = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Margin = new Padding(10),
                Cursor = Cursors.Hand
            };

            var lblIcono = new Label
            {
                Text = icono,
                Font = new Font("Segoe UI Emoji", 30F, FontStyle.Bold),
                ForeColor = color,
                AutoSize = false,
                Size = new Size(70, 60),
                Location = new Point(18, 35),
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblTitulo = new Label
            {
                Text = titulo,
                Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold),
                ForeColor = color,
                AutoSize = false,
                Size = new Size(165, 32),
                Location = new Point(95, 28),
                TextAlign = ContentAlignment.MiddleLeft
            };

            var lblDescripcion = new Label
            {
                Text = descripcion,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(70, 80, 100),
                AutoSize = false,
                Size = new Size(160, 55),
                Location = new Point(97, 65),
                TextAlign = ContentAlignment.TopLeft
            };

            var lblFlecha = new Label
            {
                Text = "›",
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = color,
                AutoSize = false,
                Size = new Size(30, 35),
                Location = new Point(238, 88),
                TextAlign = ContentAlignment.MiddleCenter
            };

            var linea = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 4,
                BackColor = color
            };

            void ClickCard(object? s, EventArgs e)
            {
                accion();
            }

            card.Click += ClickCard;
            lblIcono.Click += ClickCard;
            lblTitulo.Click += ClickCard;
            lblDescripcion.Click += ClickCard;
            lblFlecha.Click += ClickCard;

            card.MouseEnter += (s, e) =>
            {
                card.BackColor = Color.FromArgb(248, 250, 255);
            };

            card.MouseLeave += (s, e) =>
            {
                card.BackColor = Color.White;
            };

            card.Controls.Add(lblIcono);
            card.Controls.Add(lblTitulo);
            card.Controls.Add(lblDescripcion);
            card.Controls.Add(lblFlecha);
            card.Controls.Add(linea);

            return card;
        }

        private void AbrirFormulario(Form frm, string titulo)
        {
            lblTitle.Text = titulo;
            lblSubTitle.Text = $"Gestión de {titulo.ToLower()} del sistema";

            if (formularioActivo != null)
            {
                formularioActivo.Close();
                formularioActivo.Dispose();
                formularioActivo = null;
            }

            pnlContent.Controls.Clear();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            formularioActivo = frm;

            pnlContent.Controls.Add(frm);
            frm.BringToFront();
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
<<<<<<< HEAD
            AbrirFormulario(new FrmReportes(Sesion.UsuarioActual!.UsuarioId), "Reportes");
=======
            AbrirFormulario(new Reportes(Sesion.UsuarioActual!.UsuarioId), "Reportes");
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
        }

        private void CargarAuditoria()
        {
            AbrirFormulario(new Auditoria(), "Auditoría");
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            if (!Helpers.Confirmar("¿Deseas cerrar la sesión?", "Cerrar Sesión"))
                return;

            _auth.Logout();

            FrmL login = new FrmL();
            login.Show();

            Close();
        }

        private void BtnLogout_MouseEnter(object? sender, EventArgs e)
        {
            btnLogout.BackColor = Color.FromArgb(220, 60, 60);
        }

        private void BtnLogout_MouseLeave(object? sender, EventArgs e)
        {
            btnLogout.BackColor = Color.FromArgb(235, 35, 45);
        }
    }
}