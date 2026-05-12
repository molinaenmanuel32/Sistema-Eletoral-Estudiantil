using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SistemaVotacion.BLL;
using SistemaVotacion.Models;
using SistemaVotacion.UI.Controls;
using SistemaVotacion.Utils;
using static SistemaVotacion.Utils.Tema;

namespace SistemaVotacion.UI.Forms
{
    public partial class Usuarios : Form
    {
        private readonly UsuarioService _svc = new UsuarioService();
        private readonly string placeholderBuscar = "Nombre, matrícula o usuario...";

        public Usuarios()
        {
            InitializeComponent();

            TopLevel = false;
            FormBorderStyle = FormBorderStyle.None;
            Dock = DockStyle.Fill;

            ConfigurarColumnas();
            AplicarEstilos();
            Cargar();

            txtBuscar.Text = placeholderBuscar;
            txtBuscar.ForeColor = Color.Gray;

            txtBuscar.Enter += TxtBuscar_Enter;
            txtBuscar.Leave += TxtBuscar_Leave;
        }

        private void TxtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == placeholderBuscar)
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.White;
            }
        }

        private void TxtBuscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtBuscar.Text = placeholderBuscar;
                txtBuscar.ForeColor = Color.Gray;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var f = new FrmEditarUsuario(null);

            if (f.ShowDialog() == DialogResult.OK)
                Cargar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) return;

            int id = Convert.ToInt32(dgv.CurrentRow.Cells["UsuarioId"].Value);
            var usr = _svc.GetById(id);

            if (usr == null) return;

            var f = new FrmEditarUsuario(usr);

            if (f.ShowDialog() == DialogResult.OK)
                Cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) return;

            if (!Helpers.Confirmar("¿Desactivar este usuario?"))
                return;

            int id = Convert.ToInt32(dgv.CurrentRow.Cells["UsuarioId"].Value);

            _svc.Eliminar(id);
            Cargar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text == placeholderBuscar)
                return;

            Filtrar(txtBuscar.Text);
        }

        private void Cargar()
        {
            dgv.Rows.Clear();

            foreach (var u in _svc.GetAll())
            {
                AgregarFila(u);
            }
        }

        private void Filtrar(string q)
        {
            if (string.IsNullOrWhiteSpace(q))
            {
                Cargar();
                return;
            }

            dgv.Rows.Clear();

            var lista = _svc.GetAll().Where(x =>
                (x.NombreCompleto ?? "").IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0 ||
                (x.Matricula ?? "").IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0 ||
                (x.Username ?? "").IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0);

            foreach (var u in lista)
            {
                AgregarFila(u);
            }
        }

        private void AgregarFila(Usuario u)
        {
            dgv.Rows.Add(
                u.UsuarioId,
                u.Apellido,
                u.Nombre,
                u.Matricula,
                u.Curso,
                u.Seccion,
                u.Username,
                u.RolNombre,
                u.Activo
            );
        }

        private void AplicarEstilos()
        {
            BackColor = Fondo;

            btnNuevo.BackColor = Primario;
            btnEditar.BackColor = PrimarioOscuro;
            btnEliminar.BackColor = Peligro;

            btnNuevo.ForeColor = Color.White;
            btnEditar.ForeColor = Color.White;
            btnEliminar.ForeColor = Color.White;

            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEliminar.FlatStyle = FlatStyle.Flat;

            btnNuevo.FlatAppearance.BorderSize = 0;
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatAppearance.BorderSize = 0;

            dgv.EnableHeadersVisualStyles = false;
            dgv.BackgroundColor = FondoCard;
            dgv.GridColor = Borde;
            dgv.BorderStyle = BorderStyle.None;

            dgv.RowHeadersVisible = false;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv.ColumnHeadersHeight = 42;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Primario;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgv.DefaultCellStyle.BackColor = FondoCard;
            dgv.DefaultCellStyle.ForeColor = Texto;
            dgv.DefaultCellStyle.SelectionBackColor = PrimarioOscuro;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void ConfigurarColumnas()
        {
            dgv.Columns.Clear();
            dgv.AutoGenerateColumns = false;

            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "UsuarioId", HeaderText = "ID", Width = 60 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Apellido", HeaderText = "Apellido" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nombre", HeaderText = "Nombre" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Matricula", HeaderText = "Matrícula" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Curso", HeaderText = "Curso" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Seccion", HeaderText = "Sección" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Username", HeaderText = "Usuario" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "RolNombre", HeaderText = "Rol" });
            dgv.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Activo", HeaderText = "Activo" });
        }
    }
}