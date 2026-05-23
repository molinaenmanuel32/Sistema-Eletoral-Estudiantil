using Dapper;
using SistemaVotacion.DAL;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    public partial class FrmEditarMiPlancha : Form
    {
        private readonly int _usuarioId;
        private int _planchaId;
        private int _miembroSeleccionadoId = 0;
        private string _fotoPath = "";

        public FrmEditarMiPlancha(int usuarioId)
        {
            InitializeComponent();

            _usuarioId = usuarioId;

            ConfigurarTabla();
            CargarCargos();
            CargarPlanchaDelUsuario();
        }

        private void ConfigurarTabla()
        {
            dgvMiembros.Columns.Clear();
            dgvMiembros.AutoGenerateColumns = false;

            dgvMiembros.Columns.Add(new DataGridViewImageColumn
            {
                Name = "Foto",
                HeaderText = "Foto",
                Width = 70,
                ImageLayout = DataGridViewImageCellLayout.Zoom
            });
            dgvMiembros.Columns.Add(new DataGridViewTextBoxColumn { Name = "MiembroId", HeaderText = "ID", Width = 50 });
            dgvMiembros.Columns.Add(new DataGridViewTextBoxColumn { Name = "Puesto", HeaderText = "Cargo", Width = 120 });
            dgvMiembros.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nombre", HeaderText = "Nombre", Width = 180 });
            dgvMiembros.Columns.Add(new DataGridViewTextBoxColumn { Name = "Matricula", HeaderText = "Matrícula", Width = 100 });
            dgvMiembros.Columns.Add(new DataGridViewTextBoxColumn { Name = "Descripcion", HeaderText = "Descripción", Width = 180 });
            dgvMiembros.Columns.Add(new DataGridViewTextBoxColumn { Name = "FotoPath", Visible = false });

            dgvMiembros.EnableHeadersVisualStyles = false;
            dgvMiembros.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 55, 150);
            dgvMiembros.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMiembros.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvMiembros.DefaultCellStyle.SelectionBackColor = Color.FromArgb(22, 97, 255);
            dgvMiembros.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvMiembros.RowTemplate.Height = 55;

            dgvMiembros.SelectionChanged += dgvMiembros_SelectionChanged;
        }

        private void CargarCargos()
        {
            cmbPuesto.Items.Clear();
            cmbPuesto.Items.Add("Presidente");
            cmbPuesto.Items.Add("Vicepresidente");
            cmbPuesto.Items.Add("Secretario");
            cmbPuesto.Items.Add("Tesorero");
            cmbPuesto.Items.Add("Vocal");
            cmbPuesto.SelectedIndex = 0;
        }

        private void CargarPlanchaDelUsuario()
        {
            using var con = DbConnection.GetConnection();

            int? planchaId = con.QueryFirstOrDefault<int?>(
                @"SELECT TOP 1 PlanchaId
                  FROM Planchas
                  WHERE AdminUserId = @id",
                new { id = _usuarioId });

            _planchaId = planchaId ?? 0;

            if (_planchaId <= 0)
            {
                MostrarAsignacionPlancha();
            }
            else
            {
                pnlAsignarPlancha.Visible = false;
                pnlPlancha.Visible = true;
                pnlMiembros.Visible = true;

                CargarPlancha();
                CargarMiembros();
            }
        }

        private void MostrarAsignacionPlancha()
        {
            using var con = DbConnection.GetConnection();

            var libres = con.Query(
                @"SELECT p.PlanchaId, p.Nombre
                  FROM Planchas p
                  WHERE p.AdminUserId IS NULL
                  ORDER BY p.Nombre").ToList();

            pnlAsignarPlancha.Visible = true;
            pnlPlancha.Visible = false;
            pnlMiembros.Visible = false;

            if (libres.Count > 0)
            {
                cmbPlanchasDisponibles.Enabled = true;
                btnTomarPlancha.Enabled = true;
                cmbPlanchasDisponibles.DataSource = libres;
                cmbPlanchasDisponibles.DisplayMember = "Nombre";
                cmbPlanchasDisponibles.ValueMember = "PlanchaId";
                lblAsignacion.Text = "No tienes una plancha asignada.";
            }
            else
            {
                cmbPlanchasDisponibles.DataSource = null;
                cmbPlanchasDisponibles.Enabled = false;
                btnTomarPlancha.Enabled = false;
                lblAsignacion.Text = "No hay planchas disponibles.";
            }
        }

        private void btnTomarPlancha_Click(object sender, EventArgs e)
        {
            if (cmbPlanchasDisponibles.SelectedValue == null)
            {
                MessageBox.Show("Selecciona una plancha.");
                return;
            }

            int planchaSeleccionada = Convert.ToInt32(cmbPlanchasDisponibles.SelectedValue);

            using var con = DbConnection.GetConnection();

            con.Execute(
                @"UPDATE Planchas
                  SET AdminUserId = @usuarioId,
                      FechaModificacion = GETDATE()
                  WHERE PlanchaId = @planchaId",
                new { planchaId = planchaSeleccionada, usuarioId = _usuarioId });

            MessageBox.Show("Plancha asignada correctamente.");
            CargarPlanchaDelUsuario();
        }

        private void btnCrearMiPlancha_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNuevaPlancha.Text))
            {
                MessageBox.Show("Escribe el nombre de la plancha.");
                return;
            }

            using var con = DbConnection.GetConnection();

            con.Execute(
                @"INSERT INTO Planchas
                  (Nombre, Descripcion, Mision, LogoPath,
                   Color, AdminUserId, Activa)
                  VALUES
                  (@nombre, @descripcion, '',
                   NULL, '#007BFF', @adminUserId, 1)",
                new
                {
                    nombre = txtNuevaPlancha.Text.Trim(),
                    descripcion = txtNuevaDescripcion.Text.Trim(),
                    adminUserId = _usuarioId
                });

            MessageBox.Show("Plancha creada correctamente.");
            CargarPlanchaDelUsuario();
        }

        private void CargarPlancha()
        {
            using var con = DbConnection.GetConnection();

            var plancha = con.QueryFirstOrDefault(
                "SELECT * FROM Planchas WHERE PlanchaId = @id",
                new { id = _planchaId });

            if (plancha == null)
            {
                MessageBox.Show("No se encontró la plancha.");
                return;
            }

            txtNombrePlancha.Text = plancha.Nombre;
            txtDescripcion.Text = plancha.Descripcion;
        }

        private void CargarMiembros()
        {
            dgvMiembros.Rows.Clear();

            using var con = DbConnection.GetConnection();

            var miembros = con.Query(
                @"SELECT *
                  FROM MiembrosPlanchas
                  WHERE PlanchaId = @id
                  ORDER BY Orden, MiembroId",
                new { id = _planchaId });

            foreach (var m in miembros)
            {
                dgvMiembros.Rows.Add(
                    CargarImagen(m.FotoPath),
                    m.MiembroId,
                    m.Puesto,
                    m.Nombre,
                    m.Matricula,
                    m.Descripcion,
                    m.FotoPath
                );
            }

            LimpiarMiembro();
        }

        private Image CargarImagen(string ruta)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ruta) || !File.Exists(ruta))
                    return null;

                using var imgTemp = Image.FromFile(ruta);
                return new Bitmap(imgTemp, new Size(45, 45));
            }
            catch
            {
                return null;
            }
        }

        private void btnGuardarPlancha_Click(object sender, EventArgs e)
        {
            using var con = DbConnection.GetConnection();

            con.Execute(
                @"UPDATE Planchas
                  SET Nombre = @nombre,
                      Descripcion = @descripcion,
                      FechaModificacion = GETDATE()
                  WHERE PlanchaId = @id",
                new
                {
                    nombre = txtNombrePlancha.Text.Trim(),
                    descripcion = txtDescripcion.Text.Trim(),
                    id = _planchaId
                });

            MessageBox.Show("Plancha actualizada correctamente.");
        }

        private void LimpiarMiembro()
        {
            _miembroSeleccionadoId = 0;
            cmbPuesto.SelectedIndex = 0;
            txtNombreMiembro.Clear();
            txtMatricula.Clear();
            txtDescripcionMiembro.Clear();
            _fotoPath = "";
            picFoto.Image = null;
            lblFotoTexto.Text = "Sin foto";
        }

        private void dgvMiembros_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMiembros.CurrentRow == null) return;

            _miembroSeleccionadoId = Convert.ToInt32(dgvMiembros.CurrentRow.Cells["MiembroId"].Value);
            cmbPuesto.Text = dgvMiembros.CurrentRow.Cells["Puesto"].Value?.ToString();
            txtNombreMiembro.Text = dgvMiembros.CurrentRow.Cells["Nombre"].Value?.ToString();
            txtMatricula.Text = dgvMiembros.CurrentRow.Cells["Matricula"].Value?.ToString();
            txtDescripcionMiembro.Text = dgvMiembros.CurrentRow.Cells["Descripcion"].Value?.ToString();
            _fotoPath = dgvMiembros.CurrentRow.Cells["FotoPath"].Value?.ToString();

            CargarFotoPreview(_fotoPath);
        }

        private void btnSeleccionarFoto_Click(object sender, EventArgs e)
        {
            using var open = new OpenFileDialog();
            open.Title = "Seleccionar foto";
            open.Filter = "Imágenes|*.png;*.jpg;*.jpeg;*.bmp";

            if (open.ShowDialog() != DialogResult.OK) return;

            _fotoPath = CopiarFoto(open.FileName);
            CargarFotoPreview(_fotoPath);
        }

        private void CargarFotoPreview(string ruta)
        {
            if (string.IsNullOrWhiteSpace(ruta) || !File.Exists(ruta))
            {
                picFoto.Image = null;
                lblFotoTexto.Text = "Sin foto";
                return;
            }

            try
            {
                using var imgTemp = Image.FromFile(ruta);
                picFoto.Image = new Bitmap(imgTemp);
                picFoto.SizeMode = PictureBoxSizeMode.Zoom;
                lblFotoTexto.Text = Path.GetFileName(ruta);
            }
            catch
            {
                picFoto.Image = null;
                lblFotoTexto.Text = "Sin foto";
            }
        }

        private string CopiarFoto(string origen)
        {
            string carpeta = Path.Combine(Application.StartupPath, "Assets", "FotosMiembros");

            if (!Directory.Exists(carpeta))
                Directory.CreateDirectory(carpeta);

            string extension = Path.GetExtension(origen);
            string nombreArchivo = $"miembro_{DateTime.Now:yyyyMMddHHmmssfff}{extension}";
            string destino = Path.Combine(carpeta, nombreArchivo);

            File.Copy(origen, destino, true);
            return destino;
        }

        private int ObtenerOrdenPorPuesto(string puesto)
        {
            switch (puesto.ToLower())
            {
                case "presidente": return 1;
                case "vicepresidente": return 2;
                case "secretario": return 3;
                case "tesorero": return 4;
                default: return 5;
            }
        }

        // ── CRUD miembros ────────────────────────────────────────────

        private void btnAgregarMiembro_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreMiembro.Text) ||
                string.IsNullOrWhiteSpace(txtMatricula.Text))
            {
                MessageBox.Show("Completa nombre y matrícula.");
                return;
            }

            using var con = DbConnection.GetConnection();

            // ✅ FIX Error 8: UsuarioId = NULL (el miembro no es
            //    necesariamente un usuario del sistema). Antes se
            //    pasaba _usuarioId (el admin), lo que dejaba a todos
            //    los miembros con el mismo UsuarioId incorrecto.
            con.Execute(
                @"INSERT INTO MiembrosPlanchas
                  (UsuarioId, PlanchaId, Puesto, Orden,
                   Nombre, Matricula, Descripcion, FotoPath)
                  VALUES
                  (NULL, @planchaId, @puesto, @orden,
                   @nombre, @matricula, @descripcion, @fotoPath)",
                new
                {
                    planchaId = _planchaId,
                    puesto = cmbPuesto.Text,
                    orden = ObtenerOrdenPorPuesto(cmbPuesto.Text),
                    nombre = txtNombreMiembro.Text.Trim(),
                    matricula = txtMatricula.Text.Trim(),
                    descripcion = txtDescripcionMiembro.Text.Trim(),
                    fotoPath = _fotoPath
                });

            CargarMiembros();
        }

        private void btnActualizarMiembro_Click(object sender, EventArgs e)
        {
            if (_miembroSeleccionadoId <= 0)
            {
                MessageBox.Show("Selecciona un miembro.");
                return;
            }

            using var con = DbConnection.GetConnection();

            con.Execute(
                @"UPDATE MiembrosPlanchas
                  SET Puesto      = @puesto,
                      Orden       = @orden,
                      Nombre      = @nombre,
                      Matricula   = @matricula,
                      Descripcion = @descripcion,
                      FotoPath    = @fotoPath
                  WHERE MiembroId = @id",
                new
                {
                    id = _miembroSeleccionadoId,
                    puesto = cmbPuesto.Text,
                    orden = ObtenerOrdenPorPuesto(cmbPuesto.Text),
                    nombre = txtNombreMiembro.Text.Trim(),
                    matricula = txtMatricula.Text.Trim(),
                    descripcion = txtDescripcionMiembro.Text.Trim(),
                    fotoPath = _fotoPath
                });

            CargarMiembros();
        }

        private void btnEliminarMiembro_Click(object sender, EventArgs e)
        {
            if (_miembroSeleccionadoId <= 0)
            {
                MessageBox.Show("Selecciona un miembro.");
                return;
            }

            using var con = DbConnection.GetConnection();

            con.Execute(
                "DELETE FROM MiembrosPlanchas WHERE MiembroId = @id",
                new { id = _miembroSeleccionadoId });

            CargarMiembros();
        }
    }
}