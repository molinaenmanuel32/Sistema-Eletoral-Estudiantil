using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotacion.Utils
{
    /// <summary>
    /// Colores y estilos del tema visual de la aplicación.
    /// </summary>
    public static class Tema
    {
        // Paleta principal
        public static readonly Color Primario        = Color.FromArgb( 30, 136, 229);  // Azul
        public static readonly Color PrimarioOscuro  = Color.FromArgb( 13,  71, 161);
        public static readonly Color Acento          = Color.FromArgb(255, 152,   0);  // Naranja
        public static readonly Color Exito           = Color.FromArgb( 56, 142,  60);  // Verde
        public static readonly Color Peligro         = Color.FromArgb(211,  47,  47);  // Rojo
        public static readonly Color Advertencia     = Color.FromArgb(245, 127,  23);
        public static readonly Color Fondo           = Color.FromArgb( 18,  18,  18);  // Dark bg
        public static readonly Color FondoPanel      = Color.FromArgb( 30,  30,  46);
        public static readonly Color FondoCard       = Color.FromArgb( 40,  42,  58);
        public static readonly Color Texto           = Color.FromArgb(236, 236, 236);
        public static readonly Color TextoSecundario = Color.FromArgb(160, 163, 189);
        public static readonly Color Borde           = Color.FromArgb( 60,  62,  80);

        // Fuentes
        public static readonly Font FuenteTitulo    = new Font("Segoe UI", 20f, FontStyle.Bold);
        public static readonly Font FuenteSubtitulo = new Font("Segoe UI", 14f, FontStyle.Bold);
        public static readonly Font FuenteNormal    = new Font("Segoe UI",  9f);
        public static readonly Font FuenteBoton     = new Font("Segoe UI", 10f, FontStyle.Bold);
        public static readonly Font FuentePequeña   = new Font("Segoe UI",  8f);

        // Aplica estilo a un Button
        public static void EstilizarBoton(Button btn, Color? bg = null)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = bg ?? Primario;
            btn.ForeColor = Color.White;
            btn.Font      = FuenteBoton;
            btn.Cursor    = Cursors.Hand;
            btn.FlatAppearance.MouseOverBackColor = ControlPaint.Light(bg ?? Primario, 0.2f);
        }

        // Aplica estilo a un TextBox
        public static void EstilizarTextBox(TextBox tb)
        {
            tb.BackColor   = FondoCard;
            tb.ForeColor   = Texto;
            tb.BorderStyle = BorderStyle.FixedSingle;
            tb.Font        = FuenteNormal;
        }

        // Panel con estilo de card
        public static Panel CrearCard(int x, int y, int w, int h, string titulo = "")
        {
            var panel = new Panel
            {
                Location  = new Point(x, y),
                Size      = new Size(w, h),
                BackColor = FondoCard,
                Padding   = new Padding(12)
            };

            if (!string.IsNullOrEmpty(titulo))
            {
                var lbl = new Label
                {
                    Text      = titulo,
                    Font      = FuenteSubtitulo,
                    ForeColor = Texto,
                    AutoSize  = true,
                    Location  = new Point(12, 10)
                };
                panel.Controls.Add(lbl);
            }
            return panel;
        }
    }

    /// <summary>
    /// Utilidades generales del sistema.
    /// </summary>
    public static class Helpers
    {
        public static void MsgError(string mensaje, string titulo = "Error")
            => MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static void MsgExito(string mensaje, string titulo = "Éxito")
            => MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static bool Confirmar(string mensaje, string titulo = "Confirmar")
            => MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

        public static string FormatearTiempo(TimeSpan t)
        {
            if (t.TotalSeconds <= 0) return "00:00:00";
            return string.Format("{0:D2}:{1:D2}:{2:D2}", (int)t.TotalHours, t.Minutes, t.Seconds);
        }
    }
}
