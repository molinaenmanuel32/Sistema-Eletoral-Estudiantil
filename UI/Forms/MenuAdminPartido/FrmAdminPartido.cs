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
        private Form formularioActivo = null;

        public FrmMenuAdminPartido(string usuario, int usuarioId)
        {
            InitializeComponent();

            _usuario   = usuario;
            _usuarioId = usuarioId;

            lblUser.Text = _usuario + "\nAdminPartido";

            ConstruirMenu();
            CargarInicio();
        }

        private void ConstruirMenu()
        {
            pnlMenu.Controls.Clear();

            pnlMenu.Controls.Add(CrearBotonMenu("⌂", "Inicio",         CargarInicio,    true));
            pnlMenu.Controls.Add(CrearBotonMenu("▣", "Dashboard",      CargarDashboard, false));
            pnlMenu.Controls.Add(CrearBotonMenu("▤", "Editar Plancha", CargarMiPlancha, false));
            pnlMenu.Controls.Add(CrearBotonMenu("▧", "Reportes",       CargarReportes,  false));
        }

        private Button CrearBotonMenu(string icono, string texto, Action accion, bool activo)
        {
            Button btn = new Button();
            btn.Text      = "  " + icono + "   " + texto;
            btn.Height    = 48;
            btn.Width     = 225;
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = activo ? Color.FromArgb(235, 35, 45) : Color.FromArgb(0, 32, 96);
            btn.ForeColor = Color.White;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Font      = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btn.Cursor    = Cursors.Hand;
            btn.Margin    = new Padding(0, 0, 0, 8);
            btn.UseVisualStyleBackColor = false;
            btn.FlatAppearance.BorderSize = 0;

            btn.MouseEnter += delegate
            {
                if (btn.BackColor != Color.FromArgb(235, 35, 45))
                    btn.BackColor = Color.FromArgb(0, 55, 150);
            };

            btn.MouseLeave += delegate
            {
                if (btn.BackColor != Color.FromArgb(235, 35, 45))
                    btn.BackColor = Color.FromArgb(0, 32, 96);
            };

            btn.Click += delegate
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
                if (c is Button)
                    ((Button)c).BackColor = Color.FromArgb(0, 32, 96);
            }
        }

        private void CargarInicio()
        {
            lblTitle.Text    = "Inicio";
            lblSubTitle.Text = "Panel administrativo para el Admin del Partido";

            if (formularioActivo != null)
            {
                formularioActivo.Close();
                formularioActivo.Dispose();
                formularioActivo = null;
            }

            pnlContent.Controls.Clear();

            Panel contenedor = new Panel();
            contenedor.Dock      = DockStyle.Fill;
            contenedor.BackColor = Color.FromArgb(245, 247, 252);
            contenedor.AutoScroll = true;

            Label lblBienvenido = new Label();
            lblBienvenido.Text     = "¡Bienvenido, " + _usuario + "!";
            lblBienvenido.Font     = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblBienvenido.ForeColor = Color.FromArgb(0, 32, 96);
            lblBienvenido.Location = new Point(40, 40);
            lblBienvenido.Size     = new Size(700, 60);

            Label lblTexto = new Label();
            lblTexto.Text      = "Panel de administración del partido";
            lblTexto.Font      = new Font("Segoe UI", 12F);
            lblTexto.ForeColor = Color.Gray;
            lblTexto.Location  = new Point(45, 100);
            lblTexto.Size      = new Size(500, 30);

            contenedor.Controls.Add(lblBienvenido);
            contenedor.Controls.Add(lblTexto);

            pnlContent.Controls.Add(contenedor);
        }

        private void AbrirFormulario(Form frm, string titulo, string subtitulo)
        {
            lblTitle.Text    = titulo;
            lblSubTitle.Text = subtitulo;

            if (formularioActivo != null)
            {
                formularioActivo.Close();
                formularioActivo.Dispose();
                formularioActivo = null;
            }

            pnlContent.Controls.Clear();

            frm.TopLevel         = false;
            frm.FormBorderStyle  = FormBorderStyle.None;
            frm.Dock             = DockStyle.Fill;

            formularioActivo = frm;

            pnlContent.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void CargarDashboard()
        {
            FrmDashboardPartido frm = new FrmDashboardPartido(_usuarioId);
            AbrirFormulario(frm, "Dashboard", "Resumen general de tu plancha");
        }

        private void CargarMiPlancha()
        {
            FrmEditarMiPlancha frm = new FrmEditarMiPlancha(_usuarioId);
            AbrirFormulario(frm, "Editar Plancha", "Administra la información de tu plancha");
        }

        private void CargarReportes()
        {
            Reportes frm = new Reportes(Sesion.UsuarioActual.UsuarioId);
            AbrirFormulario(frm, "Reportes", "Visualiza reportes del sistema");
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            if (!Helpers.Confirmar("¿Deseas cerrar la sesión?", "Cerrar Sesión"))
                return;

            Hide();

            FrmL login = new FrmL();
            login.Show();
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
