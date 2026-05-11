using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    partial class FrmEditarMiPlancha
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Panel pnlAsignarPlancha;
        private Panel pnlPlancha;
        private Panel pnlMiembros;

        private Label lblTitulo;
        private Label lblSubtitulo;

        private Label lblAsignacion;
        private ComboBox cmbPlanchasDisponibles;
        private Button btnTomarPlancha;
        private TextBox txtNuevaPlancha;
        private TextBox txtNuevaDescripcion;
        private Button btnCrearMiPlancha;

        private Label lblNombrePlancha;
        private Label lblDescripcion;
        private TextBox txtNombrePlancha;
        private TextBox txtDescripcion;
        private Button btnGuardarPlancha;

        private Label lblMiembros;
        private Label lblPuesto;
        private Label lblNombreMiembro;
        private Label lblMatricula;
        private Label lblDescripcionMiembro;
        private Label lblFoto;
        private Label lblFotoTexto;

        private ComboBox cmbPuesto;
        private TextBox txtNombreMiembro;
        private TextBox txtMatricula;
        private TextBox txtDescripcionMiembro;

        private PictureBox picFoto;
        private Button btnSeleccionarFoto;
        private Button btnAgregarMiembro;
        private Button btnActualizarMiembro;
        private Button btnEliminarMiembro;
        private DataGridView dgvMiembros;

        protected override void Dispose(bool disposing)
        {
<<<<<<< HEAD
            if (disposing && (components != null))
=======
            if (disposing && components != null)
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
<<<<<<< HEAD
            this.pnlHeader = new Panel();
            this.pnlAsignarPlancha = new Panel();
            this.pnlPlancha = new Panel();
            this.pnlMiembros = new Panel();

            this.lblTitulo = new Label();
            this.lblSubtitulo = new Label();

            this.lblAsignacion = new Label();
            this.cmbPlanchasDisponibles = new ComboBox();
            this.btnTomarPlancha = new Button();
            this.txtNuevaPlancha = new TextBox();
            this.txtNuevaDescripcion = new TextBox();
            this.btnCrearMiPlancha = new Button();

            this.lblNombrePlancha = new Label();
            this.lblDescripcion = new Label();
            this.txtNombrePlancha = new TextBox();
            this.txtDescripcion = new TextBox();
            this.btnGuardarPlancha = new Button();

            this.lblMiembros = new Label();
            this.lblPuesto = new Label();
            this.lblNombreMiembro = new Label();
            this.lblMatricula = new Label();
            this.lblDescripcionMiembro = new Label();
            this.lblFoto = new Label();
            this.lblFotoTexto = new Label();

            this.cmbPuesto = new ComboBox();
            this.txtNombreMiembro = new TextBox();
            this.txtMatricula = new TextBox();
            this.txtDescripcionMiembro = new TextBox();

            this.picFoto = new PictureBox();

            this.btnSeleccionarFoto = new Button();
            this.btnAgregarMiembro = new Button();
            this.btnActualizarMiembro = new Button();
            this.btnEliminarMiembro = new Button();

            this.dgvMiembros = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMiembros)).BeginInit();

            this.SuspendLayout();

            // FORM
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.FromArgb(242, 245, 251);
            this.ClientSize = new Size(950, 620);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Text = "Mi Plancha";

            // HEADER
            this.pnlHeader.BackColor = Color.White;
            this.pnlHeader.Location = new Point(25, 20);
            this.pnlHeader.Size = new Size(900, 90);

            this.lblTitulo.Text = "Mi Plancha";
            this.lblTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.FromArgb(0, 45, 120);
            this.lblTitulo.Location = new Point(25, 15);
            this.lblTitulo.Size = new Size(500, 42);

            this.lblSubtitulo.Text = "Edita tu plancha y administra sus miembros.";
            this.lblSubtitulo.Font = new Font("Segoe UI", 11.5F);
            this.lblSubtitulo.ForeColor = Color.FromArgb(70, 80, 110);
            this.lblSubtitulo.Location = new Point(28, 58);
            this.lblSubtitulo.Size = new Size(700, 25);

            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblSubtitulo);

            // PANEL ASIGNAR
            this.pnlAsignarPlancha.BackColor = Color.White;
            this.pnlAsignarPlancha.Location = new Point(25, 130);
            this.pnlAsignarPlancha.Size = new Size(900, 230);
            this.pnlAsignarPlancha.Visible = false;

            this.lblAsignacion.Text = "No tienes una plancha asignada.";
            this.lblAsignacion.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblAsignacion.ForeColor = Color.FromArgb(0, 45, 120);
            this.lblAsignacion.Location = new Point(25, 25);
            this.lblAsignacion.Size = new Size(830, 35);

            this.cmbPlanchasDisponibles.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbPlanchasDisponibles.Font = new Font("Segoe UI", 11F);
            this.cmbPlanchasDisponibles.Location = new Point(25, 75);
            this.cmbPlanchasDisponibles.Size = new Size(300, 32);

            this.btnTomarPlancha.Text = "Tomar Plancha";
            this.btnTomarPlancha.Location = new Point(345, 72);
            this.btnTomarPlancha.Size = new Size(160, 38);
            this.btnTomarPlancha.BackColor = Color.FromArgb(20, 110, 220);
            this.btnTomarPlancha.ForeColor = Color.White;
            this.btnTomarPlancha.FlatStyle = FlatStyle.Flat;
            this.btnTomarPlancha.FlatAppearance.BorderSize = 0;
            this.btnTomarPlancha.Cursor = Cursors.Hand;
            this.btnTomarPlancha.Click += new System.EventHandler(this.btnTomarPlancha_Click);

            this.txtNuevaPlancha.Font = new Font("Segoe UI", 11F);
            this.txtNuevaPlancha.Location = new Point(25, 140);
            this.txtNuevaPlancha.Size = new Size(300, 32);

            this.txtNuevaDescripcion.Font = new Font("Segoe UI", 11F);
            this.txtNuevaDescripcion.Location = new Point(345, 140);
            this.txtNuevaDescripcion.Size = new Size(300, 32);

            this.btnCrearMiPlancha.Text = "Crear mi Plancha";
            this.btnCrearMiPlancha.Location = new Point(665, 137);
            this.btnCrearMiPlancha.Size = new Size(170, 38);
            this.btnCrearMiPlancha.BackColor = Color.FromArgb(20, 170, 90);
            this.btnCrearMiPlancha.ForeColor = Color.White;
            this.btnCrearMiPlancha.FlatStyle = FlatStyle.Flat;
            this.btnCrearMiPlancha.FlatAppearance.BorderSize = 0;
            this.btnCrearMiPlancha.Cursor = Cursors.Hand;
            this.btnCrearMiPlancha.Click += new System.EventHandler(this.btnCrearMiPlancha_Click);

            this.pnlAsignarPlancha.Controls.Add(this.lblAsignacion);
            this.pnlAsignarPlancha.Controls.Add(this.cmbPlanchasDisponibles);
            this.pnlAsignarPlancha.Controls.Add(this.btnTomarPlancha);
            this.pnlAsignarPlancha.Controls.Add(this.txtNuevaPlancha);
            this.pnlAsignarPlancha.Controls.Add(this.txtNuevaDescripcion);
            this.pnlAsignarPlancha.Controls.Add(this.btnCrearMiPlancha);

            // PANEL PLANCHA
            this.pnlPlancha.BackColor = Color.White;
            this.pnlPlancha.Location = new Point(25, 130);
            this.pnlPlancha.Size = new Size(900, 145);

            this.lblNombrePlancha.Text = "Nombre";
            this.lblNombrePlancha.Location = new Point(25, 20);

            this.txtNombrePlancha.Location = new Point(25, 48);
            this.txtNombrePlancha.Size = new Size(350, 28);

            this.lblDescripcion.Text = "Descripción";
            this.lblDescripcion.Location = new Point(400, 20);

            this.txtDescripcion.Location = new Point(400, 48);
            this.txtDescripcion.Size = new Size(320, 28);

            this.btnGuardarPlancha.Text = "Guardar Cambios";
            this.btnGuardarPlancha.Location = new Point(25, 95);
            this.btnGuardarPlancha.Size = new Size(180, 40);
            this.btnGuardarPlancha.BackColor = Color.FromArgb(20, 110, 220);
            this.btnGuardarPlancha.ForeColor = Color.White;
            this.btnGuardarPlancha.FlatStyle = FlatStyle.Flat;
            this.btnGuardarPlancha.FlatAppearance.BorderSize = 0;
            this.btnGuardarPlancha.Click += new System.EventHandler(this.btnGuardarPlancha_Click);

            this.pnlPlancha.Controls.Add(this.lblNombrePlancha);
            this.pnlPlancha.Controls.Add(this.txtNombrePlancha);
            this.pnlPlancha.Controls.Add(this.lblDescripcion);
            this.pnlPlancha.Controls.Add(this.txtDescripcion);
            this.pnlPlancha.Controls.Add(this.btnGuardarPlancha);

            // PANEL MIEMBROS
            this.pnlMiembros.BackColor = Color.White;
            this.pnlMiembros.Location = new Point(25, 295);
            this.pnlMiembros.Size = new Size(900, 305);

            this.lblMiembros.Text = "Miembros";
            this.lblMiembros.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblMiembros.Location = new Point(25, 12);

            this.cmbPuesto.Location = new Point(25, 78);
            this.cmbPuesto.Size = new Size(145, 28);

            this.txtNombreMiembro.Location = new Point(185, 78);
            this.txtNombreMiembro.Size = new Size(170, 28);

            this.txtMatricula.Location = new Point(370, 78);
            this.txtMatricula.Size = new Size(130, 28);

            this.txtDescripcionMiembro.Location = new Point(515, 78);
            this.txtDescripcionMiembro.Size = new Size(170, 28);

            this.picFoto.Location = new Point(25, 135);
            this.picFoto.Size = new Size(70, 60);
            this.picFoto.BorderStyle = BorderStyle.FixedSingle;
            this.picFoto.SizeMode = PictureBoxSizeMode.Zoom;

            this.lblFotoTexto.Text = "Sin foto";
            this.lblFotoTexto.Location = new Point(105, 135);
            this.lblFotoTexto.Size = new Size(200, 25);

            this.btnSeleccionarFoto.Text = "Buscar Foto";
            this.btnSeleccionarFoto.Location = new Point(105, 165);
            this.btnSeleccionarFoto.Size = new Size(120, 30);
            this.btnSeleccionarFoto.Click += new System.EventHandler(this.btnSeleccionarFoto_Click);

            this.btnAgregarMiembro.Text = "+ Agregar";
            this.btnAgregarMiembro.Location = new Point(700, 55);
            this.btnAgregarMiembro.Size = new Size(150, 32);
            this.btnAgregarMiembro.Click += new System.EventHandler(this.btnAgregarMiembro_Click);

            this.btnActualizarMiembro.Text = "Actualizar";
            this.btnActualizarMiembro.Location = new Point(700, 95);
            this.btnActualizarMiembro.Size = new Size(150, 32);
            this.btnActualizarMiembro.Click += new System.EventHandler(this.btnActualizarMiembro_Click);

            this.btnEliminarMiembro.Text = "Eliminar";
            this.btnEliminarMiembro.Location = new Point(700, 135);
            this.btnEliminarMiembro.Size = new Size(150, 32);
            this.btnEliminarMiembro.Click += new System.EventHandler(this.btnEliminarMiembro_Click);

            this.dgvMiembros.Location = new Point(25, 205);
            this.dgvMiembros.Size = new Size(850, 85);
            this.dgvMiembros.AllowUserToAddRows = false;
            this.dgvMiembros.AllowUserToDeleteRows = false;
            this.dgvMiembros.ReadOnly = true;
            this.dgvMiembros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvMiembros.MultiSelect = false;
            this.dgvMiembros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMiembros.RowHeadersVisible = false;

            this.pnlMiembros.Controls.Add(this.lblMiembros);
            this.pnlMiembros.Controls.Add(this.cmbPuesto);
            this.pnlMiembros.Controls.Add(this.txtNombreMiembro);
            this.pnlMiembros.Controls.Add(this.txtMatricula);
            this.pnlMiembros.Controls.Add(this.txtDescripcionMiembro);
            this.pnlMiembros.Controls.Add(this.picFoto);
            this.pnlMiembros.Controls.Add(this.lblFotoTexto);
            this.pnlMiembros.Controls.Add(this.btnSeleccionarFoto);
            this.pnlMiembros.Controls.Add(this.btnAgregarMiembro);
            this.pnlMiembros.Controls.Add(this.btnActualizarMiembro);
            this.pnlMiembros.Controls.Add(this.btnEliminarMiembro);
            this.pnlMiembros.Controls.Add(this.dgvMiembros);

            // CONTROLS
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlAsignarPlancha);
            this.Controls.Add(this.pnlPlancha);
            this.Controls.Add(this.pnlMiembros);

            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMiembros)).EndInit();

            this.ResumeLayout(false);
=======
            pnlHeader = new Panel();
            pnlAsignarPlancha = new Panel();
            pnlPlancha = new Panel();
            pnlMiembros = new Panel();

            lblTitulo = new Label();
            lblSubtitulo = new Label();

            lblAsignacion = new Label();
            cmbPlanchasDisponibles = new ComboBox();
            btnTomarPlancha = new Button();
            txtNuevaPlancha = new TextBox();
            txtNuevaDescripcion = new TextBox();
            btnCrearMiPlancha = new Button();

            lblNombrePlancha = new Label();
            lblDescripcion = new Label();
            txtNombrePlancha = new TextBox();
            txtDescripcion = new TextBox();
            btnGuardarPlancha = new Button();

            lblMiembros = new Label();
            lblPuesto = new Label();
            lblNombreMiembro = new Label();
            lblMatricula = new Label();
            lblDescripcionMiembro = new Label();
            lblFoto = new Label();
            lblFotoTexto = new Label();

            cmbPuesto = new ComboBox();
            txtNombreMiembro = new TextBox();
            txtMatricula = new TextBox();
            txtDescripcionMiembro = new TextBox();

            picFoto = new PictureBox();
            btnSeleccionarFoto = new Button();
            btnAgregarMiembro = new Button();
            btnActualizarMiembro = new Button();
            btnEliminarMiembro = new Button();
            dgvMiembros = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)dgvMiembros).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picFoto).BeginInit();

            SuspendLayout();

            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(242, 245, 251);
            ClientSize = new Size(950, 620);

            pnlHeader.BackColor = Color.White;
            pnlHeader.Location = new Point(25, 20);
            pnlHeader.Size = new Size(900, 90);

            lblTitulo.Text = "Mi Plancha";
            lblTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 45, 120);
            lblTitulo.Location = new Point(25, 15);
            lblTitulo.Size = new Size(500, 42);

            lblSubtitulo.Text = "Edita tu plancha y administra sus miembros.";
            lblSubtitulo.Font = new Font("Segoe UI", 11.5F);
            lblSubtitulo.ForeColor = Color.FromArgb(70, 80, 110);
            lblSubtitulo.Location = new Point(28, 58);
            lblSubtitulo.Size = new Size(700, 25);

            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Controls.Add(lblSubtitulo);

            pnlAsignarPlancha.BackColor = Color.White;
            pnlAsignarPlancha.Location = new Point(25, 130);
            pnlAsignarPlancha.Size = new Size(900, 230);
            pnlAsignarPlancha.Visible = false;

            lblAsignacion.Text = "No tienes una plancha asignada. Elige una disponible o crea la tuya.";
            lblAsignacion.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblAsignacion.ForeColor = Color.FromArgb(0, 45, 120);
            lblAsignacion.Location = new Point(25, 25);
            lblAsignacion.Size = new Size(830, 35);

            cmbPlanchasDisponibles.Font = new Font("Segoe UI", 11F);
            cmbPlanchasDisponibles.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPlanchasDisponibles.Location = new Point(25, 75);
            cmbPlanchasDisponibles.Size = new Size(300, 32);

            btnTomarPlancha.Text = "Tomar Plancha";
            btnTomarPlancha.Location = new Point(345, 72);
            btnTomarPlancha.Size = new Size(160, 38);
            btnTomarPlancha.BackColor = Color.FromArgb(20, 110, 220);
            btnTomarPlancha.ForeColor = Color.White;
            btnTomarPlancha.FlatStyle = FlatStyle.Flat;
            btnTomarPlancha.FlatAppearance.BorderSize = 0;
            btnTomarPlancha.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnTomarPlancha.Cursor = Cursors.Hand;
            btnTomarPlancha.Click += btnTomarPlancha_Click;

            txtNuevaPlancha.PlaceholderText = "Nombre de mi nueva plancha";
            txtNuevaPlancha.Font = new Font("Segoe UI", 11F);
            txtNuevaPlancha.Location = new Point(25, 140);
            txtNuevaPlancha.Size = new Size(300, 32);

            txtNuevaDescripcion.PlaceholderText = "Descripción";
            txtNuevaDescripcion.Font = new Font("Segoe UI", 11F);
            txtNuevaDescripcion.Location = new Point(345, 140);
            txtNuevaDescripcion.Size = new Size(300, 32);

            btnCrearMiPlancha.Text = "Crear mi Plancha";
            btnCrearMiPlancha.Location = new Point(665, 137);
            btnCrearMiPlancha.Size = new Size(170, 38);
            btnCrearMiPlancha.BackColor = Color.FromArgb(20, 170, 90);
            btnCrearMiPlancha.ForeColor = Color.White;
            btnCrearMiPlancha.FlatStyle = FlatStyle.Flat;
            btnCrearMiPlancha.FlatAppearance.BorderSize = 0;
            btnCrearMiPlancha.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnCrearMiPlancha.Cursor = Cursors.Hand;
            btnCrearMiPlancha.Click += btnCrearMiPlancha_Click;

            pnlAsignarPlancha.Controls.Add(lblAsignacion);
            pnlAsignarPlancha.Controls.Add(cmbPlanchasDisponibles);
            pnlAsignarPlancha.Controls.Add(btnTomarPlancha);
            pnlAsignarPlancha.Controls.Add(txtNuevaPlancha);
            pnlAsignarPlancha.Controls.Add(txtNuevaDescripcion);
            pnlAsignarPlancha.Controls.Add(btnCrearMiPlancha);

            pnlPlancha.BackColor = Color.White;
            pnlPlancha.Location = new Point(25, 130);
            pnlPlancha.Size = new Size(900, 145);

            lblNombrePlancha.Text = "Nombre de la plancha";
            lblNombrePlancha.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblNombrePlancha.Location = new Point(25, 20);
            lblNombrePlancha.Size = new Size(220, 25);

            txtNombrePlancha.Font = new Font("Segoe UI", 11F);
            txtNombrePlancha.Location = new Point(25, 48);
            txtNombrePlancha.Size = new Size(350, 32);

            lblDescripcion.Text = "Descripción";
            lblDescripcion.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblDescripcion.Location = new Point(400, 20);
            lblDescripcion.Size = new Size(220, 25);

            txtDescripcion.Font = new Font("Segoe UI", 11F);
            txtDescripcion.Location = new Point(400, 48);
            txtDescripcion.Size = new Size(320, 32);

            btnGuardarPlancha.Text = "Guardar Cambios";
            btnGuardarPlancha.BackColor = Color.FromArgb(20, 110, 220);
            btnGuardarPlancha.ForeColor = Color.White;
            btnGuardarPlancha.FlatStyle = FlatStyle.Flat;
            btnGuardarPlancha.FlatAppearance.BorderSize = 0;
            btnGuardarPlancha.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnGuardarPlancha.Location = new Point(25, 95);
            btnGuardarPlancha.Size = new Size(180, 40);
            btnGuardarPlancha.Cursor = Cursors.Hand;
            btnGuardarPlancha.Click += btnGuardarPlancha_Click;

            pnlPlancha.Controls.Add(lblNombrePlancha);
            pnlPlancha.Controls.Add(txtNombrePlancha);
            pnlPlancha.Controls.Add(lblDescripcion);
            pnlPlancha.Controls.Add(txtDescripcion);
            pnlPlancha.Controls.Add(btnGuardarPlancha);

            pnlMiembros.BackColor = Color.White;
            pnlMiembros.Location = new Point(25, 295);
            pnlMiembros.Size = new Size(900, 305);

            lblMiembros.Text = "Miembros de mi Plancha";
            lblMiembros.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblMiembros.ForeColor = Color.FromArgb(0, 45, 120);
            lblMiembros.Location = new Point(25, 12);
            lblMiembros.Size = new Size(400, 35);

            lblPuesto.Text = "Cargo";
            lblPuesto.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPuesto.Location = new Point(25, 55);
            lblPuesto.Size = new Size(100, 20);

            cmbPuesto.Font = new Font("Segoe UI", 10F);
            cmbPuesto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPuesto.Location = new Point(25, 78);
            cmbPuesto.Size = new Size(145, 28);

            lblNombreMiembro.Text = "Nombre";
            lblNombreMiembro.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblNombreMiembro.Location = new Point(185, 55);
            lblNombreMiembro.Size = new Size(100, 20);

            txtNombreMiembro.Font = new Font("Segoe UI", 10F);
            txtNombreMiembro.Location = new Point(185, 78);
            txtNombreMiembro.Size = new Size(170, 28);

            lblMatricula.Text = "Matrícula";
            lblMatricula.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblMatricula.Location = new Point(370, 55);
            lblMatricula.Size = new Size(100, 20);

            txtMatricula.Font = new Font("Segoe UI", 10F);
            txtMatricula.Location = new Point(370, 78);
            txtMatricula.Size = new Size(130, 28);

            lblDescripcionMiembro.Text = "Descripción";
            lblDescripcionMiembro.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDescripcionMiembro.Location = new Point(515, 55);
            lblDescripcionMiembro.Size = new Size(120, 20);

            txtDescripcionMiembro.Font = new Font("Segoe UI", 10F);
            txtDescripcionMiembro.Location = new Point(515, 78);
            txtDescripcionMiembro.Size = new Size(170, 28);

            lblFoto.Text = "Foto";
            lblFoto.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblFoto.Location = new Point(25, 112);
            lblFoto.Size = new Size(80, 20);

            picFoto.Location = new Point(25, 135);
            picFoto.Size = new Size(70, 60);
            picFoto.BackColor = Color.White;
            picFoto.BorderStyle = BorderStyle.FixedSingle;
            picFoto.SizeMode = PictureBoxSizeMode.Zoom;

            lblFotoTexto.Text = "Sin foto";
            lblFotoTexto.Font = new Font("Segoe UI", 8.5F);
            lblFotoTexto.ForeColor = Color.FromArgb(80, 90, 115);
            lblFotoTexto.Location = new Point(105, 135);
            lblFotoTexto.Size = new Size(200, 25);

            btnSeleccionarFoto.Text = "Buscar Foto";
            btnSeleccionarFoto.BackColor = Color.FromArgb(0, 55, 150);
            btnSeleccionarFoto.ForeColor = Color.White;
            btnSeleccionarFoto.FlatStyle = FlatStyle.Flat;
            btnSeleccionarFoto.FlatAppearance.BorderSize = 0;
            btnSeleccionarFoto.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSeleccionarFoto.Location = new Point(105, 165);
            btnSeleccionarFoto.Size = new Size(120, 30);
            btnSeleccionarFoto.Cursor = Cursors.Hand;
            btnSeleccionarFoto.Click += btnSeleccionarFoto_Click;

            btnAgregarMiembro.Text = "+ Agregar";
            btnAgregarMiembro.BackColor = Color.FromArgb(20, 110, 220);
            btnAgregarMiembro.ForeColor = Color.White;
            btnAgregarMiembro.FlatStyle = FlatStyle.Flat;
            btnAgregarMiembro.FlatAppearance.BorderSize = 0;
            btnAgregarMiembro.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAgregarMiembro.Location = new Point(700, 55);
            btnAgregarMiembro.Size = new Size(150, 32);
            btnAgregarMiembro.Cursor = Cursors.Hand;
            btnAgregarMiembro.Click += btnAgregarMiembro_Click;

            btnActualizarMiembro.Text = "Actualizar";
            btnActualizarMiembro.BackColor = Color.FromArgb(0, 55, 150);
            btnActualizarMiembro.ForeColor = Color.White;
            btnActualizarMiembro.FlatStyle = FlatStyle.Flat;
            btnActualizarMiembro.FlatAppearance.BorderSize = 0;
            btnActualizarMiembro.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnActualizarMiembro.Location = new Point(700, 95);
            btnActualizarMiembro.Size = new Size(150, 32);
            btnActualizarMiembro.Cursor = Cursors.Hand;
            btnActualizarMiembro.Click += btnActualizarMiembro_Click;

            btnEliminarMiembro.Text = "Eliminar";
            btnEliminarMiembro.BackColor = Color.FromArgb(237, 35, 45);
            btnEliminarMiembro.ForeColor = Color.White;
            btnEliminarMiembro.FlatStyle = FlatStyle.Flat;
            btnEliminarMiembro.FlatAppearance.BorderSize = 0;
            btnEliminarMiembro.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnEliminarMiembro.Location = new Point(700, 135);
            btnEliminarMiembro.Size = new Size(150, 32);
            btnEliminarMiembro.Cursor = Cursors.Hand;
            btnEliminarMiembro.Click += btnEliminarMiembro_Click;

            dgvMiembros.Location = new Point(25, 205);
            dgvMiembros.Size = new Size(850, 85);
            dgvMiembros.AllowUserToAddRows = false;
            dgvMiembros.AllowUserToDeleteRows = false;
            dgvMiembros.ReadOnly = true;
            dgvMiembros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMiembros.MultiSelect = false;
            dgvMiembros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMiembros.BackgroundColor = Color.White;
            dgvMiembros.BorderStyle = BorderStyle.FixedSingle;
            dgvMiembros.RowHeadersVisible = false;

            pnlMiembros.Controls.Add(lblMiembros);
            pnlMiembros.Controls.Add(lblPuesto);
            pnlMiembros.Controls.Add(cmbPuesto);
            pnlMiembros.Controls.Add(lblNombreMiembro);
            pnlMiembros.Controls.Add(txtNombreMiembro);
            pnlMiembros.Controls.Add(lblMatricula);
            pnlMiembros.Controls.Add(txtMatricula);
            pnlMiembros.Controls.Add(lblDescripcionMiembro);
            pnlMiembros.Controls.Add(txtDescripcionMiembro);
            pnlMiembros.Controls.Add(lblFoto);
            pnlMiembros.Controls.Add(picFoto);
            pnlMiembros.Controls.Add(lblFotoTexto);
            pnlMiembros.Controls.Add(btnSeleccionarFoto);
            pnlMiembros.Controls.Add(btnAgregarMiembro);
            pnlMiembros.Controls.Add(btnActualizarMiembro);
            pnlMiembros.Controls.Add(btnEliminarMiembro);
            pnlMiembros.Controls.Add(dgvMiembros);

            Controls.Add(pnlHeader);
            Controls.Add(pnlAsignarPlancha);
            Controls.Add(pnlPlancha);
            Controls.Add(pnlMiembros);

            ((System.ComponentModel.ISupportInitialize)dgvMiembros).EndInit();
            ((System.ComponentModel.ISupportInitialize)picFoto).EndInit();

            ResumeLayout(false);
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
        }
    }
}