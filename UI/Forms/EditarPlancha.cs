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
<<<<<<< HEAD
        private readonly Plancha _plancha;
        private readonly PlanchaService _svc = new PlanchaService();
        private string _logoPath;

        public FrmEditarPlancha(Plancha plancha)
=======
        private readonly Plancha? _plancha;
        private readonly PlanchaService _svc = new();
        private string? _logoPath;

        public FrmEditarPlancha(Plancha? plancha)
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
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

<<<<<<< HEAD
            txtNombre.Text = _plancha.Nombre;

            txtDescripcion.Text =
                _plancha.Descripcion != null
                ? _plancha.Descripcion
                : "";

            txtMision.Text =
                _plancha.Mision != null
                ? _plancha.Mision
                : "";

            txtColor.Text =
                _plancha.Color != null
                ? _plancha.Color
                : "#007BFF";

=======
            txtNombre.Text = _plancha!.Nombre;
            txtDescripcion.Text = _plancha.Descripcion ?? "";
            txtMision.Text = _plancha.Mision ?? "";
            txtColor.Text = _plancha.Color ?? "#007BFF";
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
            _logoPath = _plancha.LogoPath;

            CargarLogoPreview(_logoPath);
        }

        private void btnSeleccionarLogo_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            OpenFileDialog open = new OpenFileDialog();
=======
            using OpenFileDialog open = new OpenFileDialog();
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

            open.Title = "Seleccionar logo";
            open.Filter = "Imágenes|*.png;*.jpg;*.jpeg";

            if (open.ShowDialog() == DialogResult.OK)
            {
                _logoPath = CopiarLogo(open.FileName);
                CargarLogoPreview(_logoPath);
            }
<<<<<<< HEAD

            open.Dispose();
=======
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
        }

        private string CopiarLogo(string origen)
        {
<<<<<<< HEAD
            string carpeta = Path.Combine(
                Application.StartupPath,
                "Assets",
                "LogosPlanchas"
            );
=======
            string carpeta = Path.Combine(Application.StartupPath, "Assets", "LogosPlanchas");
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

            if (!Directory.Exists(carpeta))
                Directory.CreateDirectory(carpeta);

            string extension = Path.GetExtension(origen);
<<<<<<< HEAD

            string nombreArchivo =
                "logo_plancha_" +
                DateTime.Now.ToString("yyyyMMddHHmmssfff") +
                extension;

=======
            string nombreArchivo = $"logo_plancha_{DateTime.Now:yyyyMMddHHmmssfff}{extension}";
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
            string destino = Path.Combine(carpeta, nombreArchivo);

            File.Copy(origen, destino, true);

            return destino;
        }

<<<<<<< HEAD
        private void CargarLogoPreview(string ruta)
=======
        private void CargarLogoPreview(string? ruta)
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
        {
            if (string.IsNullOrWhiteSpace(ruta) || !File.Exists(ruta))
            {
                picLogo.Image = null;
                lblLogoTexto.Text = "Sin logo seleccionado";
                return;
            }

<<<<<<< HEAD
            var imgTemp = System.Drawing.Image.FromFile(ruta);

            picLogo.Image = new System.Drawing.Bitmap(imgTemp);

=======
            using var imgTemp = System.Drawing.Image.FromFile(ruta);
            picLogo.Image = new System.Drawing.Bitmap(imgTemp);
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
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
<<<<<<< HEAD
                Plancha nueva = new Plancha();

                nueva.Nombre = txtNombre.Text.Trim();
                nueva.Descripcion = txtDescripcion.Text.Trim();
                nueva.Mision = txtMision.Text.Trim();
                nueva.Color = txtColor.Text.Trim();
                nueva.LogoPath = _logoPath;

                if (Sesion.UsuarioActual != null)
                    nueva.AdminUserId = Sesion.UsuarioActual.UsuarioId;

                nueva.Activa = true;
=======
                var nueva = new Plancha
                {
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    Mision = txtMision.Text.Trim(),
                    Color = txtColor.Text.Trim(),
                    LogoPath = _logoPath,
                    AdminUserId = Sesion.UsuarioActual!.UsuarioId,
                    Activa = true
                };
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

                int id = _svc.Crear(nueva);

                if (id <= 0)
                {
                    Helpers.MsgError("No se pudo crear la plancha.");
                    return;
                }

                Helpers.MsgExito("Plancha creada correctamente.");
<<<<<<< HEAD

                DialogResult = DialogResult.OK;
                Close();

=======
                DialogResult = DialogResult.OK;
                Close();
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
                return;
            }

            _plancha.Nombre = txtNombre.Text.Trim();
            _plancha.Descripcion = txtDescripcion.Text.Trim();
            _plancha.Mision = txtMision.Text.Trim();
            _plancha.Color = txtColor.Text.Trim();
            _plancha.LogoPath = _logoPath;

            bool ok = _svc.Actualizar(_plancha);

            if (!ok)
            {
                Helpers.MsgError("No se pudo actualizar la plancha.");
                return;
            }

            Helpers.MsgExito("Plancha actualizada correctamente.");
<<<<<<< HEAD

=======
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
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