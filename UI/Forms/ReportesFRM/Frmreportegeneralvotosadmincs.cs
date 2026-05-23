using Microsoft.Reporting.WinForms;
using SistemaVotacion.Models;
using SistemaVotacion.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms.ReportesFRM
{
    public partial class Frmreportegeneralvotosadmincs : Form
    {
        private readonly EstadisticasVotacion _estadisticas;
        private readonly IReadOnlyList<VotoDetalle> _votos;
        private readonly string _tituloVotacion;

        public Frmreportegeneralvotosadmincs(
            EstadisticasVotacion estadisticas,
            IEnumerable<VotoDetalle> votos,
            string tituloVotacion)
        {
            _estadisticas = estadisticas
                ?? throw new ArgumentNullException(nameof(estadisticas));
            _votos = votos?.ToList()
                ?? throw new ArgumentNullException(nameof(votos));
            _tituloVotacion = tituloVotacion ?? "Votación";

            InitializeComponent();
            Text = "Reporte General de Votos | " + _tituloVotacion;
        }

        private void Frmreportegeneralvotosadmincs_Load(object sender, EventArgs e)
        {
            if (_votos.Any())
            {
                dtpFechaInicio.Value = _votos.Min(v => v.FechaVoto).Date;
                dtpFechaFin.Value = _votos.Max(v => v.FechaVoto).Date;
            }
            else
            {
                dtpFechaInicio.Value = DateTime.Today;
                dtpFechaFin.Value = DateTime.Today;
            }

            ActualizarEtiquetaResumen();
            CargarReporte();
        }

        // ─────────────────────────────────────────────────────────────
        private void CargarReporte()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                var inicio = dtpFechaInicio.Value.Date;
                var fin = dtpFechaFin.Value.Date.AddDays(1).AddSeconds(-1);

                var filtrados = _votos
                    .Where(v => v.FechaVoto >= inicio && v.FechaVoto <= fin)
                    .ToList();

                ReportHelper.CargarReporteGeneralVotos(
                    reportViewer,
                    _estadisticas,
                    filtrados,
                    _tituloVotacion,
                    inicio,
                    fin);

                lblResultados.Text =
                    "Mostrando " + filtrados.Count + " voto(s)  |  " +
                    inicio.ToString("dd/MM/yyyy") + "  →  " +
                    dtpFechaFin.Value.ToString("dd/MM/yyyy");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ObtenerMensajeCompleto(ex),
                    "Error al cargar reporte",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private static string ObtenerMensajeCompleto(Exception ex)
        {
            var sb = new StringBuilder();
            var cur = ex;
            int nivel = 0;
            while (cur != null)
            {
                sb.AppendLine(nivel == 0 ? "[Error principal]" : "[Causa " + nivel + "]");
                sb.AppendLine(cur.GetType().Name + ": " + cur.Message);
                cur = cur.InnerException;
                nivel++;
            }
            return sb.ToString();
        }

        private bool ValidarFechas()
        {
            if (dtpFechaInicio.Value.Date > dtpFechaFin.Value.Date)
            {
                MessageBox.Show(
                    "La fecha de inicio no puede ser mayor que la fecha de fin.",
                    "Rango inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ActualizarEtiquetaResumen()
        {
            lblResumen.Text =
                "Padrón: " + _estadisticas.TotalPadron +
                "  |  Válidos: " + _estadisticas.VotosValidos +
                "  |  Nulos: " + _estadisticas.VotosNulos +
                "  |  Sin votar: " + _estadisticas.SinVotar +
                "  |  Participación: " +
                _estadisticas.PorcentajeParticipacion.ToString("F1") + "%";
        }

        // ─────────────── Eventos de botones ──────────────────────────
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (ValidarFechas()) CargarReporte();
        }

        private void btnHoy_Click(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;
            CargarReporte();
        }

        private void btnTodo_Click(object sender, EventArgs e)
        {
            if (_votos.Any())
            {
                dtpFechaInicio.Value = _votos.Min(v => v.FechaVoto).Date;
                dtpFechaFin.Value = _votos.Max(v => v.FechaVoto).Date;
            }
            CargarReporte();
        }

        private void btnCerrar_Click(object sender, EventArgs e) => Close();
    }
}