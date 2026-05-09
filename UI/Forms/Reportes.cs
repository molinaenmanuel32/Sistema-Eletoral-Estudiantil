using SistemaVotacion.Utils;
using System;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();
        }

        private void btnVerGeneral_Click(object sender, EventArgs e)
        {
            AbrirReporte("Reporte General de Votos", "Reportes/ReporteGeneral.rdlc", "ReporteGeneral");
        }

        private void btnPdfGeneral_Click(object sender, EventArgs e)
        {
            DescargarReporte("Reporte General de Votos", "Reportes/ReporteGeneral.rdlc", "ReporteGeneral");
        }

        private void btnVerPadron_Click(object sender, EventArgs e)
        {
            AbrirReporte("Reporte de Padrón Electoral", "Reportes/ReportePadron.rdlc", "ReportePadron");
        }

        private void btnPdfPadron_Click(object sender, EventArgs e)
        {
            DescargarReporte("Reporte de Padrón Electoral", "Reportes/ReportePadron.rdlc", "ReportePadron");
        }

        private void btnVerGanador_Click(object sender, EventArgs e)
        {
            AbrirReporte("Reporte de Plancha Ganadora", "Reportes/ReporteGanador.rdlc", "ReporteGanador");
        }

        private void btnPdfGanador_Click(object sender, EventArgs e)
        {
            DescargarReporte("Reporte de Plancha Ganadora", "Reportes/ReporteGanador.rdlc", "ReporteGanador");
        }

        private void AbrirReporte(string titulo, string rutaRdlc, string dataSetName)
        {
            MessageBox.Show(
                $"Aquí se abrirá el ReportViewer para:\n\n{titulo}\n\nRDLC: {rutaRdlc}\nDataSet: {dataSetName}",
                "Reporte pendiente",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // Cuando tu compañero tenga los RDLC y datasets, se activará algo así:
            // var datos = servicio.ObtenerDatosDelReporte();
            // var frm = new FrmReporteViewer(titulo, rutaRdlc, dataSetName, datos);
            // frm.ShowDialog();
        }

        private void DescargarReporte(string titulo, string rutaRdlc, string dataSetName)
        {
            MessageBox.Show(
                $"Aquí se descargará el PDF de:\n\n{titulo}\n\nRDLC: {rutaRdlc}\nDataSet: {dataSetName}",
                "PDF pendiente",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // Cuando el ReportViewer esté conectado:
            // var datos = servicio.ObtenerDatosDelReporte();
            // var frm = new FrmReporteViewer(titulo, rutaRdlc, dataSetName, datos);
            // frm.ExportarPdfDirecto();
        }
    }
}