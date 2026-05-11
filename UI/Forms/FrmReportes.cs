using SistemaVotacion.Models;
using SistemaVotacion.Reports;
using SistemaVotacion.UI.Reportes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    public partial class FrmReportes : Form
    {
        private readonly int _usuarioId;

        public FrmReportes(int usuarioId)
        {
            InitializeComponent();
            _usuarioId = usuarioId;
        }


        // ─────────────────────────────────────────
        // BOTONES RDLC (PLACEHOLDER)
        // ─────────────────────────────────────────

        private void btnVerGeneral_Click(object sender, EventArgs e)
        {
            AbrirReporte(
                "Reporte General de Votos",
                "Reportes/ReporteGeneral.rdlc",
                "ReporteGeneral"
            );
        }

        private void btnPdfGeneral_Click(object sender, EventArgs e)
        {
            DescargarReporte(
                "Reporte General de Votos",
                "Reportes/ReporteGeneral.rdlc",
                "ReporteGeneral"
            );
        }

        private void btnVerPadron_Click(object sender, EventArgs e)
        {
            AbrirReporte(
                "Reporte de Padrón Electoral",
                "Reportes/ReportePadron.rdlc",
                "ReportePadron"
            );
        }

        private void btnPdfPadron_Click(object sender, EventArgs e)
        {
            DescargarReporte(
                "Reporte de Padrón Electoral",
                "Reportes/ReportePadron.rdlc",
                "ReportePadron"
            );
        }

        private void btnVerGanador_Click(object sender, EventArgs e)
        {
            AbrirReporte(
                "Reporte de Plancha Ganadora",
                "Reportes/ReporteGanador.rdlc",
                "ReporteGanador"
            );
        }

        private void btnPdfGanador_Click(object sender, EventArgs e)
        {
            DescargarReporte(
                "Reporte de Plancha Ganadora",
                "Reportes/ReporteGanador.rdlc",
                "ReporteGanador"
            );
        }

        // ─────────────────────────────────────────
        // NAVEGACIÓN REAL A FORMULARIOS
        // ─────────────────────────────────────────

        private void btnVerGeneral_Click_1(object sender, EventArgs e)
        {
            try
            {
                // TODO: Reemplaza estos valores con los datos reales de tu DAL
                var estadisticas = ObtenerEstadisticas();
                var votos = ObtenerVotos();
                string titulo = "Elecciones";

                FrmReporteGeneralVotos frm = new FrmReporteGeneralVotos(
                    estadisticas,
                    votos,
                    titulo,
                    _usuarioId);

                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerPadron_Click_1(object sender, EventArgs e)
        {
            try
            {
                // TODO: Reemplaza con tu lista real de planchas desde el DAL
                var planchas = ObtenerPlanchas();

                FrmReporteIntegrantesPlancha frm = new FrmReporteIntegrantesPlancha(
                    planchas,
                    _usuarioId);

                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerGanador_Click_1(object sender, EventArgs e)
        {
            try
            {
                // TODO: Reemplaza con los datos reales de tu DAL
                var estadisticas = ObtenerEstadisticas();
                string titulo = "Elecciones";

                FrmReportePlanchaGanadora frm = new FrmReportePlanchaGanadora(
                    estadisticas,
                    titulo,
                    _usuarioId);

                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────
        // MÉTODOS PLACEHOLDER
        // ─────────────────────────────────────────

        private void AbrirReporte(string titulo, string rutaRdlc, string dataSetName)
        {
            MessageBox.Show(
                $"Aquí se abrirá el ReportViewer:\n\n{titulo}\n\nRDLC: {rutaRdlc}\nDataset: {dataSetName}",
                "Reporte pendiente",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void DescargarReporte(string titulo, string rutaRdlc, string dataSetName)
        {
            MessageBox.Show(
                $"Aquí se descargará el PDF:\n\n{titulo}\n\nRDLC: {rutaRdlc}\nDataset: {dataSetName}",
                "PDF pendiente",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
        // ─────────────────────────────────────────
        // MOCKS — reemplaza con tu DAL real
        // ─────────────────────────────────────────

        private EstadisticasVotacion ObtenerEstadisticas()
        {
            // TODO: return TuDAL.GetEstadisticas();
            return new EstadisticasVotacion();
        }

        private IEnumerable<VotoDetalle> ObtenerVotos()
        {
            // TODO: return TuDAL.GetVotos();
            return new List<VotoDetalle>();
        }

        private IEnumerable<Plancha> ObtenerPlanchas()
        {
            // TODO: return TuDAL.GetPlanchas();
            return new List<Plancha>();
        }
    }
}