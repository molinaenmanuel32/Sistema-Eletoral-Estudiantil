using SistemaVotacion.BLL;
using SistemaVotacion.Models;
using SistemaVotacion.Reports;
using SistemaVotacion.UI.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    public partial class Reportes : Form
    {
        private readonly int _usuarioId;
        private readonly VotacionService _votSvc = new VotacionService();
        private readonly PlanchaService _plaSvc = new PlanchaService();
        private Votacion _votacion;

        public Reportes(int usuarioId)
        {
            _usuarioId = usuarioId;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _votacion = _votSvc.GetActiva();

            if (_votacion == null)
                _votacion = _votSvc.GetAll().FirstOrDefault();
        }

        // ═══════════════════════════════════════
        // GENERAL
        // ═══════════════════════════════════════
        private void btnVerGeneral_Click(object sender, EventArgs e)
        {
            if (!ValidarVotacion()) return;

            try
            {
                var estadisticas = _votSvc.GetEstadisticas(_votacion.VotacionId);
                var votos = ObtenerVotoDetalle(_votacion.VotacionId);

                new FrmReporteGeneralVotos(
                    estadisticas,
                    votos,
                    _votacion.Titulo
                ).ShowDialog();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void btnPdfGeneral_Click(object sender, EventArgs e)
        {
            btnVerGeneral_Click(sender, e);
        }

        // ═══════════════════════════════════════
        // PADRÓN
        // ═══════════════════════════════════════
        private void btnVerPadron_Click(object sender, EventArgs e)
        {
            if (!ValidarVotacion()) return;

            try
            {
                var participantes = ObtenerParticipantes(_votacion.VotacionId);

                new FrmReporteListadoParticipantes(
                    participantes,
                    _votacion.Titulo
                ).ShowDialog();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void btnPdfPadron_Click(object sender, EventArgs e)
        {
            btnVerPadron_Click(sender, e);
        }

        // ═══════════════════════════════════════
        // PLANCHA GANADORA
        // ═══════════════════════════════════════
        private void btnVerGanador_Click(object sender, EventArgs e)
        {
            if (!ValidarVotacion()) return;

            try
            {
                var estadisticas = _votSvc.GetEstadisticas(_votacion.VotacionId);

                if (estadisticas?.PorPlancha == null || !estadisticas.PorPlancha.Any())
                {
                    MessageBox.Show(
                        "No hay datos suficientes para determinar la plancha ganadora.",
                        "Sin datos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }

                new FrmReportePlanchaGanadora(
                    estadisticas,
                    _votacion.Titulo
                ).ShowDialog();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void btnPdfGanador_Click(object sender, EventArgs e)
        {
            btnVerGanador_Click(sender, e);
        }

        // ═══════════════════════════════════════
        // OBTENER VOTOS
        // ═══════════════════════════════════════
        private List<VotoDetalle> ObtenerVotoDetalle(int votacionId)
        {
            var rows = _votSvc.GetReporteGeneral(votacionId);
            var lista = new List<VotoDetalle>();
            int idx = 1;

            foreach (var r in rows)
            {
                var d = (IDictionary<string, object>)r;

                string estado = Leer(d, "EstadoVoto");
                if (estado == "Pendiente") continue;

                DateTime fecha;
                DateTime.TryParse(Leer(d, "FechaVoto"), out fecha);

                lista.Add(new VotoDetalle
                {
                    VotoId = idx++,
                    NombreVotante = Leer(d, "Participante"),
                    Matricula = Leer(d, "Matricula"),
                    Curso = Leer(d, "Curso"),
                    Seccion = Leer(d, "Seccion"),
                    PlanchaNombre = Leer(d, "PlanchaNombre"),
                    EsNulo = estado == "Nulo",
                    FechaVoto = fecha == default ? DateTime.Now : fecha
                });
            }

            return lista;
        }

        // ═══════════════════════════════════════
        // OBTENER PARTICIPANTES
        // ═══════════════════════════════════════
        private List<ParticipanteReporte> ObtenerParticipantes(int votacionId)
        {
            var rows = _votSvc.GetReporteGeneral(votacionId);
            var lista = new List<ParticipanteReporte>();
            int idx = 1;

            foreach (var r in rows)
            {
                var d = (IDictionary<string, object>)r;

                string estado = Leer(d, "EstadoVoto");

                DateTime fecha;
                DateTime.TryParse(Leer(d, "FechaVoto"), out fecha);

                lista.Add(new ParticipanteReporte
                {
                    PadronId = idx++,
                    NombreCompleto = Leer(d, "Participante"),
                    Matricula = Leer(d, "Matricula"),
                    Curso = Leer(d, "Curso"),
                    Seccion = Leer(d, "Seccion"),
                    EstadoVoto = estado == "Emitido" ? "Votó"
                                : estado == "Nulo" ? "Nulo"
                                : "Pendiente",
                    HoraVoto = fecha != default ? fecha.ToString("HH:mm") : ""
                });
            }

            return lista;
        }

        // ═══════════════════════════════════════
        // HELPERS
        // ═══════════════════════════════════════
        private static string Leer(IDictionary<string, object> d, string key)
        {
            return d != null && d.ContainsKey(key) && d[key] != null
                ? d[key].ToString()
                : "";
        }

        private bool ValidarVotacion()
        {
            if (_votacion != null) return true;

            MessageBox.Show(
                "No existe ninguna votación activa.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            return false;
        }

        private static void MostrarError(Exception ex)
        {
            MessageBox.Show(
                "Error al generar el reporte:\n" + ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }
}