using SistemaVotacion.BLL;
using SistemaVotacion.Models;
using SistemaVotacion.Utils;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    public partial class FrmAgregarMiembro : Form
    {
        private readonly int _planchaId;
        private readonly PlanchaService _svc = new();
        private readonly UsuarioService _usrSvc = new();

        private MiembroPlancha? _miembroEditar;
        private string? _fotoPath;

        public FrmAgregarMiembro(int planchaId)
        {
            _planchaId = planchaId;

            InitializeComponent();

            CargarUsuarios();
            CargarPuestos();
        }

        public FrmAgregarMiembro(int planchaId, MiembroPlancha miembroEditar)
        {
            _planchaId = planchaId;
            _miembroEditar = miembroEditar;
            _fotoPath = miembroEditar.FotoPath;

            InitializeComponent();

            CargarUsuarios();
            CargarPuestos();
            CargarDatosEditar();
        }

        private void CargarUsuarios()
        {
            var usuarios = _usrSvc.GetAll()
                .Where(u => u.RolNombre != "Admin")
                .ToList();

            cmbUsuario.DataSource = usuarios;
            cmbUsuario.DisplayMember = "NombreCompleto";
            cmbUsuario.ValueMember = "UsuarioId";
        }

        private void CargarPuestos()
        {
            cmbPuesto.Items.Clear();

            cmbPuesto.Items.Add("Presidente");
            cmbPuesto.Items.Add("Vicepresidente");
            cmbPuesto.Items.Add("Secretario");
            cmbPuesto.Items.Add("Tesorero");
            cmbPuesto.Items.Add("Vocal");

            cmbPuesto.SelectedIndex = 0;
        }

        private void CargarDatosEditar()
        {
            if (_miembroEditar == null)
                return;

            Text = "Editar Miembro";
            lblTitulo.Text = "●  Editar Miembro";
            lblSubtitulo.Text = "Modifica los datos del miembro de la plancha.";

            cmbUsuario.Enabled = false;

            cmbPuesto.Text = _miembroEditar.Puesto;
            numOrden.Value = _miembroEditar.Orden <= 0 ? 1 : _miembroEditar.Orden;
            txtDescripcion.Text = _miembroEditar.Descripcion ?? "";

            if (!string.IsNullOrWhiteSpace(_miembroEditar.FotoPath) && File.Exists(_miembroEditar.FotoPath))
            {
                picFoto.Image = Image.FromFile(_miembroEditar.FotoPath);
                picFoto.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void btnBuscarFoto_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Seleccionar foto del miembro";
            ofd.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            _fotoPath = GuardarImagen(ofd.FileName, "Miembros");

            picFoto.Image = Image.FromFile(_fotoPath);
            picFoto.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private string GuardarImagen(string rutaOriginal, string carpeta)
        {
            string carpetaDestino = Path.Combine(Application.StartupPath, "Imagenes", carpeta);

            if (!Directory.Exists(carpetaDestino))
                Directory.CreateDirectory(carpetaDestino);

            string extension = Path.GetExtension(rutaOriginal);
            string nombreArchivo = $"{Guid.NewGuid()}{extension}";
            string rutaDestino = Path.Combine(carpetaDestino, nombreArchivo);

            File.Copy(rutaOriginal, rutaDestino, true);

            return rutaDestino;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbPuesto.SelectedItem == null && string.IsNullOrWhiteSpace(cmbPuesto.Text))
            {
                Helpers.MsgError("Seleccione el cargo del miembro.");
                return;
            }

            if (_miembroEditar == null)
            {
                if (cmbUsuario.SelectedItem is not Usuario u)
                {
                    Helpers.MsgError("Seleccione un usuario.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(_fotoPath))
                {
                    Helpers.MsgError("Seleccione una foto para el miembro.");
                    return;
                }

                var miembro = new MiembroPlancha
                {
                    PlanchaId = _planchaId,
                    UsuarioId = u.UsuarioId,
                    Puesto = cmbPuesto.Text.Trim(),
                    Orden = (int)numOrden.Value,
                    Descripcion = txtDescripcion.Text.Trim(),
                    Nombre = u.NombreCompleto,
                    Matricula = u.Matricula,
                    FotoPath = _fotoPath
                };

                var (ok, msg) = _svc.AgregarMiembro(miembro);

                if (!ok)
                {
                    Helpers.MsgError(msg);
                    return;
                }
            }
            else
            {
                _miembroEditar.Puesto = cmbPuesto.Text.Trim();
                _miembroEditar.Orden = (int)numOrden.Value;
                _miembroEditar.Descripcion = txtDescripcion.Text.Trim();

                if (!string.IsNullOrWhiteSpace(_fotoPath))
                    _miembroEditar.FotoPath = _fotoPath;

                var (ok, msg) = _svc.EditarMiembro(_miembroEditar);

                if (!ok)
                {
                    Helpers.MsgError(msg);
                    return;
                }
            }

            Helpers.MsgExito("Miembro guardado correctamente.");

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