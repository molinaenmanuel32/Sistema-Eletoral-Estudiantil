using System;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    public partial class FrmMenuAdminPartido : Form
    {
        private readonly string _usuario;
        private readonly int _usuarioId;

        public FrmMenuAdminPartido(string usuario, int usuarioId)
        {
            InitializeComponent();

            _usuario = usuario;
            _usuarioId = usuarioId;

            lblUser.Text = usuario + "\nAdminPartido";
            AbrirFormulario(new FrmDashboardPartido(_usuarioId));
        }

        private void AbrirFormulario(Form form)
        {
            pnlContent.Controls.Clear();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            pnlContent.Controls.Add(form);
            form.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmDashboardPartido(_usuarioId));
        }

        private void btnMiPlancha_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmEditarMiPlancha(_usuarioId));
        }

        private void btnMiembros_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmEditarMiPlancha(_usuarioId));
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmReportesPartido(_usuarioId));
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Hide();
            new FrmL().Show();
        }
    }
}