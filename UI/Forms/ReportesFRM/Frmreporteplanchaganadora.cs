using System;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using SistemaVotacion.Models;

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

            Text = $"Reporte – Plancha Ganadora | {_tituloVotacion}";
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

                reportViewer.LocalReport.DataSources.Clear();

                // ⚠️ Ajusta según tu RDLC real
                var dataSource = new ReportDataSource(
                    "DataSetPlanchaGanadora",
                    new[] { _estadisticas }
                );

                reportViewer.LocalReport.DataSources.Add(dataSource);
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al generar el reporte:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            // Regresa al formulario anterior (Reportes)
            this.Close();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarReporte();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}