using Dapper;
using SistemaVotacion.DAL;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    public partial class FrmEditarMiPlancha : Form
    {
        private readonly int _usuarioId;
        private int _planchaId;

        public FrmEditarMiPlancha(int usuarioId)
        {
            InitializeComponent();

            _usuarioId = usuarioId;
            CargarPlanchaDelUsuario();
        }

        private void CargarPlanchaDelUsuario()
        {
            using var con = DbConnection.GetConnection();

            int? planchaId = con.QueryFirstOrDefault<int?>(
                "SELECT PlanchaId FROM Usuarios WHERE UsuarioId = @id",
                new { id = _usuarioId });

            _planchaId = planchaId ?? 0;

            if (_planchaId <= 0)
            {
                MostrarAsignacionPlancha();
            }
            else
            {
                pnlAsignarPlancha.Visible = false;
                pnlPlancha.Visible = true;
                pnlMiembros.Visible = true;

                CargarPlancha();
                CargarMiembros();
            }
        }

        private void MostrarAsignacionPlancha()
        {
            using var con = DbConnection.GetConnection();

            var libres = con.Query(
                @"SELECT PlanchaId, Nombre
                  FROM Planchas p
                  WHERE NOT EXISTS (
                      SELECT 1
                      FROM Usuarios u
                      WHERE u.PlanchaId = p.PlanchaId
                  )").ToList();

            pnlAsignarPlancha.Visible = true;
            pnlPlancha.Visible = false;
            pnlMiembros.Visible = false;

            if (libres.Count > 0)
            {
                cmbPlanchasDisponibles.Enabled = true;
                btnTomarPlancha.Enabled = true;

                cmbPlanchasDisponibles.DataSource = libres;
                cmbPlanchasDisponibles.DisplayMember = "Nombre";
                cmbPlanchasDisponibles.ValueMember = "PlanchaId";

                lblAsignacion.Text = "No tienes una plancha asignada. Elige una disponible o crea la tuya.";
            }
            else
            {
                cmbPlanchasDisponibles.DataSource = null;
                cmbPlanchasDisponibles.Enabled = false;
                btnTomarPlancha.Enabled = false;

                lblAsignacion.Text = "No hay planchas libres. Puedes crear tu propia plancha.";
            }
        }

        private void btnTomarPlancha_Click(object sender, EventArgs e)
        {
            if (cmbPlanchasDisponibles.SelectedValue == null)
            {
                MessageBox.Show("Selecciona una plancha.");
                return;
            }

            int planchaSeleccionada = Convert.ToInt32(cmbPlanchasDisponibles.SelectedValue);

            using var con = DbConnection.GetConnection();

            con.Execute(
                @"UPDATE Usuarios
                  SET PlanchaId = @planchaId
                  WHERE UsuarioId = @usuarioId
                  AND (PlanchaId IS NULL OR PlanchaId = 0)",
                new
                {
                    planchaId = planchaSeleccionada,
                    usuarioId = _usuarioId
                });

            MessageBox.Show("Plancha asignada correctamente.");

            CargarPlanchaDelUsuario();
        }

        private void btnCrearMiPlancha_Click(object sender, EventArgs e)
        {
            if (txtNuevaPlancha.Text.Trim() == "")
            {
                MessageBox.Show("Escribe el nombre de la plancha.");
                return;
            }

            using var con = DbConnection.GetConnection();

            int nuevaPlanchaId = con.ExecuteScalar<int>(
                @"INSERT INTO Planchas (Nombre, Descripcion, Activa)
                  OUTPUT INSERTED.PlanchaId
                  VALUES (@nombre, @descripcion, 1)",
                new
                {
                    nombre = txtNuevaPlancha.Text.Trim(),
                    descripcion = txtNuevaDescripcion.Text.Trim()
                });

            con.Execute(
                @"UPDATE Usuarios
                  SET PlanchaId = @planchaId
                  WHERE UsuarioId = @usuarioId
                  AND (PlanchaId IS NULL OR PlanchaId = 0)",
                new
                {
                    planchaId = nuevaPlanchaId,
                    usuarioId = _usuarioId
                });

            MessageBox.Show("Tu plancha fue creada correctamente.");

            CargarPlanchaDelUsuario();
        }

        private void CargarPlancha()
        {
            using var con = DbConnection.GetConnection();

            var plancha = con.QueryFirstOrDefault(
                "SELECT * FROM Planchas WHERE PlanchaId = @id",
                new { id = _planchaId });

            if (plancha == null)
            {
                MessageBox.Show("No se encontró la plancha asignada.");
                return;
            }

            txtNombrePlancha.Text = plancha.Nombre;
            txtDescripcion.Text = plancha.Descripcion;
        }

        private void CargarMiembros()
        {
            using var con = DbConnection.GetConnection();

            var miembros = con.Query(
                @"SELECT 
                    MiembroId,
                    PlanchaId,
                    Puesto,
                    Nombre,
                    Matricula,
                    Descripcion
                  FROM MiembrosPlanchas
                  WHERE PlanchaId = @id",
                new { id = _planchaId });

            dgvMiembros.DataSource = miembros;
        }

        private void btnGuardarPlancha_Click(object sender, EventArgs e)
        {
            if (txtNombrePlancha.Text.Trim() == "")
            {
                MessageBox.Show("Escribe el nombre de la plancha.");
                return;
            }

            using var con = DbConnection.GetConnection();

            con.Execute(
                @"UPDATE Planchas
                  SET Nombre = @nombre,
                      Descripcion = @descripcion
                  WHERE PlanchaId = @id",
                new
                {
                    nombre = txtNombrePlancha.Text.Trim(),
                    descripcion = txtDescripcion.Text.Trim(),
                    id = _planchaId
                });

            MessageBox.Show("Plancha actualizada correctamente.");
            CargarPlancha();
        }

        private void btnAgregarMiembro_Click(object sender, EventArgs e)
        {
            if (txtNombreMiembro.Text.Trim() == "" ||
                txtMatricula.Text.Trim() == "")
            {
                MessageBox.Show("Completa nombre y matrícula.");
                return;
            }

            using var con = DbConnection.GetConnection();

            con.Execute(
                @"INSERT INTO MiembrosPlanchas
        (
            UsuarioId,
            PlanchaId,
            Puesto,
            Nombre,
            Matricula,
            Descripcion
        )
        VALUES
        (
            @usuarioId,
            @planchaId,
            @puesto,
            @nombre,
            @matricula,
            @descripcion
        )",
                new
                {
                    usuarioId = _usuarioId,
                    planchaId = _planchaId,
                    puesto = txtPuesto.Text.Trim(),
                    nombre = txtNombreMiembro.Text.Trim(),
                    matricula = txtMatricula.Text.Trim(),
                    descripcion = txtDescripcionMiembro.Text.Trim()
                });

            MessageBox.Show("Miembro agregado correctamente.");

            LimpiarMiembro();
            CargarMiembros();
        }

        private void btnEliminarMiembro_Click(object sender, EventArgs e)
        {
            if (dgvMiembros.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un miembro.");
                return;
            }

            int miembroId = Convert.ToInt32(dgvMiembros.CurrentRow.Cells["MiembroId"].Value);

            DialogResult r = MessageBox.Show(
                "¿Seguro que deseas eliminar este miembro?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r != DialogResult.Yes)
                return;

            using var con = DbConnection.GetConnection();

            con.Execute(
                @"DELETE FROM MiembrosPlanchas
                  WHERE MiembroId = @id
                  AND PlanchaId = @planchaId",
                new
                {
                    id = miembroId,
                    planchaId = _planchaId
                });

            MessageBox.Show("Miembro eliminado correctamente.");
            CargarMiembros();
        }

        private void LimpiarMiembro()
        {
            txtPuesto.Clear();
            txtNombreMiembro.Clear();
            txtMatricula.Clear();
            txtDescripcionMiembro.Clear();
            txtNombreMiembro.Focus();
        }
    }
}