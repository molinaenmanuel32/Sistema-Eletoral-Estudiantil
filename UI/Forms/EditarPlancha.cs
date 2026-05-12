using SistemaVotacion.BLL;
using SistemaVotacion.Models;
using SistemaVotacion.Utils;
using System;
using System.IO;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    public partial class FrmEditarPlancha : Form
    {
        private readonly Plancha _plancha;
        private readonly PlanchaService _svc = new PlanchaService();
        private string _logoPath;

        public FrmEditarPlancha(Plancha plancha)
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

            txtNombre.Text      = _plancha.Nombre;
            txtDescripcion.Text = _plancha.Descripcion != null ? _plancha.Descripcion : "";
            txtMision.Text      = _plancha.Mision != null ? _plancha.Mision : "";
            txtColor.Text       = _plancha.Color != null ? _plancha.Color : "#007BFF";

            _logoPath = _plancha.LogoPath;
            CargarLogoPreview(_logoPath);
        }

        private void btnSeleccionarLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title  = "Seleccionar logo";
            open.Filter = "Imágenes|*.png;*.jpg;*.jpeg";

            if (open.ShowDialog() == DialogResult.OK)
            {
                _logoPath = CopiarLogo(open.FileName);
                CargarLogoPreview(_logoPath);
            }

            open.Dispose();
        }

        private string CopiarLogo(string origen)
        {
            string carpeta = Path.Combine(Application.StartupPath, "Assets", "LogosPlanchas");

            if (!Directory.Exists(carpeta))
                Directory.CreateDirectory(carpeta);

            string extension    = Path.GetExtension(origen);
            string nombreArchivo = "logo_plancha_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + extension;
            string destino      = Path.Combine(carpeta, nombreArchivo);

            File.Copy(origen, destino, true);
            return destino;
        }

        private void CargarLogoPreview(string ruta)
        {
            if (string.IsNullOrWhiteSpace(ruta) || !File.Exists(ruta))
            {
                picLogo.Image    = null;
                lblLogoTexto.Text = "Sin logo seleccionado";
                return;
            }

            var imgTemp = System.Drawing.Image.FromFile(ruta);
            picLogo.Image = new System.Drawing.Bitmap(imgTemp);
            lblLogoTexto.Text = Path.GetFileName(ruta);
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
                Plancha nueva = new Plancha();
                nueva.Nombre      = txtNombre.Text.Trim();
                nueva.Descripcion = txtDescripcion.Text.Trim();
                nueva.Mision      = txtMision.Text.Trim();
                nueva.Color       = txtColor.Text.Trim();
                nueva.LogoPath    = _logoPath;

                if (Sesion.UsuarioActual != null)
                    nueva.AdminUserId = Sesion.UsuarioActual.UsuarioId;

                nueva.Activa = true;

                int id = _svc.Crear(nueva);

                if (id <= 0)
                {
                    Helpers.MsgError("No se pudo crear la plancha.");
                    return;
                }

                Helpers.MsgExito("Plancha creada correctamente.");
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            _plancha.Nombre      = txtNombre.Text.Trim();
            _plancha.Descripcion = txtDescripcion.Text.Trim();
            _plancha.Mision      = txtMision.Text.Trim();
            _plancha.Color       = txtColor.Text.Trim();
            _plancha.LogoPath    = _logoPath;

            bool ok = _svc.Actualizar(_plancha);

            if (!ok)
            {
                Helpers.MsgError("No se pudo actualizar la plancha.");
                return;
            }

            Helpers.MsgExito("Plancha actualizada correctamente.");
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
