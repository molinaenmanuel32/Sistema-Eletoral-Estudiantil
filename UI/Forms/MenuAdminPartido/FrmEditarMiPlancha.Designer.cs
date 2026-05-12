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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.pnlAsignarPlancha = new System.Windows.Forms.Panel();
            this.pnlPlancha = new System.Windows.Forms.Panel();
            this.pnlMiembros = new System.Windows.Forms.Panel();
            this.lblAsignacion = new System.Windows.Forms.Label();
            this.cmbPlanchasDisponibles = new System.Windows.Forms.ComboBox();
            this.btnTomarPlancha = new System.Windows.Forms.Button();
            this.txtNuevaPlancha = new System.Windows.Forms.TextBox();
            this.txtNuevaDescripcion = new System.Windows.Forms.TextBox();
            this.btnCrearMiPlancha = new System.Windows.Forms.Button();
            this.lblNombrePlancha = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtNombrePlancha = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnGuardarPlancha = new System.Windows.Forms.Button();
            this.lblMiembros = new System.Windows.Forms.Label();
            this.lblPuesto = new System.Windows.Forms.Label();
            this.lblNombreMiembro = new System.Windows.Forms.Label();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.lblDescripcionMiembro = new System.Windows.Forms.Label();
            this.lblFotoTexto = new System.Windows.Forms.Label();
            this.cmbPuesto = new System.Windows.Forms.ComboBox();
            this.txtNombreMiembro = new System.Windows.Forms.TextBox();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.txtDescripcionMiembro = new System.Windows.Forms.TextBox();
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.btnSeleccionarFoto = new System.Windows.Forms.Button();
            this.btnAgregarMiembro = new System.Windows.Forms.Button();
            this.btnActualizarMiembro = new System.Windows.Forms.Button();
            this.btnEliminarMiembro = new System.Windows.Forms.Button();
            this.dgvMiembros = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMiembros)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Location = new System.Drawing.Point(25, 20);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(900, 90);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            this.lblTitulo.Location = new System.Drawing.Point(21, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(251, 55);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Mi Plancha";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitulo.Location = new System.Drawing.Point(25, 55);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(100, 23);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Edita tu plancha y administra sus miembros.";
            // 
            // pnlAsignarPlancha
            // 
            this.pnlAsignarPlancha.Location = new System.Drawing.Point(0, 0);
            this.pnlAsignarPlancha.Name = "pnlAsignarPlancha";
            this.pnlAsignarPlancha.Size = new System.Drawing.Size(200, 100);
            this.pnlAsignarPlancha.TabIndex = 1;
            // 
            // pnlPlancha
            // 
            this.pnlPlancha.Location = new System.Drawing.Point(0, 0);
            this.pnlPlancha.Name = "pnlPlancha";
            this.pnlPlancha.Size = new System.Drawing.Size(200, 100);
            this.pnlPlancha.TabIndex = 2;
            // 
            // pnlMiembros
            // 
            this.pnlMiembros.Location = new System.Drawing.Point(0, 0);
            this.pnlMiembros.Name = "pnlMiembros";
            this.pnlMiembros.Size = new System.Drawing.Size(200, 100);
            this.pnlMiembros.TabIndex = 3;
            // 
            // lblAsignacion
            // 
            this.lblAsignacion.Location = new System.Drawing.Point(0, 0);
            this.lblAsignacion.Name = "lblAsignacion";
            this.lblAsignacion.Size = new System.Drawing.Size(100, 23);
            this.lblAsignacion.TabIndex = 0;
            // 
            // cmbPlanchasDisponibles
            // 
            this.cmbPlanchasDisponibles.Location = new System.Drawing.Point(0, 0);
            this.cmbPlanchasDisponibles.Name = "cmbPlanchasDisponibles";
            this.cmbPlanchasDisponibles.Size = new System.Drawing.Size(121, 24);
            this.cmbPlanchasDisponibles.TabIndex = 0;
            // 
            // btnTomarPlancha
            // 
            this.btnTomarPlancha.Location = new System.Drawing.Point(0, 0);
            this.btnTomarPlancha.Name = "btnTomarPlancha";
            this.btnTomarPlancha.Size = new System.Drawing.Size(75, 23);
            this.btnTomarPlancha.TabIndex = 0;
            // 
            // txtNuevaPlancha
            // 
            this.txtNuevaPlancha.Location = new System.Drawing.Point(0, 0);
            this.txtNuevaPlancha.Name = "txtNuevaPlancha";
            this.txtNuevaPlancha.Size = new System.Drawing.Size(100, 22);
            this.txtNuevaPlancha.TabIndex = 0;
            // 
            // txtNuevaDescripcion
            // 
            this.txtNuevaDescripcion.Location = new System.Drawing.Point(0, 0);
            this.txtNuevaDescripcion.Name = "txtNuevaDescripcion";
            this.txtNuevaDescripcion.Size = new System.Drawing.Size(100, 22);
            this.txtNuevaDescripcion.TabIndex = 0;
            // 
            // btnCrearMiPlancha
            // 
            this.btnCrearMiPlancha.Location = new System.Drawing.Point(0, 0);
            this.btnCrearMiPlancha.Name = "btnCrearMiPlancha";
            this.btnCrearMiPlancha.Size = new System.Drawing.Size(75, 23);
            this.btnCrearMiPlancha.TabIndex = 0;
            // 
            // lblNombrePlancha
            // 
            this.lblNombrePlancha.Location = new System.Drawing.Point(0, 0);
            this.lblNombrePlancha.Name = "lblNombrePlancha";
            this.lblNombrePlancha.Size = new System.Drawing.Size(100, 23);
            this.lblNombrePlancha.TabIndex = 0;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(0, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(100, 23);
            this.lblDescripcion.TabIndex = 0;
            // 
            // txtNombrePlancha
            // 
            this.txtNombrePlancha.Location = new System.Drawing.Point(0, 0);
            this.txtNombrePlancha.Name = "txtNombrePlancha";
            this.txtNombrePlancha.Size = new System.Drawing.Size(100, 22);
            this.txtNombrePlancha.TabIndex = 0;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(0, 0);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(100, 22);
            this.txtDescripcion.TabIndex = 0;
            // 
            // btnGuardarPlancha
            // 
            this.btnGuardarPlancha.Location = new System.Drawing.Point(0, 0);
            this.btnGuardarPlancha.Name = "btnGuardarPlancha";
            this.btnGuardarPlancha.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarPlancha.TabIndex = 0;
            // 
            // lblMiembros
            // 
            this.lblMiembros.Location = new System.Drawing.Point(0, 0);
            this.lblMiembros.Name = "lblMiembros";
            this.lblMiembros.Size = new System.Drawing.Size(100, 23);
            this.lblMiembros.TabIndex = 0;
            // 
            // lblPuesto
            // 
            this.lblPuesto.Location = new System.Drawing.Point(0, 0);
            this.lblPuesto.Name = "lblPuesto";
            this.lblPuesto.Size = new System.Drawing.Size(100, 23);
            this.lblPuesto.TabIndex = 0;
            // 
            // lblNombreMiembro
            // 
            this.lblNombreMiembro.Location = new System.Drawing.Point(0, 0);
            this.lblNombreMiembro.Name = "lblNombreMiembro";
            this.lblNombreMiembro.Size = new System.Drawing.Size(100, 23);
            this.lblNombreMiembro.TabIndex = 0;
            // 
            // lblMatricula
            // 
            this.lblMatricula.Location = new System.Drawing.Point(0, 0);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(100, 23);
            this.lblMatricula.TabIndex = 0;
            // 
            // lblDescripcionMiembro
            // 
            this.lblDescripcionMiembro.Location = new System.Drawing.Point(0, 0);
            this.lblDescripcionMiembro.Name = "lblDescripcionMiembro";
            this.lblDescripcionMiembro.Size = new System.Drawing.Size(100, 23);
            this.lblDescripcionMiembro.TabIndex = 0;
            // 
            // lblFotoTexto
            // 
            this.lblFotoTexto.Location = new System.Drawing.Point(0, 0);
            this.lblFotoTexto.Name = "lblFotoTexto";
            this.lblFotoTexto.Size = new System.Drawing.Size(100, 23);
            this.lblFotoTexto.TabIndex = 0;
            // 
            // cmbPuesto
            // 
            this.cmbPuesto.Location = new System.Drawing.Point(0, 0);
            this.cmbPuesto.Name = "cmbPuesto";
            this.cmbPuesto.Size = new System.Drawing.Size(121, 24);
            this.cmbPuesto.TabIndex = 0;
            // 
            // txtNombreMiembro
            // 
            this.txtNombreMiembro.Location = new System.Drawing.Point(0, 0);
            this.txtNombreMiembro.Name = "txtNombreMiembro";
            this.txtNombreMiembro.Size = new System.Drawing.Size(100, 22);
            this.txtNombreMiembro.TabIndex = 0;
            // 
            // txtMatricula
            // 
            this.txtMatricula.Location = new System.Drawing.Point(0, 0);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(100, 22);
            this.txtMatricula.TabIndex = 0;
            // 
            // txtDescripcionMiembro
            // 
            this.txtDescripcionMiembro.Location = new System.Drawing.Point(0, 0);
            this.txtDescripcionMiembro.Name = "txtDescripcionMiembro";
            this.txtDescripcionMiembro.Size = new System.Drawing.Size(100, 22);
            this.txtDescripcionMiembro.TabIndex = 0;
            // 
            // picFoto
            // 
            this.picFoto.Location = new System.Drawing.Point(0, 0);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(100, 50);
            this.picFoto.TabIndex = 0;
            this.picFoto.TabStop = false;
            // 
            // btnSeleccionarFoto
            // 
            this.btnSeleccionarFoto.Location = new System.Drawing.Point(0, 0);
            this.btnSeleccionarFoto.Name = "btnSeleccionarFoto";
            this.btnSeleccionarFoto.Size = new System.Drawing.Size(75, 23);
            this.btnSeleccionarFoto.TabIndex = 0;
            // 
            // btnAgregarMiembro
            // 
            this.btnAgregarMiembro.Location = new System.Drawing.Point(0, 0);
            this.btnAgregarMiembro.Name = "btnAgregarMiembro";
            this.btnAgregarMiembro.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarMiembro.TabIndex = 0;
            // 
            // btnActualizarMiembro
            // 
            this.btnActualizarMiembro.Location = new System.Drawing.Point(0, 0);
            this.btnActualizarMiembro.Name = "btnActualizarMiembro";
            this.btnActualizarMiembro.Size = new System.Drawing.Size(75, 23);
            this.btnActualizarMiembro.TabIndex = 0;
            // 
            // btnEliminarMiembro
            // 
            this.btnEliminarMiembro.Location = new System.Drawing.Point(0, 0);
            this.btnEliminarMiembro.Name = "btnEliminarMiembro";
            this.btnEliminarMiembro.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarMiembro.TabIndex = 0;
            // 
            // dgvMiembros
            // 
            this.dgvMiembros.ColumnHeadersHeight = 29;
            this.dgvMiembros.Location = new System.Drawing.Point(0, 0);
            this.dgvMiembros.Name = "dgvMiembros";
            this.dgvMiembros.RowHeadersWidth = 51;
            this.dgvMiembros.Size = new System.Drawing.Size(240, 150);
            this.dgvMiembros.TabIndex = 0;
            // 
            // FrmEditarMiPlancha
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(950, 620);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlAsignarPlancha);
            this.Controls.Add(this.pnlPlancha);
            this.Controls.Add(this.pnlMiembros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmEditarMiPlancha";
            this.Text = "Mi Plancha";
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMiembros)).EndInit();
            this.ResumeLayout(false);

        }
    }
}