using System;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    public partial class FrmDashboardPartido : Form
    {
        private readonly int _planchaId;

        public FrmDashboardPartido(int planchaId)
        {
            InitializeComponent();
            _planchaId = planchaId;
            lblInfo.Text = "Panel exclusivo para la plancha ID: " + _planchaId;
        }
    }
}