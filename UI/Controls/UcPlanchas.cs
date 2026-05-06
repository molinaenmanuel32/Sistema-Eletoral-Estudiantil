using SistemaVotacion.BLL;
using SistemaVotacion.Models;
using SistemaVotacion.Utils;

namespace SistemaVotacion.UI.Controls;

public class UcPlanchas : UserControl
{
    private DataGridView dgvPlanchas  = null!;
    private DataGridView dgvMiembros  = null!;
    private Button  btnNueva    = null!;
    private Button  btnEditar   = null!;
    private Button  btnAddMiembro = null!;
    private Button  btnQuitarMiembro = null!;
    private Label   lblPlancha  = null!;

    private readonly PlanchaService  _planchaSvc = new();
    private readonly UsuarioService  _usrSvc     = new();
    private Plancha? _planchaSeleccionada;

    public UcPlanchas()
    {
        BackColor = Tema.Fondo;
        Dock      = DockStyle.Fill;
        BuildUI();
        CargarPlanchas();
    }

    private void BuildUI()
    {
        // ── Barra de acciones ─────────────────────────────────────
        var pnlTop = new Panel { Dock = DockStyle.Top, Height = 55, BackColor = Tema.FondoPanel, Padding = new Padding(10, 8, 10, 8) };

        btnNueva = new Button { Text = "+ Nueva Plancha", Width = 160, Height = 38, Location = new Point(10, 8) };
        Tema.EstilizarBoton(btnNueva, Tema.Exito);
        btnNueva.Click += BtnNueva_Click;

        btnEditar = new Button { Text = "Editar", Width = 100, Height = 38, Location = new Point(180, 8), Enabled = false };
        Tema.EstilizarBoton(btnEditar, Tema.Acento);
        btnEditar.Click += BtnEditar_Click;

        pnlTop.Controls.AddRange(new Control[] { btnNueva, btnEditar });

        // ── Split: lista planchas | miembros ────────────────────────
        var split = new SplitContainer
        {
            Dock        = DockStyle.Fill,
            Orientation = Orientation.Vertical,
            SplitterDistance = 420,
            BackColor   = Tema.Fondo
        };

        // Lista de planchas
        dgvPlanchas = CrearGrid();
        dgvPlanchas.Columns.AddRange(
            ColText("PlanchaId", "ID",      40),
            ColText("Nombre",    "Plancha", 180),
            ColText("AdminNombre","Admin",  160),
            ColCheck("Activa",   "Activa",   55));
        dgvPlanchas.SelectionChanged += DgvPlanchas_SelectionChanged;

        var pnlLeft = new Panel { Dock = DockStyle.Fill, BackColor = Tema.FondoCard, Padding = new Padding(5) };
        var lblLeft = new Label { Text = "Planchas Registradas", Font = Tema.FuenteSubtitulo, ForeColor = Tema.Texto, AutoSize = true, Location = new Point(5, 5) };
        dgvPlanchas.Location = new Point(0, 35);
        dgvPlanchas.Size     = new Size(415, 550);
        pnlLeft.Controls.AddRange(new Control[] { lblLeft, dgvPlanchas });

        // Detalle / miembros
        lblPlancha = new Label { Text = "Seleccione una plancha", Font = Tema.FuenteSubtitulo, ForeColor = Tema.Texto, AutoSize = true, Location = new Point(5, 5) };

        btnAddMiembro = new Button { Text = "+ Agregar Miembro", Width = 160, Height = 34, Location = new Point(5, 35), Enabled = false };
        Tema.EstilizarBoton(btnAddMiembro, Tema.Primario);
        btnAddMiembro.Click += BtnAddMiembro_Click;

        btnQuitarMiembro = new Button { Text = "Quitar", Width = 80, Height = 34, Location = new Point(175, 35), Enabled = false };
        Tema.EstilizarBoton(btnQuitarMiembro, Tema.Peligro);
        btnQuitarMiembro.Click += BtnQuitarMiembro_Click;

        dgvMiembros = CrearGrid();
        dgvMiembros.Location = new Point(0, 80);
        dgvMiembros.Size     = new Size(790, 510);
        dgvMiembros.Columns.AddRange(
            ColText("MiembroId",    "ID",         40),
            ColText("Puesto",       "Puesto",     150),
            ColText("NombreCompleto","Nombre",    200),
            ColText("Matricula",    "Matricula",  110),
            ColText("Descripcion",  "Descripcion",200));

        var pnlRight = new Panel { Dock = DockStyle.Fill, BackColor = Tema.FondoCard, Padding = new Padding(5) };
        pnlRight.Controls.AddRange(new Control[] { lblPlancha, btnAddMiembro, btnQuitarMiembro, dgvMiembros });

        split.Panel1.Controls.Add(pnlLeft);
        split.Panel2.Controls.Add(pnlRight);

        Controls.AddRange(new Control[] { split, pnlTop });
    }

    private void CargarPlanchas()
    {
        dgvPlanchas.Rows.Clear();
        foreach (var p in _planchaSvc.GetAll())
            dgvPlanchas.Rows.Add(p.PlanchaId, p.Nombre, p.AdminNombre, p.Activa);
    }

    private void CargarMiembros(int planchaId)
    {
        dgvMiembros.Rows.Clear();
        foreach (var m in _planchaSvc.GetMiembros(planchaId))
            dgvMiembros.Rows.Add(m.MiembroId, m.Puesto, m.NombreCompleto, m.Matricula, m.Descripcion);
    }

    private void DgvPlanchas_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvPlanchas.CurrentRow is null) return;
        int id = (int)dgvPlanchas.CurrentRow.Cells["PlanchaId"].Value;
        _planchaSeleccionada = _planchaSvc.GetById(id);
        if (_planchaSeleccionada is null) return;
        lblPlancha.Text = $"Miembros: {_planchaSeleccionada.Nombre}";
        CargarMiembros(id);
        btnEditar.Enabled      = true;
        btnAddMiembro.Enabled  = true;
        btnQuitarMiembro.Enabled = true;
    }

    private void BtnNueva_Click(object? sender, EventArgs e)
    {
        var frm = new FrmEditarPlancha(null);
        if (frm.ShowDialog() == DialogResult.OK) CargarPlanchas();
    }

    private void BtnEditar_Click(object? sender, EventArgs e)
    {
        if (_planchaSeleccionada is null) return;
        // Solo AdminPartido puede editar su propia plancha, Admin puede editar cualquiera
        if (Sesion.EsAdminPartido && _planchaSeleccionada.AdminUserId != Sesion.UsuarioActual!.UsuarioId)
        {
            Helpers.MsgError("Solo puedes editar tu propia plancha.");
            return;
        }
        var frm = new FrmEditarPlancha(_planchaSeleccionada);
        if (frm.ShowDialog() == DialogResult.OK) { CargarPlanchas(); CargarMiembros(_planchaSeleccionada.PlanchaId); }
    }

    private void BtnAddMiembro_Click(object? sender, EventArgs e)
    {
        if (_planchaSeleccionada is null) return;
        var frm = new FrmAgregarMiembro(_planchaSeleccionada.PlanchaId);
        if (frm.ShowDialog() == DialogResult.OK) CargarMiembros(_planchaSeleccionada.PlanchaId);
    }

    private void BtnQuitarMiembro_Click(object? sender, EventArgs e)
    {
        if (dgvMiembros.CurrentRow is null) return;
        if (!Helpers.Confirmar("Quitar este miembro de la plancha?")) return;
        int miembroId = (int)dgvMiembros.CurrentRow.Cells["MiembroId"].Value;
        _planchaSvc.EliminarMiembro(miembroId);
        CargarMiembros(_planchaSeleccionada!.PlanchaId);
    }

    // ── Helpers ──────────────────────────────────────────────────
    private static DataGridView CrearGrid()
    {
        var g = new DataGridView
        {
            AutoSizeColumnsMode  = DataGridViewAutoSizeColumnsMode.None,
            SelectionMode        = DataGridViewSelectionMode.FullRowSelect,
            MultiSelect          = false,
            ReadOnly             = true,
            AllowUserToAddRows   = false,
            AllowUserToDeleteRows= false,
            BackgroundColor      = Tema.FondoCard,
            ForeColor            = Tema.Texto,
            GridColor            = Tema.Borde,
            BorderStyle          = BorderStyle.None,
            RowHeadersVisible    = false,
            Font                 = Tema.FuenteNormal
        };
        g.ColumnHeadersDefaultCellStyle.BackColor = Tema.PrimarioOscuro;
        g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        g.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 9f, FontStyle.Bold);
        g.DefaultCellStyle.BackColor              = Tema.FondoCard;
        g.DefaultCellStyle.ForeColor              = Tema.Texto;
        g.DefaultCellStyle.SelectionBackColor     = Tema.Primario;
        g.DefaultCellStyle.SelectionForeColor     = Color.White;
        g.AlternatingRowsDefaultCellStyle.BackColor = Tema.FondoPanel;
        return g;
    }

    private static DataGridViewTextBoxColumn ColText(string name, string header, int w) => new()
        { Name = name, HeaderText = header, Width = w };

    private static DataGridViewCheckBoxColumn ColCheck(string name, string header, int w) => new()
        { Name = name, HeaderText = header, Width = w };
}

// ── Formulario editar plancha ────────────────────────────────────────────────
public class FrmEditarPlancha : Form
{
    private TextBox  txtNombre = null!, txtDescripcion = null!, txtMision = null!, txtColor = null!;
    private Button   btnGuardar = null!, btnCancelar = null!;
    private readonly Plancha? _plancha;
    private readonly PlanchaService _svc = new();

    public FrmEditarPlancha(Plancha? plancha)
    {
        _plancha = plancha;
        Text            = plancha is null ? "Nueva Plancha" : "Editar Plancha";
        Size            = new Size(480, 420);
        StartPosition   = FormStartPosition.CenterParent;
        BackColor       = Tema.FondoPanel;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox     = false;

        int y = 20;
        Controls.Add(Campo("Nombre de la Plancha", ref txtNombre, ref y));
        Controls.Add(Campo("Descripcion",          ref txtDescripcion, ref y, 80));
        Controls.Add(Campo("Mision",               ref txtMision, ref y, 60));
        Controls.Add(Campo("Color (hex)",           ref txtColor, ref y));

        btnGuardar = new Button { Text = "Guardar", Location = new Point(280, y + 10), Size = new Size(100, 36) };
        btnCancelar = new Button { Text = "Cancelar", Location = new Point(390, y + 10), Size = new Size(80, 36) };
        Tema.EstilizarBoton(btnGuardar, Tema.Exito);
        Tema.EstilizarBoton(btnCancelar, Tema.Peligro);
        btnGuardar.Click  += BtnGuardar_Click;
        btnCancelar.Click += (s, e) => DialogResult = DialogResult.Cancel;
        Controls.AddRange(new Control[] { btnGuardar, btnCancelar });

        if (plancha is not null)
        {
            txtNombre.Text      = plancha.Nombre;
            txtDescripcion.Text = plancha.Descripcion ?? "";
            txtMision.Text      = plancha.Mision ?? "";
            txtColor.Text       = plancha.Color;
        }
        else txtColor.Text = "#007BFF";
    }

    private Panel Campo(string label, ref TextBox tb, ref int y, int height = 26)
    {
        var p   = new Panel { Location = new Point(20, y), Size = new Size(430, height + 30), BackColor = Tema.FondoPanel };
        var lbl = new Label { Text = label, Font = Tema.FuentePequeña, ForeColor = Tema.TextoSecundario, AutoSize = true, Location = new Point(0, 0) };
        tb = new TextBox { Location = new Point(0, 18), Size = new Size(430, height), Multiline = height > 30 };
        Tema.EstilizarTextBox(tb);
        p.Controls.AddRange(new Control[] { lbl, tb });
        y += height + 40;
        return p;
    }

    private void BtnGuardar_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtNombre.Text)) { Helpers.MsgError("El nombre es obligatorio."); return; }

        if (_plancha is null)
        {
            var nueva = new Plancha { Nombre = txtNombre.Text.Trim(), Descripcion = txtDescripcion.Text, Mision = txtMision.Text, Color = txtColor.Text, AdminUserId = Sesion.UsuarioActual!.UsuarioId, Activa = true };
            var (ok, msg, _) = new PlanchaService().Crear(nueva);
            if (!ok) { Helpers.MsgError(msg); return; }
        }
        else
        {
            _plancha.Nombre      = txtNombre.Text.Trim();
            _plancha.Descripcion = txtDescripcion.Text;
            _plancha.Mision      = txtMision.Text;
            _plancha.Color       = txtColor.Text;
            var (ok, msg) = new PlanchaService().Actualizar(_plancha);
            if (!ok) { Helpers.MsgError(msg); return; }
        }
        Helpers.MsgExito("Plancha guardada correctamente.");
        DialogResult = DialogResult.OK;
    }
}

// ── Formulario agregar miembro ───────────────────────────────────────────────
public class FrmAgregarMiembro : Form
{
    private ComboBox cmbUsuario = null!;
    private TextBox  txtPuesto  = null!, txtDescripcion = null!;
    private NumericUpDown numOrden = null!;
    private Button   btnGuardar = null!;
    private readonly int _planchaId;
    private readonly PlanchaService _svc = new();
    private readonly UsuarioService _usrSvc = new();

    public FrmAgregarMiembro(int planchaId)
    {
        _planchaId      = planchaId;
        Text            = "Agregar Miembro a Plancha";
        Size            = new Size(440, 320);
        StartPosition   = FormStartPosition.CenterParent;
        BackColor       = Tema.FondoPanel;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox     = false;

        // Cargar usuarios sin plancha
        var usuarios = _usrSvc.GetAll().Where(u => u.RolNombre != "Admin").ToList();

        var lblU = new Label { Text = "Usuario", ForeColor = Tema.Texto, AutoSize = true, Location = new Point(20, 20) };
        cmbUsuario = new ComboBox { Location = new Point(20, 40), Size = new Size(390, 28), DropDownStyle = ComboBoxStyle.DropDownList, BackColor = Tema.FondoCard, ForeColor = Tema.Texto };
        cmbUsuario.DataSource    = usuarios;
        cmbUsuario.DisplayMember = "NombreCompleto";
        cmbUsuario.ValueMember   = "UsuarioId";

        var lblP = new Label { Text = "Puesto", ForeColor = Tema.Texto, AutoSize = true, Location = new Point(20, 80) };
        txtPuesto = new TextBox { Location = new Point(20, 100), Size = new Size(250, 26) };
        Tema.EstilizarTextBox(txtPuesto);

        var lblO = new Label { Text = "Orden", ForeColor = Tema.Texto, AutoSize = true, Location = new Point(285, 80) };
        numOrden  = new NumericUpDown { Location = new Point(285, 100), Size = new Size(125, 26), Minimum = 1, Maximum = 99, BackColor = Tema.FondoCard, ForeColor = Tema.Texto };

        var lblD = new Label { Text = "Descripcion breve", ForeColor = Tema.Texto, AutoSize = true, Location = new Point(20, 140) };
        txtDescripcion = new TextBox { Location = new Point(20, 160), Size = new Size(390, 60), Multiline = true };
        Tema.EstilizarTextBox(txtDescripcion);

        btnGuardar = new Button { Text = "Agregar", Location = new Point(280, 235), Size = new Size(130, 38) };
        Tema.EstilizarBoton(btnGuardar, Tema.Exito);
        btnGuardar.Click += BtnGuardar_Click;

        Controls.AddRange(new Control[] { lblU, cmbUsuario, lblP, txtPuesto, lblO, numOrden, lblD, txtDescripcion, btnGuardar });
    }

    private void BtnGuardar_Click(object? sender, EventArgs e)
    {
        if (cmbUsuario.SelectedItem is not Usuario u) return;
        if (string.IsNullOrWhiteSpace(txtPuesto.Text)) { Helpers.MsgError("Indique el puesto."); return; }

        var m = new MiembroPlancha
        {
            PlanchaId   = _planchaId,
            UsuarioId   = u.UsuarioId,
            Puesto      = txtPuesto.Text.Trim(),
            Orden       = (int)numOrden.Value,
            Descripcion = txtDescripcion.Text
        };
        var (ok, msg) = _svc.AgregarMiembro(m);
        if (!ok) { Helpers.MsgError(msg); return; }
        Helpers.MsgExito("Miembro agregado.");
        DialogResult = DialogResult.OK;
    }
}
