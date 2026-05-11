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
<<<<<<< HEAD
        private readonly VotacionService _svc = new VotacionService();
        private Votacion _votacion;
=======
        private readonly VotacionService _svc = new();
        private Votacion? _votacion;
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

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
<<<<<<< HEAD
            timerDashboard.Tick += TimerDashboard_Tick;
            timerDashboard.Start();

            this.Resize += FrmDashboard_Resize;
        }

        private void TimerDashboard_Tick(object sender, EventArgs e)
        {
            Cargar();
        }

        private void FrmDashboard_Resize(object sender, EventArgs e)
        {
            AjustarTamanos();
=======
            timerDashboard.Tick += (s, e) => Cargar();
            timerDashboard.Start();

            Resize += (s, e) => AjustarTamanos();
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            timerDashboard.Stop();
            timerDashboard.Dispose();
<<<<<<< HEAD

=======
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
            base.OnFormClosed(e);
        }

        private void Cargar()
        {
            _votacion = _svc.GetActiva();

<<<<<<< HEAD
            if (_votacion == null)
=======
            if (_votacion is null)
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
            {
                MostrarSinVotacion();
                return;
            }

<<<<<<< HEAD
            EstadisticasVotacion stats =
                _svc.GetEstadisticas(_votacion.VotacionId);

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
            Panel[] cards =
            {
                CrearTarjeta(
                    "Padrón Total",
                    stats.TotalPadron.ToString(),
                    "👥",
                    AzulClaro),

                CrearTarjeta(
                    "Votos Emitidos",
                    stats.TotalVotos.ToString(),
                    "✓",
                    Color.FromArgb(40,160,80)),

                CrearTarjeta(
                    "Votos Nulos",
                    stats.VotosNulos.ToString(),
                    "⚠",
                    Rojo),

                CrearTarjeta(
                    "Sin Votar",
                    stats.SinVotar.ToString(),
                    "◷",
                    Color.FromArgb(255,145,0))
            };

            foreach (Panel card in cards)
=======
            var cards = new[]
            {
                CrearTarjeta("Padrón Total", stats.TotalPadron.ToString(), "👥", AzulClaro),
                CrearTarjeta("Votos Emitidos", stats.TotalVotos.ToString(), "✓", Color.FromArgb(40, 160, 80)),
                CrearTarjeta("Votos Nulos", stats.VotosNulos.ToString(), "⚠", Rojo),
                CrearTarjeta("Sin Votar", stats.SinVotar.ToString(), "◷", Color.FromArgb(255, 145, 0))
            };

            foreach (var card in cards)
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
            {
                card.Margin = new Padding(0, 0, 15, 0);
                pnlStats.Controls.Add(card);
            }

            AjustarTamanos();

<<<<<<< HEAD
            if (_votacion != null)
            {
                TimeSpan tr = _votacion.TiempoRestante;

                lblTiempo.Text = Helpers.FormatearTiempo(tr);

                lblTiempo.ForeColor =
                    tr.TotalMinutes < 10
                    ? Rojo
                    : AzulClaro;
            }

            int pct = (int)stats.PorcentajeParticipacion;

            pbParticipacion.Value = Math.Min(pct, 100);

            lblPorcentaje.Text =
                "Participación: "
                + stats.PorcentajeParticipacion.ToString("F1")
                + "%   ("
                + stats.TotalVotos
                + " de "
                + stats.TotalPadron
                + ")";

            pnlBarras.Controls.Clear();

=======
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
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
            pnlBarras.Controls.Add(lblTituloBarras);

            int y = 75;

            if (!stats.PorPlancha.Any())
            {
<<<<<<< HEAD
                Label lbl = new Label();

                lbl.Text =
                    "Todavía no hay votos registrados por plancha.";

                lbl.Font = new Font("Segoe UI", 11f);

                lbl.ForeColor = TextoSuave;

                lbl.Location = new Point(25, y);

                lbl.Size = new Size(700, 35);

                pnlBarras.Controls.Add(lbl);
=======
                pnlBarras.Controls.Add(new Label
                {
                    Text = "Todavía no hay votos registrados por plancha.",
                    Font = new Font("Segoe UI", 11f),
                    ForeColor = TextoSuave,
                    Location = new Point(25, y),
                    Size = new Size(700, 35)
                });
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

                return;
            }

            foreach (var ep in stats.PorPlancha)
            {
<<<<<<< HEAD
                Panel card = new Panel();

                card.BackColor = Color.White;
                card.Location = new Point(25, y);
                card.Size = new Size(pnlBarras.Width - 60, 95);

                PictureBox logo = new PictureBox();

                logo.Location = new Point(15, 15);
                logo.Size = new Size(60, 60);
                logo.SizeMode = PictureBoxSizeMode.Zoom;
                logo.BackColor = Color.FromArgb(245, 247, 252);

                if (!string.IsNullOrWhiteSpace(ep.LogoPath)
                    && File.Exists(ep.LogoPath))
                {
                    Image imgTemp = Image.FromFile(ep.LogoPath);

                    logo.Image = new Bitmap(imgTemp);
                }

                Label lblNombre = new Label();

                lblNombre.Text = ep.Plancha;
                lblNombre.Font =
                    new Font("Segoe UI Semibold", 12f, FontStyle.Bold);

                lblNombre.ForeColor = Texto;
                lblNombre.Location = new Point(90, 12);
                lblNombre.Size = new Size(350, 25);

                Label lblInfo = new Label();

                lblInfo.Text =
                    ep.TotalVotos
                    + " votos • "
                    + ep.Porcentaje.ToString("F1")
                    + "%";

                lblInfo.Font = new Font("Segoe UI", 10f);
                lblInfo.ForeColor = TextoSuave;
                lblInfo.Location = new Point(90, 40);
                lblInfo.Size = new Size(260, 22);

                Panel barraBg = new Panel();

                barraBg.Location = new Point(90, 68);
                barraBg.Size = new Size(card.Width - 120, 10);
                barraBg.BackColor = Color.FromArgb(225, 230, 240);

                Panel barra = new Panel();

                barra.Height = 10;

                barra.Width =
                    (int)((card.Width - 120)
                    * ((double)ep.Porcentaje / 100.0));

                barra.BackColor = AzulClaro;
=======
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
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

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
<<<<<<< HEAD
                Invoke(new MethodInvoker(MostrarSinVotacion));
=======
                Invoke(MostrarSinVotacion);
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
                return;
            }

            pnlStats.Controls.Clear();

<<<<<<< HEAD
            Label lbl = new Label();

            lbl.Text =
                "No hay ninguna votación activa en este momento.";

            lbl.Font =
                new Font("Segoe UI", 15f, FontStyle.Bold);

            lbl.ForeColor = TextoSuave;

            lbl.Location = new Point(20, 35);

            lbl.Size = new Size(800, 45);

            pnlStats.Controls.Add(lbl);

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
            Panel p = new Panel();

            p.Size = new Size(220, 120);
            p.BackColor = Card;

            Panel barra = new Panel();

            barra.Dock = DockStyle.Top;
            barra.Height = 6;
            barra.BackColor = color;

            Label lblIcono = new Label();

            lblIcono.Text = icono;

            lblIcono.Font =
                new Font("Segoe UI Emoji", 24f, FontStyle.Bold);

            lblIcono.ForeColor = color;

            lblIcono.Location = new Point(15, 32);

            lblIcono.Size = new Size(55, 45);

            Label lblValor = new Label();

            lblValor.Text = valor;

            lblValor.Font =
                new Font("Segoe UI", 27f, FontStyle.Bold);

            lblValor.ForeColor = color;

            lblValor.Location = new Point(75, 28);

            lblValor.Size = new Size(120, 45);

            Label lblTitulo = new Label();

            lblTitulo.Text = titulo;

            lblTitulo.Font =
                new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);

            lblTitulo.ForeColor = TextoSuave;

            lblTitulo.Location = new Point(75, 75);

            lblTitulo.Size = new Size(135, 25);
=======
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
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

            p.Controls.Add(barra);
            p.Controls.Add(lblIcono);
            p.Controls.Add(lblValor);
            p.Controls.Add(lblTitulo);

            return p;
        }
<<<<<<< HEAD
=======

      
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
    }
}