using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SistemaVotacion.BLL;
using SistemaVotacion.Models;
using SistemaVotacion.UI.Forms;
using SistemaVotacion.Utils;

namespace SistemaVotacion.UI.Controls
{
    public partial class UcPlanchas : UserControl
    {
        private DataGridView dgvPlanchas;
        private DataGridView dgvMiembros;

        private Button btnNueva;
        private Button btnEditar;
        private Button btnAddMiembro;
        private Button btnEditarMiembro;
        private Button btnQuitarMiembro;

        private Label lblPlancha;

        private readonly PlanchaService _planchaSvc = new PlanchaService();
        private Plancha _planchaSeleccionada;

        public UcPlanchas()
        {
            InitializeComponent();

            BackColor = Tema.Fondo;
            Dock = DockStyle.Fill;

            BuildUI();
            CargarPlanchas();
        }

        private void BuildUI()
        {
            Panel pnlTop = new Panel();
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Height = 60;
            pnlTop.BackColor = Tema.FondoPanel;
            pnlTop.Padding = new Padding(10);

            btnNueva = new Button();
            btnNueva.Text = "+ Nueva Plancha";
            btnNueva.Width = 170;
            btnNueva.Height = 40;
            btnNueva.Location = new Point(10, 10);
            Tema.EstilizarBoton(btnNueva, Tema.Exito);
            btnNueva.Click += BtnNueva_Click;

            btnEditar = new Button();
            btnEditar.Text = "Editar Plancha";
            btnEditar.Width = 140;
            btnEditar.Height = 40;
            btnEditar.Location = new Point(190, 10);
            btnEditar.Enabled = false;
            Tema.EstilizarBoton(btnEditar, Tema.Acento);
            btnEditar.Click += BtnEditar_Click;

            pnlTop.Controls.Add(btnNueva);
            pnlTop.Controls.Add(btnEditar);

            SplitContainer split = new SplitContainer();
            split.Dock = DockStyle.Fill;
            split.Orientation = Orientation.Vertical;
            split.SplitterWidth = 4;
            split.BackColor = Tema.Fondo;
            split.FixedPanel = FixedPanel.Panel1;
            split.Panel1MinSize = 350;
            split.Panel2MinSize = 450;
            split.SplitterDistance = 420;

            // ── Panel izquierdo: lista de planchas ───────────────────
            Panel pnlLeft = new Panel();
            pnlLeft.Dock = DockStyle.Fill;
            pnlLeft.BackColor = Tema.FondoCard;
            pnlLeft.Padding = new Padding(10);

            Label lblLeft = new Label();
            lblLeft.Text = "Planchas Registradas";
            lblLeft.Dock = DockStyle.Top;
            lblLeft.Height = 40;
            lblLeft.Font = Tema.FuenteSubtitulo;
            lblLeft.ForeColor = Tema.Texto;
            lblLeft.TextAlign = ContentAlignment.MiddleLeft;

            dgvPlanchas = CrearGrid();
            dgvPlanchas.Dock = DockStyle.Fill;
            dgvPlanchas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPlanchas.Columns.AddRange(
                ColImage("Logo", "Logo", 60),
                ColText("PlanchaId", "ID", 50),
                ColText("Nombre", "Plancha", 180),
                ColText("AdminNombre", "Admin", 150),
                ColCheck("Activa", "Activa", 70)
            );
            dgvPlanchas.SelectionChanged += DgvPlanchas_SelectionChanged;

            pnlLeft.Controls.Add(dgvPlanchas);
            pnlLeft.Controls.Add(lblLeft);

            // ── Panel derecho: miembros ──────────────────────────────
            Panel pnlRight = new Panel();
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.BackColor = Tema.FondoCard;
            pnlRight.Padding = new Padding(10);

            lblPlancha = new Label();
            lblPlancha.Text = "Seleccione una plancha";
            lblPlancha.Dock = DockStyle.Top;
            lblPlancha.Height = 40;
            lblPlancha.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblPlancha.ForeColor = Tema.Texto;
            lblPlancha.TextAlign = ContentAlignment.MiddleLeft;

            Panel pnlBotonesMiembros = new Panel();
            pnlBotonesMiembros.Dock = DockStyle.Top;
            pnlBotonesMiembros.Height = 50;
            pnlBotonesMiembros.BackColor = Tema.FondoCard;

            btnAddMiembro = new Button();
            btnAddMiembro.Text = "+ Agregar";
            btnAddMiembro.Width = 120;
            btnAddMiembro.Height = 36;
            btnAddMiembro.Location = new Point(0, 7);
            btnAddMiembro.Enabled = false;
            Tema.EstilizarBoton(btnAddMiembro, Tema.Primario);
            btnAddMiembro.Click += BtnAddMiembro_Click;

            btnEditarMiembro = new Button();
            btnEditarMiembro.Text = "Editar Miembro";
            btnEditarMiembro.Width = 150;
            btnEditarMiembro.Height = 36;
            btnEditarMiembro.Location = new Point(130, 7);
            btnEditarMiembro.Enabled = false;
            Tema.EstilizarBoton(btnEditarMiembro, Tema.Acento);
            btnEditarMiembro.Click += BtnEditarMiembro_Click;

            btnQuitarMiembro = new Button();
            btnQuitarMiembro.Text = "Quitar";
            btnQuitarMiembro.Width = 100;
            btnQuitarMiembro.Height = 36;
            btnQuitarMiembro.Location = new Point(290, 7);
            btnQuitarMiembro.Enabled = false;
            Tema.EstilizarBoton(btnQuitarMiembro, Tema.Peligro);
            btnQuitarMiembro.Click += BtnQuitarMiembro_Click;

            pnlBotonesMiembros.Controls.Add(btnAddMiembro);
            pnlBotonesMiembros.Controls.Add(btnEditarMiembro);
            pnlBotonesMiembros.Controls.Add(btnQuitarMiembro);

            dgvMiembros = CrearGrid();
            dgvMiembros.Dock = DockStyle.Fill;
            dgvMiembros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMiembros.Columns.AddRange(
                ColImage("Foto", "Foto", 60),
                ColText("MiembroId", "ID", 50),
                ColText("Puesto", "Cargo", 130),
                ColText("NombreCompleto", "Nombre", 180),
                ColText("Matricula", "Matrícula", 120),
                ColText("Descripcion", "Descripción", 180)
            );

            pnlRight.Controls.Add(dgvMiembros);
            pnlRight.Controls.Add(pnlBotonesMiembros);
            pnlRight.Controls.Add(lblPlancha);

            split.Panel1.Controls.Add(pnlLeft);
            split.Panel2.Controls.Add(pnlRight);

            Controls.Add(split);
            Controls.Add(pnlTop);
        }

        // ── Carga de datos ───────────────────────────────────────────

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

        // ── Eventos de planchas ──────────────────────────────────────

        private void DgvPlanchas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPlanchas.CurrentRow == null) return;
            if (dgvPlanchas.CurrentRow.Cells["PlanchaId"].Value == null) return;

            int id = Convert.ToInt32(dgvPlanchas.CurrentRow.Cells["PlanchaId"].Value);
            _planchaSeleccionada = _planchaSvc.GetById(id);

            if (_planchaSeleccionada == null) return;

            lblPlancha.Text = "Miembros de " + _planchaSeleccionada.Nombre;
            CargarMiembros(id);

            btnEditar.Enabled = true;
            btnAddMiembro.Enabled = true;
            btnEditarMiembro.Enabled = true;
            btnQuitarMiembro.Enabled = true;
        }

        private void BtnNueva_Click(object sender, EventArgs e)
        {
            var frm = new FrmEditarPlancha(null);
            if (frm.ShowDialog() == DialogResult.OK)
                CargarPlanchas();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (_planchaSeleccionada == null)
            {
                Helpers.MsgError("Seleccione una plancha.");
                return;
            }

            var frm = new FrmEditarPlancha(_planchaSeleccionada);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarPlanchas();
                CargarMiembros(_planchaSeleccionada.PlanchaId);
            }
        }

        // ── Eventos de miembros ──────────────────────────────────────

        private void BtnAddMiembro_Click(object sender, EventArgs e)
        {
            if (_planchaSeleccionada == null)
            {
                Helpers.MsgError("Seleccione una plancha primero.");
                return;
            }

            var frm = new FrmAgregarMiembro(_planchaSeleccionada.PlanchaId);
            if (frm.ShowDialog() == DialogResult.OK)
                CargarMiembros(_planchaSeleccionada.PlanchaId);
        }

        private void BtnEditarMiembro_Click(object sender, EventArgs e)
        {
            if (_planchaSeleccionada == null || dgvMiembros.CurrentRow == null)
            {
                Helpers.MsgError("Seleccione un miembro.");
                return;
            }

            int id = Convert.ToInt32(dgvMiembros.CurrentRow.Cells["MiembroId"].Value);
            var m = _planchaSvc.GetMiembroById(id);
            if (m == null) return;

            var frm = new FrmAgregarMiembro(_planchaSeleccionada.PlanchaId, m);
            if (frm.ShowDialog() == DialogResult.OK)
                CargarMiembros(_planchaSeleccionada.PlanchaId);
        }

        private void BtnQuitarMiembro_Click(object sender, EventArgs e)
        {
            if (_planchaSeleccionada == null || dgvMiembros.CurrentRow == null)
            {
                Helpers.MsgError("Seleccione un miembro.");
                return;
            }

            int id = Convert.ToInt32(dgvMiembros.CurrentRow.Cells["MiembroId"].Value);
            string nombre = dgvMiembros.CurrentRow.Cells["NombreCompleto"].Value?.ToString() ?? "este miembro";

            var confirm = MessageBox.Show(
                $"¿Quitar a {nombre} de la plancha?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                _planchaSvc.EliminarMiembro(id);
                CargarMiembros(_planchaSeleccionada.PlanchaId);
            }
        }

        // ── Helpers ──────────────────────────────────────────────────

        private Image CargarImagen(string ruta)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ruta) || !File.Exists(ruta))
                    return null;

                Image imgTemp = Image.FromFile(ruta);
                return new Bitmap(imgTemp, new Size(45, 45));
            }
            catch
            {
                return null;
            }
        }

        private static DataGridView CrearGrid()
        {
            var g = new DataGridView();
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.MultiSelect = false;
            g.ReadOnly = true;
            g.AllowUserToAddRows = false;
            g.AllowUserToDeleteRows = false;
            g.AllowUserToResizeRows = false;
            g.BackgroundColor = Tema.FondoCard;
            g.ForeColor = Tema.Texto;
            g.GridColor = Tema.Borde;
            g.BorderStyle = BorderStyle.None;
            g.RowHeadersVisible = false;
            g.Font = Tema.FuenteNormal;
            g.EnableHeadersVisualStyles = false;
            g.ColumnHeadersHeight = 36;
            g.RowTemplate.Height = 55;
            return g;
        }

        private static DataGridViewTextBoxColumn ColText(string name, string header, int w)
            => new DataGridViewTextBoxColumn { Name = name, HeaderText = header, Width = w };

        private static DataGridViewCheckBoxColumn ColCheck(string name, string header, int w)
            => new DataGridViewCheckBoxColumn { Name = name, HeaderText = header, Width = w };

        private static DataGridViewImageColumn ColImage(string name, string header, int w)
            => new DataGridViewImageColumn
            {
                Name = name,
                HeaderText = header,
                Width = w,
                ImageLayout = DataGridViewImageCellLayout.Zoom
            };

        private void InitializeComponent()
        {
            SuspendLayout();
            Name = "UcPlanchas";
            Size = new Size(1000, 700);
            ResumeLayout(false);
        }
    }
}