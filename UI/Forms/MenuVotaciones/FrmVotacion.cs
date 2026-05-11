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
        private System.Windows.Forms.Timer _timer = null!;
        private readonly VotacionService _svc = new();
        private readonly AuthService _auth = new();
        private readonly PlanchaService _planchaSvc = new();

        private Votacion? _votacion;

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
            lblBienvenido.Text = $"Hola, {Sesion.UsuarioActual?.NombreCompleto}";

            pnlPostVoto.Visible = false;
            pnlPlanchasContainer.Visible = true;
            pnlFooter.Visible = true;
            btnVotarNulo.Visible = true;

            _votacion = _svc.GetActiva();

            if (_votacion == null)
            {
                lblTitulo.Text = "No hay votación activa";
                lblEstado.Text = "No hay votación activa en este momento.";
                lblInstruccion.Text = "Espere a que el administrador active una votación.";
                OcultarControles();
                MostrarMenuPostVoto();
                return;
            }

            lblTitulo.Text = _votacion.Titulo;
            lblEstado.Text = "Votación activa";
            lblInstruccion.Text = "Seleccione una plancha para emitir su voto. Revise bien antes de confirmar.";

            if (_svc.VerificarSiVoto(_votacion.VotacionId))
            {
                lblEstado.Text = "Ya votaste en esta votación.";
                lblInstruccion.Text = "Puedes consultar otras votaciones activas y revisar los resultados.";
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
                Label lbl = new Label
                {
                    Text = "No hay planchas activas disponibles.",
                    Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(0, 32, 96),
                    Dock = DockStyle.Top,
                    Height = 60,
                    TextAlign = ContentAlignment.MiddleCenter
                };

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
            Panel card = new Panel
            {
                Size = new Size(240, 170),
                BackColor = Color.White,
                Cursor = Cursors.Hand,
                BorderStyle = BorderStyle.FixedSingle
            };

            PictureBox pic = new PictureBox
            {
                Location = new Point(70, 15),
                Size = new Size(100, 75),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.FromArgb(245, 247, 252),
                Image = CargarImagen(p.LogoPath)
            };

            Label lblNombre = new Label
            {
                Text = p.Nombre,
                Location = new Point(10, 95),
                Size = new Size(220, 30),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 55, 150)
            };

            Label lblTexto = new Label
            {
                Text = "Click para votar",
                Location = new Point(10, 125),
                Size = new Size(220, 25),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(90, 100, 120)
            };

            Panel linea = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 5,
                BackColor = Color.FromArgb(230, 40, 45)
            };

            void ClickCard(object? sender, EventArgs e)
            {
                ConfirmarVoto(p.PlanchaId);
            }

            card.Click += ClickCard;
            pic.Click += ClickCard;
            lblNombre.Click += ClickCard;
            lblTexto.Click += ClickCard;

            card.Controls.Add(pic);
            card.Controls.Add(lblNombre);
            card.Controls.Add(lblTexto);
            card.Controls.Add(linea);

            return card;
        }

        private Image? CargarImagen(string? ruta)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ruta) || !File.Exists(ruta))
                    return null;

                using var temp = Image.FromFile(ruta);
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

            var (ok, msg) = _svc.Votar(_votacion.VotacionId, planchaId);

            if (!ok)
            {
                MessageBox.Show(msg);
                return;
            }

            lblEstado.Text = "Voto registrado correctamente";
            lblInstruccion.Text = "Gracias por participar. Puedes revisar los resultados activos.";

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

        private void CargarVotacionesActivas()
        {
            pnlVotacionesActivas.Controls.Clear();

            using var con = DbConnection.GetConnection();

            var votaciones = con.Query(
                """
                SELECT VotacionId, Titulo, FechaInicio, FechaFin, Activa
                FROM Votaciones
                WHERE Activa = 1
                ORDER BY FechaInicio DESC
                """).ToList();

            if (votaciones.Count == 0)
            {
                pnlVotacionesActivas.Controls.Add(new Label
                {
                    Text = "No hay más votaciones activas.",
                    Dock = DockStyle.Top,
                    Height = 40,
                    Font = new Font("Segoe UI", 10.5F),
                    ForeColor = Color.FromArgb(90, 100, 120)
                });

                return;
            }

            int y = 5;

            foreach (var v in votaciones)
            {
                Label lbl = new Label
                {
                    Text = $"• {v.Titulo}",
                    Location = new Point(10, y),
                    Size = new Size(480, 30),
                    Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(0, 55, 150)
                };

                pnlVotacionesActivas.Controls.Add(lbl);

                y += 35;
            }
        }

        private void CargarResultadosActivos()
        {
            pnlResultadosActivos.Controls.Clear();

            using var con = DbConnection.GetConnection();

            var resultados = con.Query(
                """
        SELECT 
            ISNULL(p.Nombre, 'Voto Nulo') AS Plancha,
            p.LogoPath,
            COUNT(vo.VotoId) AS TotalVotos
        FROM Votaciones v
        LEFT JOIN Votos vo ON vo.VotacionId = v.VotacionId
        LEFT JOIN Planchas p ON p.PlanchaId = vo.PlanchaId
        WHERE v.Activa = 1
        GROUP BY p.Nombre, p.LogoPath
        ORDER BY TotalVotos DESC
        """).ToList();

            if (resultados.Count == 0)
            {
                pnlResultadosActivos.Controls.Add(new Label
                {
                    Text = "Todavía no hay votos registrados.",
                    Dock = DockStyle.Top,
                    Height = 40,
                    Font = new Font("Segoe UI", 10.5F),
                    ForeColor = Color.FromArgb(90, 100, 120)
                });

                return;
            }

            int y = 10;

            foreach (var r in resultados)
            {
                Panel fila = new Panel
                {
                    Location = new Point(10, y),
                    Size = new Size(500, 70),
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle
                };

                PictureBox picLogo = new PictureBox
                {
                    Location = new Point(10, 8),
                    Size = new Size(55, 55),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BackColor = Color.FromArgb(245, 247, 252)
                };

                // CARGAR LOGO
                try
                {
                    if (r.LogoPath != null && File.Exists(r.LogoPath.ToString()))
                    {
                        using var temp = Image.FromFile(r.LogoPath.ToString());

                        picLogo.Image = new Bitmap(temp);
                    }
                }
                catch
                {
                    picLogo.Image = null;
                }

                Label lblPlancha = new Label
                {
                    Text = r.Plancha,
                    Location = new Point(80, 10),
                    Size = new Size(250, 25),
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(0, 32, 96)
                };

                Label lblTexto = new Label
                {
                    Text = "Total de votos",
                    Location = new Point(80, 35),
                    Size = new Size(180, 20),
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.FromArgb(90, 100, 120)
                };

                Label lblVotos = new Label
                {
                    Text = $"{r.TotalVotos} votos",
                    Location = new Point(340, 20),
                    Size = new Size(140, 25),
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(230, 40, 45),
                    TextAlign = ContentAlignment.MiddleRight
                };

                fila.Controls.Add(picLogo);
                fila.Controls.Add(lblPlancha);
                fila.Controls.Add(lblTexto);
                fila.Controls.Add(lblVotos);

                pnlResultadosActivos.Controls.Add(fila);

                y += 80;
            }
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (_votacion == null) return;

            lblTiempo.Text = Helpers.FormatearTiempo(_votacion.TiempoRestante);
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
            _auth.Logout();
            new FrmL().Show();
            Close();
        }
    }
}