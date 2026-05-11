using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SistemaVotacion.BLL;
using SistemaVotacion.Models;
using SistemaVotacion.UI.Controls;
using SistemaVotacion.Utils;

namespace SistemaVotacion.UI.Forms
{
    public partial class Usuarios : Form
    {
<<<<<<< HEAD
        private readonly UsuarioService _svc = new UsuarioService();

        private readonly string placeholderBuscar = "Nombre, matrícula o usuario...";
=======
        private readonly UsuarioService _svc = new();

>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

        public Usuarios()
        {
            InitializeComponent();

            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            ConfigurarColumnas();
            AplicarEstilos();
            Cargar();

<<<<<<< HEAD
            // Placeholder compatible con .NET Framework
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
                txtBuscar.ForeColor = Color.Black;
            }
        }

        private void TxtBuscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtBuscar.Text = placeholderBuscar;
                txtBuscar.ForeColor = Color.Gray;
            }
=======
  
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var f = new FrmEditarUsuario(null);

            if (f.ShowDialog() == DialogResult.OK)
                Cargar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            if (dgv.CurrentRow == null) return;
=======
            if (dgv.CurrentRow is null) return;
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

            int id = Convert.ToInt32(dgv.CurrentRow.Cells["UsuarioId"].Value);
            var usr = _svc.GetById(id);

<<<<<<< HEAD
            if (usr == null) return;
=======
            if (usr is null) return;
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

            var f = new FrmEditarUsuario(usr);

            if (f.ShowDialog() == DialogResult.OK)
                Cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            if (dgv.CurrentRow == null) return;
=======
            if (dgv.CurrentRow is null) return;
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739

            if (!Helpers.Confirmar("¿Desactivar este usuario?")) return;

            int id = Convert.ToInt32(dgv.CurrentRow.Cells["UsuarioId"].Value);

            _svc.Eliminar(id);
            Cargar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
<<<<<<< HEAD
            if (txtBuscar.Text == placeholderBuscar)
                return;

=======
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
            Filtrar(txtBuscar.Text);
        }

        private void Cargar()
        {
            dgv.Rows.Clear();

            foreach (var u in _svc.GetAll())
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
        }

        private void Filtrar(string q)
        {
            if (string.IsNullOrWhiteSpace(q))
            {
                Cargar();
                return;
            }

            dgv.Rows.Clear();

            foreach (var u in _svc.GetAll().Where(x =>
<<<<<<< HEAD
    x.NombreCompleto.ToLower().Contains(q.ToLower()) ||
    x.Matricula.ToLower().Contains(q.ToLower()) ||
    x.Username.ToLower().Contains(q.ToLower())))
=======
                x.NombreCompleto.Contains(q, StringComparison.OrdinalIgnoreCase) ||
                x.Matricula.Contains(q, StringComparison.OrdinalIgnoreCase) ||
                x.Username.Contains(q, StringComparison.OrdinalIgnoreCase)))
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
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
        }

        private void AplicarEstilos()
        {
            BackColor = Fondo;

            btnNuevo.BackColor = AzulClaro;
            btnNuevo.ForeColor = Color.White;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.FlatAppearance.BorderSize = 0;

            btnEditar.BackColor = Azul;
            btnEditar.ForeColor = Color.White;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.FlatAppearance.BorderSize = 0;

            btnEliminar.BackColor = Rojo;
            btnEliminar.ForeColor = Color.White;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.FlatAppearance.BorderSize = 0;

            dgv.EnableHeadersVisualStyles = false;
            dgv.BackgroundColor = Card;
            dgv.GridColor = Borde;
            dgv.BorderStyle = BorderStyle.None;
            dgv.RowHeadersVisible = false;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv.ColumnHeadersVisible = true;
            dgv.ColumnHeadersHeight = 42;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Azul;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10f, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgv.DefaultCellStyle.BackColor = Card;
            dgv.DefaultCellStyle.ForeColor = Texto;
            dgv.DefaultCellStyle.SelectionBackColor = AzulClaro;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10f);

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 255);
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Texto;
<<<<<<< HEAD
=======

>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
        }

        private void ConfigurarColumnas()
        {
            dgv.Columns.Clear();
            dgv.AutoGenerateColumns = false;

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UsuarioId",
                HeaderText = "ID",
                Width = 60
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Apellido",
                HeaderText = "Apellido",
                Width = 120
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nombre",
                HeaderText = "Nombre",
                Width = 120
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Matricula",
                HeaderText = "Matrícula",
                Width = 120
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Curso",
                HeaderText = "Curso",
                Width = 110
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Seccion",
                HeaderText = "Sección",
                Width = 90
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Username",
                HeaderText = "Usuario",
                Width = 120
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RolNombre",
                HeaderText = "Rol",
                Width = 110
            });

            dgv.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "Activo",
                HeaderText = "Activo",
                Width = 70
            });
        }
    }
}