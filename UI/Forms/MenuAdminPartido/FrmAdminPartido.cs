using SistemaVotacion.BLL;
using SistemaVotacion.Models;
using SistemaVotacion.Utils;
using System;
using System.Drawing;
using System.Linq;
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

            _usuario = usuario;
            _usuarioId = usuarioId;

            lblUser.Text = _usuario + "\nAdminPartido";

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
            Button btn = new Button();
            btn.Text = "  " + icono + "   " + texto;
            btn.Height = 48;
            btn.Width = 225;
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = activo ? Color.FromArgb(235, 35, 45) : Color.FromArgb(0, 32, 96);
            btn.ForeColor = Color.White;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.Margin = new Padding(0, 0, 0, 8);
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
            lblTitle.Text = "Inicio";
            lblSubTitle.Text = "Panel administrativo para el Admin del Partido";

            if (formularioActivo != null)
            {
                formularioActivo.Close();
                formularioActivo.Dispose();
                formularioActivo = null;
            }

            pnlContent.Controls.Clear();
            pnlContent.Padding = new Padding(0);

            Panel contenedor = new Panel();
            contenedor.Dock = DockStyle.Fill;
            contenedor.BackColor = Color.FromArgb(245, 247, 252);
            contenedor.AutoScroll = true;

            // ── Obtener datos reales de la plancha ─────────────────────
            var planchaService = new PlanchaService();
            var votacionService = new VotacionService();

            // Buscar la plancha que administra este usuario
            Plancha miPlancha = planchaService.GetAll()
                .FirstOrDefault(p => p.AdminUserId == _usuarioId);

            // Votación activa
            Votacion votacionActiva = votacionService.GetActiva();

            // ── Banner de bienvenida ───────────────────────────────────
            Panel banner = new Panel();
            banner.Location = new Point(30, 30);
            banner.Size = new Size(860, 90);
            banner.BackColor = Color.FromArgb(0, 32, 96);

            Label lblWelcome = new Label();
            lblWelcome.Text = "¡Bienvenido, " + _usuario + "!";
            lblWelcome.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.Location = new Point(24, 14);
            lblWelcome.Size = new Size(700, 36);
            lblWelcome.AutoSize = false;

            Label lblSubBanner = new Label();
            lblSubBanner.Text = miPlancha != null
                ? "Plancha: " + miPlancha.Nombre
                : "Aún no tienes una plancha registrada.";
            lblSubBanner.Font = new Font("Segoe UI", 10F);
            lblSubBanner.ForeColor = Color.FromArgb(160, 180, 214);
            lblSubBanner.Location = new Point(26, 54);
            lblSubBanner.Size = new Size(700, 22);
            lblSubBanner.AutoSize = false;

            banner.Controls.Add(lblWelcome);
            banner.Controls.Add(lblSubBanner);
            contenedor.Controls.Add(banner);

            if (miPlancha == null)
            {
                // ── Sin plancha: mensaje informativo ───────────────────
                Panel cardVacia = new Panel();
                cardVacia.Location = new Point(30, 140);
                cardVacia.Size = new Size(860, 120);
                cardVacia.BackColor = Color.White;

                Label lblSinPlancha = new Label();
                lblSinPlancha.Text = "No tienes una plancha asignada.";
                lblSinPlancha.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                lblSinPlancha.ForeColor = Color.FromArgb(0, 32, 96);
                lblSinPlancha.Location = new Point(24, 28);
                lblSinPlancha.Size = new Size(800, 30);
                lblSinPlancha.AutoSize = false;

                Label lblSinPlanchaDesc = new Label();
                lblSinPlanchaDesc.Text = "Contacta al administrador para que te asigne una plancha.";
                lblSinPlanchaDesc.Font = new Font("Segoe UI", 10F);
                lblSinPlanchaDesc.ForeColor = Color.FromArgb(140, 150, 170);
                lblSinPlanchaDesc.Location = new Point(26, 64);
                lblSinPlanchaDesc.Size = new Size(800, 22);
                lblSinPlanchaDesc.AutoSize = false;

                cardVacia.Controls.Add(lblSinPlancha);
                cardVacia.Controls.Add(lblSinPlanchaDesc);
                contenedor.Controls.Add(cardVacia);

                pnlContent.Controls.Add(contenedor);
                return;
            }

            // ── Obtener miembros y votos de la plancha ─────────────────
            var miembros = planchaService.GetMiembros(miPlancha.PlanchaId).ToList();

            int votosRecibidos = 0;
            int totalVotos = 0;
            int posicion = 0;

            if (votacionActiva != null)
            {
                try
                {
                    var stats = votacionService.GetEstadisticas(votacionActiva.VotacionId);
                    totalVotos = stats.TotalVotos;

                    var statPlancha = stats.PorPlancha
                        .FirstOrDefault(p => p.PlanchaId == miPlancha.PlanchaId);

                    if (statPlancha != null)
                        votosRecibidos = statPlancha.TotalVotos;

                    // Calcular posición
                    var ranking = stats.PorPlancha
                        .OrderByDescending(p => p.TotalVotos)
                        .ToList();

                    posicion = ranking.FindIndex(p => p.PlanchaId == miPlancha.PlanchaId) + 1;
                }
                catch { }
            }

            // ── Tarjetas de estadísticas ───────────────────────────────
            string[] titles = { "Miembros", "Votos recibidos", "Posición" };
            string[] values = {
        miembros.Count.ToString(),
        votosRecibidos.ToString(),
        posicion > 0 ? "#" + posicion : "-"
    };
            string[] subs = {
        "En tu plancha",
        votacionActiva != null ? "En votación activa" : "Sin votación activa",
        posicion > 0 ? "En el ranking actual" : "Sin datos aún"
    };
            Color[] colors = {
        Color.FromArgb(0, 32, 96),
        Color.FromArgb(235, 35, 45),
        Color.FromArgb(15, 110, 86)
    };

            for (int i = 0; i < 3; i++)
            {
                Panel card = new Panel();
                card.Location = new Point(30 + i * 210, 140);
                card.Size = new Size(190, 100);
                card.BackColor = Color.White;

                Label lTitle = new Label();
                lTitle.Text = titles[i];
                lTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
                lTitle.ForeColor = Color.FromArgb(120, 130, 155);
                lTitle.Location = new Point(12, 12);
                lTitle.Size = new Size(165, 18);
                lTitle.AutoSize = false;

                Label lVal = new Label();
                lVal.Text = values[i];
                lVal.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
                lVal.ForeColor = colors[i];
                lVal.Location = new Point(10, 30);
                lVal.Size = new Size(165, 44);
                lVal.AutoSize = false;

                Label lSub = new Label();
                lSub.Text = subs[i];
                lSub.Font = new Font("Segoe UI", 8.5F);
                lSub.ForeColor = Color.FromArgb(150, 160, 180);
                lSub.Location = new Point(12, 76);
                lSub.Size = new Size(165, 18);
                lSub.AutoSize = false;

                card.Controls.Add(lTitle);
                card.Controls.Add(lVal);
                card.Controls.Add(lSub);
                contenedor.Controls.Add(card);
            }

            // ── Info de la plancha ─────────────────────────────────────
            Panel cardPlancha = new Panel();
            cardPlancha.Location = new Point(30, 260);
            cardPlancha.Size = new Size(630, 100);
            cardPlancha.BackColor = Color.White;

            Label lNombrePlancha = new Label();
            lNombrePlancha.Text = miPlancha.Nombre;
            lNombrePlancha.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lNombrePlancha.ForeColor = Color.FromArgb(0, 32, 96);
            lNombrePlancha.Location = new Point(16, 14);
            lNombrePlancha.Size = new Size(590, 28);
            lNombrePlancha.AutoSize = false;

            Label lDescPlancha = new Label();
            lDescPlancha.Text = string.IsNullOrWhiteSpace(miPlancha.Descripcion)
                ? "Sin descripción registrada."
                : miPlancha.Descripcion;
            lDescPlancha.Font = new Font("Segoe UI", 9F);
            lDescPlancha.ForeColor = Color.FromArgb(140, 150, 170);
            lDescPlancha.Location = new Point(18, 46);
            lDescPlancha.Size = new Size(590, 40);
            lDescPlancha.AutoSize = false;

            cardPlancha.Controls.Add(lNombrePlancha);
            cardPlancha.Controls.Add(lDescPlancha);
            contenedor.Controls.Add(cardPlancha);

            // ── Estado votación ────────────────────────────────────────
            Panel cardVotacion = new Panel();
            cardVotacion.Location = new Point(670, 260);
            cardVotacion.Size = new Size(220, 100);
            cardVotacion.BackColor = votacionActiva != null
                ? Color.FromArgb(225, 245, 238)
                : Color.FromArgb(252, 235, 235);

            Label lVotLabel = new Label();
            lVotLabel.Text = "Votación";
            lVotLabel.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lVotLabel.ForeColor = Color.FromArgb(120, 130, 155);
            lVotLabel.Location = new Point(14, 14);
            lVotLabel.Size = new Size(190, 18);
            lVotLabel.AutoSize = false;

            Label lVotVal = new Label();
            lVotVal.Text = votacionActiva != null ? "Activa" : "Inactiva";
            lVotVal.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lVotVal.ForeColor = votacionActiva != null
                ? Color.FromArgb(15, 110, 86)
                : Color.FromArgb(163, 45, 45);
            lVotVal.Location = new Point(12, 34);
            lVotVal.Size = new Size(190, 36);
            lVotVal.AutoSize = false;

            Label lVotSub = new Label();
            lVotSub.Text = votacionActiva != null
                ? votacionActiva.Titulo
                : "Sin votación en curso";
            lVotSub.Font = new Font("Segoe UI", 8.5F);
            lVotSub.ForeColor = Color.FromArgb(150, 160, 180);
            lVotSub.Location = new Point(14, 72);
            lVotSub.Size = new Size(190, 18);
            lVotSub.AutoSize = false;

            cardVotacion.Controls.Add(lVotLabel);
            cardVotacion.Controls.Add(lVotVal);
            cardVotacion.Controls.Add(lVotSub);
            contenedor.Controls.Add(cardVotacion);

            // ── Accesos rápidos ────────────────────────────────────────
            string[] aTitles = { "Ver Dashboard", "Editar Plancha", "Ver Reportes" };
            string[] aDescs = { "Resumen de tu plancha", "Actualiza candidatos", "Estadísticas y resultados" };
            Color[] aBg = {
        Color.FromArgb(230, 241, 251),
        Color.FromArgb(252, 235, 235),
        Color.FromArgb(225, 245, 238)
    };
            Color[] aFg = {
        Color.FromArgb(0, 32, 96),
        Color.FromArgb(163, 45, 45),
        Color.FromArgb(15, 110, 86)
    };
            Action[] clicks = { CargarDashboard, CargarMiPlancha, CargarReportes };

            for (int i = 0; i < 3; i++)
            {
                int idx = i;
                Panel card = new Panel();
                card.Location = new Point(30 + i * 210, 380);
                card.Size = new Size(190, 80);
                card.BackColor = Color.White;
                card.Cursor = Cursors.Hand;

                Panel icon = new Panel();
                icon.Location = new Point(12, 18);
                icon.Size = new Size(40, 40);
                icon.BackColor = aBg[i];

                Label lTitle = new Label();
                lTitle.Text = aTitles[i];
                lTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                lTitle.ForeColor = aFg[i];
                lTitle.Location = new Point(62, 14);
                lTitle.Size = new Size(120, 22);
                lTitle.AutoSize = false;

                Label lDesc = new Label();
                lDesc.Text = aDescs[i];
                lDesc.Font = new Font("Segoe UI", 8.5F);
                lDesc.ForeColor = Color.FromArgb(140, 150, 170);
                lDesc.Location = new Point(62, 38);
                lDesc.Size = new Size(120, 32);
                lDesc.AutoSize = false;

                card.Controls.Add(icon);
                card.Controls.Add(lTitle);
                card.Controls.Add(lDesc);
                card.Click += (s, e) => { DesmarcarBotones(); clicks[idx](); };

                contenedor.Controls.Add(card);
            }

            pnlContent.Controls.Add(contenedor);
        }

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