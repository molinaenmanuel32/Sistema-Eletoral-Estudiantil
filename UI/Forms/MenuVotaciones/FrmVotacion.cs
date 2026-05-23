using Dapper;
using SistemaVotacion.BLL;
using SistemaVotacion.DAL;
using SistemaVotacion.Models;
using SistemaVotacion.Utils;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    public partial class FrmVotacion : Form
    {
        private System.Windows.Forms.Timer _timer;

        private readonly VotacionService _svc = new VotacionService();
        private readonly AuthService _auth = new AuthService();
        private readonly PlanchaService _planchaSvc = new PlanchaService();

        private Votacion _votacion;

        public FrmVotacion()
        {
            InitializeComponent();

            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 1000;
            _timer.Tick += Timer_Tick;

            Cargar();
        }

        private void Cargar()
        {
            if (Sesion.UsuarioActual != null)
            {
                lblBienvenido.Text =
                    "Hola, " + Sesion.UsuarioActual.NombreCompleto;
            }

            pnlPostVoto.Visible = false;
            pnlPlanchasContainer.Visible = true;
            pnlFooter.Visible = true;
            btnVotarNulo.Visible = true;

            _votacion = _svc.GetActiva();

            if (_votacion == null)
            {
                lblTitulo.Text = "No hay votación activa";

                lblEstado.Text =
                    "No hay votación activa en este momento.";

                lblInstruccion.Text =
                    "Espere a que el administrador active una votación.";

                OcultarControles();
                MostrarMenuPostVoto();

                return;
            }

            lblTitulo.Text = _votacion.Titulo;

            lblEstado.Text = "Votación activa";

            lblInstruccion.Text =
                "Seleccione una plancha para emitir su voto.";

            if (_svc.VerificarSiVoto(_votacion.VotacionId))
            {
                lblEstado.Text =
                    "Ya votaste en esta votación.";

                lblInstruccion.Text =
                    "Puedes revisar otras votaciones.";

                OcultarControles();
                MostrarMenuPostVoto();

                return;
            }

            MostrarPlanchas();

            _timer.Start();
        }

        private void MostrarPlanchas()
        {
            pnlPlanchas.Controls.Clear();

            var planchas = _planchaSvc.GetAll()
                .Where(p => p.Activa)
                .ToList();

            if (planchas.Count == 0)
            {
                Label lbl = new Label();

                lbl.Text = "No hay planchas activas.";
                lbl.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                lbl.ForeColor = Color.FromArgb(0, 32, 96);
                lbl.Dock = DockStyle.Top;
                lbl.Height = 60;
                lbl.TextAlign = ContentAlignment.MiddleCenter;

                pnlPlanchas.Controls.Add(lbl);

                return;
            }

            int x = 20;
            int y = 20;

            foreach (var p in planchas)
            {
                Panel card = CrearCardPlancha(p);

                card.Location = new Point(x, y);

                pnlPlanchas.Controls.Add(card);

                x += 260;

                if (x + 250 > pnlPlanchas.Width)
                {
                    x = 20;
                    y += 190;
                }
            }
        }

        private Panel CrearCardPlancha(Plancha p)
        {
            Panel card = new Panel();

            card.Size = new Size(240, 170);
            card.BackColor = Color.White;
            card.Cursor = Cursors.Hand;
            card.BorderStyle = BorderStyle.FixedSingle;

            PictureBox pic = new PictureBox();

            pic.Location = new Point(70, 15);
            pic.Size = new Size(100, 75);
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.BackColor = Color.FromArgb(245, 247, 252);

            pic.Image = CargarImagen(p.LogoPath);

            Label lblNombre = new Label();

            lblNombre.Text = p.Nombre;
            lblNombre.Location = new Point(10, 95);
            lblNombre.Size = new Size(220, 30);
            lblNombre.TextAlign = ContentAlignment.MiddleCenter;
            lblNombre.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(0, 55, 150);

            Label lblTexto = new Label();

            lblTexto.Text = "Click para votar";
            lblTexto.Location = new Point(10, 125);
            lblTexto.Size = new Size(220, 25);
            lblTexto.TextAlign = ContentAlignment.MiddleCenter;
            lblTexto.Font = new Font("Segoe UI", 9F);

            Panel linea = new Panel();

            linea.Dock = DockStyle.Bottom;
            linea.Height = 5;
            linea.BackColor = Color.FromArgb(230, 40, 45);

            card.Click += delegate
            {
                ConfirmarVoto(p.PlanchaId);
            };

            pic.Click += delegate
            {
                ConfirmarVoto(p.PlanchaId);
            };

            lblNombre.Click += delegate
            {
                ConfirmarVoto(p.PlanchaId);
            };

            lblTexto.Click += delegate
            {
                ConfirmarVoto(p.PlanchaId);
            };

            card.Controls.Add(pic);
            card.Controls.Add(lblNombre);
            card.Controls.Add(lblTexto);
            card.Controls.Add(linea);

            return card;
        }

        private Image CargarImagen(string ruta)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ruta))
                    return null;

                if (!File.Exists(ruta))
                    return null;

                var temp = Image.FromFile(ruta);

                return new Bitmap(temp);
            }
            catch
            {
                return null;
            }
        }

        private void ConfirmarVoto(int? planchaId)
        {
            if (_votacion == null)
            {
                MessageBox.Show("No hay votación activa.");
                return;
            }

            if (!Helpers.Confirmar("¿Confirmar voto?", "Votar"))
                return;

            var r = _svc.Votar(_votacion.VotacionId, planchaId);

            bool ok = r.Item1;
            string msg = r.Item2;

            if (!ok)
            {
                MessageBox.Show(msg);
                return;
            }

            _timer.Stop();

            lblEstado.Text =
                "Voto registrado correctamente";

            lblInstruccion.Text =
                "Gracias por participar.";

            OcultarControles();

            MostrarMenuPostVoto();
        }

        private void OcultarControles()
        {
            pnlPlanchasContainer.Visible = false;
            pnlFooter.Visible = false;
            btnVotarNulo.Visible = false;
        }

        private void MostrarMenuPostVoto()
        {
            pnlPostVoto.Visible = true;

            pnlPostVoto.BringToFront();

            CargarVotacionesActivas();
            CargarResultadosActivos();
        }

        private void AbrirVotacion(Votacion votacion)
        {
            // FIX: detener el timer anterior antes de reasignar votacion
            _timer.Stop();

            _votacion = votacion;

            pnlPostVoto.Visible = false;

            pnlPlanchasContainer.Visible = true;
            pnlFooter.Visible = true;
            btnVotarNulo.Visible = true;

            lblTitulo.Text = votacion.Titulo;

            lblEstado.Text = "Votación activa";

            lblInstruccion.Text =
                "Seleccione una plancha para emitir su voto.";

            // FIX: verificar si ya votó en ESTA votación antes de mostrar planchas
            if (_svc.VerificarSiVoto(votacion.VotacionId))
            {
                lblEstado.Text = "Ya votaste en esta votación.";
                lblInstruccion.Text = "Puedes revisar otras votaciones.";

                OcultarControles();
                MostrarMenuPostVoto();

                return;
            }

            MostrarPlanchas();

            _timer.Start();
        }

        private void CargarVotacionesActivas()
        {
            pnlVotacionesActivas.Controls.Clear();

            var votaciones = _svc.GetAll()
                .Where(v => v.Activa)
                .ToList();

            if (votaciones.Count == 0)
            {
                Label lbl = new Label();

                lbl.Text = "No hay votaciones activas.";
                lbl.Dock = DockStyle.Top;
                lbl.Height = 40;
                lbl.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                lbl.ForeColor = Color.FromArgb(120, 120, 120);

                pnlVotacionesActivas.Controls.Add(lbl);

                return;
            }

            int y = 10;

            foreach (var v in votaciones)
            {
                Panel card = new Panel();

                card.Size = new Size(450, 100);
                card.Location = new Point(10, y);

                card.BackColor = Color.White;
                card.BorderStyle = BorderStyle.FixedSingle;

                Label lblTituloV = new Label();

                lblTituloV.Text = v.Titulo;
                lblTituloV.Font =
                    new Font("Segoe UI", 12F, FontStyle.Bold);

                lblTituloV.ForeColor =
                    Color.FromArgb(0, 55, 150);

                lblTituloV.Location = new Point(15, 10);
                lblTituloV.Size = new Size(300, 30);

                Label lblFecha = new Label();

                lblFecha.Text =
                    "Finaliza: " +
                    v.FechaFin.ToString("dd/MM/yyyy HH:mm");

                lblFecha.Font =
                    new Font("Segoe UI", 9F);

                lblFecha.ForeColor =
                    Color.FromArgb(90, 100, 120);

                lblFecha.Location = new Point(15, 45);
                lblFecha.Size = new Size(250, 25);

                Button btnEntrar = new Button();

                btnEntrar.Text = "Ver Planchas";
                btnEntrar.Size = new Size(120, 40);

                btnEntrar.Location = new Point(300, 28);

                btnEntrar.BackColor =
                    Color.FromArgb(22, 97, 255);

                btnEntrar.ForeColor = Color.White;

                btnEntrar.FlatStyle = FlatStyle.Flat;
                btnEntrar.FlatAppearance.BorderSize = 0;

                btnEntrar.Cursor = Cursors.Hand;

                btnEntrar.Click += delegate
                {
                    AbrirVotacion(v);
                };

                card.Controls.Add(lblTituloV);
                card.Controls.Add(lblFecha);
                card.Controls.Add(btnEntrar);

                pnlVotacionesActivas.Controls.Add(card);

                y += 115;
            }
        }

        // ─────────────────────────────────────────────────────────
        // RESULTADOS: muestra estadísticas reales por plancha
        // ─────────────────────────────────────────────────────────
        private void CargarResultadosActivos()
        {
            pnlResultadosActivos.Controls.Clear();

            var votaciones = _svc.GetAll()
                .Where(v =>
                    v.FechaInicio <= DateTime.Now &&
                    v.FechaFin >= DateTime.Now)
                .OrderBy(v => v.FechaFin)
                .ToList();

            if (votaciones.Count == 0)
            {
                Label lbl = new Label();

                lbl.Text = "No hay resultados disponibles.";

                lbl.Dock = DockStyle.Top;

                lbl.Height = 40;

                lbl.Font =
                    new Font("Segoe UI", 11F, FontStyle.Bold);

                lbl.ForeColor =
                    Color.FromArgb(120, 120, 120);

                pnlResultadosActivos.Controls.Add(lbl);

                return;
            }

            int y = 10;

            foreach (var v in votaciones)
            {
                EstadisticasVotacion stats;

                try
                {
                    stats = _svc.GetEstadisticas(v.VotacionId);
                }
                catch
                {
                    continue;
                }

                if (stats == null)
                    continue;

                // ─────────────────────────────
                // CARD PRINCIPAL
                // ─────────────────────────────
                Panel card = new Panel();

                card.Location = new Point(10, y);

                card.Size = new Size(
                    pnlResultadosActivos.Width - 35,
                    230);

                card.BackColor = Color.White;

                card.BorderStyle = BorderStyle.FixedSingle;

                // ─────────────────────────────
                // TÍTULO
                // ─────────────────────────────
                Label lblTituloV = new Label();

                lblTituloV.Text = v.Titulo;

                lblTituloV.Font =
                    new Font("Segoe UI", 12F, FontStyle.Bold);

                lblTituloV.ForeColor =
                    Color.FromArgb(0, 55, 150);

                lblTituloV.Location =
                    new Point(15, 10);

                lblTituloV.Size =
                    new Size(500, 25);

                card.Controls.Add(lblTituloV);

                // ─────────────────────────────
                // PARTICIPACIÓN
                // ─────────────────────────────
                Label lblPartic = new Label();

                lblPartic.Text =
                    "Participación: " +
                    stats.TotalVotos +
                    "/" +
                    stats.TotalPadron +
                    " (" +
                    stats.PorcentajeParticipacion.ToString("0") +
                    "%)";

                lblPartic.Font =
                    new Font("Segoe UI", 9F);

                lblPartic.ForeColor =
                    Color.FromArgb(70, 70, 70);

                lblPartic.Location =
                    new Point(15, 40);

                lblPartic.Size =
                    new Size(400, 20);

                card.Controls.Add(lblPartic);

                int yInterno = 70;

                // ─────────────────────────────
                // RESULTADOS POR PLANCHA
                // ─────────────────────────────
                if (stats.PorPlancha != null &&
                    stats.PorPlancha.Count > 0)
                {
                    foreach (var ep in stats.PorPlancha)
                    {
                        Label lblPlancha = new Label();

                        lblPlancha.Text =
                            ep.Plancha +
                            " - " +
                            ep.TotalVotos +
                            " votos (" +
                            ep.Porcentaje.ToString("0.0") +
                            "%)";

                        lblPlancha.Font =
                            new Font("Segoe UI", 9F, FontStyle.Bold);

                        lblPlancha.ForeColor =
                            Color.FromArgb(0, 32, 96);

                        lblPlancha.Location =
                            new Point(18, yInterno);

                        lblPlancha.Size =
                            new Size(450, 18);

                        card.Controls.Add(lblPlancha);

                        yInterno += 20;

                        // ─────────────────────────
                        // BARRA FONDO
                        // ─────────────────────────
                        Panel barraFondo = new Panel();

                        barraFondo.Location =
                            new Point(18, yInterno);

                        barraFondo.Size =
                            new Size(450, 16);

                        barraFondo.BackColor =
                            Color.FromArgb(220, 224, 235);

                        // ─────────────────────────
                        // BARRA RELLENO
                        // ─────────────────────────
                        Panel barraRelleno = new Panel();

                        int anchoRelleno =
                            (int)(450m *
                            ep.Porcentaje / 100m);

                        barraRelleno.Location =
                            new Point(0, 0);

                        barraRelleno.Size =
                            new Size(
                                Math.Max(anchoRelleno, 2),
                                16);

                        try
                        {
                            barraRelleno.BackColor =
                                string.IsNullOrWhiteSpace(ep.Color)
                                ? Color.FromArgb(22, 97, 255)
                                : ColorTranslator.FromHtml(ep.Color);
                        }
                        catch
                        {
                            barraRelleno.BackColor =
                                Color.FromArgb(22, 97, 255);
                        }

                        barraFondo.Controls.Add(barraRelleno);

                        card.Controls.Add(barraFondo);

                        yInterno += 28;
                    }
                }
                else
                {
                    Label lblSin = new Label();

                    lblSin.Text =
                        "Sin votos registrados aún.";

                    lblSin.Font =
                        new Font("Segoe UI", 9F, FontStyle.Italic);

                    lblSin.ForeColor =
                        Color.Gray;

                    lblSin.Location =
                        new Point(18, yInterno);

                    lblSin.Size =
                        new Size(300, 20);

                    card.Controls.Add(lblSin);

                    yInterno += 30;
                }

                // ─────────────────────────────
                // VOTOS NULOS
                // ─────────────────────────────
                Label lblNulos = new Label();

                lblNulos.Text =
                    "Votos nulos/blanco: " +
                    stats.VotosNulos;

                lblNulos.Font =
                    new Font("Segoe UI", 9F);

                lblNulos.ForeColor =
                    Color.FromArgb(150, 50, 50);

                lblNulos.Location =
                    new Point(18, yInterno);

                lblNulos.Size =
                    new Size(250, 18);

                card.Controls.Add(lblNulos);

                // ─────────────────────────────
                // LÍNEA INFERIOR
                // ─────────────────────────────
                Panel linea = new Panel();

                linea.Dock = DockStyle.Bottom;

                linea.Height = 5;

                linea.BackColor =
                    Color.FromArgb(230, 40, 45);

                card.Controls.Add(linea);

                pnlResultadosActivos.Controls.Add(card);

                y += 245;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_votacion == null)
                return;

            TimeSpan tr = _votacion.TiempoRestante;

            lblTiempo.Text = Helpers.FormatearTiempo(tr);

            // Cuando el tiempo se acaba, actualizar el estado
            if (tr.TotalSeconds <= 0)
            {
                _timer.Stop();

                lblEstado.Text = "La votación ha finalizado.";
                lblInstruccion.Text = "El tiempo de votación ha expirado.";

                OcultarControles();
                MostrarMenuPostVoto();
            }
        }

        private void BtnVotarNulo_Click(object sender, EventArgs e)
        {
            ConfirmarVoto(null);
        }

        private void btnActualizarPost_Click(object sender, EventArgs e)
        {
            CargarVotacionesActivas();
            CargarResultadosActivos();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            _timer.Stop();

            _auth.Logout();

            FrmL frm = new FrmL();

            frm.Show();

            Close();
        }

        private void lblEstado_Click(object sender, EventArgs e)
        {

        }
    }
}