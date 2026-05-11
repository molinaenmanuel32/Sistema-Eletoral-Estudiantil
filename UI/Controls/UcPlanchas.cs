using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SistemaVotacion.BLL;
using SistemaVotacion.Models;
using SistemaVotacion.UI.Forms;
using SistemaVotacion.Utils;

namespace SistemaVotacion.UI.Controls;

public class UcPlanchas : UserControl
{
    private DataGridView dgvPlanchas = null!;
    private DataGridView dgvMiembros = null!;

    private Button btnNueva = null!;
    private Button btnEditar = null!;
    private Button btnAddMiembro = null!;
    private Button btnEditarMiembro = null!;
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
            Text = "Editar Plancha",
            Width = 140,
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
            FixedPanel = FixedPanel.Panel1,
            Panel1MinSize = 350,
            Panel2MinSize = 450,
            SplitterDistance = 420
        };

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
            Height = 40,
            Font = Tema.FuenteSubtitulo,
            ForeColor = Tema.Texto,
            TextAlign = ContentAlignment.MiddleLeft
        };

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
            Height = 40,
            Font = new Font("Segoe UI", 14F, FontStyle.Bold),
            ForeColor = Tema.Texto,
            TextAlign = ContentAlignment.MiddleLeft
        };

        var pnlBotonesMiembros = new Panel
        {
            Dock = DockStyle.Top,
            Height = 50,
            BackColor = Tema.FondoCard
        };

        btnAddMiembro = new Button
        {
            Text = "+ Agregar",
            Width = 120,
            Height = 36,
            Location = new Point(0, 7),
            Enabled = false
        };
        Tema.EstilizarBoton(btnAddMiembro, Tema.Primario);
        btnAddMiembro.Click += BtnAddMiembro_Click;

        btnEditarMiembro = new Button
        {
            Text = "Editar Miembro",
            Width = 150,
            Height = 36,
            Location = new Point(130, 7),
            Enabled = false
        };
        Tema.EstilizarBoton(btnEditarMiembro, Tema.Acento);
        btnEditarMiembro.Click += BtnEditarMiembro_Click;

        btnQuitarMiembro = new Button
        {
            Text = "Quitar",
            Width = 100,
            Height = 36,
            Location = new Point(290, 7),
            Enabled = false
        };
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

        btnEditar.Enabled = false;
        btnAddMiembro.Enabled = false;
        btnEditarMiembro.Enabled = false;
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
                CargarImagen(m.FotoPath),
                m.MiembroId,
                m.Puesto,
                !string.IsNullOrWhiteSpace(m.NombreCompleto) ? m.NombreCompleto : m.Nombre,
                m.Matricula,
                m.Descripcion
            );
        }
    }

    private Image? CargarImagen(string? ruta)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(ruta) || !File.Exists(ruta))
                return null;

            using var imgTemp = Image.FromFile(ruta);
            return new Bitmap(imgTemp, new Size(45, 45));
        }
        catch
        {
            return null;
        }
    }

    private void DgvPlanchas_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvPlanchas.CurrentRow == null) return;
        if (dgvPlanchas.CurrentRow.Cells["PlanchaId"].Value == null) return;

        int id = Convert.ToInt32(dgvPlanchas.CurrentRow.Cells["PlanchaId"].Value);

        _planchaSeleccionada = _planchaSvc.GetById(id);

        if (_planchaSeleccionada == null) return;

        lblPlancha.Text = $"Miembros de {_planchaSeleccionada.Nombre}";

        CargarMiembros(id);

        btnEditar.Enabled = true;
        btnAddMiembro.Enabled = true;
        btnEditarMiembro.Enabled = true;
        btnQuitarMiembro.Enabled = true;
    }

    private void BtnNueva_Click(object? sender, EventArgs e)
    {
        using var frm = new FrmEditarPlancha(null);

        if (frm.ShowDialog() == DialogResult.OK)
            CargarPlanchas();
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
            CargarMiembros(_planchaSeleccionada.PlanchaId);
    }

    private void BtnEditarMiembro_Click(object? sender, EventArgs e)
    {
        if (_planchaSeleccionada == null)
        {
            Helpers.MsgError("Seleccione una plancha.");
            return;
        }

        if (dgvMiembros.CurrentRow == null)
        {
            Helpers.MsgError("Seleccione un miembro.");
            return;
        }

        int miembroId = Convert.ToInt32(dgvMiembros.CurrentRow.Cells["MiembroId"].Value);

        var miembro = _planchaSvc.GetMiembroById(miembroId);

        if (miembro == null)
        {
            Helpers.MsgError("No se encontró el miembro.");
            return;
        }

        using var frm = new FrmAgregarMiembro(_planchaSeleccionada.PlanchaId, miembro);

        if (frm.ShowDialog() == DialogResult.OK)
            CargarMiembros(_planchaSeleccionada.PlanchaId);
    }

    private void BtnQuitarMiembro_Click(object? sender, EventArgs e)
    {
        if (_planchaSeleccionada == null) return;

        if (dgvMiembros.CurrentRow == null)
        {
            Helpers.MsgError("Seleccione un miembro.");
            return;
        }

        if (!Helpers.Confirmar("¿Deseas quitar este miembro de la plancha?"))
            return;

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
            ColumnHeadersHeight = 36,
            RowTemplate = { Height = 55 }
        };

        g.ColumnHeadersDefaultCellStyle.BackColor = Tema.Primario;
        g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        g.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

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

    private static DataGridViewImageColumn ColImage(string name, string header, int w)
    {
        return new DataGridViewImageColumn
        {
            Name = name,
            HeaderText = header,
            Width = w,
            ImageLayout = DataGridViewImageCellLayout.Zoom
        };
    }
}