using SistemaVotacion.BLL;
using SistemaVotacion.Models;
using SistemaVotacion.Utils;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    public partial class FrmAgregarMiembro : Form
    {
        private readonly int _planchaId;
        private readonly PlanchaService _svc = new();
        private readonly UsuarioService _usrSvc = new();

        public FrmAgregarMiembro(int planchaId)
        {
            _planchaId = planchaId;

            InitializeComponent();

            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            var usuarios = _usrSvc.GetAll()
                .Where(u => u.RolNombre != "Admin")
                .ToList();

            cmbUsuario.DataSource = usuarios;
            cmbUsuario.DisplayMember = "NombreCompleto";
            cmbUsuario.ValueMember = "UsuarioId";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbUsuario.SelectedItem is not Usuario u)
            {
                Helpers.MsgError("Seleccione un usuario.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPuesto.Text))
            {
                Helpers.MsgError("Ingrese el puesto.");
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}