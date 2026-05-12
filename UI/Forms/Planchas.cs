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
        private readonly PlanchaService _planchaSvc = new PlanchaService();
        private Plancha _planchaSeleccionada;

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

            dgvPlanchas.Columns.Add(new DataGridViewTextBoxColumn { Name = "PlanchaId", HeaderText = "ID", Width = 60 });
            dgvPlanchas.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nombre", HeaderText = "Plancha", Width = 220 });
            dgvPlanchas.Columns.Add(new DataGridViewTextBoxColumn { Name = "AdminNombre", HeaderText = "Admin", Width = 160 });
            dgvPlanchas.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Activa", HeaderText = "Activa", Width = 70 });

            dgvMiembros.Columns.Add(new DataGridViewImageColumn
            {
                Name = "Foto",
                HeaderText = "Foto",
                Width = 70,
                ImageLayout = DataGridViewImageCellLayout.Zoom
            });

            dgvMiembros.Columns.Add(new DataGridViewTextBoxColumn { Name = "MiembroId", HeaderText = "ID", Width = 50 });
            dgvMiembros.Columns.Add(new DataGridViewTextBoxColumn { Name = "Puesto", HeaderText = "Cargo", Width = 130 });
            dgvMiembros.Columns.Add(new DataGridViewTextBoxColumn { Name = "NombreCompleto", HeaderText = "Nombre", Width = 180 });
            dgvMiembros.Columns.Add(new DataGridViewTextBoxColumn { Name = "Matricula", HeaderText = "Matrícula", Width = 120 });
            dgvMiembros.Columns.Add(new DataGridViewTextBoxColumn { Name = "Descripcion", HeaderText = "Descripción", Width = 180 });
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

            _planchaSeleccionada = null;
            dgvMiembros.Rows.Clear();
        }

        private Image CargarImagen(string ruta)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ruta) || !File.Exists(ruta))
                    return null;

                Image img = Image.FromFile(ruta);
                return new Bitmap(img, new Size(45, 45));
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
                    m.NombreCompleto ?? m.Nombre,
                    m.Matricula,
                    m.Descripcion
                );
            }
        }

        private void dgvPlanchas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPlanchas.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvPlanchas.CurrentRow.Cells["PlanchaId"].Value);

            _planchaSeleccionada = _planchaSvc.GetById(id);

            if (_planchaSeleccionada == null) return;

            CargarMiembros(id);
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            var frm = new FrmEditarPlancha(null);

            if (frm.ShowDialog() == DialogResult.OK)
                CargarPlanchas();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (_planchaSeleccionada == null)
                return;

            var frm = new FrmEditarPlancha(_planchaSeleccionada);

            if (frm.ShowDialog() == DialogResult.OK)
                CargarPlanchas();
        }

        private void btnAddMiembro_Click(object sender, EventArgs e)
        {
            if (_planchaSeleccionada == null)
                return;

            var frm = new FrmAgregarMiembro(_planchaSeleccionada.PlanchaId);

            if (frm.ShowDialog() == DialogResult.OK)
                CargarMiembros(_planchaSeleccionada.PlanchaId);
        }

        private void btnEditarMiembro_Click(object sender, EventArgs e)
        {
            if (_planchaSeleccionada == null || dgvMiembros.CurrentRow == null)
                return;

            int id = Convert.ToInt32(dgvMiembros.CurrentRow.Cells["MiembroId"].Value);
            var miembro = _planchaSvc.GetMiembroById(id);

            if (miembro == null) return;

            var frm = new FrmAgregarMiembro(_planchaSeleccionada.PlanchaId, miembro);

            if (frm.ShowDialog() == DialogResult.OK)
                CargarMiembros(_planchaSeleccionada.PlanchaId);
        }

        private void btnQuitarMiembro_Click(object sender, EventArgs e)
        {
            if (_planchaSeleccionada == null || dgvMiembros.CurrentRow == null)
                return;

            int id = Convert.ToInt32(dgvMiembros.CurrentRow.Cells["MiembroId"].Value);

            _planchaSvc.EliminarMiembro(id);
            CargarMiembros(_planchaSeleccionada.PlanchaId);
        }
    }
}