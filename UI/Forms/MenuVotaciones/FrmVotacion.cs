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

        private void CargarVotacionesActivas()
        {
            pnlVotacionesActivas.Controls.Clear();

            Label lbl = new Label();

            lbl.Text = "Votaciones activas cargadas.";
            lbl.Dock = DockStyle.Top;
            lbl.Height = 40;
            lbl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            pnlVotacionesActivas.Controls.Add(lbl);
        }

        private void CargarResultadosActivos()
        {
            pnlResultadosActivos.Controls.Clear();

            Label lbl = new Label();

            lbl.Text = "Resultados cargados.";
            lbl.Dock = DockStyle.Top;
            lbl.Height = 40;
            lbl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            pnlResultadosActivos.Controls.Add(lbl);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_votacion == null)
                return;

            lblTiempo.Text =
                Helpers.FormatearTiempo(_votacion.TiempoRestante);
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

            FrmL frm = new FrmL();

            frm.Show();

            Close();
        }
    }
}