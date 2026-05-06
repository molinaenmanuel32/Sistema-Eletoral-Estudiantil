using SistemaVotacion.BLL;
using SistemaVotacion.Models;
using SistemaVotacion.Utils;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace SistemaVotacion.UI.Forms
{
    public partial class FrmVotacion : Form
    {
        private System.Windows.Forms.Timer _timer;
        private readonly VotacionService _svc = new();
        private readonly AuthService _auth = new();
        private Votacion? _votacion;

        public FrmVotacion()
        {
            InitializeComponent();

            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 1000;
            _timer.Tick += Timer_Tick;

            btnVotarNulo.Click += (s, e) => ConfirmarVoto(null);

            Cargar();
        }

        private void Cargar()
        {
            lblBienvenido.Text = $"Hola, {Sesion.UsuarioActual?.NombreCompleto}";

            _votacion = _svc.GetActiva();

            if (_votacion == null)
            {
                lblTitulo.Text = "No hay votacion activa";
                lblEstado.Text = "Espere a que el administrador active una votacion.";
                return;
            }

            lblTitulo.Text = _votacion.Titulo;

            if (_svc.VerificarSiVoto(_votacion.VotacionId))
            {
                lblEstado.Text = "✅ Ya votaste.";
                OcultarControles();
                return;
            }

            MostrarPlanchas();
            _timer.Start();
        }

        private void MostrarPlanchas()
        {
            pnlPlanchas.Controls.Clear();

            var planchas = new PlanchaService().GetAll().Where(p => p.Activa).ToList();

            int x = 0, y = 0;

            foreach (var p in planchas)
            {
                var btn = new Button
                {
                    Text = p.Nombre,
                    Size = new Size(200, 80),
                    Location = new Point(x, y)
                };

                int id = p.PlanchaId;
                btn.Click += (s, e) => ConfirmarVoto(id);

                pnlPlanchas.Controls.Add(btn);

                x += 210;
                if (x > 800)
                {
                    x = 0;
                    y += 90;
                }
            }
        }

        private void ConfirmarVoto(int? planchaId)
        {
            if (!Helpers.Confirmar("Confirmar voto?", "Votar")) return;

            var (ok, msg) = _svc.Votar(_votacion!.VotacionId, planchaId);

            if (!ok)
            {
                MessageBox.Show(msg);
                return;
            }

            lblEstado.Text = "✅ Voto registrado";
            OcultarControles();
        }

        private void OcultarControles()
        {
            pnlPlanchas.Visible = false;
            btnVotarNulo.Visible = false;
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

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            _auth.Logout();
            new FrmL().Show();
            Close();
        }
    }
}