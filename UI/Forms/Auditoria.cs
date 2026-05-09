using SistemaVotacion.DAL;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    public partial class Auditoria : Form
    {
        private readonly AuditoriaRepository _repo = new AuditoriaRepository();

        public Auditoria()
        {
            InitializeComponent();

            CrearColumnasAuditoria();

            txtBuscar.TextChanged += (s, e) => FiltrarAuditoria();

            CargarAuditoria();
        }

        private void CrearColumnasAuditoria()
        {
            dgvAuditoria.Columns.Clear();
            dgvAuditoria.AutoGenerateColumns = false;

            dgvAuditoria.Columns.Add("LogId", "ID");
            dgvAuditoria.Columns.Add("Accion", "Acción");
            dgvAuditoria.Columns.Add("Detalle", "Detalle");
            dgvAuditoria.Columns.Add("Fecha", "Fecha");
            dgvAuditoria.Columns.Add("UsuarioId", "Usuario");

            dgvAuditoria.Columns["LogId"].FillWeight = 45;
            dgvAuditoria.Columns["Accion"].FillWeight = 120;
            dgvAuditoria.Columns["Detalle"].FillWeight = 260;
            dgvAuditoria.Columns["Fecha"].FillWeight = 150;
            dgvAuditoria.Columns["UsuarioId"].FillWeight = 70;
        }

        private void CargarAuditoria()
        {
            dgvAuditoria.Rows.Clear();

            var logs = _repo.GetRecientes(200).ToList();

            lblTotal.Text = $"Total de registros: {logs.Count}";

            foreach (var log in logs)
            {
                dgvAuditoria.Rows.Add(
                    log.LogId,
                    log.Accion,
                    log.Detalle,
                    log.Fecha,
                    log.UsuarioId?.ToString() ?? "-"
                );
            }
        }

        private void FiltrarAuditoria()
        {
            string q = txtBuscar.Text.Trim().ToLower();

            dgvAuditoria.Rows.Clear();

            var logs = _repo.GetRecientes(200).ToList();

            if (!string.IsNullOrWhiteSpace(q))
            {
                logs = logs.Where(x =>
                    (x.Accion ?? "").ToLower().Contains(q) ||
                    (x.Detalle ?? "").ToLower().Contains(q) ||
                    (x.UsuarioId?.ToString() ?? "").Contains(q)
                ).ToList();
            }

            lblTotal.Text = $"Total de registros: {logs.Count}";

            foreach (var log in logs)
            {
                dgvAuditoria.Rows.Add(
                    log.LogId,
                    log.Accion,
                    log.Detalle,
                    log.Fecha,
                    log.UsuarioId?.ToString() ?? "-"
                );
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarAuditoria();
        }
    }
}