using SistemaVotacion.Models;
using System;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Reportes
{
    public partial class FrmReportePlanchaGanadora : Form
    {
        private readonly EstadisticasVotacion _estadisticas;
        private readonly string _tituloVotacion;
        private readonly int _usuarioId;

        public FrmReportePlanchaGanadora(
            EstadisticasVotacion estadisticas,
            string tituloVotacion,
            int usuarioId)
        {
            _estadisticas   = estadisticas ?? throw new ArgumentNullException(nameof(estadisticas));
            _tituloVotacion = tituloVotacion ?? "Votación";
            _usuarioId      = usuarioId;

            InitializeComponent();
            Text = "Reporte – Plancha Ganadora | " + _tituloVotacion;
        }

        private void FrmReportePlanchaGanadora_Load(object sender, EventArgs e) => CargarReporte();

        private void CargarReporte()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                // ReportViewer integration goes here
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e) => CargarReporte();

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            var menu = new SistemaVotacion.UI.Forms.Reportes(_usuarioId);
            menu.Show();
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e) => Close();
    }
}
