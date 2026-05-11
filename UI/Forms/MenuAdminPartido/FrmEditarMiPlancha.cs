using Dapper;
using SistemaVotacion.DAL;
using SistemaVotacion.Utils;
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
        private string? _fotoPath;

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

            dgvMiembros.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MiembroId",
                HeaderText = "ID",
                Width = 50
            });

            dgvMiembros.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Puesto",
                HeaderText = "Cargo",
                Width = 130
            });

            dgvMiembros.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nombre",
                HeaderText = "Nombre",
                Width = 180
            });

            dgvMiembros.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Matricula",
                HeaderText = "Matrícula",
                Width = 110
            });

            dgvMiembros.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Descripcion",
                HeaderText = "Descripción",
                Width = 180
            });

            dgvMiembros.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FotoPath",
                HeaderText = "FotoPath",
                Visible = false
            });

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
<<<<<<< HEAD
            var con = DbConnection.GetConnection();
=======
            using var con = DbConnection.GetConnection();
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

            int? planchaId = con.QueryFirstOrDefault<int?>(
                """
                SELECT TOP 1 PlanchaId
                FROM Usuarios
                WHERE UsuarioId = @id
                """,
                new { id = _usuarioId });

            if (planchaId == null || planchaId <= 0)
            {
                planchaId = con.QueryFirstOrDefault<int?>(
                    """
                    SELECT TOP 1 PlanchaId
                    FROM Planchas
                    WHERE AdminUserId = @id
                    """,
                    new { id = _usuarioId });
            }

            _planchaId = planchaId ?? 0;

            if (_planchaId <= 0)
                MostrarAsignacionPlancha();
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
<<<<<<< HEAD
            var con = DbConnection.GetConnection();
=======
            using var con = DbConnection.GetConnection();
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

            var libres = con.Query(
                """
                SELECT p.PlanchaId, p.Nombre
                FROM Planchas p
                WHERE NOT EXISTS 
                (
                    SELECT 1
                    FROM Usuarios u
                    WHERE u.PlanchaId = p.PlanchaId
                )
                ORDER BY p.Nombre
                """).ToList();

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

                lblAsignacion.Text = "No tienes una plancha asignada. Elige una disponible o crea la tuya.";
            }
            else
            {
                cmbPlanchasDisponibles.DataSource = null;
                cmbPlanchasDisponibles.Enabled = false;
                btnTomarPlancha.Enabled = false;

                lblAsignacion.Text = "No hay planchas libres. Puedes crear tu propia plancha.";
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

<<<<<<< HEAD
            var con = DbConnection.GetConnection();
=======
            using var con = DbConnection.GetConnection();
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

            con.Execute(
                """
                UPDATE Usuarios
                SET PlanchaId = @planchaId
                WHERE UsuarioId = @usuarioId
                """,
                new
                {
                    planchaId = planchaSeleccionada,
                    usuarioId = _usuarioId
                });

            con.Execute(
                """
                UPDATE Planchas
                SET AdminUserId = @usuarioId,
                    FechaModificacion = GETDATE()
                WHERE PlanchaId = @planchaId
                """,
                new
                {
                    planchaId = planchaSeleccionada,
                    usuarioId = _usuarioId
                });

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

<<<<<<< HEAD
            var con = DbConnection.GetConnection();
=======
            using var con = DbConnection.GetConnection();
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

            int nuevaPlanchaId = con.ExecuteScalar<int>(
                """
                INSERT INTO Planchas 
                (
                    Nombre, 
                    Descripcion, 
                    Mision, 
                    LogoPath, 
                    Color, 
                    AdminUserId, 
                    Activa
                )
                OUTPUT INSERTED.PlanchaId
                VALUES 
                (
                    @nombre, 
                    @descripcion, 
                    '', 
                    NULL, 
                    '#007BFF', 
                    @adminUserId, 
                    1
                )
                """,
                new
                {
                    nombre = txtNuevaPlancha.Text.Trim(),
                    descripcion = txtNuevaDescripcion.Text.Trim(),
                    adminUserId = _usuarioId
                });

            con.Execute(
                """
                UPDATE Usuarios
                SET PlanchaId = @planchaId
                WHERE UsuarioId = @usuarioId
                """,
                new
                {
                    planchaId = nuevaPlanchaId,
                    usuarioId = _usuarioId
                });

            MessageBox.Show("Tu plancha fue creada correctamente.");

            CargarPlanchaDelUsuario();
        }

        private void CargarPlancha()
        {
<<<<<<< HEAD
            var con = DbConnection.GetConnection();
=======
            using var con = DbConnection.GetConnection();
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

            var plancha = con.QueryFirstOrDefault(
                """
                SELECT *
                FROM Planchas
                WHERE PlanchaId = @id
                """,
                new { id = _planchaId });

            if (plancha == null)
            {
                MessageBox.Show("No se encontró la plancha asignada.");
                return;
            }

            txtNombrePlancha.Text = plancha.Nombre;
            txtDescripcion.Text = plancha.Descripcion;
        }

        private void CargarMiembros()
        {
            dgvMiembros.Rows.Clear();

<<<<<<< HEAD
            var con = DbConnection.GetConnection();
=======
            using var con = DbConnection.GetConnection();
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

            var miembros = con.Query(
                """
                SELECT 
                    MiembroId,
                    PlanchaId,
                    UsuarioId,
                    Puesto,
                    Orden,
                    Descripcion,
                    Nombre,
                    Matricula,
                    FotoPath
                FROM MiembrosPlanchas
                WHERE PlanchaId = @id
                ORDER BY Orden, MiembroId
                """,
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

        private Image? CargarImagen(string? ruta)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ruta) || !File.Exists(ruta))
                    return null;

<<<<<<< HEAD
                var imgTemp = Image.FromFile(ruta);
=======
                using var imgTemp = Image.FromFile(ruta);
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
                return new Bitmap(imgTemp, new Size(45, 45));
            }
            catch
            {
                return null;
            }
        }

        private void btnGuardarPlancha_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombrePlancha.Text))
            {
                MessageBox.Show("Escribe el nombre de la plancha.");
                return;
            }

<<<<<<< HEAD
            var con = DbConnection.GetConnection();
=======
            using var con = DbConnection.GetConnection();
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

            con.Execute(
                """
                UPDATE Planchas
                SET Nombre = @nombre,
                    Descripcion = @descripcion,
                    FechaModificacion = GETDATE()
                WHERE PlanchaId = @id
                """,
                new
                {
                    nombre = txtNombrePlancha.Text.Trim(),
                    descripcion = txtDescripcion.Text.Trim(),
                    id = _planchaId
                });

            MessageBox.Show("Plancha actualizada correctamente.");
            CargarPlancha();
        }

        private void btnSeleccionarFoto_Click(object sender, EventArgs e)
        {
            using OpenFileDialog open = new OpenFileDialog();

            open.Title = "Seleccionar foto del miembro";
            open.Filter = "Imágenes|*.png;*.jpg;*.jpeg;*.bmp";

            if (open.ShowDialog() != DialogResult.OK)
                return;

            _fotoPath = CopiarFoto(open.FileName);
            CargarFotoPreview(_fotoPath);
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

        private void CargarFotoPreview(string? ruta)
        {
            if (string.IsNullOrWhiteSpace(ruta) || !File.Exists(ruta))
            {
                picFoto.Image = null;
                lblFotoTexto.Text = "Sin foto";
                return;
            }

<<<<<<< HEAD
            var imgTemp = Image.FromFile(ruta);
=======
            using var imgTemp = Image.FromFile(ruta);
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
            picFoto.Image = new Bitmap(imgTemp);
            picFoto.SizeMode = PictureBoxSizeMode.Zoom;
            lblFotoTexto.Text = Path.GetFileName(ruta);
        }

        private bool ExisteCargoUnico(string puesto, int miembroIdExcluir = 0)
        {
            if (!puesto.Equals("Presidente", StringComparison.OrdinalIgnoreCase) &&
                !puesto.Equals("Vicepresidente", StringComparison.OrdinalIgnoreCase))
                return false;

<<<<<<< HEAD
            var con = DbConnection.GetConnection();
=======
            using var con = DbConnection.GetConnection();
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

            int total = con.ExecuteScalar<int>(
                """
                SELECT COUNT(1)
                FROM MiembrosPlanchas
                WHERE PlanchaId = @planchaId
                  AND LOWER(LTRIM(RTRIM(Puesto))) = LOWER(LTRIM(RTRIM(@puesto)))
                  AND MiembroId <> @miembroIdExcluir
                """,
                new
                {
                    planchaId = _planchaId,
                    puesto,
                    miembroIdExcluir
                });

            return total > 0;
        }

        private void btnAgregarMiembro_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreMiembro.Text) ||
                string.IsNullOrWhiteSpace(txtMatricula.Text))
            {
                MessageBox.Show("Completa nombre y matrícula.");
                return;
            }

            string puesto = cmbPuesto.Text.Trim();

            if (ExisteCargoUnico(puesto))
            {
                MessageBox.Show($"Ya existe un {puesto} en esta plancha.");
                return;
            }

<<<<<<< HEAD
            var con = DbConnection.GetConnection();
=======
            using var con = DbConnection.GetConnection();
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

            con.Execute(
                """
                INSERT INTO MiembrosPlanchas
                (
                    UsuarioId,
                    PlanchaId,
                    Puesto,
                    Orden,
                    Nombre,
                    Matricula,
                    Descripcion,
                    FotoPath
                )
                VALUES
                (
                    @usuarioId,
                    @planchaId,
                    @puesto,
                    @orden,
                    @nombre,
                    @matricula,
                    @descripcion,
                    @fotoPath
                )
                """,
                new
                {
                    usuarioId = _usuarioId,
                    planchaId = _planchaId,
                    puesto,
                    orden = ObtenerOrdenPorPuesto(puesto),
                    nombre = txtNombreMiembro.Text.Trim(),
                    matricula = txtMatricula.Text.Trim(),
                    descripcion = txtDescripcionMiembro.Text.Trim(),
                    fotoPath = _fotoPath
                });

            MessageBox.Show("Miembro agregado correctamente.");

            CargarMiembros();
        }

        private void btnActualizarMiembro_Click(object sender, EventArgs e)
        {
            if (_miembroSeleccionadoId <= 0)
            {
                MessageBox.Show("Selecciona un miembro para actualizar.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombreMiembro.Text) ||
                string.IsNullOrWhiteSpace(txtMatricula.Text))
            {
                MessageBox.Show("Completa nombre y matrícula.");
                return;
            }

            string puesto = cmbPuesto.Text.Trim();

            if (ExisteCargoUnico(puesto, _miembroSeleccionadoId))
            {
                MessageBox.Show($"Ya existe un {puesto} en esta plancha.");
                return;
            }

<<<<<<< HEAD
            var con = DbConnection.GetConnection();
=======
            using var con = DbConnection.GetConnection();
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

            con.Execute(
                """
                UPDATE MiembrosPlanchas
                SET Puesto = @puesto,
                    Orden = @orden,
                    Nombre = @nombre,
                    Matricula = @matricula,
                    Descripcion = @descripcion,
                    FotoPath = @fotoPath
                WHERE MiembroId = @miembroId
                  AND PlanchaId = @planchaId
                """,
                new
                {
                    puesto,
                    orden = ObtenerOrdenPorPuesto(puesto),
                    nombre = txtNombreMiembro.Text.Trim(),
                    matricula = txtMatricula.Text.Trim(),
                    descripcion = txtDescripcionMiembro.Text.Trim(),
                    fotoPath = _fotoPath,
                    miembroId = _miembroSeleccionadoId,
                    planchaId = _planchaId
                });

            MessageBox.Show("Miembro actualizado correctamente.");

            CargarMiembros();
        }

        private int ObtenerOrdenPorPuesto(string puesto)
        {
            return puesto.ToLower() switch
            {
                "presidente" => 1,
                "vicepresidente" => 2,
                "secretario" => 3,
                "tesorero" => 4,
                _ => 5
            };
        }

        private void btnEliminarMiembro_Click(object sender, EventArgs e)
        {
            if (dgvMiembros.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un miembro.");
                return;
            }

            int miembroId = Convert.ToInt32(dgvMiembros.CurrentRow.Cells["MiembroId"].Value);

            DialogResult r = MessageBox.Show(
                "¿Seguro que deseas eliminar este miembro?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r != DialogResult.Yes)
                return;

<<<<<<< HEAD
            var con = DbConnection.GetConnection();
=======
            using var con = DbConnection.GetConnection();
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

            con.Execute(
                """
                DELETE FROM MiembrosPlanchas
                WHERE MiembroId = @id
                  AND PlanchaId = @planchaId
                """,
                new
                {
                    id = miembroId,
                    planchaId = _planchaId
                });

            MessageBox.Show("Miembro eliminado correctamente.");
            CargarMiembros();
        }

        private void dgvMiembros_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvMiembros.CurrentRow == null)
                return;

            if (dgvMiembros.CurrentRow.Cells["MiembroId"].Value == null)
                return;

            _miembroSeleccionadoId = Convert.ToInt32(dgvMiembros.CurrentRow.Cells["MiembroId"].Value);

            cmbPuesto.Text = dgvMiembros.CurrentRow.Cells["Puesto"].Value?.ToString() ?? "Presidente";
            txtNombreMiembro.Text = dgvMiembros.CurrentRow.Cells["Nombre"].Value?.ToString() ?? "";
            txtMatricula.Text = dgvMiembros.CurrentRow.Cells["Matricula"].Value?.ToString() ?? "";
            txtDescripcionMiembro.Text = dgvMiembros.CurrentRow.Cells["Descripcion"].Value?.ToString() ?? "";
            _fotoPath = dgvMiembros.CurrentRow.Cells["FotoPath"].Value?.ToString();

            CargarFotoPreview(_fotoPath);
        }

        private void LimpiarMiembro()
        {
            _miembroSeleccionadoId = 0;
            cmbPuesto.SelectedIndex = 0;
            txtNombreMiembro.Clear();
            txtMatricula.Clear();
            txtDescripcionMiembro.Clear();
            _fotoPath = null;
            CargarFotoPreview(null);
            txtNombreMiembro.Focus();
        }
    }
}