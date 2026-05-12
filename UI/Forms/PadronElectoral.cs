using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SistemaVotacion.BLL;
using SistemaVotacion.Models;
using SistemaVotacion.Utils;

namespace SistemaVotacion.UI.Forms
{
    public partial class PadronElectoral : Form
    {
        private readonly VotacionService _svc = new VotacionService();

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

            if (votaciones.Count > 0)
                Cargar();
        }

        private void Cargar()
        {
            int vid;

            if (!int.TryParse(cmbVotacion.SelectedValue.ToString(), out vid))
                return;

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
            int vid;
            if (!int.TryParse(cmbVotacion.SelectedValue.ToString(), out vid))
                return;

            var disponibles = new UsuarioService().GetVotantesDisponibles(vid).ToList();

            if (disponibles.Count == 0)
            {
                Helpers.MsgError("No hay votantes disponibles.");
                return;
            }

            Form frm = new Form();
            frm.Text = "Agregar al Padrón";
            frm.Size = new Size(430, 170);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.BackColor = Color.FromArgb(245, 247, 252);

            ComboBox cmb = new ComboBox();
            cmb.Location = new Point(25, 25);
            cmb.Size = new Size(360, 30);
            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb.DataSource = disponibles;
            cmb.DisplayMember = "NombreCompleto";
            cmb.ValueMember = "UsuarioId";

            Button btn = new Button();
            btn.Text = "Agregar";
            btn.Location = new Point(270, 80);
            btn.Size = new Size(115, 38);
            btn.BackColor = Color.FromArgb(22, 97, 255);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;

            btn.Click += delegate
            {
                int uid;
                if (!int.TryParse(cmb.SelectedValue.ToString(), out uid))
                    return;

                var r = _svc.AgregarAlPadron(vid, uid);
                bool ok = r.Item1;
                string msg = r.Item2;

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
            if (dgv.CurrentRow == null) return;

            if (!Helpers.Confirmar("¿Quitar del padrón?"))
                return;

            int id = Convert.ToInt32(dgv.CurrentRow.Cells["PadronId"].Value);

            _svc.EliminarDelPadron(id);
            Cargar();
        }
    }
}