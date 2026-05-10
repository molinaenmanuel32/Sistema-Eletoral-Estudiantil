using System;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    public partial class FrmReportesPartido : Form
    {
        private readonly int _planchaId;

        public FrmReportesPartido(int planchaId)
        {
            InitializeComponent();
            _planchaId = planchaId;
            lblInfo.Text = "Reportes disponibles para la plancha ID: " + _planchaId;
        }
    }
}