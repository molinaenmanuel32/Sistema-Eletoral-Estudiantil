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
                btn.Text = "  " + item.Item1 + "   " + item.Item2;
                btn.Height = 48;
                btn.Width = 225;
                btn.FlatStyle = FlatStyle.Flat;
                btn.ForeColor = Color.White;
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
                btn.Cursor = Cursors.Hand;
                btn.Margin = new Padding(0, 0, 0, 8);
                btn.FlatAppearance.BorderSize = 0;

                btn.BackColor = (item.Item2 == "Inicio")
                    ? Color.FromArgb(235, 35, 45)
                    : Color.FromArgb(0, 32, 96);

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
                    item.Item3();
                };

                pnlMenu.Controls.Add(btn);
            }
        }

        private void DesmarcarBotones()
        {
            foreach (Control c in pnlMenu.Controls)
                if (c is Button b)
                    b.BackColor = Color.FromArgb(0, 32, 96);
        }

        // ════════════════════════════════════════════════════════
        //  INICIO — banner + 6 tarjetas en 2 filas de 3
        // ════════════════════════════════════════════════════════
        private void CargarInicio()
        {
            lblTitle.Text = "Inicio";
            lblSubTitle.Text = "Panel de administración del sistema";

            if (formularioActivo != null)
            {
                formularioActivo.Close();
                formularioActivo.Dispose();
                formularioActivo = null;
            }

            pnlContent.Controls.Clear();

            Panel contenedor = new Panel();
            contenedor.Dock = DockStyle.Fill;
            contenedor.BackColor = Color.FromArgb(245, 247, 252);
            contenedor.AutoScroll = true;
            contenedor.Padding = new Padding(10);

            var user = Sesion.UsuarioActual;

            // ── BANNER ───────────────────────────────────────
            Panel pnlBanner = new Panel();
            pnlBanner.Location = new Point(10, 10);
            pnlBanner.Size = new Size(860, 120);
            pnlBanner.BackColor = Color.FromArgb(232, 240, 255);
            pnlBanner.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Cuadro blanco con check rojo
            Panel pnlCheck = new Panel();
            pnlCheck.Location = new Point(18, 15);
            pnlCheck.Size = new Size(88, 90);
            pnlCheck.BackColor = Color.White;

            Label lblCheck = new Label();
            lblCheck.Text = "v";
            lblCheck.Font = new Font("Wingdings 2", 52F, FontStyle.Bold);
            lblCheck.ForeColor = Color.FromArgb(235, 35, 45);
            lblCheck.Dock = DockStyle.Fill;
            lblCheck.TextAlign = ContentAlignment.MiddleCenter;
            pnlCheck.Controls.Add(lblCheck);

            Label lblBT = new Label();
            lblBT.Text = "¡Bienvenido!";
            lblBT.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblBT.ForeColor = Color.FromArgb(0, 32, 96);
            lblBT.Location = new Point(122, 14);
            lblBT.Size = new Size(500, 42);

            Label lblBS1 = new Label();
            lblBS1.Text = "Sistema de Votaciones Estudiantiles";
            lblBS1.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblBS1.ForeColor = Color.FromArgb(0, 32, 96);
            lblBS1.Location = new Point(122, 56);
            lblBS1.Size = new Size(500, 28);

            Label lblBS2 = new Label();
            lblBS2.Text = "Selecciona una opción del menú para comenzar.";
            lblBS2.Font = new Font("Segoe UI", 10F);
            lblBS2.ForeColor = Color.FromArgb(80, 100, 140);
            lblBS2.Location = new Point(122, 84);
            lblBS2.Size = new Size(500, 24);

            Label lblEscuela = new Label();
            lblEscuela.Text = "n";
            lblEscuela.Font = new Font("Wingdings", 64F);
            lblEscuela.ForeColor = Color.FromArgb(20, 20, 60);
            lblEscuela.Location = new Point(730, 4);
            lblEscuela.Size = new Size(110, 112);
            lblEscuela.TextAlign = ContentAlignment.MiddleCenter;

            pnlBanner.Controls.Add(pnlCheck);
            pnlBanner.Controls.Add(lblBT);
            pnlBanner.Controls.Add(lblBS1);
            pnlBanner.Controls.Add(lblBS2);
            pnlBanner.Controls.Add(lblEscuela);

            // ── TARJETAS fila 1 ───────────────────────────────
            var fila1 = new (string Titulo, string Desc, Color Color, Action Accion)[]
            {
                ("Votación",  "Gestiona y controla\nlas votaciones",      Color.FromArgb(111, 66, 193), CargarVotacion),
                ("Planchas",  "Administra las\nplanchas",                 Color.FromArgb( 40,167,  69), CargarPlanchas),
                ("Usuarios",  "Gestiona usuarios,\nroles",                Color.FromArgb(  0,123, 255), CargarUsuarios),
            };

            // ── TARJETAS fila 2 ───────────────────────────────
            var fila2 = new (string Titulo, string Desc, Color Color, Action Accion)[]
            {
                ("Padrón",    "Administra el padrón\nelectoral estudiantil.", Color.FromArgb(255,153,   0), CargarPadron   ),
                ("Reportes",  "Visualiza y descarga\nreportes del sistema.",  Color.FromArgb(220, 53, 130), CargarReportes ),
                ("Auditoría", "Consulta movimientos\ny registros.",           Color.FromArgb(108,117, 125), CargarAuditoria),
            };

            // Iconos Wingdings para cada tarjeta
            string[] icoFila1 = { "P", "2", "R" };
            string[] icoFila2 = { "H", "B", "F" };

            int cardW = 270;
            int cardH = 130;
            int gapX = 14;
            int startX = 10;

            for (int i = 0; i < fila1.Length; i++)
            {
                var t = fila1[i];
                Panel card = CrearTarjeta(icoFila1[i], t.Titulo, t.Desc, t.Color, t.Accion);
                card.Location = new Point(startX + i * (cardW + gapX), 148);
                card.Size = new Size(cardW, cardH);
                contenedor.Controls.Add(card);
            }

            for (int i = 0; i < fila2.Length; i++)
            {
                var t = fila2[i];
                Panel card = CrearTarjeta(icoFila2[i], t.Titulo, t.Desc, t.Color, t.Accion);
                card.Location = new Point(startX + i * (cardW + gapX), 292);
                card.Size = new Size(cardW, cardH);
                contenedor.Controls.Add(card);
            }

            contenedor.Controls.Add(pnlBanner);
            pnlContent.Controls.Add(contenedor);
        }

        private Panel CrearTarjeta(string icono, string titulo, string desc, Color colorAcento, Action accion)
        {
            Panel card = new Panel();
            card.BackColor = Color.White;
            card.Cursor = Cursors.Hand;

            Label lblIco = new Label();
            lblIco.Text = icono;
            lblIco.Font = new Font("Wingdings", 36F);
            lblIco.ForeColor = colorAcento;
            lblIco.Location = new Point(10, 18);
            lblIco.Size = new Size(66, 66);
            lblIco.TextAlign = ContentAlignment.MiddleCenter;

            Label lblTit = new Label();
            lblTit.Text = titulo;
            lblTit.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTit.ForeColor = colorAcento;
            lblTit.Location = new Point(84, 20);
            lblTit.Size = new Size(175, 28);

            Label lblDesc = new Label();
            lblDesc.Text = desc;
            lblDesc.Font = new Font("Segoe UI", 9.5F);
            lblDesc.ForeColor = Color.FromArgb(92, 105, 130);
            lblDesc.Location = new Point(84, 48);
            lblDesc.Size = new Size(175, 52);

            Panel barra = new Panel();
            barra.BackColor = colorAcento;
            barra.Dock = DockStyle.Bottom;
            barra.Height = 5;

            card.Controls.Add(barra);
            card.Controls.Add(lblIco);
            card.Controls.Add(lblTit);
            card.Controls.Add(lblDesc);

            void AgregarEventos(Control ctrl)
            {
                ctrl.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(245, 247, 255);
                ctrl.MouseLeave += (s, e) => card.BackColor = Color.White;
                ctrl.Click += (s, e) => { DesmarcarBotones(); accion(); };
                foreach (Control child in ctrl.Controls)
                    AgregarEventos(child);
            }
            AgregarEventos(card);

            return card;
        }

        private void AbrirFormulario(Form frm, string titulo)
        {
            lblTitle.Text = titulo;
            lblSubTitle.Text = "Gestión de " + titulo.ToLower();

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
            frm.Show();
        }

        private void CargarDashboard() => AbrirFormulario(new FrmDashboard(), "Dashboard");
        private void CargarVotacion() => AbrirFormulario(new VotacionAdmin(), "Votación");
        private void CargarPlanchas() => AbrirFormulario(new Planchas(), "Planchas");
        private void CargarUsuarios() => AbrirFormulario(new Usuarios(), "Usuarios");
        private void CargarPadron() => AbrirFormulario(new PadronElectoral(), "Padrón Electoral");
        private void CargarReportes() => AbrirFormulario(new FrmReportesAdmin(Sesion.UsuarioActual.UsuarioId), "Reportes");
        private void CargarAuditoria() => AbrirFormulario(new Auditoria(), "Auditoría");

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            if (!Helpers.Confirmar("¿Deseas cerrar sesión?"))
                return;

            _auth.Logout();

            FrmL login = new FrmL();
            login.Show();

            Close();
        }

        private void BtnLogout_MouseEnter(object sender, EventArgs e) =>
            btnLogout.BackColor = Color.FromArgb(220, 60, 60);

        private void BtnLogout_MouseLeave(object sender, EventArgs e) =>
            btnLogout.BackColor = Color.FromArgb(235, 35, 45);
    }
}