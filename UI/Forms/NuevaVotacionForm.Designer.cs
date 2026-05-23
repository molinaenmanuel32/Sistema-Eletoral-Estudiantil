using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    partial class NuevaVotacionForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitulo;
        private TextBox txtTitulo;

        private Label lblDescripcion;
        private TextBox txtDescripcion;

        private Label lblInicio;
        private DateTimePicker dtInicio;

        private Label lblFin;
        private DateTimePicker dtFin;

        private Button btnCrear;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblInicio = new System.Windows.Forms.Label();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFin = new System.Windows.Forms.Label();
            this.dtFin = new System.Windows.Forms.DateTimePicker();
            this.btnCrear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FORM
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 35);
            this.ClientSize = new System.Drawing.Size(520, 360);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NuevaVotacionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nueva Votación";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTitulo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(55, 23);
            this.lblTitulo.Text = "Título";
            // 
            // txtTitulo
            // 
            this.txtTitulo.BackColor = System.Drawing.Color.FromArgb(28, 28, 48);
            this.txtTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTitulo.ForeColor = System.Drawing.Color.White;
            this.txtTitulo.Location = new System.Drawing.Point(20, 50);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(470, 30);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDescripcion.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblDescripcion.Location = new System.Drawing.Point(20, 95);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(99, 23);
            this.lblDescripcion.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.Color.FromArgb(28, 28, 48);
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.ForeColor = System.Drawing.Color.White;
            this.txtDescripcion.Location = new System.Drawing.Point(20, 125);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(470, 70);
            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInicio.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblInicio.Location = new System.Drawing.Point(20, 220);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(98, 23);
            this.lblInicio.Text = "Fecha Inicio";
            // 
            // dtInicio
            // 
            this.dtInicio.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtInicio.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInicio.Location = new System.Drawing.Point(20, 250);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(220, 30);
            // 
            // lblFin
            // 
            this.lblFin.AutoSize = true;
            this.lblFin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFin.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblFin.Location = new System.Drawing.Point(270, 220);
            this.lblFin.Name = "lblFin";
            this.lblFin.Size = new System.Drawing.Size(77, 23);
            this.lblFin.Text = "Fecha Fin";
            // 
            // dtFin
            // 
            this.dtFin.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFin.Location = new System.Drawing.Point(270, 250);
            this.dtFin.Name = "dtFin";
            this.dtFin.Size = new System.Drawing.Size(220, 30);
            // 
            // btnCrear
            // 
            this.btnCrear.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnCrear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrear.FlatAppearance.BorderSize = 0;
            this.btnCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCrear.ForeColor = System.Drawing.Color.White;
            this.btnCrear.Location = new System.Drawing.Point(310, 300);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(180, 45);
            this.btnCrear.Text = "Crear Votación";
            this.btnCrear.UseVisualStyleBackColor = false;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // CONTROLES
            // 
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.txtTitulo);

            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtDescripcion);

            this.Controls.Add(this.lblInicio);
            this.Controls.Add(this.dtInicio);

            this.Controls.Add(this.lblFin);
            this.Controls.Add(this.dtFin);

            this.Controls.Add(this.btnCrear);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}