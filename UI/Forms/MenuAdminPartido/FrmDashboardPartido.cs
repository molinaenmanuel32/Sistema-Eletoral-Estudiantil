using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SistemaVotacion.BLL;
using SistemaVotacion.Models;
using SistemaVotacion.Utils;

namespace SistemaVotacion.UI.Forms
{
    public partial class FrmDashboardPartido : Form
    {
        private readonly VotacionService _svc = new VotacionService();
        private readonly int _usuarioId;
        private int _planchaId;
        private Votacion _votacion;

        // Colores
        private readonly Color AzulClaro = Color.FromArgb(52, 152, 219);
        private readonly Color Rojo = Color.FromArgb(231, 76, 60);
        private readonly Color Texto = Color.FromArgb(35, 35, 35);
        private readonly Color TextoSuave = Color.FromArgb(110, 110, 110);
        private readonly Color Card = Color.White;

        public FrmDashboardPartido(int usuarioId)
        {
            InitializeComponent();

            _usuarioId = usuarioId;

            TopLevel = false;
            FormBorderStyle = FormBorderStyle.None;
            Dock = DockStyle.Fill;
            AutoScroll = true;

            AjustarTamanos();
            Cargar();

            timerDashboard.Interval = 3000;
            timerDashboard.Tick += delegate { Cargar(); };
            timerDashboard.Start();

            Resize += delegate { AjustarTamanos(); };
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            timerDashboard.Stop();
            timerDashboard.Dispose();
            base.OnFormClosed(e);
        }

        private void AjustarTamanos()
        {
            if (pnlStats != null) pnlStats.Width = ClientSize.Width - 40;
            if (pnlBarras != null) pnlBarras.Width = ClientSize.Width - 40;
        }

        private void Cargar()
        {
            _votacion = _svc.GetActiva();

            if (_votacion == null)
            {
                MostrarSinVotacion();
                return;
            }

            EstadisticasVotacion stats = _svc.GetEstadisticas(_votacion.VotacionId);

            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate { Actualizar(stats); }));
                return;
            }

            Actualizar(stats);
        }

        private void Actualizar(EstadisticasVotacion stats)
        {
            pnlStats.Controls.Clear();

            var miPlancha = stats.PorPlancha.FirstOrDefault();
            int votosMiPlancha = 0;
            double porcentajeMiPlancha = 0;

            if (miPlancha != null)
            {
                votosMiPlancha = miPlancha.TotalVotos;
                porcentajeMiPlancha = (double)miPlancha.Porcentaje;
            }

            Panel[] cards =
            {
                CrearTarjeta("Padrón Total",   stats.TotalPadron.ToString(), "👥", AzulClaro),
                CrearTarjeta("Votos Emitidos", stats.TotalVotos.ToString(),  "✓",  Color.FromArgb(40, 160, 80)),
                CrearTarjeta("Votos Nulos",    stats.VotosNulos.ToString(),  "⚠",  Rojo),
                CrearTarjeta("Sin Votar",      stats.SinVotar.ToString(),    "◷",  Color.FromArgb(255, 145, 0))
            };

            foreach (Panel card in cards)
            {
                card.Margin = new Padding(0, 0, 15, 0);
                pnlStats.Controls.Add(card);
            }

            AjustarTamanos();

            TimeSpan tr = _votacion.TiempoRestante;
            lblTiempo.Text = Helpers.FormatearTiempo(tr);
            lblTiempo.ForeColor = tr.TotalMinutes < 10 ? Rojo : AzulClaro;

            int pct = (int)stats.PorcentajeParticipacion;
            pbParticipacion.Value = Math.Min(pct, 100);

            lblPorcentaje.Text =
                "Participación: " + stats.PorcentajeParticipacion.ToString("F1") +
                "%   (" + stats.TotalVotos + " de " + stats.TotalPadron + ")";

            pnlBarras.Controls.Clear();
            pnlBarras.Controls.Add(lblTituloBarras);

            int y = 75;

            if (!stats.PorPlancha.Any())
            {
                pnlBarras.Controls.Add(new Label
                {
                    Text = "Todavía no hay votos registrados.",
                    Font = new Font("Segoe UI", 11f),
                    ForeColor = TextoSuave,
                    Location = new Point(25, y),
                    Size = new Size(700, 35)
                });
                return;
            }

            foreach (var ep in stats.PorPlancha)
            {
                Panel card = new Panel
                {
                    BackColor = Color.White,
                    Location = new Point(25, y),
                    Size = new Size(pnlBarras.Width - 60, 95)
                };

                PictureBox logo = new PictureBox
                {
                    Location = new Point(15, 15),
                    Size = new Size(60, 60),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BackColor = Color.FromArgb(245, 247, 252)
                };

                if (!string.IsNullOrWhiteSpace(ep.LogoPath) && File.Exists(ep.LogoPath))
                {
                    Image imgTemp = Image.FromFile(ep.LogoPath);
                    logo.Image = new Bitmap(imgTemp);
                }

                Label lblNombre = new Label
                {
                    Text = ep.Plancha,
                    Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold),
                    ForeColor = Texto,
                    Location = new Point(90, 12),
                    Size = new Size(350, 25)
                };

                Label lblInfo = new Label
                {
                    Text = ep.TotalVotos + " votos • " + ep.Porcentaje.ToString("F1") + "%",
                    Font = new Font("Segoe UI", 10f),
                    ForeColor = TextoSuave,
                    Location = new Point(90, 40),
                    Size = new Size(260, 22)
                };

                Panel barraBg = new Panel
                {
                    Location = new Point(90, 68),
                    Size = new Size(card.Width - 120, 10),
                    BackColor = Color.FromArgb(225, 230, 240)
                };

                Panel barra = new Panel
                {
                    Height = 10,
                    Width = (int)((card.Width - 120) * (double)(ep.Porcentaje / 100m)),
                    BackColor = AzulClaro
                };

                barraBg.Controls.Add(barra);
                card.Controls.Add(logo);
                card.Controls.Add(lblNombre);
                card.Controls.Add(lblInfo);
                card.Controls.Add(barraBg);
                pnlBarras.Controls.Add(card);

                y += 110;
            }
        }

        private void MostrarSinVotacion()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(MostrarSinVotacion));
                return;
            }

            pnlStats.Controls.Clear();

            pnlStats.Controls.Add(new Label
            {
                Text = "No hay ninguna votación activa en este momento.",
                Font = new Font("Segoe UI", 15f, FontStyle.Bold),
                ForeColor = TextoSuave,
                Location = new Point(20, 35),
                Size = new Size(800, 45)
            });

            lblTiempo.Text = "--:--:--";
            pbParticipacion.Value = 0;
            lblPorcentaje.Text = "Participación: --";
        }

        private Panel CrearTarjeta(string titulo, string valor, string icono, Color color)
        {
            Panel p = new Panel { Size = new Size(220, 120), BackColor = Card };

            Panel barra = new Panel { Dock = DockStyle.Top, Height = 6, BackColor = color };

            Label lblIcono = new Label
            {
                Text = icono,
                Font = new Font("Segoe UI Emoji", 24f, FontStyle.Bold),
                ForeColor = color,
                Location = new Point(15, 32),
                Size = new Size(55, 45),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblValor = new Label
            {
                Text = valor,
                Font = new Font("Segoe UI", 27f, FontStyle.Bold),
                ForeColor = color,
                Location = new Point(75, 28),
                Size = new Size(120, 45),
                TextAlign = ContentAlignment.MiddleLeft
            };

            Label lblTitulo = new Label
            {
                Text = titulo,
                Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold),
                ForeColor = TextoSuave,
                Location = new Point(75, 75),
                Size = new Size(135, 25),
                TextAlign = ContentAlignment.MiddleLeft
            };

            p.Controls.Add(barra);
            p.Controls.Add(lblIcono);
            p.Controls.Add(lblValor);
            p.Controls.Add(lblTitulo);

            return p;
        }
    }
}