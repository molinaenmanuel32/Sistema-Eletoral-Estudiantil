// ══════════════════════════════════════════════════════════════════
//  ReportHelper.cs  –  SistemaVotacion
//  Métodos de extensión para cargar cada .rdlc en ReportViewer.
//  Referencia NuGet requerida:
//    Microsoft.Reporting.WinForms  (o .WebForms según el proyecto)
// ══════════════════════════════════════════════════════════════════
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;                       // WinForms
using Microsoft.Reporting.WinForms;               // ReportViewer WinForms
// Si usas WebForms: using Microsoft.Reporting.WebForms;
using SistemaVotacion.Models;

namespace SistemaVotacion.Reports
{
    public static class ReportHelper
    {
        // ──────────────────────────────────────────
        // Ruta base donde están los .rdlc
        // Ajusta según la estructura de tu proyecto
        // ──────────────────────────────────────────
        private const string ReportsPath = "Reports\\";

        // ══════════════════════════════════════════
        // 1. PLANCHA GANADORA
        // ══════════════════════════════════════════
        /// <summary>
        /// Carga el reporte de plancha ganadora con estadísticas generales.
        /// </summary>
        /// <param name="viewer">El control ReportViewer del formulario.</param>
        /// <param name="estadisticas">Objeto EstadisticasVotacion con todos los datos.</param>
        /// <param name="tituloVotacion">Nombre de la votación.</param>
        public static void CargarReportePlanchaGanadora(
            ReportViewer viewer,
            EstadisticasVotacion estadisticas,
            string tituloVotacion)
        {
            viewer.Reset();
            viewer.LocalReport.ReportPath = ReportsPath + "ReportePlanchaGanadora.rdlc";

            // ── Parámetros ──────────────────────────────────────────
            viewer.LocalReport.SetParameters(new[]
            {
                new ReportParameter("TituloVotacion", tituloVotacion),
                new ReportParameter("FechaReporte",  DateTime.Now.ToString("O"))
            });

            // ── dsResumen: 1 fila con los totales ──────────────────
            var dtResumen = new DataTable("dsResumen");
            dtResumen.Columns.Add("TotalPadron", typeof(int));
            dtResumen.Columns.Add("TotalVotos", typeof(int));
            dtResumen.Columns.Add("VotosNulos", typeof(int));
            dtResumen.Columns.Add("VotosValidos", typeof(int));
            dtResumen.Columns.Add("SinVotar", typeof(int));
            dtResumen.Columns.Add("PorcentajeParticipacion", typeof(decimal));
            dtResumen.Rows.Add(
                estadisticas.TotalPadron,
                estadisticas.TotalVotos,
                estadisticas.VotosNulos,
                estadisticas.VotosValidos,
                estadisticas.SinVotar,
                estadisticas.PorcentajeParticipacion);

            // ── dsGanadora: plancha con más votos ──────────────────
            var ganadora = estadisticas.PorPlancha.OrderByDescending(p => p.TotalVotos).First();
            var dtGanadora = new DataTable("dsGanadora");
            dtGanadora.Columns.Add("PlanchaId", typeof(int));
            dtGanadora.Columns.Add("Plancha", typeof(string));
            dtGanadora.Columns.Add("Color", typeof(string));
            dtGanadora.Columns.Add("TotalVotos", typeof(int));
            dtGanadora.Columns.Add("Porcentaje", typeof(decimal));
            dtGanadora.Columns.Add("LogoPath", typeof(string));
            dtGanadora.Rows.Add(
                ganadora.PlanchaId,
                ganadora.Plancha,
                ganadora.Color,
                ganadora.TotalVotos,
                ganadora.Porcentaje,
                ganadora.LogoPath ?? "");

            // ── dsPlanchas: todas las planchas ─────────────────────
            var dtPlanchas = new DataTable("dsPlanchas");
            dtPlanchas.Columns.Add("PlanchaId", typeof(int));
            dtPlanchas.Columns.Add("Plancha", typeof(string));
            dtPlanchas.Columns.Add("Color", typeof(string));
            dtPlanchas.Columns.Add("TotalVotos", typeof(int));
            dtPlanchas.Columns.Add("Porcentaje", typeof(decimal));
            foreach (var p in estadisticas.PorPlancha.OrderByDescending(x => x.TotalVotos))
                dtPlanchas.Rows.Add(p.PlanchaId, p.Plancha, p.Color, p.TotalVotos, p.Porcentaje);

            // ── Bind ────────────────────────────────────────────────
            viewer.LocalReport.DataSources.Clear();
            viewer.LocalReport.DataSources.Add(new ReportDataSource("dsResumen", dtResumen));
            viewer.LocalReport.DataSources.Add(new ReportDataSource("dsGanadora", dtGanadora));
            viewer.LocalReport.DataSources.Add(new ReportDataSource("dsPlanchas", dtPlanchas));

            viewer.RefreshReport();
        }

        // ══════════════════════════════════════════
        // 2. INTEGRANTES DE PLANCHA
        // ══════════════════════════════════════════
        /// <summary>
        /// Carga el reporte de integrantes de una plancha.
        /// </summary>
        public static void CargarReporteIntegrantesPlancha(
            ReportViewer viewer,
            Plancha plancha)
        {
            viewer.Reset();
            viewer.LocalReport.ReportPath = ReportsPath + "ReporteIntegrantesPlancha.rdlc";

            viewer.LocalReport.SetParameters(new[]
            {
                new ReportParameter("PlanchaId", plancha.PlanchaId.ToString())
            });

            // ── dsInfoPlancha: datos de la plancha ─────────────────
            var dtInfo = new DataTable("dsInfoPlancha");
            dtInfo.Columns.Add("PlanchaId", typeof(int));
            dtInfo.Columns.Add("Nombre", typeof(string));
            dtInfo.Columns.Add("Descripcion", typeof(string));
            dtInfo.Columns.Add("Mision", typeof(string));
            dtInfo.Columns.Add("Color", typeof(string));
            dtInfo.Columns.Add("AdminNombre", typeof(string));
            dtInfo.Columns.Add("Activa", typeof(bool));
            dtInfo.Rows.Add(
                plancha.PlanchaId,
                plancha.Nombre,
                plancha.Descripcion ?? "",
                plancha.Mision ?? "",
                plancha.Color ?? "#007BFF",
                plancha.AdminNombre ?? "",
                plancha.Activa);

            // ── dsMiembros: integrantes ─────────────────────────────
            var dtMiembros = new DataTable("dsMiembros");
            dtMiembros.Columns.Add("MiembroId", typeof(int));
            dtMiembros.Columns.Add("NombreCompleto", typeof(string));
            dtMiembros.Columns.Add("Matricula", typeof(string));
            dtMiembros.Columns.Add("Puesto", typeof(string));
            dtMiembros.Columns.Add("Descripcion", typeof(string));
            dtMiembros.Columns.Add("Orden", typeof(int));
            dtMiembros.Columns.Add("FotoPath", typeof(string));
            foreach (var m in plancha.Miembros.OrderBy(x => x.Orden))
                dtMiembros.Rows.Add(
                    m.MiembroId,
                    m.NombreCompleto ?? m.Nombre,
                    m.Matricula ?? "",
                    m.Puesto ?? "",
                    m.Descripcion ?? "",
                    m.Orden,
                    m.FotoPath ?? "");

            viewer.LocalReport.DataSources.Clear();
            viewer.LocalReport.DataSources.Add(new ReportDataSource("dsInfoPlancha", dtInfo));
            viewer.LocalReport.DataSources.Add(new ReportDataSource("dsMiembros", dtMiembros));

            viewer.RefreshReport();
        }

        // ══════════════════════════════════════════
        // 3. REPORTE GENERAL DE VOTOS
        // ══════════════════════════════════════════
        /// <summary>
        /// Carga el reporte general de votos.
        /// </summary>
        /// <param name="votos">Lista de votos con datos extendidos (JOIN Padron + Plancha).</param>
        public static void CargarReporteGeneralVotos(
            ReportViewer viewer,
            EstadisticasVotacion estadisticas,
            IEnumerable<VotoDetalle> votos,
            string tituloVotacion,
            DateTime fechaInicio,
            DateTime fechaFin)
        {
            viewer.Reset();
            viewer.LocalReport.ReportPath = ReportsPath + "ReporteGeneralVotos.rdlc";

            viewer.LocalReport.SetParameters(new[]
            {
                new ReportParameter("TituloVotacion", tituloVotacion),
                new ReportParameter("FechaInicio",    fechaInicio.ToString("O")),
                new ReportParameter("FechaFin",       fechaFin.ToString("O"))
            });

            // ── dsResumen ──────────────────────────────────────────
            var dtResumen = new DataTable("dsResumen");
            dtResumen.Columns.Add("TotalPadron", typeof(int));
            dtResumen.Columns.Add("TotalVotos", typeof(int));
            dtResumen.Columns.Add("VotosNulos", typeof(int));
            dtResumen.Columns.Add("VotosValidos", typeof(int));
            dtResumen.Columns.Add("SinVotar", typeof(int));
            dtResumen.Columns.Add("PorcentajeParticipacion", typeof(decimal));
            dtResumen.Rows.Add(
                estadisticas.TotalPadron,
                estadisticas.TotalVotos,
                estadisticas.VotosNulos,
                estadisticas.VotosValidos,
                estadisticas.SinVotar,
                estadisticas.PorcentajeParticipacion);

            // ── dsPorPlancha ───────────────────────────────────────
            var dtPorPlancha = new DataTable("dsPorPlancha");
            dtPorPlancha.Columns.Add("Plancha", typeof(string));
            dtPorPlancha.Columns.Add("TotalVotos", typeof(int));
            dtPorPlancha.Columns.Add("Porcentaje", typeof(decimal));
            dtPorPlancha.Columns.Add("Color", typeof(string));
            foreach (var p in estadisticas.PorPlancha.OrderByDescending(x => x.TotalVotos))
                dtPorPlancha.Rows.Add(p.Plancha, p.TotalVotos, p.Porcentaje, p.Color);

            // ── dsDetalleVotos ─────────────────────────────────────
            var dtDetalle = new DataTable("dsDetalleVotos");
            dtDetalle.Columns.Add("VotoId", typeof(int));
            dtDetalle.Columns.Add("NombreVotante", typeof(string));
            dtDetalle.Columns.Add("Matricula", typeof(string));
            dtDetalle.Columns.Add("Curso", typeof(string));
            dtDetalle.Columns.Add("Seccion", typeof(string));
            dtDetalle.Columns.Add("PlanchaNombre", typeof(string));
            dtDetalle.Columns.Add("EsNulo", typeof(bool));
            dtDetalle.Columns.Add("FechaVoto", typeof(DateTime));
            foreach (var v in votos.OrderBy(x => x.FechaVoto))
                dtDetalle.Rows.Add(
                    v.VotoId,
                    v.NombreVotante,
                    v.Matricula,
                    v.Curso,
                    v.Seccion,
                    v.PlanchaNombre ?? "—",
                    v.EsNulo,
                    v.FechaVoto);

            viewer.LocalReport.DataSources.Clear();
            viewer.LocalReport.DataSources.Add(new ReportDataSource("dsResumen", dtResumen));
            viewer.LocalReport.DataSources.Add(new ReportDataSource("dsPorPlancha", dtPorPlancha));
            viewer.LocalReport.DataSources.Add(new ReportDataSource("dsDetalleVotos", dtDetalle));

            viewer.RefreshReport();
        }

        // ══════════════════════════════════════════
        // 4. LISTADO GENERAL DE PARTICIPANTES
        // ══════════════════════════════════════════
        /// <summary>
        /// Carga el reporte de padrón / participantes.
        /// </summary>
        /// <param name="participantes">Lista de Padron con campo EstadoVoto y HoraVoto adicionales.</param>
        public static void CargarReporteListadoParticipantes(
            ReportViewer viewer,
            IEnumerable<ParticipanteReporte> participantes,
            string tituloVotacion,
            string filtroEstado = "Todos",
            string filtroCurso = "")
        {
            viewer.Reset();
            viewer.LocalReport.ReportPath = ReportsPath + "ReporteListadoParticipantes.rdlc";

            viewer.LocalReport.SetParameters(new[]
            {
                new ReportParameter("TituloVotacion", tituloVotacion),
                new ReportParameter("FiltroEstado",   filtroEstado),
                new ReportParameter("FiltroCurso",    filtroCurso)
            });

            var dtParticipantes = new DataTable("dsParticipantes");
            dtParticipantes.Columns.Add("PadronId", typeof(int));
            dtParticipantes.Columns.Add("NombreCompleto", typeof(string));
            dtParticipantes.Columns.Add("Matricula", typeof(string));
            dtParticipantes.Columns.Add("Curso", typeof(string));
            dtParticipantes.Columns.Add("Seccion", typeof(string));
            dtParticipantes.Columns.Add("EstadoVoto", typeof(string));
            dtParticipantes.Columns.Add("HoraVoto", typeof(string));

            // Aplicar filtros antes de añadir al DataTable (optimización)
            var query = participantes.AsEnumerable();
            if (filtroEstado != "Todos")
                query = query.Where(p => p.EstadoVoto == filtroEstado);
            if (!string.IsNullOrWhiteSpace(filtroCurso))
                query = query.Where(p => p.Curso == filtroCurso);

            foreach (var p in query.OrderBy(x => x.Curso).ThenBy(x => x.NombreCompleto))
                dtParticipantes.Rows.Add(
                    p.PadronId,
                    p.NombreCompleto,
                    p.Matricula,
                    p.Curso,
                    p.Seccion,
                    p.EstadoVoto,
                    p.HoraVoto ?? "");

            viewer.LocalReport.DataSources.Clear();
            viewer.LocalReport.DataSources.Add(new ReportDataSource("dsParticipantes", dtParticipantes));

            viewer.RefreshReport();
        }
    }

    // ══════════════════════════════════════════════
    //  DTOs adicionales usados por los helpers
    // ══════════════════════════════════════════════

    /// <summary>
    /// Voto con datos JOIN de Padron y Plancha — se construye en la capa de datos.
    /// </summary>
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

    /// <summary>
    /// Fila del padrón enriquecida con estado de voto para el reporte de participantes.
    /// EstadoVoto: "Votó" | "Pendiente"
    /// HoraVoto  : "HH:mm" si votó, null si no.
    /// </summary>
    public class ParticipanteReporte
    {
        public int PadronId { get; set; }
        public string NombreCompleto { get; set; }
        public string Matricula { get; set; }
        public string Curso { get; set; }
        public string Seccion { get; set; }
        public string EstadoVoto { get; set; }  // "Votó" | "Pendiente"
        public string HoraVoto { get; set; }
    }
}
