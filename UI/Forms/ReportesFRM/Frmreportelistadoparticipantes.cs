using Microsoft.Reporting.WinForms;
using SistemaVotacion.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Reportes
{
    public partial class FrmReporteListadoParticipantes : Form
    {
        // ── Datos ────────────────────────────────────────────────────
        private readonly IReadOnlyList<ParticipanteReporte> _participantes;
        private readonly string _tituloVotacion;

        // ── Constructor ──────────────────────────────────────────────
        public FrmReporteListadoParticipantes(
            IEnumerable<ParticipanteReporte> participantes,
            string tituloVotacion)
        {
            _participantes = participantes?.ToList()
                              ?? throw new ArgumentNullException(nameof(participantes));
            _tituloVotacion = tituloVotacion ?? "Votación";

            InitializeComponent();
            Text = $"Reporte – Listado de Participantes | {_tituloVotacion}";
        }

        // ── Load ─────────────────────────────────────────────────────
        private void FrmReporteListadoParticipantes_Load(object sender, EventArgs e)
        {
            CargarComboCurso();
            ActualizarEtiquetaResumen();
            CargarReporte();
        }

        // ── Combo de cursos ───────────────────────────────────────────
        private void CargarComboCurso()
        {
            var cursos = _participantes
                .Select(p => p.Curso)
                .Where(c => !string.IsNullOrWhiteSpace(c))
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            cboCurso.Items.Clear();
            cboCurso.Items.Add("(Todos los cursos)");
            foreach (var c in cursos) cboCurso.Items.Add(c);
            cboCurso.SelectedIndex = 0;
        }

        // ── Resumen rápido ────────────────────────────────────────────
        private void ActualizarEtiquetaResumen()
        {
            int total = _participantes.Count;
            int votaron = _participantes.Count(p => p.EstadoVoto == "Votó");
            int pendientes = total - votaron;

            lblResumen.Text =
                $"Total padrón: {total}  |  Votaron: {votaron}  |  Pendientes: {pendientes}  |  " +
                $"Participación: {(total > 0 ? (votaron * 100m / total) : 0):F1} %";
        }

        // ── Reporte ──────────────────────────────────────────────────
        private void CargarReporte()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                string estado = cboEstado.SelectedItem?.ToString() ?? "Todos";
                string curso = cboCurso.SelectedIndex <= 0
                                    ? ""
                                    : cboCurso.SelectedItem?.ToString() ?? "";

                ReportHelper.CargarReporteListadoParticipantes(
                    reportViewer,
                    _participantes,
                    _tituloVotacion,
                    estado,
                    curso);

                var query = _participantes.AsEnumerable();
                if (estado != "Todos") query = query.Where(p => p.EstadoVoto == estado);
                if (!string.IsNullOrWhiteSpace(curso)) query = query.Where(p => p.Curso == curso);

                lblResultados.Text =
                    $"Registros mostrados: {query.Count()}  " +
                    $"(Filtro: estado = {estado}" +
                    (string.IsNullOrWhiteSpace(curso) ? "" : $", curso = {curso}") + ")";
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

        // ── Eventos ──────────────────────────────────────────────────
        private void btnGenerar_Click(object sender, EventArgs e) => CargarReporte();

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            cboEstado.SelectedIndex = 0;
            cboCurso.SelectedIndex = 0;
            CargarReporte();
        }

        private void btnCerrar_Click(object sender, EventArgs e) => Close();
    }
}