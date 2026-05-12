using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using SistemaVotacion.BLL;
using SistemaVotacion.Models;
using SistemaVotacion.Utils;
using SistemaVotacion.UI.Forms;

namespace SistemaVotacion.UI.Controls
{
    // ════════════════════════════════════════════════════════════
    //  GESTIÓN DE USUARIOS
    // ════════════════════════════════════════════════════════════
    public class UcUsuarios : UserControl
    {
        private DataGridView dgv;
        private TextBox txtBuscar;
        private readonly UsuarioService _svc = new UsuarioService();

        public UcUsuarios()
        {
            BackColor = Tema.Fondo;
            Dock = DockStyle.Fill;

            BuildUI();
            Cargar();
        }

        private void BuildUI()
        {
            var pnlTop = new Panel
            {
                Dock = DockStyle.Top,
                Height = 55,
                BackColor = Tema.FondoPanel,
                Padding = new Padding(10, 8, 10, 8)
            };

            // NUEVO
            var btnNuevo = new Button
            {
                Text = "+ Nuevo Usuario",
                Width = 150,
                Height = 38,
                Location = new Point(10, 8)
            };

            Tema.EstilizarBoton(btnNuevo, Tema.Exito);

            btnNuevo.Click += (s, e) =>
            {
                FrmEditarUsuario f = new FrmEditarUsuario(null);

                if (f.ShowDialog() == DialogResult.OK)
                    Cargar();
            };

            // EDITAR
            var btnEditar = new Button
            {
                Text = "Editar",
                Width = 90,
                Height = 38,
                Location = new Point(170, 8)
            };

            Tema.EstilizarBoton(btnEditar, Tema.Acento);

            btnEditar.Click += (s, e) =>
            {
                if (dgv.CurrentRow == null)
                    return;

                int id = Convert.ToInt32(dgv.CurrentRow.Cells["UsuarioId"].Value);

                Usuario usr = _svc.GetById(id);

                if (usr == null)
                    return;

                FrmEditarUsuario f = new FrmEditarUsuario(usr);

                if (f.ShowDialog() == DialogResult.OK)
                    Cargar();
            };

            // ELIMINAR
            var btnEliminar = new Button
            {
                Text = "Desactivar",
                Width = 110,
                Height = 38,
                Location = new Point(270, 8)
            };

            Tema.EstilizarBoton(btnEliminar, Tema.Peligro);

            btnEliminar.Click += (s, e) =>
            {
                if (dgv.CurrentRow == null)
                    return;

                if (!Helpers.Confirmar("Desactivar este usuario?"))
                    return;

                int id = Convert.ToInt32(dgv.CurrentRow.Cells["UsuarioId"].Value);

                _svc.Eliminar(id);

                Cargar();
            };

            // BUSCAR
            txtBuscar = new TextBox
            {
                Text = "Buscar...",
                ForeColor = Color.Gray,
                Location = new Point(420, 13),
                Size = new Size(220, 30),
                BackColor = Tema.FondoCard,
                BorderStyle = BorderStyle.FixedSingle
            };

            txtBuscar.Enter += (s, e) =>
            {
                if (txtBuscar.Text == "Buscar...")
                {
                    txtBuscar.Text = "";
                    txtBuscar.ForeColor = Tema.Texto;
                }
            };

            txtBuscar.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                {
                    txtBuscar.Text = "Buscar...";
                    txtBuscar.ForeColor = Color.Gray;
                }
            };

            txtBuscar.TextChanged += (s, e) =>
            {
                if (txtBuscar.Text != "Buscar...")
                    Filtrar(txtBuscar.Text);
            };

            pnlTop.Controls.AddRange(new Control[]
            {
                btnNuevo,
                btnEditar,
                btnEliminar,
                txtBuscar
            });

            dgv = ConstruirGrid();

            dgv.Dock = DockStyle.Fill;

            dgv.Columns.AddRange(
                Col("UsuarioId", "ID", 50),
                Col("Apellido", "Apellido", 130),
                Col("Nombre", "Nombre", 130),
                Col("Matricula", "Matricula", 110),
                Col("Curso", "Curso", 90),
                Col("Seccion", "Seccion", 60),
                Col("Username", "Username", 120),
                Col("RolNombre", "Rol", 90),

                new DataGridViewCheckBoxColumn
                {
                    Name = "Activo",
                    HeaderText = "Activo",
                    Width = 55
                }
            );

            Controls.Add(dgv);
            Controls.Add(pnlTop);
        }

        private void Cargar()
        {
            dgv.Rows.Clear();

            foreach (Usuario u in _svc.GetAll())
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

            foreach (Usuario u in _svc.GetAll().Where(x =>
                x.NombreCompleto.ToLower().Contains(q.ToLower()) ||
                x.Matricula.ToLower().Contains(q.ToLower()) ||
                x.Username.ToLower().Contains(q.ToLower())))
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

        private static DataGridView ConstruirGrid()
        {
            DataGridView g = new DataGridView
            {
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                ReadOnly = true,

                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,

                BackgroundColor = Tema.FondoCard,
                ForeColor = Tema.Texto,

                GridColor = Tema.Borde,
                BorderStyle = BorderStyle.None,

                RowHeadersVisible = false,
                Font = Tema.FuenteNormal,

                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            };

            g.ColumnHeadersDefaultCellStyle.BackColor = Tema.PrimarioOscuro;
            g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            g.DefaultCellStyle.BackColor = Tema.FondoCard;
            g.DefaultCellStyle.ForeColor = Tema.Texto;

            g.DefaultCellStyle.SelectionBackColor = Tema.Primario;
            g.DefaultCellStyle.SelectionForeColor = Color.White;

            g.AlternatingRowsDefaultCellStyle.BackColor = Tema.FondoPanel;

            return g;
        }

        private static DataGridViewTextBoxColumn Col(string name, string header, int w)
        {
            return new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                Width = w
            };
        }
    }
}
