using System;
using System.Drawing;
using System.Windows.Forms;
using SistemaVotacion.BLL;
using SistemaVotacion.Models;
using SistemaVotacion.UI.Controls;
using SistemaVotacion.Utils;

namespace SistemaVotacion.UI.Forms
{
    public partial class VotacionAdmin : Form
    {
        private readonly VotacionService _svc = new VotacionService();

        public VotacionAdmin()
        {
            InitializeComponent();

            TopLevel = false;
            FormBorderStyle = FormBorderStyle.None;
            Dock = DockStyle.Fill;

            ConfigurarColumnas();
            AplicarEstilos();
            Cargar();
        }

        private void AplicarEstilos()
        {
            btnNueva.BackColor = Color.FromArgb(22, 97, 255);
            btnActivar.BackColor = Color.FromArgb(0, 55, 150);
            btnCerrar.BackColor = Color.FromArgb(230, 40, 45);

            btnNueva.ForeColor = Color.White;
            btnActivar.ForeColor = Color.White;
            btnCerrar.ForeColor = Color.White;

            btnNueva.FlatStyle = FlatStyle.Flat;
            btnActivar.FlatStyle = FlatStyle.Flat;
            btnCerrar.FlatStyle = FlatStyle.Flat;

            btnNueva.FlatAppearance.BorderSize = 0;
            btnActivar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatAppearance.BorderSize = 0;

            dgv.EnableHeadersVisualStyles = false;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.GridColor = Color.FromArgb(220, 225, 235);

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 55, 150);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI Semibold", 10f, FontStyle.Bold);

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(10, 35, 90);
            dgv.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(22, 97, 255);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            dgv.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(248, 250, 255);

            dgv.RowTemplate.Height = 35;
        }

        private void ConfigurarColumnas()
        {
            dgv.Columns.Clear();
            dgv.AutoGenerateColumns = false;

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "VotacionId",
                HeaderText = "ID",
                Width = 60
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Titulo",
                HeaderText = "Título",
                Width = 280
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FechaInicio",
                HeaderText = "Inicio",
                Width = 180
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FechaFin",
                HeaderText = "Fin",
                Width = 180
            });

            dgv.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "Activa",
                HeaderText = "Activa",
                Width = 80
            });
        }

        private void Cargar()
        {
            dgv.Rows.Clear();

            var activa = _svc.GetActiva();

            lblEstado.Text = activa == null
                ? "Sin votación activa"
                : $"Votación activa: {activa.Titulo}";

            foreach (var v in _svc.GetAll())
            {
                dgv.Rows.Add(
                    v.VotacionId,
                    v.Titulo,
                    v.FechaInicio.ToString("dd/MM/yyyy HH:mm"),
                    v.FechaFin.ToString("dd/MM/yyyy HH:mm"),
                    v.Activa
                );
            }
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            var frm = new NuevaVotacionForm();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.NuevaVotacion != null)
                {
                    var result = _svc.Crear(frm.NuevaVotacion);

                    if (!result.Item1)
                    {
                        MessageBox.Show(
                            result.Item2,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        return;
                    }

                    MessageBox.Show(
                        result.Item2,
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    Cargar();
                }
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null)
                return;

            int id = Convert.ToInt32(
                dgv.CurrentRow.Cells["VotacionId"].Value
            );

            if (!Helpers.Confirmar("¿Activar esta votación?"))
                return;

            _svc.Activar(id);

            MessageBox.Show(
                "Votación activada",
                "Sistema",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            Cargar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null)
                return;

            int id = Convert.ToInt32(
                dgv.CurrentRow.Cells["VotacionId"].Value
            );

            if (!Helpers.Confirmar("¿Cerrar esta votación y marcar nulos?"))
                return;

            _svc.Cerrar(id);

            MessageBox.Show(
                "Votación cerrada",
                "Sistema",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            Cargar();
        }

        private void VotacionAdmin_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccione una votación.",
                    "Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            try
            {
                // Obtener ID seleccionado
                int id = Convert.ToInt32(
                    dgv.CurrentRow.Cells["VotacionId"].Value
                );

                // Buscar votación
                var votacion = _svc.GetById(id);

                if (votacion == null)
                {
                    MessageBox.Show(
                        "Votación no encontrada.",
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                // Abrir formulario de edición
                NuevaVotacionForm frm =
                    new NuevaVotacionForm(votacion);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var result = _svc.Actualizar(
                        frm.NuevaVotacion
                    );

                    MessageBox.Show(
                        result.Item2,
                        "Sistema",
                        MessageBoxButtons.OK,
                        result.Item1
                            ? MessageBoxIcon.Information
                            : MessageBoxIcon.Warning
                    );

                    if (result.Item1)
                    {
                        Cargar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error:\n" + ex.Message,
                    "Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}