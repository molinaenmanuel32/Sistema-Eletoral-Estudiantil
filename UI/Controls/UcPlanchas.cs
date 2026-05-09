using SistemaVotacion.BLL;
using SistemaVotacion.Models;
using SistemaVotacion.Utils;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Controls;

public class UcPlanchas : UserControl
{
    private DataGridView dgvPlanchas = null!;
    private DataGridView dgvMiembros = null!;
    private Button btnNueva = null!;
    private Button btnEditar = null!;
    private Button btnAddMiembro = null!;
    private Button btnQuitarMiembro = null!;
    private Label lblPlancha = null!;

    private readonly PlanchaService _planchaSvc = new();
    private Plancha? _planchaSeleccionada;

    public UcPlanchas()
    {
        BackColor = Tema.Fondo;
        Dock = DockStyle.Fill;
        BuildUI();
        CargarPlanchas();
    }

    private void BuildUI()
    {
        var pnlTop = new Panel
        {
            Dock = DockStyle.Top,
            Height = 60,
            BackColor = Tema.FondoPanel,
            Padding = new Padding(10)
        };

        btnNueva = new Button
        {
            Text = "+ Nueva Plancha",
            Width = 170,
            Height = 40,
            Location = new Point(10, 10)
        };
        Tema.EstilizarBoton(btnNueva, Tema.Exito);
        btnNueva.Click += BtnNueva_Click;

        btnEditar = new Button
        {
            Text = "Editar",
            Width = 110,
            Height = 40,
            Location = new Point(190, 10),
            Enabled = false
        };
        Tema.EstilizarBoton(btnEditar, Tema.Acento);
        btnEditar.Click += BtnEditar_Click;

        pnlTop.Controls.Add(btnNueva);
        pnlTop.Controls.Add(btnEditar);

        var split = new SplitContainer
        {
            Dock = DockStyle.Fill,
            Orientation = Orientation.Vertical,
            SplitterWidth = 4,
            BackColor = Tema.Fondo,
            FixedPanel = FixedPanel.Panel2,
            Panel1MinSize = 100,
            Panel2MinSize = 100
        };

        split.SplitterDistance = 600;

        // PANEL IZQUIERDO
        var pnlLeft = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Tema.FondoCard,
            Padding = new Padding(10)
        };

        var lblLeft = new Label
        {
            Text = "Planchas Registradas",
            Dock = DockStyle.Top,
            Height = 35,
            Font = Tema.FuenteSubtitulo,
            ForeColor = Tema.Texto,
            TextAlign = ContentAlignment.MiddleLeft
        };

        dgvPlanchas = CrearGrid();
        dgvPlanchas.Dock = DockStyle.Fill;
        dgvPlanchas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        dgvPlanchas.Columns.AddRange(
            ColText("PlanchaId", "ID", 60),
            ColText("Nombre", "Plancha", 230),
            ColText("AdminNombre", "Admin", 180),
            ColCheck("Activa", "Activa", 80)
        );

        dgvPlanchas.Columns["PlanchaId"].FillWeight = 15;
        dgvPlanchas.Columns["Nombre"].FillWeight = 45;
        dgvPlanchas.Columns["AdminNombre"].FillWeight = 35;
        dgvPlanchas.Columns["Activa"].FillWeight = 15;

        dgvPlanchas.SelectionChanged += DgvPlanchas_SelectionChanged;

        pnlLeft.Controls.Add(dgvPlanchas);
        pnlLeft.Controls.Add(lblLeft);

        // PANEL DERECHO
        var pnlRight = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Tema.FondoCard,
            Padding = new Padding(10)
        };

        lblPlancha = new Label
        {
            Text = "Seleccione una plancha",
            Dock = DockStyle.Top,
            Height = 35,
            Font = new Font("Segoe UI", 14f, FontStyle.Bold),
            ForeColor = Tema.Texto,
            TextAlign = ContentAlignment.MiddleLeft
        };

        var pnlBotonesMiembros = new Panel
        {
            Dock = DockStyle.Top,
            Height = 45,
            BackColor = Tema.FondoCard
        };

        btnAddMiembro = new Button
        {
            Text = "+ Agregar",
            Width = 150,
            Height = 34,
            Location = new Point(0, 5),
            Enabled = false
        };
        Tema.EstilizarBoton(btnAddMiembro, Tema.Primario);
        btnAddMiembro.Click += BtnAddMiembro_Click;

        btnQuitarMiembro = new Button
        {
            Text = "Quitar",
            Width = 90,
            Height = 34,
            Location = new Point(160, 5),
            Enabled = false
        };
        Tema.EstilizarBoton(btnQuitarMiembro, Tema.Peligro);
        btnQuitarMiembro.Click += BtnQuitarMiembro_Click;

        pnlBotonesMiembros.Controls.Add(btnAddMiembro);
        pnlBotonesMiembros.Controls.Add(btnQuitarMiembro);

        dgvMiembros = CrearGrid();
        dgvMiembros.Dock = DockStyle.Fill;
        dgvMiembros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        dgvMiembros.Columns.AddRange(
            ColText("MiembroId", "ID", 50),
            ColText("Puesto", "Puesto", 130),
            ColText("NombreCompleto", "Nombre", 180),
            ColText("Matricula", "Matrícula", 110),
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

    private void CargarPlanchas()
    {
        dgvPlanchas.Rows.Clear();

        foreach (var p in _planchaSvc.GetAll())
        {
            dgvPlanchas.Rows.Add(
                p.PlanchaId,
                p.Nombre,
                p.AdminNombre,
                p.Activa
            );
        }

        btnEditar.Enabled = false;
        btnAddMiembro.Enabled = false;
        btnQuitarMiembro.Enabled = false;
        lblPlancha.Text = "Seleccione una plancha";
        dgvMiembros.Rows.Clear();
    }

    private void CargarMiembros(int planchaId)
    {
        dgvMiembros.Rows.Clear();

        foreach (var m in _planchaSvc.GetMiembros(planchaId))
        {
            dgvMiembros.Rows.Add(
                m.MiembroId,
                m.Puesto,
                m.NombreCompleto,
                m.Matricula,
                m.Descripcion
            );
        }
    }

    private void DgvPlanchas_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvPlanchas.CurrentRow == null) return;
        if (dgvPlanchas.CurrentRow.Cells["PlanchaId"].Value == null) return;

        int id = Convert.ToInt32(dgvPlanchas.CurrentRow.Cells["PlanchaId"].Value);

        _planchaSeleccionada = _planchaSvc.GetById(id);

        if (_planchaSeleccionada == null) return;

        lblPlancha.Text = $"Miembros: {_planchaSeleccionada.Nombre}";

        CargarMiembros(id);

        btnEditar.Enabled = true;
        btnAddMiembro.Enabled = true;
        btnQuitarMiembro.Enabled = true;
    }

    private void BtnNueva_Click(object? sender, EventArgs e)
    {
        using var frm = new FrmEditarPlancha(null);

        if (frm.ShowDialog() == DialogResult.OK)
        {
            CargarPlanchas();
        }
    }

    private void BtnEditar_Click(object? sender, EventArgs e)
    {
        if (_planchaSeleccionada == null)
        {
            Helpers.MsgError("Seleccione una plancha.");
            return;
        }

        if (Sesion.EsAdminPartido &&
            _planchaSeleccionada.AdminUserId != Sesion.UsuarioActual!.UsuarioId)
        {
            Helpers.MsgError("Solo puedes editar tu propia plancha.");
            return;
        }

        using var frm = new FrmEditarPlancha(_planchaSeleccionada);

        if (frm.ShowDialog() == DialogResult.OK)
        {
            CargarPlanchas();
            CargarMiembros(_planchaSeleccionada.PlanchaId);
        }
    }

    private void BtnAddMiembro_Click(object? sender, EventArgs e)
    {
        if (_planchaSeleccionada == null)
        {
            Helpers.MsgError("Seleccione una plancha primero.");
            return;
        }

        using var frm = new FrmAgregarMiembro(_planchaSeleccionada.PlanchaId);

        if (frm.ShowDialog() == DialogResult.OK)
        {
            CargarMiembros(_planchaSeleccionada.PlanchaId);
        }
    }

    private void BtnQuitarMiembro_Click(object? sender, EventArgs e)
    {
        if (_planchaSeleccionada == null) return;

        if (dgvMiembros.CurrentRow == null)
        {
            Helpers.MsgError("Seleccione un miembro.");
            return;
        }

        if (!Helpers.Confirmar("¿Deseas quitar este miembro de la plancha?")) return;

        int miembroId = Convert.ToInt32(dgvMiembros.CurrentRow.Cells["MiembroId"].Value);

        _planchaSvc.EliminarMiembro(miembroId);
        CargarMiembros(_planchaSeleccionada.PlanchaId);
    }

    private static DataGridView CrearGrid()
    {
        var g = new DataGridView
        {
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            MultiSelect = false,
            ReadOnly = true,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            AllowUserToResizeRows = false,
            BackgroundColor = Tema.FondoCard,
            ForeColor = Tema.Texto,
            GridColor = Tema.Borde,
            BorderStyle = BorderStyle.None,
            RowHeadersVisible = false,
            Font = Tema.FuenteNormal,
            EnableHeadersVisualStyles = false,
            ColumnHeadersHeight = 32,
            RowTemplate = { Height = 30 }
        };

        g.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
        g.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
        g.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);

        g.DefaultCellStyle.BackColor = Tema.FondoCard;
        g.DefaultCellStyle.ForeColor = Tema.Texto;
        g.DefaultCellStyle.SelectionBackColor = Tema.Primario;
        g.DefaultCellStyle.SelectionForeColor = Color.White;

        g.AlternatingRowsDefaultCellStyle.BackColor = Tema.FondoPanel;

        return g;
    }

    private static DataGridViewTextBoxColumn ColText(string name, string header, int w)
    {
        return new DataGridViewTextBoxColumn
        {
            Name = name,
            HeaderText = header,
            Width = w
        };
    }

    private static DataGridViewCheckBoxColumn ColCheck(string name, string header, int w)
    {
        return new DataGridViewCheckBoxColumn
        {
            Name = name,
            HeaderText = header,
            Width = w
        };
    }
}

public class FrmEditarPlancha : Form
{
    private TextBox txtNombre = null!;
    private TextBox txtDescripcion = null!;
    private TextBox txtMision = null!;
    private TextBox txtColor = null!;
    private Button btnGuardar = null!;
    private Button btnCancelar = null!;

    private readonly Plancha? _plancha;
    private readonly PlanchaService _svc = new();

    public FrmEditarPlancha(Plancha? plancha)
    {
        _plancha = plancha;

        Text = plancha == null ? "Nueva Plancha" : "Editar Plancha";
        Size = new Size(520, 500);
        StartPosition = FormStartPosition.CenterParent;
        BackColor = Tema.FondoPanel;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;

        BuildUI();

        if (plancha != null)
        {
            txtNombre.Text = plancha.Nombre;
            txtDescripcion.Text = plancha.Descripcion ?? "";
            txtMision.Text = plancha.Mision ?? "";
            txtColor.Text = plancha.Color;
        }
        else
        {
            txtColor.Text = "#007BFF";
        }
    }

    private void BuildUI()
    {
        var contenedor = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(25),
            BackColor = Tema.FondoPanel
        };

        int y = 10;

        txtNombre = CrearTextBox(contenedor, "Nombre de la Plancha", y, 30);
        y += 75;

        txtDescripcion = CrearTextBox(contenedor, "Descripción", y, 80, true);
        y += 125;

        txtMision = CrearTextBox(contenedor, "Misión", y, 70, true);
        y += 115;

        txtColor = CrearTextBox(contenedor, "Color HEX", y, 30);
        y += 60;

        btnGuardar = new Button
        {
            Text = "Guardar",
            Size = new Size(120, 40),
            Location = new Point(220, y)
        };
        Tema.EstilizarBoton(btnGuardar, Tema.Exito);
        btnGuardar.Click += BtnGuardar_Click;

        btnCancelar = new Button
        {
            Text = "Cancelar",
            Size = new Size(120, 40),
            Location = new Point(350, y)
        };
        Tema.EstilizarBoton(btnCancelar, Tema.Peligro);
        btnCancelar.Click += (s, e) => DialogResult = DialogResult.Cancel;

        contenedor.Controls.Add(btnGuardar);
        contenedor.Controls.Add(btnCancelar);

        Controls.Add(contenedor);
    }

    private TextBox CrearTextBox(Panel parent, string label, int y, int height, bool multiline = false)
    {
        var lbl = new Label
        {
            Text = label,
            Location = new Point(0, y),
            Size = new Size(450, 20),
            ForeColor = Tema.TextoSecundario,
            Font = Tema.FuentePequeña
        };

        var txt = new TextBox
        {
            Location = new Point(0, y + 25),
            Size = new Size(450, height),
            Multiline = multiline,
            BackColor = Tema.FondoCard,
            ForeColor = Tema.Texto,
            BorderStyle = BorderStyle.FixedSingle
        };

        parent.Controls.Add(lbl);
        parent.Controls.Add(txt);

        return txt;
    }

    private void BtnGuardar_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtNombre.Text))
        {
            Helpers.MsgError("El nombre de la plancha es obligatorio.");
            return;
        }

        if (string.IsNullOrWhiteSpace(txtColor.Text))
        {
            txtColor.Text = "#007BFF";
        }

        if (_plancha == null)
        {
            var nueva = new Plancha
            {
                Nombre = txtNombre.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                Mision = txtMision.Text.Trim(),
                Color = txtColor.Text.Trim(),
                AdminUserId = Sesion.UsuarioActual!.UsuarioId,
                Activa = true
            };

            var (ok, msg, _) = _svc.Crear(nueva);

            if (!ok)
            {
                Helpers.MsgError(msg);
                return;
            }
        }
        else
        {
            _plancha.Nombre = txtNombre.Text.Trim();
            _plancha.Descripcion = txtDescripcion.Text.Trim();
            _plancha.Mision = txtMision.Text.Trim();
            _plancha.Color = txtColor.Text.Trim();

            var (ok, msg) = _svc.Actualizar(_plancha);

            if (!ok)
            {
                Helpers.MsgError(msg);
                return;
            }
        }

        Helpers.MsgExito("Plancha guardada correctamente.");
        DialogResult = DialogResult.OK;
        Close();
    }
}

public class FrmAgregarMiembro : Form
{
    private ComboBox cmbUsuario = null!;
    private TextBox txtPuesto = null!;
    private TextBox txtDescripcion = null!;
    private NumericUpDown numOrden = null!;
    private Button btnGuardar = null!;

    private readonly int _planchaId;
    private readonly PlanchaService _svc = new();
    private readonly UsuarioService _usrSvc = new();

    public FrmAgregarMiembro(int planchaId)
    {
        _planchaId = planchaId;

        Text = "Agregar Miembro";
        Size = new Size(460, 350);
        StartPosition = FormStartPosition.CenterParent;
        BackColor = Tema.FondoPanel;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;

        BuildUI();
    }

    private void BuildUI()
    {
        var usuarios = _usrSvc.GetAll()
            .Where(u => u.RolNombre != "Admin")
            .ToList();

        var lblU = CrearLabel("Usuario", 20);
        cmbUsuario = new ComboBox
        {
            Location = new Point(20, 45),
            Size = new Size(400, 30),
            DropDownStyle = ComboBoxStyle.DropDownList,
            BackColor = Tema.FondoCard,
            ForeColor = Tema.Texto
        };

        cmbUsuario.DataSource = usuarios;
        cmbUsuario.DisplayMember = "NombreCompleto";
        cmbUsuario.ValueMember = "UsuarioId";

        var lblP = CrearLabel("Puesto", 90);
        txtPuesto = new TextBox
        {
            Location = new Point(20, 115),
            Size = new Size(250, 28),
            BackColor = Tema.FondoCard,
            ForeColor = Tema.Texto
        };

        var lblO = new Label
        {
            Text = "Orden",
            Location = new Point(290, 90),
            Size = new Size(120, 20),
            ForeColor = Tema.Texto
        };

        numOrden = new NumericUpDown
        {
            Location = new Point(290, 115),
            Size = new Size(130, 28),
            Minimum = 1,
            Maximum = 99,
            BackColor = Tema.FondoCard,
            ForeColor = Tema.Texto
        };

        var lblD = CrearLabel("Descripción breve", 155);
        txtDescripcion = new TextBox
        {
            Location = new Point(20, 180),
            Size = new Size(400, 70),
            Multiline = true,
            BackColor = Tema.FondoCard,
            ForeColor = Tema.Texto
        };

        btnGuardar = new Button
        {
            Text = "Agregar Miembro",
            Location = new Point(260, 265),
            Size = new Size(160, 38)
        };
        Tema.EstilizarBoton(btnGuardar, Tema.Exito);
        btnGuardar.Click += BtnGuardar_Click;

        Controls.AddRange(new Control[]
        {
            lblU, cmbUsuario,
            lblP, txtPuesto,
            lblO, numOrden,
            lblD, txtDescripcion,
            btnGuardar
        });
    }

    private Label CrearLabel(string text, int y)
    {
        return new Label
        {
            Text = text,
            Location = new Point(20, y),
            Size = new Size(400, 20),
            ForeColor = Tema.Texto
        };
    }

    private void BtnGuardar_Click(object? sender, EventArgs e)
    {
        if (cmbUsuario.SelectedItem is not Usuario u)
        {
            Helpers.MsgError("Seleccione un usuario.");
            return;
        }

        if (string.IsNullOrWhiteSpace(txtPuesto.Text))
        {
            Helpers.MsgError("Indique el puesto del miembro.");
            return;
        }

        var miembro = new MiembroPlancha
        {
            PlanchaId = _planchaId,
            UsuarioId = u.UsuarioId,
            Puesto = txtPuesto.Text.Trim(),
            Orden = (int)numOrden.Value,
            Descripcion = txtDescripcion.Text.Trim()
        };

        var (ok, msg) = _svc.AgregarMiembro(miembro);

        if (!ok)
        {
            Helpers.MsgError(msg);
            return;
        }

        Helpers.MsgExito("Miembro agregado correctamente.");
        DialogResult = DialogResult.OK;
        Close();
    }
}