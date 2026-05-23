using SistemaVotacion.Models;
using System;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    public partial class NuevaVotacionForm : Form
    {
        public Votacion NuevaVotacion { get; private set; }

        private Votacion _editando;

        // ─────────────────────────────
        // CREAR
        // ─────────────────────────────
        public NuevaVotacionForm()
        {
            InitializeComponent();
        }

        // ─────────────────────────────
        // EDITAR
        // ─────────────────────────────
        public NuevaVotacionForm(Votacion votacion)
        {
            InitializeComponent();

            _editando = votacion;

            if (_editando != null)
            {
                txtTitulo.Text =
                    _editando.Titulo;

                txtDescripcion.Text =
                    _editando.Descripcion;

                dtInicio.Value =
                    _editando.FechaInicio;

                dtFin.Value =
                    _editando.FechaFin;

                btnCrear.Text = "Actualizar Votación";

                this.Text = "Editar Votación";
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string titulo =
                txtTitulo.Text.Trim();

            string descripcion =
                txtDescripcion.Text.Trim();

            DateTime inicio =
                dtInicio.Value;

            DateTime fin =
                dtFin.Value;

            if (string.IsNullOrWhiteSpace(titulo))
            {
                MessageBox.Show(
                    "Ingrese un título"
                );

                return;
            }

            if (fin <= inicio)
            {
                MessageBox.Show(
                    "La fecha fin debe ser mayor a la fecha inicio"
                );

                return;
            }

            // ─────────────────────────
            // CREAR NUEVA
            // ─────────────────────────
            if (_editando == null)
            {
                NuevaVotacion = new Votacion
                {
                    Titulo = titulo,
                    Descripcion = descripcion,
                    FechaInicio = inicio,
                    FechaFin = fin,
                    Activa = false,
                    CreadoPor = 1,
                    FechaCreacion = DateTime.Now
                };

                MessageBox.Show(
                    "Votación creada correctamente"
                );
            }
            // ─────────────────────────
            // ACTUALIZAR EXISTENTE
            // ─────────────────────────
            else
            {
                _editando.Titulo =
                    titulo;

                _editando.Descripcion =
                    descripcion;

                _editando.FechaInicio =
                    inicio;

                _editando.FechaFin =
                    fin;

                NuevaVotacion = _editando;

                MessageBox.Show(
                    "Votación actualizada correctamente"
                );
            }

            DialogResult = DialogResult.OK;

            Close();
        }
    }
}