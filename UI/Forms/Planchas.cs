using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SistemaVotacion.BLL;
using SistemaVotacion.Models;
using SistemaVotacion.Utils;

namespace SistemaVotacion.UI.Forms
{
    public partial class Planchas : Form
    {
        private readonly PlanchaService _planchaSvc = new();
        private Plancha? _planchaSeleccionada;

        public Planchas()
        {
            InitializeComponent();

            TopLevel = false;
            FormBorderStyle = FormBorderStyle.None;
            Dock = DockStyle.Fill;

            ConfigurarColumnas();
            AplicarEstilos();
            CargarPlanchas();
        }

        private void ConfigurarColumnas()
        {
            dgvPlanchas.Columns.Clear();
            dgvMiembros.Columns.Clear();

            dgvPlanchas.AutoGenerateColumns = false;
            dgvMiembros.AutoGenerateColumns = false;

            dgvPlanchas.Columns.Add(new DataGridViewImageColumn
            {
                Name = "Logo",
                HeaderText = "Logo",
                Width = 70,
                ImageLayout = DataGridViewImageCellLayout.Zoom
            });

            dgvPlanchas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PlanchaId",
                HeaderText = "ID",
                Width = 60
            });

            dgvPlanchas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nombre",
                HeaderText = "Plancha",
                Width = 220
            });

            dgvPlanchas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "AdminNombre",
                HeaderText = "Admin",
                Width = 160
            });

            dgvPlanchas.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "Activa",
                HeaderText = "Activa",
                Width = 70
            });

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
                Name = "NombreCompleto",
                HeaderText = "Nombre",
                Width = 180
            });

            dgvMiembros.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Matricula",
                HeaderText = "Matrícula",
                Width = 120
            });

            dgvMiembros.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Descripcion",
                HeaderText = "Descripción",
                Width = 180
            });
        }

        private void AplicarEstilos()
        {
            EstilizarGrid(dgvPlanchas);
            EstilizarGrid(dgvMiembros);
        }

        private void EstilizarGrid(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.GridColor = Color.FromArgb(220, 225, 235);
            dgv.RowHeadersVisible = false;
            dgv.ReadOnly = true;
            dgv.MultiSelect = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ColumnHeadersHeight = 42;
            dgv.RowTemplate.Height = 55;
            dgv.Font = new Font("Segoe UI", 10F);

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 55, 150);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(10, 35, 90);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(22, 97, 255);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 255);
        }

        private void CargarPlanchas()
        {
            dgvPlanchas.Rows.Clear();

            foreach (var p in _planchaSvc.GetAll())
            {
                dgvPlanchas.Rows.Add(
                    CargarImagen(p.LogoPath),
                    p.PlanchaId,
                    p.Nombre,
                    p.AdminNombre,
                    p.Activa
                );
            }

            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnAddMiembro.Enabled = false;
            btnEditarMiembro.Enabled = false;
            btnQuitarMiembro.Enabled = false;

            lblPlancha.Text = "Seleccione una plancha";
            dgvMiembros.Rows.Clear();
        }

        private Image? CargarImagen(string? ruta)
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

        private void CargarMiembros(int planchaId)
        {
            dgvMiembros.Rows.Clear();

            foreach (var m in _planchaSvc.GetMiembros(planchaId))
            {
                dgvMiembros.Rows.Add(
                    CargarImagen(m.FotoPath),
                    m.MiembroId,
                    m.Puesto,
                    !string.IsNullOrWhiteSpace(m.NombreCompleto) ? m.NombreCompleto : m.Nombre,
                    m.Matricula,
                    m.Descripcion
                );
            }
        }

        private void dgvPlanchas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPlanchas.CurrentRow == null) return;
            if (dgvPlanchas.CurrentRow.Cells["PlanchaId"].Value == null) return;

            int id = Convert.ToInt32(dgvPlanchas.CurrentRow.Cells["PlanchaId"].Value);

            _planchaSeleccionada = _planchaSvc.GetById(id);

            if (_planchaSeleccionada == null) return;

            lblPlancha.Text = $"Miembros de {_planchaSeleccionada.Nombre}";

            CargarMiembros(id);

            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnAddMiembro.Enabled = true;
            btnEditarMiembro.Enabled = true;
            btnQuitarMiembro.Enabled = true;
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            using var frm = new FrmEditarPlancha(null);

            if (frm.ShowDialog() == DialogResult.OK)
                CargarPlanchas();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (_planchaSeleccionada == null)
            {
                Helpers.MsgError("Seleccione una plancha.");
                return;
            }

            using var frm = new FrmEditarPlancha(_planchaSeleccionada);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarPlanchas();
                CargarMiembros(_planchaSeleccionada.PlanchaId);
            }
        }

        private void BtnEliminar_Click(object? sender, EventArgs e)
        {
            if (_planchaSeleccionada == null)
            {
                Helpers.MsgError("Seleccione una plancha.");
                return;
            }

            if (!Helpers.Confirmar($"¿Desea eliminar la plancha '{_planchaSeleccionada.Nombre}'?"))
                return;

            bool ok = _planchaSvc.Eliminar(_planchaSeleccionada.PlanchaId);

            if (!ok)
            {
                Helpers.MsgError("No se pudo eliminar la plancha.");
                return;
            }

            Helpers.MsgExito("Plancha eliminada correctamente.");

            _planchaSeleccionada = null;
            CargarPlanchas();
            dgvMiembros.Rows.Clear();
        }

        private void btnAddMiembro_Click(object sender, EventArgs e)
        {
            if (_planchaSeleccionada == null)
            {
                Helpers.MsgError("Seleccione una plancha primero.");
                return;
            }

            using var frm = new FrmAgregarMiembro(_planchaSeleccionada.PlanchaId);

            if (frm.ShowDialog() == DialogResult.OK)
                CargarMiembros(_planchaSeleccionada.PlanchaId);
        }

        private void btnEditarMiembro_Click(object sender, EventArgs e)
        {
            if (_planchaSeleccionada == null)
            {
                Helpers.MsgError("Seleccione una plancha.");
                return;
            }

            if (dgvMiembros.CurrentRow == null)
            {
                Helpers.MsgError("Seleccione un miembro.");
                return;
            }

            int miembroId = Convert.ToInt32(dgvMiembros.CurrentRow.Cells["MiembroId"].Value);

            var miembro = _planchaSvc.GetMiembroById(miembroId);

            if (miembro == null)
            {
                Helpers.MsgError("No se encontró el miembro.");
                return;
            }

            using var frm = new FrmAgregarMiembro(_planchaSeleccionada.PlanchaId, miembro);

            if (frm.ShowDialog() == DialogResult.OK)
                CargarMiembros(_planchaSeleccionada.PlanchaId);
        }

        private void btnQuitarMiembro_Click(object sender, EventArgs e)
        {
            if (_planchaSeleccionada == null) return;

            if (dgvMiembros.CurrentRow == null)
            {
                Helpers.MsgError("Seleccione un miembro.");
                return;
            }

            if (!Helpers.Confirmar("¿Deseas quitar este miembro de la plancha?"))
                return;

            int miembroId = Convert.ToInt32(dgvMiembros.CurrentRow.Cells["MiembroId"].Value);

            _planchaSvc.EliminarMiembro(miembroId);
            CargarMiembros(_planchaSeleccionada.PlanchaId);
        }
    }
}