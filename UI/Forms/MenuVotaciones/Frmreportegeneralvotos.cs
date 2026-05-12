using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SistemaVotacion.Models;
using SistemaVotacion.BLL;

namespace SistemaVotacion.UI.Reportes
{
    public partial class FrmReporteGeneralVotos : Form
    {
        private readonly EstadisticasVotacion _estadisticas;
        private readonly string _tituloVotacion;
        private readonly int _usuarioId;

        public FrmReporteGeneralVotos(
            EstadisticasVotacion estadisticas,
            string tituloVotacion,
            int usuarioId)
        {
            _estadisticas   = estadisticas ?? throw new ArgumentNullException(nameof(estadisticas));
            _tituloVotacion = tituloVotacion ?? "Votación";
            _usuarioId      = usuarioId;

            InitializeComponent();
            Text = "Reporte General de Votos | " + _tituloVotacion;
        }

        private void FrmReporteGeneralVotos_Load(object sender, EventArgs e)
        {
            CargarReporte();
        }

        private void CargarReporte()
        {
            try
            {
                // ReportViewer would be loaded here with actual data
                // For now show summary in a label if available
                if (lblResumen != null)
                {
                    lblResumen.Text =
                        "Padrón: " + _estadisticas.TotalPadron +
                        " | Válidos: " + _estadisticas.VotosValidos +
                        " | Nulos: " + _estadisticas.VotosNulos +
                        " | Sin votar: " + _estadisticas.SinVotar +
                        " | Participación: " + _estadisticas.PorcentajeParticipacion.ToString("F1") + "%";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            var menu = new SistemaVotacion.UI.Forms.Reportes(_usuarioId);
            menu.Show();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
