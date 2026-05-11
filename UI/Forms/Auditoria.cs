<<<<<<< HEAD
﻿// ============================
// Auditoria.cs
// ============================

using SistemaVotacion.DAL;
using System;
using System.Collections.Generic;
=======
﻿using SistemaVotacion.DAL;
using System;
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
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

<<<<<<< HEAD
            txtBuscar.TextChanged += TxtBuscar_TextChanged;
=======
            txtBuscar.TextChanged += (s, e) => FiltrarAuditoria();
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

            CargarAuditoria();
        }

<<<<<<< HEAD
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarAuditoria();
        }

=======
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
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

<<<<<<< HEAD
            List<dynamic> logs = _repo.GetRecientes(200).ToList<dynamic>();

            lblTotal.Text = "Total de registros: " + logs.Count;
=======
            var logs = _repo.GetRecientes(200).ToList();

            lblTotal.Text = $"Total de registros: {logs.Count}";
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

            foreach (var log in logs)
            {
                dgvAuditoria.Rows.Add(
                    log.LogId,
                    log.Accion,
                    log.Detalle,
                    log.Fecha,
<<<<<<< HEAD
                    log.UsuarioId != null ? log.UsuarioId.ToString() : "-"
=======
                    log.UsuarioId?.ToString() ?? "-"
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
                );
            }
        }

        private void FiltrarAuditoria()
        {
            string q = txtBuscar.Text.Trim().ToLower();

            dgvAuditoria.Rows.Clear();

<<<<<<< HEAD
            List<dynamic> logs = _repo.GetRecientes(200).ToList<dynamic>();
=======
            var logs = _repo.GetRecientes(200).ToList();
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

            if (!string.IsNullOrWhiteSpace(q))
            {
                logs = logs.Where(x =>
<<<<<<< HEAD
                    ((x.Accion ?? "").ToLower().Contains(q)) ||
                    ((x.Detalle ?? "").ToLower().Contains(q)) ||
                    ((x.UsuarioId != null ? x.UsuarioId.ToString() : "").Contains(q))
                ).ToList();
            }

            lblTotal.Text = "Total de registros: " + logs.Count;
=======
                    (x.Accion ?? "").ToLower().Contains(q) ||
                    (x.Detalle ?? "").ToLower().Contains(q) ||
                    (x.UsuarioId?.ToString() ?? "").Contains(q)
                ).ToList();
            }

            lblTotal.Text = $"Total de registros: {logs.Count}";
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

            foreach (var log in logs)
            {
                dgvAuditoria.Rows.Add(
                    log.LogId,
                    log.Accion,
                    log.Detalle,
                    log.Fecha,
<<<<<<< HEAD
                    log.UsuarioId != null ? log.UsuarioId.ToString() : "-"
=======
                    log.UsuarioId?.ToString() ?? "-"
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
                );
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarAuditoria();
        }
    }
}