using System;
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
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
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
            this.Name = "FrmEditarMiPlancha";
            this.Text = "Mi Plancha";

            // =========================================================
            // HEADER
            // =========================================================

            this.pnlHeader.BackColor = Color.White;
            this.pnlHeader.Location = new Point(25, 20);
            this.pnlHeader.Size = new Size(900, 90);

            this.lblTitulo.Text = "Mi Plancha";
            this.lblTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.FromArgb(0, 45, 120);
            this.lblTitulo.Location = new Point(25, 10);
            this.lblTitulo.Size = new Size(400, 45);

            this.lblSubtitulo.Text = "Edita tu plancha y administra sus miembros.";
            this.lblSubtitulo.Font = new Font("Segoe UI", 11F);
            this.lblSubtitulo.ForeColor = Color.Gray;
            this.lblSubtitulo.Location = new Point(28, 55);
            this.lblSubtitulo.Size = new Size(500, 25);

            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblSubtitulo);

            // =========================================================
            // PANEL ASIGNAR PLANCHA
            // =========================================================

            this.pnlAsignarPlancha.BackColor = Color.White;
            this.pnlAsignarPlancha.Location = new Point(25, 130);
            this.pnlAsignarPlancha.Size = new Size(900, 230);
            this.pnlAsignarPlancha.Visible = false;

            this.lblAsignacion.Text = "No tienes una plancha asignada.";
            this.lblAsignacion.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblAsignacion.ForeColor = Color.FromArgb(0, 45, 120);
            this.lblAsignacion.Location = new Point(25, 20);
            this.lblAsignacion.Size = new Size(700, 30);

            this.cmbPlanchasDisponibles.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbPlanchasDisponibles.Font = new Font("Segoe UI", 11F);
            this.cmbPlanchasDisponibles.Location = new Point(25, 70);
            this.cmbPlanchasDisponibles.Size = new Size(300, 32);

            this.btnTomarPlancha.Text = "Tomar Plancha";
            this.btnTomarPlancha.BackColor = Color.FromArgb(20, 110, 220);
            this.btnTomarPlancha.ForeColor = Color.White;
            this.btnTomarPlancha.FlatStyle = FlatStyle.Flat;
            this.btnTomarPlancha.FlatAppearance.BorderSize = 0;
            this.btnTomarPlancha.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnTomarPlancha.Location = new Point(345, 68);
            this.btnTomarPlancha.Size = new Size(160, 36);
            this.btnTomarPlancha.Cursor = Cursors.Hand;
            this.btnTomarPlancha.Click += btnTomarPlancha_Click;

            this.txtNuevaPlancha.Font = new Font("Segoe UI", 11F);
            this.txtNuevaPlancha.Location = new Point(25, 140);
            this.txtNuevaPlancha.Size = new Size(300, 32);

            this.txtNuevaDescripcion.Font = new Font("Segoe UI", 11F);
            this.txtNuevaDescripcion.Location = new Point(345, 140);
            this.txtNuevaDescripcion.Size = new Size(300, 32);

            this.btnCrearMiPlancha.Text = "Crear mi Plancha";
            this.btnCrearMiPlancha.BackColor = Color.FromArgb(20, 170, 90);
            this.btnCrearMiPlancha.ForeColor = Color.White;
            this.btnCrearMiPlancha.FlatStyle = FlatStyle.Flat;
            this.btnCrearMiPlancha.FlatAppearance.BorderSize = 0;
            this.btnCrearMiPlancha.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCrearMiPlancha.Location = new Point(665, 138);
            this.btnCrearMiPlancha.Size = new Size(170, 36);
            this.btnCrearMiPlancha.Cursor = Cursors.Hand;
            this.btnCrearMiPlancha.Click += btnCrearMiPlancha_Click;

            this.pnlAsignarPlancha.Controls.Add(this.lblAsignacion);
            this.pnlAsignarPlancha.Controls.Add(this.cmbPlanchasDisponibles);
            this.pnlAsignarPlancha.Controls.Add(this.btnTomarPlancha);
            this.pnlAsignarPlancha.Controls.Add(this.txtNuevaPlancha);
            this.pnlAsignarPlancha.Controls.Add(this.txtNuevaDescripcion);
            this.pnlAsignarPlancha.Controls.Add(this.btnCrearMiPlancha);

            // =========================================================
            // PANEL PLANCHA
            // =========================================================

            this.pnlPlancha.BackColor = Color.White;
            this.pnlPlancha.Location = new Point(25, 130);
            this.pnlPlancha.Size = new Size(900, 145);

            this.lblNombrePlancha.Text = "Nombre de la Plancha";
            this.lblNombrePlancha.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblNombrePlancha.Location = new Point(25, 18);
            this.lblNombrePlancha.Size = new Size(220, 25);

            this.txtNombrePlancha.Font = new Font("Segoe UI", 11F);
            this.txtNombrePlancha.Location = new Point(25, 45);
            this.txtNombrePlancha.Size = new Size(350, 32);

            this.lblDescripcion.Text = "Descripción";
            this.lblDescripcion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblDescripcion.Location = new Point(400, 18);
            this.lblDescripcion.Size = new Size(150, 25);

            this.txtDescripcion.Font = new Font("Segoe UI", 11F);
            this.txtDescripcion.Location = new Point(400, 45);
            this.txtDescripcion.Size = new Size(320, 32);

            this.btnGuardarPlancha.Text = "Guardar Cambios";
            this.btnGuardarPlancha.BackColor = Color.FromArgb(20, 110, 220);
            this.btnGuardarPlancha.ForeColor = Color.White;
            this.btnGuardarPlancha.FlatStyle = FlatStyle.Flat;
            this.btnGuardarPlancha.FlatAppearance.BorderSize = 0;
            this.btnGuardarPlancha.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnGuardarPlancha.Location = new Point(25, 92);
            this.btnGuardarPlancha.Size = new Size(180, 38);
            this.btnGuardarPlancha.Cursor = Cursors.Hand;
            this.btnGuardarPlancha.Click += btnGuardarPlancha_Click;

            this.pnlPlancha.Controls.Add(this.lblNombrePlancha);
            this.pnlPlancha.Controls.Add(this.txtNombrePlancha);
            this.pnlPlancha.Controls.Add(this.lblDescripcion);
            this.pnlPlancha.Controls.Add(this.txtDescripcion);
            this.pnlPlancha.Controls.Add(this.btnGuardarPlancha);

            // =========================================================
            // PANEL MIEMBROS
            // =========================================================

            this.pnlMiembros.BackColor = Color.White;
            this.pnlMiembros.Location = new Point(25, 295);
            this.pnlMiembros.Size = new Size(900, 305);

            this.lblMiembros.Text = "Miembros de la Plancha";
            this.lblMiembros.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblMiembros.ForeColor = Color.FromArgb(0, 45, 120);
            this.lblMiembros.Location = new Point(25, 10);
            this.lblMiembros.Size = new Size(350, 35);

            this.lblPuesto.Text = "Cargo";
            this.lblPuesto.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblPuesto.Location = new Point(25, 55);

            this.cmbPuesto.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbPuesto.Font = new Font("Segoe UI", 10F);
            this.cmbPuesto.Location = new Point(25, 78);
            this.cmbPuesto.Size = new Size(145, 28);

            this.lblNombreMiembro.Text = "Nombre";
            this.lblNombreMiembro.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblNombreMiembro.Location = new Point(185, 55);

            this.txtNombreMiembro.Font = new Font("Segoe UI", 10F);
            this.txtNombreMiembro.Location = new Point(185, 78);
            this.txtNombreMiembro.Size = new Size(170, 28);

            this.lblMatricula.Text = "Matrícula";
            this.lblMatricula.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblMatricula.Location = new Point(370, 55);

            this.txtMatricula.Font = new Font("Segoe UI", 10F);
            this.txtMatricula.Location = new Point(370, 78);
            this.txtMatricula.Size = new Size(130, 28);

            this.lblDescripcionMiembro.Text = "Descripción";
            this.lblDescripcionMiembro.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblDescripcionMiembro.Location = new Point(515, 55);

            this.txtDescripcionMiembro.Font = new Font("Segoe UI", 10F);
            this.txtDescripcionMiembro.Location = new Point(515, 78);
            this.txtDescripcionMiembro.Size = new Size(170, 28);

            this.lblFoto.Text = "Foto";
            this.lblFoto.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblFoto.Location = new Point(25, 112);

            this.picFoto.Location = new Point(25, 135);
            this.picFoto.Size = new Size(70, 60);
            this.picFoto.BackColor = Color.White;
            this.picFoto.BorderStyle = BorderStyle.FixedSingle;
            this.picFoto.SizeMode = PictureBoxSizeMode.Zoom;

            this.lblFotoTexto.Text = "Sin foto";
            this.lblFotoTexto.Font = new Font("Segoe UI", 8F);
            this.lblFotoTexto.ForeColor = Color.Gray;
            this.lblFotoTexto.Location = new Point(105, 138);
            this.lblFotoTexto.Size = new Size(200, 20);

            this.btnSeleccionarFoto.Text = "Buscar Foto";
            this.btnSeleccionarFoto.BackColor = Color.FromArgb(0, 55, 150);
            this.btnSeleccionarFoto.ForeColor = Color.White;
            this.btnSeleccionarFoto.FlatStyle = FlatStyle.Flat;
            this.btnSeleccionarFoto.FlatAppearance.BorderSize = 0;
            this.btnSeleccionarFoto.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnSeleccionarFoto.Location = new Point(105, 165);
            this.btnSeleccionarFoto.Size = new Size(120, 30);
            this.btnSeleccionarFoto.Cursor = Cursors.Hand;
            this.btnSeleccionarFoto.Click += btnSeleccionarFoto_Click;

            this.btnAgregarMiembro.Text = "+ Agregar";
            this.btnAgregarMiembro.BackColor = Color.FromArgb(20, 110, 220);
            this.btnAgregarMiembro.ForeColor = Color.White;
            this.btnAgregarMiembro.FlatStyle = FlatStyle.Flat;
            this.btnAgregarMiembro.FlatAppearance.BorderSize = 0;
            this.btnAgregarMiembro.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnAgregarMiembro.Location = new Point(700, 55);
            this.btnAgregarMiembro.Size = new Size(150, 32);
            this.btnAgregarMiembro.Cursor = Cursors.Hand;
            this.btnAgregarMiembro.Click += btnAgregarMiembro_Click;

            this.btnActualizarMiembro.Text = "Actualizar";
            this.btnActualizarMiembro.BackColor = Color.FromArgb(0, 55, 150);
            this.btnActualizarMiembro.ForeColor = Color.White;
            this.btnActualizarMiembro.FlatStyle = FlatStyle.Flat;
            this.btnActualizarMiembro.FlatAppearance.BorderSize = 0;
            this.btnActualizarMiembro.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnActualizarMiembro.Location = new Point(700, 95);
            this.btnActualizarMiembro.Size = new Size(150, 32);
            this.btnActualizarMiembro.Cursor = Cursors.Hand;
            this.btnActualizarMiembro.Click += btnActualizarMiembro_Click;

            this.btnEliminarMiembro.Text = "Eliminar";
            this.btnEliminarMiembro.BackColor = Color.FromArgb(237, 35, 45);
            this.btnEliminarMiembro.ForeColor = Color.White;
            this.btnEliminarMiembro.FlatStyle = FlatStyle.Flat;
            this.btnEliminarMiembro.FlatAppearance.BorderSize = 0;
            this.btnEliminarMiembro.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnEliminarMiembro.Location = new Point(700, 135);
            this.btnEliminarMiembro.Size = new Size(150, 32);
            this.btnEliminarMiembro.Cursor = Cursors.Hand;
            this.btnEliminarMiembro.Click += btnEliminarMiembro_Click;

            this.dgvMiembros.Location = new Point(25, 205);
            this.dgvMiembros.Size = new Size(850, 85);
            this.dgvMiembros.AllowUserToAddRows = false;
            this.dgvMiembros.AllowUserToDeleteRows = false;
            this.dgvMiembros.ReadOnly = true;
            this.dgvMiembros.MultiSelect = false;
            this.dgvMiembros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvMiembros.BackgroundColor = Color.White;
            this.dgvMiembros.BorderStyle = BorderStyle.FixedSingle;
            this.dgvMiembros.RowHeadersVisible = false;

            this.pnlMiembros.Controls.Add(this.lblMiembros);
            this.pnlMiembros.Controls.Add(this.lblPuesto);
            this.pnlMiembros.Controls.Add(this.cmbPuesto);
            this.pnlMiembros.Controls.Add(this.lblNombreMiembro);
            this.pnlMiembros.Controls.Add(this.txtNombreMiembro);
            this.pnlMiembros.Controls.Add(this.lblMatricula);
            this.pnlMiembros.Controls.Add(this.txtMatricula);
            this.pnlMiembros.Controls.Add(this.lblDescripcionMiembro);
            this.pnlMiembros.Controls.Add(this.txtDescripcionMiembro);
            this.pnlMiembros.Controls.Add(this.lblFoto);
            this.pnlMiembros.Controls.Add(this.picFoto);
            this.pnlMiembros.Controls.Add(this.lblFotoTexto);
            this.pnlMiembros.Controls.Add(this.btnSeleccionarFoto);
            this.pnlMiembros.Controls.Add(this.btnAgregarMiembro);
            this.pnlMiembros.Controls.Add(this.btnActualizarMiembro);
            this.pnlMiembros.Controls.Add(this.btnEliminarMiembro);
            this.pnlMiembros.Controls.Add(this.dgvMiembros);

            // =========================================================
            // ADD CONTROLS
            // =========================================================

            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlAsignarPlancha);
            this.Controls.Add(this.pnlPlancha);
            this.Controls.Add(this.pnlMiembros);

            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMiembros)).EndInit();

            this.ResumeLayout(false);
        }
    }
}