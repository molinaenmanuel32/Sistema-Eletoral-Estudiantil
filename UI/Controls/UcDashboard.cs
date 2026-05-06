using SistemaVotacion.BLL;
using SistemaVotacion.Models;
using SistemaVotacion.Utils;

namespace SistemaVotacion.UI.Controls;

public class UcDashboard : UserControl
{
    private System.Windows.Forms.Timer _timer = null!;
    private Panel   pnlStats  = null!;
    private Panel   pnlBarras = null!;
    private Label   lblTiempo = null!;
    private Label   lblPorcentaje = null!;
    private ProgressBar pbParticipacion = null!;

    private readonly VotacionService _svc = new();
    private Votacion? _votacion;

    public UcDashboard()
    {
        BackColor = Tema.Fondo;
        Dock      = DockStyle.Fill;
        BuildUI();
        Cargar();

        _timer = new System.Windows.Forms.Timer { Interval = 3000 };
        _timer.Tick += (s, e) => Cargar();
        _timer.Start();
    }

    protected override void Dispose(bool disposing)
    {
        _timer?.Stop();
        _timer?.Dispose();
        base.Dispose(disposing);
    }

    private void BuildUI()
    {
        pnlStats = new Panel
        {
            Location = new Point(0, 0),
            Size     = new Size(1000, 130),
            Anchor   = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
        };

        var pnlTimer = new Panel
        {
            Location  = new Point(0, 145),
            Size      = new Size(380, 90),
            BackColor = Tema.FondoCard
        };
        lblTiempo = new Label
        {
            Text      = "--:--:--",
            Font      = new Font("Segoe UI", 30f, FontStyle.Bold),
            ForeColor = Tema.Acento,
            AutoSize  = false,
            Size      = new Size(280, 55),
            Location  = new Point(60, 18),
            TextAlign = ContentAlignment.MiddleCenter
        };
        var lblTLabel = new Label
        {
            Text      = "Tiempo restante",
            Font      = Tema.FuentePequeña,
            ForeColor = Tema.TextoSecundario,
            AutoSize  = true,
            Location  = new Point(10, 5)
        };
        pnlTimer.Controls.AddRange(new Control[] { lblTLabel, lblTiempo });

        var pnlPart = new Panel
        {
            Location  = new Point(0, 250),
            Size      = new Size(1000, 80),
            BackColor = Tema.FondoCard
        };
        lblPorcentaje = new Label
        {
            Text      = "Participacion: 0%",
            Font      = new Font("Segoe UI", 11f, FontStyle.Bold),
            ForeColor = Tema.Texto,
            AutoSize  = true,
            Location  = new Point(15, 10)
        };
        pbParticipacion = new ProgressBar
        {
            Location = new Point(15, 38),
            Size     = new Size(960, 25),
            Style    = ProgressBarStyle.Continuous
        };
        pnlPart.Controls.AddRange(new Control[] { lblPorcentaje, pbParticipacion });

        pnlBarras = new Panel
        {
            Location  = new Point(0, 350),
            Size      = new Size(1000, 360),
            BackColor = Tema.FondoCard,
            AutoScroll = true
        };
        var lblBTitle = new Label
        {
            Text      = "Resultados por Plancha",
            Font      = Tema.FuenteSubtitulo,
            ForeColor = Tema.Texto,
            AutoSize  = true,
            Location  = new Point(15, 10)
        };
        pnlBarras.Controls.Add(lblBTitle);

        Controls.AddRange(new Control[] { pnlStats, pnlTimer, pnlPart, pnlBarras });
    }

    private void Cargar()
    {
        _votacion = _svc.GetActiva();
        if (_votacion is null) { MostrarSinVotacion(); return; }
        var stats = _svc.GetEstadisticas(_votacion.VotacionId);
        if (InvokeRequired) { Invoke(() => Actualizar(stats)); return; }
        Actualizar(stats);
    }

    private void Actualizar(EstadisticasVotacion stats)
    {
        pnlStats.Controls.Clear();
        (string titulo, string valor, Color color)[] cards =
        {
            ("Padron Total",    stats.TotalPadron.ToString(), Tema.Primario),
            ("Votos Emitidos",  stats.TotalVotos.ToString(),  Tema.Exito),
            ("Votos Nulos",     stats.VotosNulos.ToString(),  Tema.Peligro),
            ("Sin Votar",       stats.SinVotar.ToString(),    Tema.Advertencia),
        };

        int x = 0;
        foreach (var (titulo, valor, color) in cards)
        {
            var card = CrearTarjeta(titulo, valor, color);
            card.Location = new Point(x, 0);
            pnlStats.Controls.Add(card);
            x += 245;
        }

        if (_votacion is not null)
        {
            var tr = _votacion.TiempoRestante;
            lblTiempo.Text      = Helpers.FormatearTiempo(tr);
            lblTiempo.ForeColor = tr.TotalMinutes < 10 ? Tema.Peligro : Tema.Acento;
        }

        int pct = (int)stats.PorcentajeParticipacion;
        pbParticipacion.Value = Math.Min(pct, 100);
        lblPorcentaje.Text    = $"Participacion: {stats.PorcentajeParticipacion:F1}%  " +
                                 $"({stats.TotalVotos} de {stats.TotalPadron})";

        var lblTit = pnlBarras.Controls.OfType<Label>().First();
        pnlBarras.Controls.Clear();
        pnlBarras.Controls.Add(lblTit);

        int y = 45;
        foreach (var ep in stats.PorPlancha)
        {
            var color = ParseColor(ep.Color);
            var lbl = new Label
            {
                Text      = $"{ep.Plancha}  -  {ep.TotalVotos} votos  ({ep.Porcentaje:F1}%)",
                Font      = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = Tema.Texto,
                AutoSize  = true,
                Location  = new Point(15, y)
            };
            var pb = new ProgressBar
            {
                Location = new Point(15, y + 22),
                Size     = new Size(Math.Max(pnlBarras.Width - 40, 200), 22),
                Value    = (int)Math.Min(ep.Porcentaje, 100),
                Style    = ProgressBarStyle.Continuous
            };
            pnlBarras.Controls.AddRange(new Control[] { lbl, pb });
            y += 60;
        }
    }

    private void MostrarSinVotacion()
    {
        if (InvokeRequired) { Invoke(MostrarSinVotacion); return; }
        pnlStats.Controls.Clear();
        pnlStats.Controls.Add(new Label
        {
            Text      = "No hay ninguna votacion activa en este momento.",
            Font      = Tema.FuenteSubtitulo,
            ForeColor = Tema.TextoSecundario,
            AutoSize  = true,
            Location  = new Point(20, 30)
        });
        lblTiempo.Text        = "--:--:--";
        pbParticipacion.Value = 0;
        lblPorcentaje.Text    = "Participacion: --";
    }

    private static Panel CrearTarjeta(string titulo, string valor, Color color)
    {
        var p   = new Panel { Size = new Size(235, 115), BackColor = Tema.FondoCard };
        var top = new Panel { Dock = DockStyle.Top, Height = 8, BackColor = color };
        var lv  = new Label { Text = valor, Font = new Font("Segoe UI", 30f, FontStyle.Bold), ForeColor = color, AutoSize = true, Location = new Point(15, 20) };
        var lt  = new Label { Text = titulo, Font = Tema.FuentePequeña, ForeColor = Tema.TextoSecundario, AutoSize = true, Location = new Point(15, 75) };
        p.Controls.AddRange(new Control[] { top, lv, lt });
        return p;
    }

    private static Color ParseColor(string hex)
    {
        try { return ColorTranslator.FromHtml(hex); }
        catch { return Tema.Primario; }
    }
}
