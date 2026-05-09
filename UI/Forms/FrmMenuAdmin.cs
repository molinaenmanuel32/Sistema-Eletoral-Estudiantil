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
                : "Usuario no identificado";

            var menuItems = new List<(string icon, string text, Action action)>
            {
                ("🏠", "Inicio", new Action(CargarInicio)),
                ("📊", "Dashboard", new Action(CargarDashboard)),
                ("🗳️", "Votación", new Action(CargarVotacion)),
                ("📋", "Planchas", new Action(CargarPlanchas)),
                ("👥", "Usuarios", new Action(CargarUsuarios)),
                ("📜", "Padrón Electoral", new Action(CargarPadron)),
                ("📈", "Reportes", new Action(CargarReportes)),
                ("🔒", "Auditoría", new Action(CargarAuditoria)),
            };

            if (Sesion.EsAdminPartido)
            {
                menuItems = menuItems
                    .Where(x => new[] { "🏠", "📋", "📈" }.Contains(x.icon))
                    .ToList();
            }

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
            {
                if (c is Button b)
                    b.BackColor = Color.FromArgb(0, 36, 105);
            }
        }

        private void CargarInicio()
        {
            lblTitle.Text = "Inicio";

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

            var lblBienvenido = new Label
            {
                Text = "¡Bienvenido!",
                Font = new Font("Segoe UI Semibold", 26F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                AutoSize = true,
                Location = new Point(35, 30)
            };

            var lblDesc = new Label
            {
                Text = "Sistema de Votaciones Estudiantiles",
                Font = new Font("Segoe UI", 13F),
                ForeColor = Color.FromArgb(100, 116, 139),
                AutoSize = true,
                Location = new Point(38, 88)
            };

            var grid = new TableLayoutPanel
            {
                Location = new Point(35, 150),
                Size = new Size(900, 440),
                ColumnCount = 3,
                RowCount = 2,
                BackColor = Color.Transparent
            };



            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));

            grid.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            grid.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            grid.Controls.Add(CrearTarjeta("🗳️", "Votación", "Gestiona y controla las votaciones disponibles.", Color.FromArgb(111, 76, 255), CargarVotacion), 0, 0);
            grid.Controls.Add(CrearTarjeta("📋", "Planchas", "Administra las planchas electorales del sistema.", Color.FromArgb(34, 197, 94), CargarPlanchas), 1, 0);
            grid.Controls.Add(CrearTarjeta("👥", "Usuarios", "Gestiona usuarios, roles y accesos.", Color.FromArgb(37, 99, 235), CargarUsuarios), 2, 0);

            grid.Controls.Add(CrearTarjeta("📜", "Padrón", "Administra el padrón electoral estudiantil.", Color.FromArgb(245, 158, 11), CargarPadron), 0, 1);
            grid.Controls.Add(CrearTarjeta("📈", "Reportes", "Visualiza y descarga reportes del sistema.", Color.FromArgb(236, 72, 153), CargarReportes), 1, 1);
            grid.Controls.Add(CrearTarjeta("🔒", "Auditoría", "Consulta movimientos y accesos del sistema.", Color.FromArgb(100, 116, 139), CargarAuditoria), 2, 1);

            contenedor.Controls.Add(lblBienvenido);
            contenedor.Controls.Add(lblDesc);
            contenedor.Controls.Add(grid);

            pnlContent.Controls.Add(contenedor);
        }

        private Panel CrearTarjeta(string icono, string titulo, string descripcion, Color color, Action accion)
        {
            var card = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Margin = new Padding(12),
                Cursor = Cursors.Hand
            };

            var lblIcono = new Label
            {
                Text = icono,
                Font = new Font("Segoe UI Emoji", 42F),
                ForeColor = color,
                AutoSize = false,
                Size = new Size(120, 80),
                Location = new Point(75, 18),
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblTitulo = new Label
            {
                Text = titulo,
                Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold),
                ForeColor = color,
                AutoSize = false,
                Size = new Size(240, 38),
                Location = new Point(15, 100),
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblDescripcion = new Label
            {
                Text = descripcion,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(90, 95, 110),
                AutoSize = false,
                Size = new Size(230, 55),
                Location = new Point(20, 140),
                TextAlign = ContentAlignment.TopCenter
            };

            var lblFlecha = new Label
            {
                Text = "›",
                Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                ForeColor = color,
                AutoSize = false,
                Size = new Size(30, 35),
                Location = new Point(228, 158),
                TextAlign = ContentAlignment.MiddleCenter
            };

            void ClickCard(object? s, EventArgs e) => accion();

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

            return card;
        }


        private void AbrirFormulario(Form frm, string titulo)
        {
            lblTitle.Text = titulo;

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
            AbrirFormulario(new Reportes(), "Reportes");
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
            btnLogout.BackColor = Color.FromArgb(200, 40, 40);
        }
    }
}