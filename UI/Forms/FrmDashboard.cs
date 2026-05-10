using SistemaVotacion.BLL;
using SistemaVotacion.Models;
using SistemaVotacion.Utils;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace SistemaVotacion.UI.Forms
{
    public partial class FrmDashboard : Form
    {
        private readonly VotacionService _svc = new();
        private Votacion? _votacion;

        public FrmDashboard()
        {
            InitializeComponent();

            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;

            AjustarTamanos();

            Cargar();

            timerDashboard.Interval = 3000;
            timerDashboard.Tick += (s, e) => Cargar();
            timerDashboard.Start();

            Resize += (s, e) => AjustarTamanos();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            timerDashboard.Stop();
            timerDashboard.Dispose();
            base.OnFormClosed(e);
        }

        private void Cargar()
        {
            _votacion = _svc.GetActiva();

            if (_votacion is null)
            {
                MostrarSinVotacion();
                return;
            }

            var stats = _svc.GetEstadisticas(_votacion.VotacionId);

            if (InvokeRequired)
            {
                Invoke(() => Actualizar(stats));
                return;
            }

            Actualizar(stats);
        }

        private void Actualizar(EstadisticasVotacion stats)
        {
            pnlStats.Controls.Clear();

            var cards = new[]
            {
                CrearTarjeta("Padrón Total", stats.TotalPadron.ToString(), "👥", AzulClaro),
                CrearTarjeta("Votos Emitidos", stats.TotalVotos.ToString(), "✓", Color.FromArgb(40, 160, 80)),
                CrearTarjeta("Votos Nulos", stats.VotosNulos.ToString(), "⚠", Rojo),
                CrearTarjeta("Sin Votar", stats.SinVotar.ToString(), "◷", Color.FromArgb(255, 145, 0))
            };

            foreach (var card in cards)
            {
                card.Margin = new Padding(0, 0, 15, 0);
                pnlStats.Controls.Add(card);
            }

            AjustarTamanos();

            if (_votacion is not null)
            {
                var tr = _votacion.TiempoRestante;
                lblTiempo.Text = Helpers.FormatearTiempo(tr);
                lblTiempo.ForeColor = tr.TotalMinutes < 10 ? Rojo : AzulClaro;
            }

            int pct = (int)stats.PorcentajeParticipacion;
            pbParticipacion.Value = Math.Min(pct, 100);

            lblPorcentaje.Text =
                $"Participación: {stats.PorcentajeParticipacion:F1}%   ({stats.TotalVotos} de {stats.TotalPadron})";

            pnlBarras.Controls.Clear();
            pnlBarras.Controls.Add(lblTituloBarras);

            int y = 75;

            if (!stats.PorPlancha.Any())
            {
                pnlBarras.Controls.Add(new Label
                {
                    Text = "Todavía no hay votos registrados por plancha.",
                    Font = new Font("Segoe UI", 11f),
                    ForeColor = TextoSuave,
                    Location = new Point(25, y),
                    Size = new Size(700, 35)
                });

                return;
            }

            foreach (var ep in stats.PorPlancha)
            {
                var card = new Panel
                {
                    BackColor = Color.White,
                    Location = new Point(25, y),
                    Size = new Size(pnlBarras.Width - 60, 95)
                };

                var logo = new PictureBox
                {
                    Location = new Point(15, 15),
                    Size = new Size(60, 60),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BackColor = Color.FromArgb(245, 247, 252)
                };

                if (!string.IsNullOrWhiteSpace(ep.LogoPath) && File.Exists(ep.LogoPath))
                {
                    using var imgTemp = Image.FromFile(ep.LogoPath);
                    logo.Image = new Bitmap(imgTemp);
                }

                var lblNombre = new Label
                {
                    Text = ep.Plancha,
                    Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold),
                    ForeColor = Texto,
                    Location = new Point(90, 12),
                    Size = new Size(350, 25)
                };

                var lblInfo = new Label
                {
                    Text = $"{ep.TotalVotos} votos • {ep.Porcentaje:F1}%",
                    Font = new Font("Segoe UI", 10f),
                    ForeColor = TextoSuave,
                    Location = new Point(90, 40),
                    Size = new Size(260, 22)
                };

                var barraBg = new Panel
                {
                    Location = new Point(90, 68),
                    Size = new Size(card.Width - 120, 10),
                    BackColor = Color.FromArgb(225, 230, 240)
                };

                var barra = new Panel
                {
                    Height = 10,
                    Width = (int)((card.Width - 120) * ((double)ep.Porcentaje / 100.0)),
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
                Invoke(MostrarSinVotacion);
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
            var p = new Panel
            {
                Size = new Size(220, 120),
                BackColor = Card
            };

            var barra = new Panel
            {
                Dock = DockStyle.Top,
                Height = 6,
                BackColor = color
            };

            var lblIcono = new Label
            {
                Text = icono,
                Font = new Font("Segoe UI Emoji", 24f, FontStyle.Bold),
                ForeColor = color,
                Location = new Point(15, 32),
                Size = new Size(55, 45),
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblValor = new Label
            {
                Text = valor,
                Font = new Font("Segoe UI", 27f, FontStyle.Bold),
                ForeColor = color,
                Location = new Point(75, 28),
                Size = new Size(120, 45),
                TextAlign = ContentAlignment.MiddleLeft
            };

            var lblTitulo = new Label
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