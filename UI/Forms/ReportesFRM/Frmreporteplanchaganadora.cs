using System;
using System.Windows.Forms;
using SistemaVotacion.Models;
using SistemaVotacion.Reports;

namespace SistemaVotacion.UI.Reportes
{
    public partial class FrmReportePlanchaGanadora : Form
    {
        private readonly EstadisticasVotacion _estadisticas;
        private readonly string _tituloVotacion;

        public FrmReportePlanchaGanadora(EstadisticasVotacion estadisticas, string tituloVotacion)
        {
            _estadisticas = estadisticas ?? throw new ArgumentNullException(nameof(estadisticas));
            _tituloVotacion = tituloVotacion ?? "Votación";

            InitializeComponent();
            Text = "Reporte – Plancha Ganadora | " + _tituloVotacion;
        }

        private void FrmReportePlanchaGanadora_Load(object sender, EventArgs e)
        {
            CargarReporte();
        }

        private void CargarReporte()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (_estadisticas.PorPlancha == null || _estadisticas.PorPlancha.Count == 0)
                {
                    MessageBox.Show(
                        "No hay votos registrados aún para determinar la plancha ganadora.",
                        "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                ReportHelper.CargarReportePlanchaGanadora(
                    reportViewer,
                    _estadisticas,
                    _tituloVotacion);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al generar el reporte:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e) => CargarReporte();

        private void btnVolver_Click(object sender, EventArgs e) => Close();

        private void btnCerrar_Click(object sender, EventArgs e) => Close();
    }
}
