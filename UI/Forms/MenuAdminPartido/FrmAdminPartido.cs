using SistemaVotacion.BLL;
using SistemaVotacion.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    public partial class FrmMenuAdminPartido : Form
    {
        private readonly string _usuario;
        private readonly int _usuarioId;
<<<<<<< HEAD

        private Form formularioActivo = null;
=======
        private Form? formularioActivo = null;
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

        public FrmMenuAdminPartido(string usuario, int usuarioId)
        {
            InitializeComponent();

            _usuario = usuario;
            _usuarioId = usuarioId;

<<<<<<< HEAD
            lblUser.Text = _usuario + "\nAdminPartido";
=======
            lblUser.Text = $"{_usuario}\nAdminPartido";
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

            ConstruirMenu();
            CargarInicio();
        }

        private void ConstruirMenu()
        {
            pnlMenu.Controls.Clear();

            pnlMenu.Controls.Add(CrearBotonMenu("⌂", "Inicio", CargarInicio, true));
            pnlMenu.Controls.Add(CrearBotonMenu("▣", "Dashboard", CargarDashboard, false));
            pnlMenu.Controls.Add(CrearBotonMenu("▤", "Editar Plancha", CargarMiPlancha, false));
            pnlMenu.Controls.Add(CrearBotonMenu("▧", "Reportes", CargarReportes, false));
        }

        private Button CrearBotonMenu(string icono, string texto, Action accion, bool activo)
        {
<<<<<<< HEAD
            Button btn = new Button();

            btn.Text = "  " + icono + "   " + texto;
            btn.Height = 48;
            btn.Width = 225;
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = activo
                ? Color.FromArgb(235, 35, 45)
                : Color.FromArgb(0, 32, 96);

            btn.ForeColor = Color.White;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.Margin = new Padding(0, 0, 0, 8);
            btn.UseVisualStyleBackColor = false;

            btn.FlatAppearance.BorderSize = 0;

            btn.MouseEnter += delegate
=======
            var btn = new Button
            {
                Text = $"  {icono}   {texto}",
                Height = 48,
                Width = 225,
                FlatStyle = FlatStyle.Flat,
                BackColor = activo ? Color.FromArgb(235, 35, 45) : Color.FromArgb(0, 32, 96),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Margin = new Padding(0, 0, 0, 8),
                UseVisualStyleBackColor = false
            };

            btn.FlatAppearance.BorderSize = 0;

            btn.MouseEnter += (s, e) =>
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
            {
                if (btn.BackColor != Color.FromArgb(235, 35, 45))
                    btn.BackColor = Color.FromArgb(0, 55, 150);
            };

<<<<<<< HEAD
            btn.MouseLeave += delegate
=======
            btn.MouseLeave += (s, e) =>
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
            {
                if (btn.BackColor != Color.FromArgb(235, 35, 45))
                    btn.BackColor = Color.FromArgb(0, 32, 96);
            };

<<<<<<< HEAD
            btn.Click += delegate
=======
            btn.Click += (s, e) =>
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
            {
                DesmarcarBotones();
                btn.BackColor = Color.FromArgb(235, 35, 45);
                accion();
            };

            return btn;
        }

        private void DesmarcarBotones()
        {
            foreach (Control c in pnlMenu.Controls)
            {
<<<<<<< HEAD
                if (c is Button)
                {
                    ((Button)c).BackColor = Color.FromArgb(0, 32, 96);
                }
=======
                if (c is Button b)
                    b.BackColor = Color.FromArgb(0, 32, 96);
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
            }
        }

        private void CargarInicio()
        {
            lblTitle.Text = "Inicio";
            lblSubTitle.Text = "Panel administrativo para el Admin del Partido";

            if (formularioActivo != null)
            {
                formularioActivo.Close();
                formularioActivo.Dispose();
                formularioActivo = null;
            }

            pnlContent.Controls.Clear();

<<<<<<< HEAD
            Panel contenedor = new Panel();
            contenedor.Dock = DockStyle.Fill;
            contenedor.BackColor = Color.FromArgb(245, 247, 252);
            contenedor.AutoScroll = true;

            Label lblBienvenido = new Label();
            lblBienvenido.Text = "¡Bienvenido, " + _usuario + "!";
            lblBienvenido.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblBienvenido.ForeColor = Color.FromArgb(0, 32, 96);
            lblBienvenido.Location = new Point(40, 40);
            lblBienvenido.Size = new Size(700, 60);

            Label lblTexto = new Label();
            lblTexto.Text = "Panel de administración del partido";
            lblTexto.Font = new Font("Segoe UI", 12F);
            lblTexto.ForeColor = Color.Gray;
            lblTexto.Location = new Point(45, 100);
            lblTexto.Size = new Size(500, 30);

            contenedor.Controls.Add(lblBienvenido);
            contenedor.Controls.Add(lblTexto);

            pnlContent.Controls.Add(contenedor);
        }

=======
            var contenedor = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 247, 252),
                AutoScroll = true
            };

            var hero = new Panel
            {
                Location = new Point(35, 25),
                Size = new Size(900, 185),
                BackColor = Color.FromArgb(232, 241, 255)
            };

            var logoBox = new Label
            {
                Text = "V",
                Font = new Font("Segoe UI", 42F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(235, 35, 45),
                Location = new Point(35, 42),
                Size = new Size(105, 95),
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblBienvenido = new Label
            {
                Text = $"¡Bienvenido, {_usuario}!",
                Font = new Font("Segoe UI Semibold", 27F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 32, 96),
                Location = new Point(170, 42),
                Size = new Size(650, 55)
            };

            var lblDesc = new Label
            {
                Text = "Panel de Administración de Partido",
                Font = new Font("Segoe UI", 15F),
                ForeColor = Color.FromArgb(65, 82, 115),
                Location = new Point(174, 98),
                Size = new Size(520, 32)
            };

            var lblTexto = new Label
            {
                Text = "Administra tu plancha, revisa el dashboard y consulta tus reportes.",
                Font = new Font("Segoe UI", 10.5F),
                ForeColor = Color.FromArgb(95, 105, 125),
                Location = new Point(176, 132),
                Size = new Size(650, 28)
            };

            var decoracion = new Label
            {
                Text = "▰▰▰",
                Font = new Font("Segoe UI", 38F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 55, 150),
                Location = new Point(705, 60),
                Size = new Size(160, 70),
                TextAlign = ContentAlignment.MiddleCenter
            };

            hero.Controls.Add(logoBox);
            hero.Controls.Add(lblBienvenido);
            hero.Controls.Add(lblDesc);
            hero.Controls.Add(lblTexto);
            hero.Controls.Add(decoracion);

            contenedor.Controls.Add(hero);

            var grid = new TableLayoutPanel
            {
                Location = new Point(35, 245),
                Size = new Size(900, 155),
                ColumnCount = 3,
                RowCount = 1,
                BackColor = Color.Transparent
            };

            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            grid.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            grid.Controls.Add(CrearTarjeta("D", "Dashboard", "Consulta el resumen\nde tu partido.", Color.FromArgb(37, 99, 235), CargarDashboard), 0, 0);
            grid.Controls.Add(CrearTarjeta("P", "Editar Plancha", "Edita tu plancha y\nadministra miembros.", Color.FromArgb(34, 197, 94), CargarMiPlancha), 1, 0);
            grid.Controls.Add(CrearTarjeta("R", "Reportes", "Visualiza y descarga\nreportes del sistema.", Color.FromArgb(236, 72, 153), CargarReportes), 2, 0);

            contenedor.Controls.Add(grid);
            pnlContent.Controls.Add(contenedor);
        }

        private Panel CrearTarjeta(string letra, string titulo, string descripcion, Color color, Action accion)
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
                Text = letra,
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = color,
                AutoSize = false,
                Size = new Size(58, 58),
                Location = new Point(22, 36),
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblTitulo = new Label
            {
                Text = titulo,
                Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold),
                ForeColor = color,
                AutoSize = false,
                Size = new Size(175, 32),
                Location = new Point(100, 28),
                TextAlign = ContentAlignment.MiddleLeft
            };

            var lblDescripcion = new Label
            {
                Text = descripcion,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(70, 80, 100),
                AutoSize = false,
                Size = new Size(165, 55),
                Location = new Point(102, 65),
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
                DesmarcarBotones();
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

>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
        private void AbrirFormulario(Form frm, string titulo, string subtitulo)
        {
            lblTitle.Text = titulo;
            lblSubTitle.Text = subtitulo;

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
<<<<<<< HEAD

=======
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
            frm.BringToFront();
            frm.Show();
        }

        private void CargarDashboard()
        {
<<<<<<< HEAD
            FrmDashboardPartido frm = new FrmDashboardPartido(_usuarioId);

            AbrirFormulario(
                frm,
                "Dashboard",
                "Resumen general de tu plancha"
=======
            AbrirFormulario(
                new FrmDashboardPartido(_usuarioId),
                "Dashboard",
                "Resumen general de tu plancha y actividad del sistema"
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
            );
        }

        private void CargarMiPlancha()
        {
<<<<<<< HEAD
            FrmEditarMiPlancha frm = new FrmEditarMiPlancha(_usuarioId);

            AbrirFormulario(
                frm,
                "Editar Plancha",
                "Administra la información de tu plancha"
=======
            AbrirFormulario(
                new FrmEditarMiPlancha(_usuarioId),
                "Editar Plancha",
                "Administra la información y los miembros de tu plancha"
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
            );
        }

        private void CargarReportes()
        {
<<<<<<< HEAD
            FrmReportes frm = new FrmReportes(Sesion.UsuarioActual.UsuarioId);

            AbrirFormulario(
                frm,
                "Reportes",
                "Visualiza reportes del sistema"
=======
            AbrirFormulario(
                new Reportes(Sesion.UsuarioActual!.UsuarioId),
                "Reportes",
                "Visualiza y descarga reportes relacionados con el sistema"
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
            );
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            if (!Helpers.Confirmar("¿Deseas cerrar la sesión?", "Cerrar Sesión"))
                return;

            Hide();
<<<<<<< HEAD

            FrmL login = new FrmL();
            login.Show();
        }

        private void BtnLogout_MouseEnter(object sender, EventArgs e)
=======
            new FrmL().Show();
        }

        private void BtnLogout_MouseEnter(object? sender, EventArgs e)
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
        {
            btnLogout.BackColor = Color.FromArgb(220, 60, 60);
        }

<<<<<<< HEAD
        private void BtnLogout_MouseLeave(object sender, EventArgs e)
=======
        private void BtnLogout_MouseLeave(object? sender, EventArgs e)
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
        {
            btnLogout.BackColor = Color.FromArgb(235, 35, 45);
        }
    }
}