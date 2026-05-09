using SistemaVotacion.BLL;
using SistemaVotacion.Models;
using SistemaVotacion.Utils;
using System;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    public partial class FrmEditarPlancha : Form
    {
        private readonly Plancha? _plancha;
        private readonly PlanchaService _svc = new();

        public FrmEditarPlancha(Plancha? plancha)
        {
            _plancha = plancha;

            InitializeComponent();

            if (_plancha != null)
                CargarDatos();
            else
                txtColor.Text = "#007BFF";
        }

        private void CargarDatos()
        {
            Text = "Editar Plancha";
            lblTitulo.Text = "●  Editar Plancha";
            lblSubtitulo.Text = "Modifica la información de la plancha seleccionada.";

            txtNombre.Text = _plancha!.Nombre;
            txtDescripcion.Text = _plancha.Descripcion ?? "";
            txtMision.Text = _plancha.Mision ?? "";
            txtColor.Text = _plancha.Color ?? "#007BFF";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                Helpers.MsgError("El nombre de la plancha es obligatorio.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtColor.Text))
                txtColor.Text = "#007BFF";

            if (_plancha == null)
            {
                var nueva = new Plancha
                {
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    Mision = txtMision.Text.Trim(),
                    Color = txtColor.Text.Trim(),
                    AdminUserId = Sesion.UsuarioActual!.UsuarioId,
                    Activa = true
                };

                var (ok, msg, _) = _svc.Crear(nueva);

                if (!ok)
                {
                    Helpers.MsgError(msg);
                    return;
                }
            }
            else
            {
                _plancha.Nombre = txtNombre.Text.Trim();
                _plancha.Descripcion = txtDescripcion.Text.Trim();
                _plancha.Mision = txtMision.Text.Trim();
                _plancha.Color = txtColor.Text.Trim();

                var (ok, msg) = _svc.Actualizar(_plancha);

                if (!ok)
                {
                    Helpers.MsgError(msg);
                    return;
                }
            }

            Helpers.MsgExito("Plancha guardada correctamente.");
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}