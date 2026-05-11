<<<<<<< HEAD
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
=======
using SistemaVotacion.BLL;
using SistemaVotacion.Models;
using SistemaVotacion.Utils;

namespace SistemaVotacion.UI.Controls;

// ════════════════════════════════════════════════════════════
//  GESTIÓN DE USUARIOS
// ════════════════════════════════════════════════════════════
public class UcUsuarios : UserControl
{
    private DataGridView dgv   = null!;
    private TextBox      txtBuscar = null!;
    private readonly UsuarioService _svc = new();

    public UcUsuarios()
    {
        BackColor = Tema.Fondo; Dock = DockStyle.Fill;
        BuildUI(); Cargar();
    }

    private void BuildUI()
    {
        var pnlTop = new Panel { Dock = DockStyle.Top, Height = 55, BackColor = Tema.FondoPanel, Padding = new Padding(10, 8, 10, 8) };

        var btnNuevo = new Button { Text = "+ Nuevo Usuario", Width = 150, Height = 38, Location = new Point(10, 8) };
        Tema.EstilizarBoton(btnNuevo, Tema.Exito);
        btnNuevo.Click += (s, e) => { var f = new FrmEditarUsuario(null); if (f.ShowDialog() == DialogResult.OK) Cargar(); };

        var btnEditar = new Button { Text = "Editar", Width = 90, Height = 38, Location = new Point(170, 8) };
        Tema.EstilizarBoton(btnEditar, Tema.Acento);
        btnEditar.Click += (s, e) =>
        {
            if (dgv.CurrentRow is null) return;
            int id = (int)dgv.CurrentRow.Cells["UsuarioId"].Value;
            var usr = _svc.GetById(id);
            if (usr is null) return;
            var f = new FrmEditarUsuario(usr);
            if (f.ShowDialog() == DialogResult.OK) Cargar();
        };

        var btnEliminar = new Button { Text = "Desactivar", Width = 110, Height = 38, Location = new Point(270, 8) };
        Tema.EstilizarBoton(btnEliminar, Tema.Peligro);
        btnEliminar.Click += (s, e) =>
        {
            if (dgv.CurrentRow is null) return;
            if (!Helpers.Confirmar("Desactivar este usuario?")) return;
            int id = (int)dgv.CurrentRow.Cells["UsuarioId"].Value;
            _svc.Eliminar(id);
            Cargar();
        };

        txtBuscar = new TextBox { PlaceholderText = "Buscar...", Location = new Point(420, 13), Size = new Size(220, 30), BackColor = Tema.FondoCard, ForeColor = Tema.Texto, BorderStyle = BorderStyle.FixedSingle };
        txtBuscar.TextChanged += (s, e) => Filtrar(txtBuscar.Text);

        pnlTop.Controls.AddRange(new Control[] { btnNuevo, btnEditar, btnEliminar, txtBuscar });

        dgv = ConstruirGrid();
        dgv.Dock = DockStyle.Fill;
        dgv.Columns.AddRange(
            Col("UsuarioId",  "ID",        50),
            Col("Apellido",   "Apellido", 130),
            Col("Nombre",     "Nombre",   130),
            Col("Matricula",  "Matricula", 110),
            Col("Curso",      "Curso",     90),
            Col("Seccion",    "Seccion",   60),
            Col("Username",   "Username", 120),
            Col("RolNombre",  "Rol",       90),
            new DataGridViewCheckBoxColumn { Name = "Activo", HeaderText = "Activo", Width = 55 });

        Controls.AddRange(new Control[] { dgv, pnlTop });
    }

    private void Cargar()
    {
        dgv.Rows.Clear();
        foreach (var u in _svc.GetAll())
            dgv.Rows.Add(u.UsuarioId, u.Apellido, u.Nombre, u.Matricula, u.Curso, u.Seccion, u.Username, u.RolNombre, u.Activo);
    }

    private void Filtrar(string q)
    {
        if (string.IsNullOrWhiteSpace(q)) { Cargar(); return; }
        dgv.Rows.Clear();
        foreach (var u in _svc.GetAll().Where(x =>
            x.NombreCompleto.Contains(q, StringComparison.OrdinalIgnoreCase) ||
            x.Matricula.Contains(q,      StringComparison.OrdinalIgnoreCase) ||
            x.Username.Contains(q,       StringComparison.OrdinalIgnoreCase)))
            dgv.Rows.Add(u.UsuarioId, u.Apellido, u.Nombre, u.Matricula, u.Curso, u.Seccion, u.Username, u.RolNombre, u.Activo);
    }

    private static DataGridView ConstruirGrid()
    {
        var g = new DataGridView
        {
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            MultiSelect   = false, ReadOnly = true,
            AllowUserToAddRows = false, AllowUserToDeleteRows = false,
            BackgroundColor = Tema.FondoCard, ForeColor = Tema.Texto,
            GridColor = Tema.Borde, BorderStyle = BorderStyle.None,
            RowHeadersVisible = false, Font = Tema.FuenteNormal,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        };
        g.ColumnHeadersDefaultCellStyle.BackColor = Tema.PrimarioOscuro;
        g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        g.DefaultCellStyle.BackColor  = Tema.FondoCard;
        g.DefaultCellStyle.ForeColor  = Tema.Texto;
        g.DefaultCellStyle.SelectionBackColor = Tema.Primario;
        g.DefaultCellStyle.SelectionForeColor = Color.White;
        g.AlternatingRowsDefaultCellStyle.BackColor = Tema.FondoPanel;
        return g;
    }

    private static DataGridViewTextBoxColumn Col(string name, string header, int w) =>
        new() { Name = name, HeaderText = header, Width = w };
}

// ── Formulario editar usuario ────────────────────────────────────────────────
public class FrmEditarUsuario : Form
{
    private TextBox txtNombre = null!, txtApellido = null!, txtMatricula = null!,
                    txtCurso = null!, txtSeccion = null!, txtEmail = null!,
                    txtUsername = null!, txtPassword = null!;
    private ComboBox cmbRol = null!;
    private readonly Usuario? _usuario;
    private readonly UsuarioService _svc = new();

    public FrmEditarUsuario(Usuario? usuario)
    {
        _usuario        = usuario;
        Text            = usuario is null ? "Nuevo Usuario" : "Editar Usuario";
        Size            = new Size(500, 520);
        StartPosition   = FormStartPosition.CenterParent;
        BackColor       = Tema.FondoPanel;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox     = false;

        int y = 15;
        var Fld = (string lbl, ref TextBox tb, bool pass = false) =>
        {
            var p   = new Panel { Location = new Point(20, y), Size = new Size(450, 52), BackColor = Tema.FondoPanel };
            var l   = new Label { Text = lbl, ForeColor = Tema.TextoSecundario, AutoSize = true, Location = new Point(0, 0) };
            tb = new TextBox { Location = new Point(0, 18), Size = new Size(450, 26) };
            if (pass) tb.PasswordChar = '*';
            Tema.EstilizarTextBox(tb);
            p.Controls.AddRange(new Control[] { l, tb });
            Controls.Add(p); y += 57;
        };

        Fld("Nombre",     ref txtNombre);
        Fld("Apellido",   ref txtApellido);
        Fld("Matricula",  ref txtMatricula);
        Fld("Curso",      ref txtCurso);
        Fld("Seccion",    ref txtSeccion);
        Fld("Email",      ref txtEmail);
        Fld("Username",   ref txtUsername);
        Fld("Password",   ref txtPassword, true);

        var lblRol = new Label { Text = "Rol", ForeColor = Tema.TextoSecundario, AutoSize = true, Location = new Point(20, y) };
        cmbRol = new ComboBox { Location = new Point(20, y + 18), Size = new Size(200, 28), DropDownStyle = ComboBoxStyle.DropDownList, BackColor = Tema.FondoCard, ForeColor = Tema.Texto };
        cmbRol.Items.AddRange(new object[] { "Admin", "AdminPartido", "Votante" });
        cmbRol.SelectedIndex = 2;
        Controls.AddRange(new Control[] { lblRol, cmbRol });
        y += 55;

        var btnGuardar = new Button { Text = "Guardar", Location = new Point(330, y), Size = new Size(140, 38) };
        Tema.EstilizarBoton(btnGuardar, Tema.Exito);
        btnGuardar.Click += BtnGuardar_Click;
        Controls.Add(btnGuardar);

        if (usuario is not null)
        {
            txtNombre.Text    = usuario.Nombre;
            txtApellido.Text  = usuario.Apellido;
            txtMatricula.Text = usuario.Matricula;
            txtCurso.Text     = usuario.Curso ?? "";
            txtSeccion.Text   = usuario.Seccion ?? "";
            txtEmail.Text     = usuario.Email ?? "";
            txtUsername.Text  = usuario.Username;
            txtPassword.PlaceholderText = "(dejar en blanco para no cambiar)";
            cmbRol.SelectedItem = usuario.RolNombre;
        }

        Height = y + 100;
    }

    private void BtnGuardar_Click(object? sender, EventArgs e)
    {
        var u = _usuario ?? new Usuario();
        u.Nombre    = txtNombre.Text.Trim();
        u.Apellido  = txtApellido.Text.Trim();
        u.Matricula = txtMatricula.Text.Trim();
        u.Curso     = txtCurso.Text;
        u.Seccion   = txtSeccion.Text;
        u.Email     = txtEmail.Text;
        u.Username  = txtUsername.Text.Trim();
        u.RolNombre = cmbRol.SelectedItem?.ToString() ?? "Votante";
        // Buscar RolId por nombre (simplificado – en prod. cargar desde BD)
        u.RolId = u.RolNombre switch { "Admin" => 1, "AdminPartido" => 2, _ => 3 };
        u.Activo = true;

        (bool ok, string msg) result;
        if (_usuario is null)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text)) { Helpers.MsgError("La contraseña es obligatoria."); return; }
            result = _svc.Crear(u, txtPassword.Text);
        }
        else
        {
            result = _svc.Actualizar(u);
            if (result.ok && !string.IsNullOrWhiteSpace(txtPassword.Text))
                _svc.CambiarPassword(u.UsuarioId, txtPassword.Text);
        }

        if (!result.ok) { Helpers.MsgError(result.msg); return; }
        Helpers.MsgExito(result.msg);
        DialogResult = DialogResult.OK;
    }
}

// ════════════════════════════════════════════════════════════
//  GESTIÓN DE VOTACIÓN (ADMIN)
// ════════════════════════════════════════════════════════════
public class UcVotacionAdmin : UserControl
{
    private DataGridView dgv = null!;
    private Label lblEstado  = null!;
    private readonly VotacionService _svc = new();

    public UcVotacionAdmin()
    {
        BackColor = Tema.Fondo; Dock = DockStyle.Fill;
        BuildUI(); Cargar();
    }

    private void BuildUI()
    {
        var pnlTop = new Panel { Dock = DockStyle.Top, Height = 55, BackColor = Tema.FondoPanel, Padding = new Padding(10, 8, 10, 8) };

        var btnNueva = new Button { Text = "+ Nueva Votacion", Width = 160, Height = 38, Location = new Point(10, 8) };
        Tema.EstilizarBoton(btnNueva, Tema.Exito);
        btnNueva.Click += BtnNueva_Click;

        var btnActivar = new Button { Text = "Activar", Width = 90, Height = 38, Location = new Point(180, 8) };
        Tema.EstilizarBoton(btnActivar, Tema.Primario);
        btnActivar.Click += (s, e) =>
        {
            if (dgv.CurrentRow is null) return;
            int id = (int)dgv.CurrentRow.Cells["VotacionId"].Value;
            if (!Helpers.Confirmar("Activar esta votacion? Se desactivara cualquier otra.")) return;
            _svc.Activar(id); Cargar();
        };

        var btnCerrar = new Button { Text = "Cerrar y Nulos", Width = 140, Height = 38, Location = new Point(280, 8) };
        Tema.EstilizarBoton(btnCerrar, Tema.Peligro);
        btnCerrar.Click += (s, e) =>
        {
            if (dgv.CurrentRow is null) return;
            int id = (int)dgv.CurrentRow.Cells["VotacionId"].Value;
            if (!Helpers.Confirmar("Cerrar la votacion y marcar votos nulos a quienes no votaron?")) return;
            var (ok, msg) = _svc.Cerrar(id);
            Helpers.MsgExito(msg); Cargar();
        };

        lblEstado = new Label { ForeColor = Tema.Exito, AutoSize = true, Font = new Font("Segoe UI", 9f, FontStyle.Bold), Location = new Point(435, 18) };
        pnlTop.Controls.AddRange(new Control[] { btnNueva, btnActivar, btnCerrar, lblEstado });

        dgv = new DataGridView
        {
            Dock = DockStyle.Fill, ReadOnly = true, AllowUserToAddRows = false,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect, MultiSelect = false,
            BackgroundColor = Tema.FondoCard, ForeColor = Tema.Texto,
            BorderStyle = BorderStyle.None, RowHeadersVisible = false, Font = Tema.FuenteNormal,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        };
        dgv.ColumnHeadersDefaultCellStyle.BackColor = Tema.PrimarioOscuro;
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgv.DefaultCellStyle.BackColor  = Tema.FondoCard;
        dgv.DefaultCellStyle.ForeColor  = Tema.Texto;
        dgv.DefaultCellStyle.SelectionBackColor = Tema.Primario;
        dgv.DefaultCellStyle.SelectionForeColor = Color.White;
        dgv.Columns.AddRange(
            new DataGridViewTextBoxColumn { Name = "VotacionId", HeaderText = "ID",        Width = 50 },
            new DataGridViewTextBoxColumn { Name = "Titulo",     HeaderText = "Titulo",    Width = 300 },
            new DataGridViewTextBoxColumn { Name = "FechaInicio",HeaderText = "Inicio",    Width = 160 },
            new DataGridViewTextBoxColumn { Name = "FechaFin",   HeaderText = "Fin",       Width = 160 },
            new DataGridViewCheckBoxColumn{ Name = "Activa",     HeaderText = "Activa",    Width = 60 });

        Controls.AddRange(new Control[] { dgv, pnlTop });
    }

    private void Cargar()
    {
        dgv.Rows.Clear();
        var activa = _svc.GetActiva();
        lblEstado.Text = activa is null ? "Sin votacion activa" : $"Votacion activa: {activa.Titulo}";
        foreach (var v in _svc.GetAll())
            dgv.Rows.Add(v.VotacionId, v.Titulo, v.FechaInicio, v.FechaFin, v.Activa);
    }

    private void BtnNueva_Click(object? sender, EventArgs e)
    {
        var frm = new FrmNuevaVotacion();
        if (frm.ShowDialog() == DialogResult.OK) Cargar();
    }
}

public class FrmNuevaVotacion : Form
{
    private TextBox txtTitulo = null!, txtDesc = null!;
    private DateTimePicker dtpInicio = null!, dtpFin = null!;
    private readonly VotacionService _svc = new();

    public FrmNuevaVotacion()
    {
        Text = "Nueva Votacion"; Size = new Size(460, 320);
        StartPosition = FormStartPosition.CenterParent;
        BackColor = Tema.FondoPanel; FormBorderStyle = FormBorderStyle.FixedDialog; MaximizeBox = false;

        var lblT = Lbl("Titulo",       new Point(20,  20)); txtTitulo = TB(new Point(20, 40), 410);
        var lblD = Lbl("Descripcion",  new Point(20,  80)); txtDesc   = TB(new Point(20, 100), 410, 50, true);
        var lblI = Lbl("Fecha Inicio", new Point(20, 165)); dtpInicio = DTP(new Point(20, 185));
        var lblF = Lbl("Fecha Fin",    new Point(230,165)); dtpFin    = DTP(new Point(230,185));
        dtpInicio.Value = DateTime.Now;
        dtpFin.Value    = DateTime.Now.AddHours(2);

        var btnGuardar = new Button { Text = "Crear Votacion", Location = new Point(290, 240), Size = new Size(150, 38) };
        Tema.EstilizarBoton(btnGuardar, Tema.Exito);
        btnGuardar.Click += (s, e) =>
        {
            var v = new Votacion { Titulo = txtTitulo.Text.Trim(), Descripcion = txtDesc.Text, FechaInicio = dtpInicio.Value, FechaFin = dtpFin.Value };
            var (ok, msg, _) = _svc.Crear(v);
            if (!ok) { Helpers.MsgError(msg); return; }
            Helpers.MsgExito("Votacion creada."); DialogResult = DialogResult.OK;
        };
        Controls.AddRange(new Control[] { lblT, txtTitulo, lblD, txtDesc, lblI, dtpInicio, lblF, dtpFin, btnGuardar });
    }
    private Label Lbl(string t, Point p) => new() { Text = t, ForeColor = Tema.TextoSecundario, AutoSize = true, Location = p };
    private TextBox TB(Point p, int w, int h = 26, bool ml = false) { var tb = new TextBox { Location = p, Size = new Size(w, h), Multiline = ml }; Tema.EstilizarTextBox(tb); return tb; }
    private DateTimePicker DTP(Point p) => new() { Location = p, Size = new Size(190, 26), Format = DateTimePickerFormat.Custom, CustomFormat = "yyyy-MM-dd HH:mm", ShowUpDown = true, BackColor = Tema.FondoCard, ForeColor = Tema.Texto };
}

// ════════════════════════════════════════════════════════════
//  PADRÓN ELECTORAL
// ════════════════════════════════════════════════════════════
public class UcPadron : UserControl
{
    private DataGridView dgv = null!;
    private ComboBox cmbVotacion = null!;
    private readonly VotacionService _svc = new();

    public UcPadron() { BackColor = Tema.Fondo; Dock = DockStyle.Fill; BuildUI(); }

    private void BuildUI()
    {
        var pnlTop = new Panel { Dock = DockStyle.Top, Height = 55, BackColor = Tema.FondoPanel, Padding = new Padding(10, 8, 10, 8) };
        var lblV = new Label { Text = "Votacion:", ForeColor = Tema.Texto, AutoSize = true, Location = new Point(10, 17) };
        cmbVotacion = new ComboBox { Location = new Point(80, 12), Size = new Size(300, 30), DropDownStyle = ComboBoxStyle.DropDownList, BackColor = Tema.FondoCard, ForeColor = Tema.Texto };

        var votaciones = _svc.GetAll().ToList();
        cmbVotacion.DataSource    = votaciones;
        cmbVotacion.DisplayMember = "Titulo";
        cmbVotacion.ValueMember   = "VotacionId";
        cmbVotacion.SelectedIndexChanged += (s, e) => Cargar();

        var btnAdd = new Button { Text = "+ Agregar al Padron", Width = 170, Height = 38, Location = new Point(400, 8) };
        Tema.EstilizarBoton(btnAdd, Tema.Exito);
        btnAdd.Click += BtnAdd_Click;

        var btnQuitar = new Button { Text = "Quitar", Width = 80, Height = 38, Location = new Point(580, 8) };
        Tema.EstilizarBoton(btnQuitar, Tema.Peligro);
        btnQuitar.Click += (s, e) =>
        {
            if (dgv.CurrentRow is null) return;
            if (!Helpers.Confirmar("Quitar del padron?")) return;
            int id = (int)dgv.CurrentRow.Cells["PadronId"].Value;
            _svc.EliminarDelPadron(id); Cargar();
        };

        pnlTop.Controls.AddRange(new Control[] { lblV, cmbVotacion, btnAdd, btnQuitar });

        dgv = new DataGridView
        {
            Dock = DockStyle.Fill, ReadOnly = true, AllowUserToAddRows = false,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            BackgroundColor = Tema.FondoCard, ForeColor = Tema.Texto,
            BorderStyle = BorderStyle.None, RowHeadersVisible = false, Font = Tema.FuenteNormal,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        };
        dgv.ColumnHeadersDefaultCellStyle.BackColor = Tema.PrimarioOscuro;
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgv.DefaultCellStyle.BackColor  = Tema.FondoCard;
        dgv.DefaultCellStyle.ForeColor  = Tema.Texto;
        dgv.DefaultCellStyle.SelectionBackColor = Tema.Primario;
        dgv.Columns.AddRange(
            new DataGridViewTextBoxColumn { Name = "PadronId",     HeaderText = "ID",         Width = 50 },
            new DataGridViewTextBoxColumn { Name = "NombreCompleto",HeaderText = "Nombre",    Width = 200 },
            new DataGridViewTextBoxColumn { Name = "Matricula",    HeaderText = "Matricula",  Width = 120 },
            new DataGridViewTextBoxColumn { Name = "Curso",        HeaderText = "Curso",      Width = 100 },
            new DataGridViewTextBoxColumn { Name = "Seccion",      HeaderText = "Seccion",    Width = 70 });

        Controls.AddRange(new Control[] { dgv, pnlTop });
        if (votaciones.Any()) Cargar();
    }

    private void Cargar()
    {
        if (cmbVotacion.SelectedValue is not int vid) return;
        dgv.Rows.Clear();
        foreach (var p in _svc.GetPadron(vid))
            dgv.Rows.Add(p.PadronId, p.NombreCompleto, p.Matricula, p.Curso, p.Seccion);
    }

    private void BtnAdd_Click(object? sender, EventArgs e)
    {
        if (cmbVotacion.SelectedValue is not int vid) return;
        var disponibles = new UsuarioService().GetVotantesDisponibles(vid).ToList();
        if (!disponibles.Any()) { Helpers.MsgError("No hay votantes disponibles para agregar."); return; }

        var frm  = new Form { Text = "Agregar al Padron", Size = new Size(400, 160), StartPosition = FormStartPosition.CenterParent, BackColor = Tema.FondoPanel, FormBorderStyle = FormBorderStyle.FixedDialog };
        var cmb  = new ComboBox { Location = new Point(20, 20), Size = new Size(340, 30), DropDownStyle = ComboBoxStyle.DropDownList, BackColor = Tema.FondoCard, ForeColor = Tema.Texto, DataSource = disponibles, DisplayMember = "NombreCompleto", ValueMember = "UsuarioId" };
        var btn  = new Button { Text = "Agregar", Location = new Point(270, 70), Size = new Size(90, 36) };
        Tema.EstilizarBoton(btn, Tema.Exito);
        btn.Click += (s, e) =>
        {
            if (cmb.SelectedValue is not int uid) return;
            var (ok, msg) = _svc.AgregarAlPadron(vid, uid);
            if (!ok) Helpers.MsgError(msg); else { Helpers.MsgExito(msg); frm.Close(); }
        };
        frm.Controls.AddRange(new Control[] { cmb, btn });
        frm.ShowDialog();
        Cargar();
    }
}

// ════════════════════════════════════════════════════════════
//  REPORTES
// ════════════════════════════════════════════════════════════
public class UcReportes : UserControl
{
    private readonly VotacionService _svc = new();

    public UcReportes() { BackColor = Tema.Fondo; Dock = DockStyle.Fill; BuildUI(); }

    private void BuildUI()
    {
        var lbl = new Label { Text = "Seleccione un reporte a generar:", Font = Tema.FuenteSubtitulo, ForeColor = Tema.Texto, AutoSize = true, Location = new Point(30, 30) };

        var btnGeneral = BtnReporte("Reporte General de Votos",          new Point(30, 80));
        var btnPadron  = BtnReporte("Reporte de Padron Electoral",        new Point(30, 140));
        var btnGanador = BtnReporte("Reporte de Plancha Ganadora",        new Point(30, 200));

        btnGeneral.Click += (s, e) => GenerarReporte("general");
        btnPadron.Click  += (s, e) => GenerarReporte("padron");
        btnGanador.Click += (s, e) => GenerarReporte("ganador");

        Controls.AddRange(new Control[] { lbl, btnGeneral, btnPadron, btnGanador });
    }

    private Button BtnReporte(string texto, Point loc)
    {
        var btn = new Button { Text = texto, Location = loc, Size = new Size(320, 44) };
        Tema.EstilizarBoton(btn, Tema.Primario);
        return btn;
    }

    private void GenerarReporte(string tipo)
    {
        var votacion = _svc.GetActiva() ?? _svc.GetAll().FirstOrDefault();
        if (votacion is null) { Helpers.MsgError("No hay ninguna votacion disponible."); return; }

        // En produccion esto abre el Microsoft Report Viewer con RDLC
        // Por ahora exportamos a CSV simple como placeholder
        var datos = _svc.GetReporteGeneral(votacion.VotacionId);
        var lineas = new List<string> { "Participante,Matricula,Curso,Seccion,EstadoVoto,FechaVoto" };
        foreach (var d in datos)
            lineas.Add($"{d.Participante},{d.Matricula},{d.Curso},{d.Seccion},{d.EstadoVoto},{d.FechaVoto}");

        var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                                $"Reporte_{tipo}_{DateTime.Now:yyyyMMdd_HHmm}.csv");
        File.WriteAllLines(path, lineas);
        Helpers.MsgExito($"Reporte guardado en:\n{path}");
    }
}

// ════════════════════════════════════════════════════════════
//  AUDITORÍA
// ════════════════════════════════════════════════════════════
public class UcAuditoria : UserControl
{
    public UcAuditoria()
    {
        BackColor = Tema.Fondo; Dock = DockStyle.Fill;

        var dgv = new DataGridView
        {
            Dock = DockStyle.Fill, ReadOnly = true, AllowUserToAddRows = false,
            BackgroundColor = Tema.FondoCard, ForeColor = Tema.Texto,
            BorderStyle = BorderStyle.None, RowHeadersVisible = false, Font = Tema.FuenteNormal,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        };
        dgv.ColumnHeadersDefaultCellStyle.BackColor = Tema.PrimarioOscuro;
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgv.DefaultCellStyle.BackColor  = Tema.FondoCard;
        dgv.DefaultCellStyle.ForeColor  = Tema.Texto;
        dgv.DefaultCellStyle.SelectionBackColor = Tema.Primario;
        dgv.Columns.AddRange(
            new DataGridViewTextBoxColumn { Name = "LogId",    HeaderText = "ID",     Width = 60 },
            new DataGridViewTextBoxColumn { Name = "Accion",   HeaderText = "Accion", Width = 200 },
            new DataGridViewTextBoxColumn { Name = "Detalle",  HeaderText = "Detalle",Width = 300 },
            new DataGridViewTextBoxColumn { Name = "Fecha",    HeaderText = "Fecha",  Width = 160 },
            new DataGridViewTextBoxColumn { Name = "UsuarioId",HeaderText = "UsrId",  Width = 60 });

        Controls.Add(dgv);

        var logs = new DAL.AuditoriaRepository().GetRecientes(200);
        foreach (var l in logs)
            dgv.Rows.Add(l.LogId, l.Accion, l.Detalle, l.Fecha, l.UsuarioId?.ToString() ?? "-");
    }
}
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
