using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.Reporting.WinForms;
using SistemaVotacion.Models;

namespace SistemaVotacion.Reports
{
    public static class ReportHelper
    {
        // ═══════════════════════════════════════
        // 1. PLANCHA GANADORA
        // Dataset RDLC: "PlanchaGanadora"
        // Campos: PlanchaId, NombrePlancha, Votos, Porcentaje, Ganadora
        // ═══════════════════════════════════════
        public static void CargarReportePlanchaGanadora(
            ReportViewer viewer,
            EstadisticasVotacion estadisticas,
            string tituloVotacion)
        {
            viewer.Reset();
            viewer.LocalReport.ReportEmbeddedResource =
                "SistemaVotacion.UI.Reports.RptPlanchaGanadora.rdlc";

            viewer.LocalReport.SetParameters(new[]
            {
                new ReportParameter("TituloVotacion", tituloVotacion),
                new ReportParameter("FechaReporte", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"))
            });

            // Determinar ganadora (más votos)
            var ganadora = estadisticas.PorPlancha?
                .OrderByDescending(x => x.TotalVotos)
                .FirstOrDefault();

            var dt = new DataTable("PlanchaGanadora");
            dt.Columns.Add("PlanchaId", typeof(int));
            dt.Columns.Add("NombrePlancha", typeof(string));
            dt.Columns.Add("Votos", typeof(int));
            dt.Columns.Add("Porcentaje", typeof(decimal));
            dt.Columns.Add("Ganadora", typeof(bool));

            if (estadisticas.PorPlancha != null)
            {
                foreach (var p in estadisticas.PorPlancha.OrderByDescending(x => x.TotalVotos))
                {
                    dt.Rows.Add(
                        p.PlanchaId,
                        p.Plancha,                          // → NombrePlancha
                        p.TotalVotos,                       // → Votos
                        p.Porcentaje,
                        ganadora != null && p.PlanchaId == ganadora.PlanchaId  // → Ganadora
                    );
                }
            }

            SetReport(viewer, ("PlanchaGanadora", dt));
        }

        // ═══════════════════════════════════════
        // 2. INTEGRANTES PLANCHA
        // Dataset RDLC: "IntegrantesPlancha"
        // Campos: PlanchaId, NombrePlancha, MiembroNombre, Cargo, Matricula, Curso
        // ═══════════════════════════════════════
        public static void CargarReporteIntegrantesPlancha(
            ReportViewer viewer,
            Plancha plancha)
        {
            viewer.Reset();
            viewer.LocalReport.ReportEmbeddedResource =
                "SistemaVotacion.UI.Reports.RptIntegrantesPlancha.rdlc";

            var dt = new DataTable("IntegrantesPlancha");
            dt.Columns.Add("PlanchaId", typeof(int));
            dt.Columns.Add("NombrePlancha", typeof(string));
            dt.Columns.Add("MiembroNombre", typeof(string));
            dt.Columns.Add("Cargo", typeof(string));
            dt.Columns.Add("Matricula", typeof(string));
            dt.Columns.Add("Curso", typeof(string));

            if (plancha.Miembros != null)
            {
                foreach (var m in plancha.Miembros.OrderBy(x => x.Orden))
                {
                    dt.Rows.Add(
                        plancha.PlanchaId,
                        plancha.Nombre,
                        m.NombreCompleto ?? m.Nombre,   // → MiembroNombre
                        m.Puesto ?? "",                 // → Cargo
                        m.Matricula ?? "",
                        m.Curso ?? ""                   // ✅ FIX: antes siempre era ""
                    );
                }
            }

            SetReport(viewer, ("IntegrantesPlancha", dt));
        }

        // ═══════════════════════════════════════
        // 3. GENERAL DE VOTOS
        // Dataset RDLC: "Votos"
        // Campos: VotoId, NombreVotante, Matricula, Curso, Seccion,
        //         PlanchaNombre, EsNulo, FechaVoto
        // ═══════════════════════════════════════
        public static void CargarReporteGeneralVotos(
            ReportViewer viewer,
            EstadisticasVotacion estadisticas,
            IEnumerable<VotoDetalle> votos,
            string titulo,
            DateTime inicio,
            DateTime fin)
        {
            viewer.Reset();
            viewer.LocalReport.ReportEmbeddedResource =
                "SistemaVotacion.UI.Reports.RptVotosGeneral.rdlc";

            viewer.LocalReport.SetParameters(new[]
            {
                new ReportParameter("TituloVotacion", titulo),
                new ReportParameter("FechaInicio", inicio.ToString("dd/MM/yyyy HH:mm:ss")),
                new ReportParameter("FechaFin",    fin.ToString("dd/MM/yyyy HH:mm:ss"))
            });

            var dt = new DataTable("Votos");
            dt.Columns.Add("VotoId", typeof(int));
            dt.Columns.Add("NombreVotante", typeof(string));
            dt.Columns.Add("Matricula", typeof(string));
            dt.Columns.Add("Curso", typeof(string));
            dt.Columns.Add("Seccion", typeof(string));
            dt.Columns.Add("PlanchaNombre", typeof(string));
            dt.Columns.Add("EsNulo", typeof(bool));
            dt.Columns.Add("FechaVoto", typeof(DateTime));

            if (votos != null)
            {
                foreach (var v in votos.OrderBy(x => x.FechaVoto))
                {
                    dt.Rows.Add(
                        v.VotoId,
                        v.NombreVotante,
                        v.Matricula,
                        v.Curso,
                        v.Seccion,
                        v.PlanchaNombre ?? "—",
                        v.EsNulo,
                        v.FechaVoto
                    );
                }
            }

            SetReport(viewer, ("Votos", dt));
        }

        // ═══════════════════════════════════════
        // 4. LISTADO PARTICIPANTES
        // Dataset RDLC: "Participantes"
        // Campos: PadronId, NombreCompleto, Matricula, Curso,
        //         Seccion, EstadoVoto, HoraVoto
        // ═══════════════════════════════════════
        public static void CargarReporteListadoParticipantes(
            ReportViewer viewer,
            IEnumerable<ParticipanteReporte> participantes,
            string tituloVotacion,
            string filtroEstado,
            string filtroCurso)
        {
            viewer.Reset();
            viewer.LocalReport.ReportEmbeddedResource =
                "SistemaVotacion.UI.Reports.RptParticipantes.rdlc";

            viewer.LocalReport.SetParameters(new[]
            {
                new ReportParameter("TituloVotacion", tituloVotacion),
                new ReportParameter("FiltroEstado",  string.IsNullOrWhiteSpace(filtroEstado) ? "Todos" : filtroEstado),
                new ReportParameter("FiltroCurso",   string.IsNullOrWhiteSpace(filtroCurso)  ? "Todos" : filtroCurso),
                new ReportParameter("FechaReporte",  DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"))
            });

            var query = participantes.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(filtroEstado) && filtroEstado != "Todos")
                query = query.Where(p => p.EstadoVoto == filtroEstado);
            if (!string.IsNullOrWhiteSpace(filtroCurso))
                query = query.Where(p => p.Curso == filtroCurso);

            var dt = new DataTable("Participantes");
            dt.Columns.Add("PadronId", typeof(int));
            dt.Columns.Add("NombreCompleto", typeof(string));
            dt.Columns.Add("Matricula", typeof(string));
            dt.Columns.Add("Curso", typeof(string));
            dt.Columns.Add("Seccion", typeof(string));
            dt.Columns.Add("EstadoVoto", typeof(string));
            dt.Columns.Add("HoraVoto", typeof(string));

            foreach (var p in query.OrderBy(p => p.Curso).ThenBy(p => p.NombreCompleto))
            {
                dt.Rows.Add(
                    p.PadronId,
                    p.NombreCompleto,
                    p.Matricula,
                    p.Curso ?? "",
                    p.Seccion ?? "",
                    p.EstadoVoto,
                    p.HoraVoto ?? ""
                );
            }

            SetReport(viewer, ("Participantes", dt));
        }

        // ═══════════════════════════════════════
        // UTILIDAD CENTRAL
        // ═══════════════════════════════════════
        private static void SetReport(
            ReportViewer viewer,
            params (string name, DataTable table)[] sources)
        {
            viewer.LocalReport.DataSources.Clear();
            foreach (var s in sources)
                viewer.LocalReport.DataSources.Add(new ReportDataSource(s.name, s.table));
            viewer.RefreshReport();
        }
    }

    // ═══════════════════════════════════════
    // MODELOS
    // ═══════════════════════════════════════
    public class VotoDetalle
    {
        public int VotoId { get; set; }
        public string NombreVotante { get; set; }
        public string Matricula { get; set; }
        public string Curso { get; set; }
        public string Seccion { get; set; }
        public string PlanchaNombre { get; set; }
        public bool EsNulo { get; set; }
        public DateTime FechaVoto { get; set; }
    }

    public class ParticipanteReporte
    {
        public int PadronId { get; set; }
        public string NombreCompleto { get; set; }
        public string Matricula { get; set; }
        public string Curso { get; set; }
        public string Seccion { get; set; }
        public string EstadoVoto { get; set; }
        public string HoraVoto { get; set; }
    }
}