using System;
using System.Drawing;
using System.Windows.Forms;
using SistemaVotacion.BLL;
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
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10f, FontStyle.Bold);

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(10, 35, 90);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(22, 97, 255);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 255);
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

            lblEstado.Text = activa is null
                ? "Sin votación activa"
                : $"Votación activa: {activa.Titulo}";

            foreach (var v in _svc.GetAll())
            {
                dgv.Rows.Add(
                    v.VotacionId,
                    v.Titulo,
                    v.FechaInicio,
                    v.FechaFin,
                    v.Activa
                );
            }
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            var frm = new FrmVotacion();

            if (frm.ShowDialog() == DialogResult.OK)
                Cargar();
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow is null) return;

            int id = Convert.ToInt32(dgv.CurrentRow.Cells["VotacionId"].Value);

            if (!Helpers.Confirmar("¿Activar esta votación?"))
                return;

            _svc.Activar(id);
            Cargar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow is null) return;

            int id = Convert.ToInt32(dgv.CurrentRow.Cells["VotacionId"].Value);

            if (!Helpers.Confirmar("¿Cerrar esta votación y marcar nulos?"))
                return;

            _svc.Cerrar(id);
            Cargar();
        }

        private void VotacionAdmin_Load(object sender, EventArgs e)
        {
            // Si necesitas inicialización extra al cargar el formulario, colócala aquí
        }
    }
}