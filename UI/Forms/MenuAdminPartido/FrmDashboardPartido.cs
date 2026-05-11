using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
<<<<<<< HEAD

using SistemaVotacion.BLL;
using SistemaVotacion.Models;
using SistemaVotacion.Utils;
=======
using SistemaVotacion.BLL;
using SistemaVotacion.Models;
using SistemaVotacion.Utils;
using static System.Net.Mime.MediaTypeNames;
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

namespace SistemaVotacion.UI.Forms
{
    public partial class FrmDashboardPartido : Form
    {
<<<<<<< HEAD
        private readonly VotacionService _svc = new VotacionService();

        private readonly int _usuarioId;

        private int _planchaId;

        private Votacion _votacion;

        // COLORES
        private readonly Color AzulClaro = Color.FromArgb(52, 152, 219);

        private readonly Color Rojo = Color.FromArgb(231, 76, 60);

        private readonly Color Texto = Color.FromArgb(35, 35, 35);

        private readonly Color TextoSuave = Color.FromArgb(110, 110, 110);

        private readonly Color Card = Color.White;
=======
        private readonly VotacionService _svc = new();
        private readonly int _usuarioId;
        private int _planchaId;
        private Votacion? _votacion;
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

        public FrmDashboardPartido(int usuarioId)
        {
            InitializeComponent();

            _usuarioId = usuarioId;

            TopLevel = false;
<<<<<<< HEAD

            FormBorderStyle = FormBorderStyle.None;

            Dock = DockStyle.Fill;

            AutoScroll = true;

            AjustarTamanos();

            Cargar();

            timerDashboard.Interval = 3000;

            timerDashboard.Tick += delegate
            {
                Cargar();
            };

            timerDashboard.Start();

            Resize += delegate
            {
                AjustarTamanos();
            };
=======
            FormBorderStyle = FormBorderStyle.None;
            Dock = DockStyle.Fill;
            AutoScroll = true;

            AjustarTamanos();
            Cargar();

            timerDashboard.Interval = 3000;
            timerDashboard.Tick += (s, e) => Cargar();
            timerDashboard.Start();

            Resize += (s, e) => AjustarTamanos();
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            timerDashboard.Stop();
<<<<<<< HEAD

            timerDashboard.Dispose();

            base.OnFormClosed(e);
        }

        private void AjustarTamanos()
        {
            if (pnlStats != null)
            {
                pnlStats.Width = ClientSize.Width - 40;
            }

            if (pnlBarras != null)
            {
                pnlBarras.Width = ClientSize.Width - 40;
            }
        }

=======
            timerDashboard.Dispose();
            base.OnFormClosed(e);
        }

>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
        private void Cargar()
        {
            _votacion = _svc.GetActiva();

            if (_votacion == null)
            {
                MostrarSinVotacion();
                return;
            }

<<<<<<< HEAD
            EstadisticasVotacion stats = _svc.GetEstadisticas(_votacion.VotacionId);

            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate
                {
                    Actualizar(stats);
                }));

=======
            var stats = _svc.GetEstadisticas(_votacion.VotacionId);

            if (InvokeRequired)
            {
                Invoke(() => Actualizar(stats));
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
                return;
            }

            Actualizar(stats);
        }

        private void Actualizar(EstadisticasVotacion stats)
        {
            pnlStats.Controls.Clear();

<<<<<<< HEAD
            EstadisticaPlancha miPlancha = stats.PorPlancha.FirstOrDefault();

            int votosMiPlancha = 0;

            double porcentajeMiPlancha = 0;

            if (miPlancha != null)
            {
                votosMiPlancha = miPlancha.TotalVotos;
                porcentajeMiPlancha = (double)miPlancha.Porcentaje; // FIX: explicit cast
            }

            Panel[] cards =
            {
                CrearTarjeta("Padrón Total", stats.TotalPadron.ToString(), "👥", AzulClaro),

                CrearTarjeta("Votos Emitidos", stats.TotalVotos.ToString(), "✓",
                    Color.FromArgb(40, 160, 80)),

                CrearTarjeta("Votos Nulos", stats.VotosNulos.ToString(), "⚠", Rojo),

                CrearTarjeta("Sin Votar", stats.SinVotar.ToString(), "◷",
                    Color.FromArgb(255, 145, 0))
            };

            foreach (Panel card in cards)
            {
                card.Margin = new Padding(0, 0, 15, 0);

=======
            var miPlancha = stats.PorPlancha.FirstOrDefault();

            int votosMiPlancha = miPlancha?.TotalVotos ?? 0;
            double porcentajeMiPlancha = (double)(miPlancha?.Porcentaje ?? 0);

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
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
                pnlStats.Controls.Add(card);
            }

            AjustarTamanos();

<<<<<<< HEAD
            TimeSpan tr = _votacion.TiempoRestante;

            lblTiempo.Text = Helpers.FormatearTiempo(tr);

            lblTiempo.ForeColor = tr.TotalMinutes < 10
                ? Rojo
                : AzulClaro;

            int pct = (int)stats.PorcentajeParticipacion;

            pbParticipacion.Value = Math.Min(pct, 100);

            lblPorcentaje.Text =
                "Participación: " +
                stats.PorcentajeParticipacion.ToString("F1") +
                "%   (" +
                stats.TotalVotos +
                " de " +
                stats.TotalPadron +
                ")";

            pnlBarras.Controls.Clear();

=======
            var tr = _votacion.TiempoRestante;
            lblTiempo.Text = Helpers.FormatearTiempo(tr);
            lblTiempo.ForeColor = tr.TotalMinutes < 10 ? Rojo : AzulClaro;

            int pct = (int)stats.PorcentajeParticipacion;
            pbParticipacion.Value = Math.Min(pct, 100);

            lblPorcentaje.Text =
                $"Participación: {stats.PorcentajeParticipacion:F1}%   ({stats.TotalVotos} de {stats.TotalPadron})";

            pnlBarras.Controls.Clear();
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
            pnlBarras.Controls.Add(lblTituloBarras);

            int y = 75;

            if (!stats.PorPlancha.Any())
            {
                pnlBarras.Controls.Add(new Label
                {
                    Text = "Todavía no hay votos registrados.",
<<<<<<< HEAD

                    Font = new Font("Segoe UI", 11f),

                    ForeColor = TextoSuave,

                    Location = new Point(25, y),

=======
                    Font = new System.Drawing.Font("Segoe UI", 11f),
                    ForeColor = TextoSuave,
                    Location = new Point(25, y),
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
                    Size = new Size(700, 35)
                });

                return;
            }

<<<<<<< HEAD
            foreach (EstadisticaPlancha ep in stats.PorPlancha)
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

                if (!string.IsNullOrWhiteSpace(ep.LogoPath)
                    && File.Exists(ep.LogoPath))
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
                    Text = ep.TotalVotos + " votos • " +
                           ep.Porcentaje.ToString("F1") + "%",

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

                    Width = (int)((card.Width - 120)
                        * (double)(ep.Porcentaje / 100m)), // FIX: decimal division then cast to double

=======
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
                    using var imgTemp = System.Drawing.Image.FromFile(ep.LogoPath);
                    logo.Image = new Bitmap(imgTemp);
                }

                var lblNombre = new Label
                {
                    Text = ep.Plancha,
                    Font = new System.Drawing.Font("Segoe UI Semibold", 12f, System.Drawing.FontStyle.Bold),
                    ForeColor = Texto,
                    Location = new System.Drawing.Point(90, 12),
                    Size = new System.Drawing.Size(350, 25)
                };

                var lblInfo = new Label
                {
                    Text = $"{ep.TotalVotos} votos • {ep.Porcentaje:F1}%",
                    Font = new System.Drawing.Font("Segoe UI", 10f),
                    ForeColor = TextoSuave,
                    Location = new System.Drawing.Point(90, 40),
                    Size = new System.Drawing.Size(260, 22)
                };

                var barraBg = new Panel
                {
                    Location = new System.Drawing.Point(90, 68),
                    Size = new System.Drawing.Size(card.Width - 120, 10),
                    BackColor = Color.FromArgb(225, 230, 240)
                };

                var barra = new Panel
                {
                    Height = 10,
                    Width = (int)((card.Width - 120) * ((double)ep.Porcentaje / 100.0)),
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
                    BackColor = AzulClaro
                };

                barraBg.Controls.Add(barra);

                card.Controls.Add(logo);
<<<<<<< HEAD

                card.Controls.Add(lblNombre);

                card.Controls.Add(lblInfo);

=======
                card.Controls.Add(lblNombre);
                card.Controls.Add(lblInfo);
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
                card.Controls.Add(barraBg);

                pnlBarras.Controls.Add(card);

                y += 110;
            }
        }

        private void MostrarSinVotacion()
        {
            if (InvokeRequired)
            {
<<<<<<< HEAD
                Invoke(new MethodInvoker(MostrarSinVotacion));

=======
                Invoke(MostrarSinVotacion);
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
                return;
            }

            pnlStats.Controls.Clear();

            pnlStats.Controls.Add(new Label
            {
                Text = "No hay ninguna votación activa en este momento.",
<<<<<<< HEAD

                Font = new Font("Segoe UI", 15f, FontStyle.Bold),

                ForeColor = TextoSuave,

                Location = new Point(20, 35),

                Size = new Size(800, 45)
            });

            lblTiempo.Text = "--:--:--";

            pbParticipacion.Value = 0;

            lblPorcentaje.Text = "Participación: --";
        }

        private Panel CrearTarjeta(
            string titulo,
            string valor,
            string icono,
            Color color)
        {
            Panel p = new Panel
            {
                Size = new Size(220, 120),

                BackColor = Card
            };

            Panel barra = new Panel
            {
                Dock = DockStyle.Top,

                Height = 6,

                BackColor = color
            };

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

=======
                Font = new System.Drawing.Font("Segoe UI", 15f, System.Drawing.FontStyle.Bold),
                ForeColor = TextoSuave,
                Location = new System.Drawing.Point(20, 35),
                Size = new System.Drawing. Size(800, 45)
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
                Font = new System.Drawing.Font("Segoe UI Emoji", 24f, System.Drawing.FontStyle.Bold),
                ForeColor = color,
                Location = new System.Drawing.Point(15, 32),
                Size = new System.Drawing.Size(55, 45),
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };

            var lblValor = new Label
            {
                Text = valor,
                Font = new System.Drawing.Font("Segoe UI", 27f, System.Drawing.FontStyle.Bold),
                ForeColor = color,
                Location = new System.Drawing.Point(75, 28),
                Size = new System.Drawing.Size(120, 45),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };

            var lblTitulo = new Label
            {
                Text = titulo,
                Font = new System.Drawing.Font("Segoe UI Semibold", 9.5f, System.Drawing.FontStyle.Bold),
                ForeColor = TextoSuave,
                Location = new System.Drawing.Point(75, 75),
                Size = new System.Drawing.Size(135, 25),
                TextAlign = System.Drawing. ContentAlignment.MiddleLeft
            };

            p.Controls.Add(barra);
            p.Controls.Add(lblIcono);
            p.Controls.Add(lblValor);
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
            p.Controls.Add(lblTitulo);

            return p;
        }
    }
}