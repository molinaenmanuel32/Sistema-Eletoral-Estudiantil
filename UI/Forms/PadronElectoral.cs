<<<<<<< HEAD
using SistemaVotacion.BLL;
=======
﻿using SistemaVotacion.BLL;
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
using SistemaVotacion.Models;
using SistemaVotacion.Utils;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    public partial class PadronElectoral : Form
    {
        private readonly VotacionService _svc = new();

        public PadronElectoral()
        {
            InitializeComponent();

            TopLevel = false;
            FormBorderStyle = FormBorderStyle.None;
            Dock = DockStyle.Fill;

            ConfigurarColumnas();
            AplicarEstilos();
            CargarVotaciones();
        }

        private void ConfigurarColumnas()
        {
            dgv.Columns.Clear();

            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "PadronId", HeaderText = "ID", Width = 60 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "NombreCompleto", HeaderText = "Nombre", Width = 240 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Matricula", HeaderText = "Matrícula", Width = 140 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Curso", HeaderText = "Curso", Width = 120 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Seccion", HeaderText = "Sección", Width = 100 });
        }

        private void AplicarEstilos()
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
            dgv.RowTemplate.Height = 36;
            dgv.Font = new Font("Segoe UI", 10f);

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 55, 150);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10f, FontStyle.Bold);

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(10, 35, 90);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(22, 97, 255);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 255);
        }

        private void CargarVotaciones()
        {
            var votaciones = _svc.GetAll().ToList();

            cmbVotacion.DataSource = votaciones;
            cmbVotacion.DisplayMember = "Titulo";
            cmbVotacion.ValueMember = "VotacionId";

            if (votaciones.Any())
                Cargar();
        }

        private void Cargar()
        {
            if (cmbVotacion.SelectedValue is not int vid) return;

            dgv.Rows.Clear();

            foreach (var p in _svc.GetPadron(vid))
            {
                dgv.Rows.Add(
                    p.PadronId,
                    p.NombreCompleto,
                    p.Matricula,
                    p.Curso,
                    p.Seccion
                );
            }
        }

        private void cmbVotacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbVotacion.SelectedValue is not int vid) return;

            var disponibles = new UsuarioService().GetVotantesDisponibles(vid).ToList();

            if (!disponibles.Any())
            {
                Helpers.MsgError("No hay votantes disponibles para agregar.");
                return;
            }

            var frm = new Form
            {
                Text = "Agregar al Padrón",
                Size = new Size(430, 170),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.FromArgb(245, 247, 252),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            var cmb = new ComboBox
            {
                Location = new Point(25, 25),
                Size = new Size(360, 30),
                DropDownStyle = ComboBoxStyle.DropDownList,
                DataSource = disponibles,
                DisplayMember = "NombreCompleto",
                ValueMember = "UsuarioId"
            };

            var btn = new Button
            {
                Text = "Agregar",
                Location = new Point(270, 80),
                Size = new Size(115, 38),
                BackColor = Color.FromArgb(22, 97, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btn.FlatAppearance.BorderSize = 0;

            btn.Click += (s, ev) =>
            {
                if (cmb.SelectedValue is not int uid) return;

<<<<<<< HEAD
                var _r_ = _svc.AgregarAlPadron(vid, uid);
            bool ok = _r_.Item1; string msg = _r_.Item2;
=======
                var (ok, msg) = _svc.AgregarAlPadron(vid, uid);
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

                if (!ok)
                    Helpers.MsgError(msg);
                else
                {
                    Helpers.MsgExito(msg);
                    frm.Close();
                }
            };

            frm.Controls.Add(cmb);
            frm.Controls.Add(btn);

            frm.ShowDialog();
            Cargar();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            if (dgv.CurrentRow == null) return;
=======
            if (dgv.CurrentRow is null) return;
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

            if (!Helpers.Confirmar("¿Quitar del padrón?")) return;

            int id = Convert.ToInt32(dgv.CurrentRow.Cells["PadronId"].Value);

            _svc.EliminarDelPadron(id);
            Cargar();
        }
    }
}