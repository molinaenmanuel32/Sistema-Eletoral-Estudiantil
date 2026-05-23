using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SistemaVotacion.BLL;
using SistemaVotacion.Models;
using SistemaVotacion.Reports;
using SistemaVotacion.UI.Reportes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Forms
{
    public partial class FrmReportesAdmin : Form
    {
        private readonly int _usuarioId;
        private readonly VotacionService _votSvc = new VotacionService();
        private readonly PlanchaService _plaSvc = new PlanchaService();
        private Votacion _votacion;

        public FrmReportesAdmin(int usuarioId)
        {
            _usuarioId = usuarioId;
            InitializeComponent();
            QuestPDF.Settings.License = LicenseType.Community;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _votacion = _votSvc.GetActiva() ?? _votSvc.GetAll().FirstOrDefault();
        }

        private void btnVerGeneral_Click(object sender, EventArgs e)
        {
            if (!ValidarVotacion()) return;
            try
            {
                var est = _votSvc.GetEstadisticas(_votacion.VotacionId);
                var votos = ObtenerVotoDetalle(_votacion.VotacionId);
                new SistemaVotacion.UI.Forms.ReportesFRM
                    .Frmreportegeneralvotosadmincs(est, votos, _votacion.Titulo)
                    .ShowDialog();
            }
            catch (Exception ex) { MostrarError(ex); }
        }

        private void btnPdfGeneral_Click(object sender, EventArgs e)
        {
            if (!ValidarVotacion()) return;
            try
            {
                var save = new SaveFileDialog { Filter = "PDF Files|*.pdf", FileName = "ReporteGeneral.pdf" };
                if (save.ShowDialog() != DialogResult.OK) return;

                var est = _votSvc.GetEstadisticas(_votacion.VotacionId);
                var participantes = ObtenerParticipantes(_votacion.VotacionId);
                int totalVotaron = participantes.Count(x => x.EstadoVoto == "Votó");
                int totalPend = participantes.Count(x => x.EstadoVoto == "Pendiente");

                Document.Create(c => c.Page(page =>
                {
                    page.Margin(30);
                    page.Header().Text("REPORTE GENERAL DE VOTACIÓN").FontSize(20).Bold();
                    page.Content().PaddingVertical(10).Column(col =>
                    {
                        col.Item().Text("Votación: " + _votacion.Titulo);
                        col.Item().Text("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                        col.Item().Text("Administrador ID: " + _usuarioId);
                        col.Item().PaddingTop(10).Text("Total participantes: " + participantes.Count);
                        col.Item().Text("Votaron: " + totalVotaron);
                        col.Item().Text("Pendientes: " + totalPend);
                        if (est != null)
                        {
                            col.Item().Text("Votos emitidos: " + est.TotalVotos);
                            col.Item().Text("Votos nulos: " + est.VotosNulos);
                        }
                    });
                    page.Footer().AlignCenter().Text(x => { x.Span("Página "); x.CurrentPageNumber(); });
                })).GeneratePdf(save.FileName);

                MessageBox.Show("PDF generado correctamente.");
                Process.Start(new ProcessStartInfo { FileName = save.FileName, UseShellExecute = true });
            }
            catch (Exception ex) { MostrarError(ex); }
        }

        private void btnVerPadron_Click(object sender, EventArgs e)
        {
            if (!ValidarVotacion()) return;
            try
            {
                var p = ObtenerParticipantes(_votacion.VotacionId);
                new FrmReporteListadoParticipantes(p, _votacion.Titulo).ShowDialog();
            }
            catch (Exception ex) { MostrarError(ex); }
        }

        private void btnPdfPadron_Click(object sender, EventArgs e)
        {
            if (!ValidarVotacion()) return;
            try
            {
                var save = new SaveFileDialog { Filter = "PDF Files|*.pdf", FileName = "ReportePadron.pdf" };
                if (save.ShowDialog() != DialogResult.OK) return;

                var participantes = ObtenerParticipantes(_votacion.VotacionId);

                Document.Create(c => c.Page(page =>
                {
                    page.Margin(30);
                    page.Header().Text("REPORTE PADRÓN").FontSize(20).Bold();
                    page.Content().PaddingVertical(10).Column(col =>
                    {
                        col.Item().Text("Votación: " + _votacion.Titulo);
                        col.Item().Text("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                        col.Item().PaddingTop(10).Text("LISTADO DE PARTICIPANTES").Bold();
                        foreach (var p in participantes)
                            col.Item().Text(p.NombreCompleto + " | " + p.Curso + " " + p.Seccion + " | " + p.EstadoVoto);
                    });
                    page.Footer().AlignCenter().Text(x => { x.Span("Página "); x.CurrentPageNumber(); });
                })).GeneratePdf(save.FileName);

                MessageBox.Show("PDF generado correctamente.");
                Process.Start(new ProcessStartInfo { FileName = save.FileName, UseShellExecute = true });
            }
            catch (Exception ex) { MostrarError(ex); }
        }

        private void btnVerGanador_Click(object sender, EventArgs e)
        {
            if (!ValidarVotacion()) return;
            try
            {
                var est = _votSvc.GetEstadisticas(_votacion.VotacionId);
                if (est?.PorPlancha == null || !est.PorPlancha.Any())
                {
                    MessageBox.Show("No hay datos suficientes.", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                new FrmReportePlanchaGanadora(est, _votacion.Titulo).ShowDialog();
            }
            catch (Exception ex) { MostrarError(ex); }
        }

        private void btnPdfGanador_Click(object sender, EventArgs e)
        {
            if (!ValidarVotacion()) return;
            try
            {
                var estadisticas = _votSvc.GetEstadisticas(_votacion.VotacionId);
                if (estadisticas?.PorPlancha == null || !estadisticas.PorPlancha.Any())
                {
                    MessageBox.Show("No hay datos suficientes.", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var save = new SaveFileDialog
                {
                    Filter = "PDF Files|*.pdf",
                    FileName = "ReporteGanador_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".pdf"
                };
                if (save.ShowDialog() != DialogResult.OK) return;

                var ranking = estadisticas.PorPlancha.OrderByDescending(x => x.TotalVotos).ToList();
                var ganadora = ranking.First();
                int totalValidos = ranking.Sum(p => p.TotalVotos);
                int diferencia = ranking.Count > 1 ? ganadora.TotalVotos - ranking[1].TotalVotos : ganadora.TotalVotos;

                Plancha planchaDetalle = null;
                try { planchaDetalle = _plaSvc.GetById(ganadora.PlanchaId); } catch { }

                Document.Create(c => c.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(40);
                    page.DefaultTextStyle(x => x.FontFamily("Arial").FontSize(10));

                    // ENCABEZADO — sin Height(), solo Padding
                    page.Header()
                        .Background("#1B5E20")
                        .Padding(14)
                        .Column(h =>
                        {
                            h.Item().Text("SISTEMA ELECTORAL ESTUDIANTIL")
                                .FontSize(9).FontColor(Colors.White).Bold();
                            h.Item().Text("ACTA OFICIAL DE RESULTADOS")
                                .FontSize(16).FontColor(Colors.White).Bold();
                            h.Item().PaddingTop(2)
                                .Text("Votacion: " + _votacion.Titulo)
                                .FontSize(10).FontColor("#A5D6A7");
                            h.Item().PaddingTop(2)
                                .Text("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") +
                                      "   |   Votos válidos: " + totalValidos +
                                      "   |   Participación: " + estadisticas.PorcentajeParticipacion.ToString("0.0") + "%")
                                .FontSize(8).FontColor("#A5D6A7");
                        });

                    // CONTENIDO
                    page.Content().PaddingTop(15).Column(col =>
                    {
                        // ── Plancha Ganadora ──────────────────────────────
                        col.Item().BorderBottom(2).BorderColor("#1B5E20").PaddingBottom(3)
                            .Text("PLANCHA GANADORA").FontSize(12).Bold().FontColor("#1B5E20");

                        col.Item().PaddingTop(8)
                            .Background("#E8F5E9").Border(1).BorderColor("#1B5E20").Padding(10)
                            .Column(g =>
                            {
                                g.Item().Text("Plancha: " + ganadora.Plancha)
                                    .FontSize(14).Bold().FontColor("#1B5E20");
                                g.Item().PaddingTop(4)
                                    .Text("Votos obtenidos: " + ganadora.TotalVotos + " de " + totalValidos + " válidos");
                                g.Item().Text("Porcentaje: " + ganadora.Porcentaje.ToString("0.00") + "%");
                                g.Item().Text("Posición: 1er lugar");
                                g.Item().Text("Ventaja sobre 2do lugar: +" + diferencia + " votos");
                            });

                        // Descripción / Misión
                        if (planchaDetalle != null)
                        {
                            if (!string.IsNullOrWhiteSpace(planchaDetalle.Descripcion))
                                col.Item().PaddingTop(6)
                                    .Text("Descripción: " + planchaDetalle.Descripcion)
                                    .FontSize(9).FontColor("#616161");

                            if (!string.IsNullOrWhiteSpace(planchaDetalle.Mision))
                                col.Item().PaddingTop(3)
                                    .Text("Misión: " + planchaDetalle.Mision)
                                    .FontSize(9).FontColor("#616161");
                        }

                        // ── Integrantes ───────────────────────────────────
                        if (planchaDetalle?.Miembros != null && planchaDetalle.Miembros.Any())
                        {
                            col.Item().PaddingTop(14).BorderBottom(2).BorderColor("#1B5E20").PaddingBottom(3)
                                .Text("INTEGRANTES DE LA PLANCHA GANADORA")
                                .FontSize(12).Bold().FontColor("#1B5E20");

                            col.Item().PaddingTop(6).Table(tabla =>
                            {
                                tabla.ColumnsDefinition(cols =>
                                {
                                    cols.ConstantColumn(25);
                                    cols.RelativeColumn(2);
                                    cols.RelativeColumn(3);
                                    cols.RelativeColumn(2);
                                });
                                tabla.Header(h =>
                                {
                                    h.Cell().Background("#1B5E20").Padding(5).Text("#").Bold().FontColor(Colors.White).FontSize(9);
                                    h.Cell().Background("#1B5E20").Padding(5).Text("Cargo").Bold().FontColor(Colors.White).FontSize(9);
                                    h.Cell().Background("#1B5E20").Padding(5).Text("Nombre").Bold().FontColor(Colors.White).FontSize(9);
                                    h.Cell().Background("#1B5E20").Padding(5).Text("Matrícula").Bold().FontColor(Colors.White).FontSize(9);
                                });

                                var miembros = planchaDetalle.Miembros.OrderBy(m => m.Orden).ToList();
                                for (int i = 0; i < miembros.Count; i++)
                                {
                                    var m = miembros[i];
                                    string bg = i % 2 == 0 ? "#FFFFFF" : "#F1F8E9";
                                    tabla.Cell().Background(bg).BorderBottom(0.5f).BorderColor("#BDBDBD").Padding(5)
                                        .Text((i + 1).ToString()).FontSize(9);
                                    tabla.Cell().Background(bg).BorderBottom(0.5f).BorderColor("#BDBDBD").Padding(5)
                                        .Text(m.Puesto ?? "—").FontSize(9).Bold();
                                    tabla.Cell().Background(bg).BorderBottom(0.5f).BorderColor("#BDBDBD").Padding(5)
                                        .Text(m.NombreCompleto ?? m.Nombre ?? "—").FontSize(9);
                                    tabla.Cell().Background(bg).BorderBottom(0.5f).BorderColor("#BDBDBD").Padding(5)
                                        .Text(m.Matricula ?? "—").FontSize(9);
                                }
                            });
                        }

                        // ── Resultados completos ──────────────────────────
                        col.Item().PaddingTop(14).BorderBottom(2).BorderColor("#1B5E20").PaddingBottom(3)
                            .Text("RESULTADOS COMPLETOS").FontSize(12).Bold().FontColor("#1B5E20");

                        col.Item().PaddingTop(6).Table(tabla =>
                        {
                            tabla.ColumnsDefinition(cols =>
                            {
                                cols.ConstantColumn(35);
                                cols.RelativeColumn(4);
                                cols.ConstantColumn(55);
                                cols.ConstantColumn(75);
                                cols.ConstantColumn(75);
                            });
                            tabla.Header(h =>
                            {
                                h.Cell().Background("#37474F").Padding(6).Text("Pos.").Bold().FontColor(Colors.White).FontSize(9);
                                h.Cell().Background("#37474F").Padding(6).Text("Plancha").Bold().FontColor(Colors.White).FontSize(9);
                                h.Cell().Background("#37474F").Padding(6).Text("Votos").Bold().FontColor(Colors.White).FontSize(9);
                                h.Cell().Background("#37474F").Padding(6).Text("Porcentaje").Bold().FontColor(Colors.White).FontSize(9);
                                h.Cell().Background("#37474F").Padding(6).Text("Estado").Bold().FontColor(Colors.White).FontSize(9);
                            });

                            for (int i = 0; i < ranking.Count; i++)
                            {
                                var p = ranking[i];
                                bool esGan = i == 0;
                                string bg = esGan ? "#E8F5E9" : (i % 2 == 0 ? "#FFFFFF" : "#FAFAFA");
                                string pos = i == 0 ? "1er" : i == 1 ? "2do" : i == 2 ? "3er" : (i + 1) + "to";
                                string colorTexto = esGan ? "#1B5E20" : "#212121";
                                string colorSec = esGan ? "#1B5E20" : "#616161";

                                tabla.Cell().Background(bg).BorderBottom(0.5f).BorderColor("#BDBDBD").Padding(6)
                                    .Text(pos).FontSize(9).FontColor(colorSec);
                                var tn = tabla.Cell().Background(bg).BorderBottom(0.5f).BorderColor("#BDBDBD").Padding(6)
                                    .Text(p.Plancha).FontSize(9).FontColor(colorTexto);
                                if (esGan) tn.Bold();
                                tabla.Cell().Background(bg).BorderBottom(0.5f).BorderColor("#BDBDBD").Padding(6)
                                    .Text(p.TotalVotos.ToString()).FontSize(10).Bold().FontColor(colorTexto);
                                tabla.Cell().Background(bg).BorderBottom(0.5f).BorderColor("#BDBDBD").Padding(6)
                                    .Text(p.Porcentaje.ToString("0.00") + "%").FontSize(9).FontColor(colorSec);
                                var te = tabla.Cell().Background(bg).BorderBottom(0.5f).BorderColor("#BDBDBD").Padding(6)
                                    .Text(esGan ? "GANADORA" : "Participante").FontSize(8).FontColor(colorSec);
                                if (esGan) te.Bold();
                            }
                        });

                        // ── Resumen estadístico ───────────────────────────
                        col.Item().PaddingTop(14).BorderBottom(2).BorderColor("#1B5E20").PaddingBottom(3)
                            .Text("RESUMEN ESTADÍSTICO").FontSize(12).Bold().FontColor("#1B5E20");

                        col.Item().PaddingTop(8).Background("#F5F5F5").Padding(10).Column(res =>
                        {
                            res.Item().Text("Total inscritos:   " + estadisticas.TotalPadron).FontSize(10);
                            res.Item().Text("Votos emitidos:    " + estadisticas.TotalVotos).FontSize(10);
                            res.Item().Text("Votos nulos:       " + estadisticas.VotosNulos).FontSize(10);
                            res.Item().Text("Sin votar:         " + estadisticas.SinVotar).FontSize(10);
                            res.Item().Text("Participación:     " + estadisticas.PorcentajeParticipacion.ToString("0.0") + "%")
                                .FontSize(10).Bold();
                        });

                        // ── Firmas ────────────────────────────────────────
                        col.Item().PaddingTop(40).Row(firmas =>
                        {
                            firmas.RelativeItem().Column(c =>
                            {
                                c.Item().BorderTop(1).BorderColor("#212121").Width(130);
                                c.Item().PaddingTop(3).Text("Administrador Electoral").FontSize(8).FontColor("#616161");
                            });
                            firmas.ConstantItem(40);
                            firmas.RelativeItem().Column(c =>
                            {
                                c.Item().BorderTop(1).BorderColor("#212121").Width(130);
                                c.Item().PaddingTop(3).Text("Testigo").FontSize(8).FontColor("#616161");
                            });
                            firmas.ConstantItem(40);
                            firmas.RelativeItem().Column(c =>
                            {
                                c.Item().BorderTop(1).BorderColor("#212121").Width(130);
                                c.Item().PaddingTop(3).Text("Sello Institucional").FontSize(8).FontColor("#616161");
                            });
                        });
                    });

                    // PIE DE PÁGINA
                    page.Footer()
                        .BorderTop(0.5f).BorderColor("#BDBDBD").PaddingTop(5)
                        .Row(footer =>
                        {
                            footer.RelativeItem()
                                .Text("Sistema Electoral Estudiantil  |  " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"))
                                .FontSize(7).FontColor("#616161");
                            footer.ConstantItem(100).AlignRight().Text(x =>
                            {
                                x.Span("Página ").FontSize(7).FontColor("#616161");
                                x.CurrentPageNumber().FontSize(7).FontColor("#616161");
                                x.Span(" de ").FontSize(7).FontColor("#616161");
                                x.TotalPages().FontSize(7).FontColor("#616161");
                            });
                        });
                })).GeneratePdf(save.FileName);

                MessageBox.Show("PDF generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(new ProcessStartInfo { FileName = save.FileName, UseShellExecute = true });
            }
            catch (Exception ex) { MostrarError(ex); }
        }

        private void btnVerIntegrantes_Click(object sender, EventArgs e)
        {
            try
            {
                var planchas = _plaSvc.GetAll().ToList();
                if (!planchas.Any())
                {
                    MessageBox.Show("No hay planchas registradas.", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                foreach (var pl in planchas)
                    pl.Miembros = _plaSvc.GetMiembros(pl.PlanchaId).ToList();
                new FrmReporteIntegrantesPlancha(planchas).ShowDialog();
            }
            catch (Exception ex) { MostrarError(ex); }
        }

        private void btnPdfIntegrantes_Click(object sender, EventArgs e)
        {
            try
            {
                var planchas = _plaSvc.GetAll().ToList();
                if (!planchas.Any())
                {
                    MessageBox.Show("No hay planchas registradas.", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                foreach (var pl in planchas)
                    pl.Miembros = _plaSvc.GetMiembros(pl.PlanchaId).ToList();

                var save = new SaveFileDialog { Filter = "PDF Files|*.pdf", FileName = "ReportePlanchas.pdf" };
                if (save.ShowDialog() != DialogResult.OK) return;

                Document.Create(c => c.Page(page =>
                {
                    page.Margin(30);
                    page.Header().Column(col =>
                    {
                        col.Item().AlignCenter().Text("REPORTE COMPLETO DE PLANCHAS").FontSize(22).Bold();
                        col.Item().AlignCenter().Text(DateTime.Now.ToString("dd/MM/yyyy HH:mm")).FontSize(10);
                    });
                    page.Content().PaddingVertical(15).Column(col =>
                    {
                        foreach (var plancha in planchas)
                        {
                            col.Item().PaddingTop(15);
                            col.Item().Background("#D9E7FF").Padding(10).Column(c =>
                            {
                                c.Item().Text("PLANCHA: " + plancha.Nombre).FontSize(16).Bold();
                                c.Item().Text("ID: " + plancha.PlanchaId);
                                if (!string.IsNullOrWhiteSpace(plancha.Descripcion))
                                    c.Item().Text("Descripción: " + plancha.Descripcion);
                            });
                            col.Item().PaddingTop(6);
                            if (plancha.Miembros != null && plancha.Miembros.Any())
                            {
                                foreach (var m in plancha.Miembros)
                                {
                                    col.Item().Border(1).BorderColor("#CCCCCC").Padding(6).Column(mc =>
                                    {
                                        mc.Item().Text("Nombre: " + m.Nombre).Bold();
                                        mc.Item().Text("Cargo: " + m.Puesto);
                                    });
                                }
                            }
                            else
                            {
                                col.Item().Text("Sin integrantes registrados.").FontColor("#616161");
                            }
                        }
                    });
                    page.Footer().AlignCenter().Text(x => { x.Span("Página "); x.CurrentPageNumber(); });
                })).GeneratePdf(save.FileName);

                MessageBox.Show("PDF generado correctamente.", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(new ProcessStartInfo { FileName = save.FileName, UseShellExecute = true });
            }
            catch (Exception ex) { MostrarError(ex); }
        }

        // ── HELPERS ───────────────────────────────────────────────
        private List<VotoDetalle> ObtenerVotoDetalle(int votacionId)
        {
            var rows = _votSvc.GetReporteGeneral(votacionId);
            var lista = new List<VotoDetalle>();
            int idx = 1;
            foreach (var r in rows)
            {
                var d = (IDictionary<string, object>)r;
                string est = Leer(d, "EstadoVoto");
                if (est == "Pendiente") continue;
                DateTime.TryParse(Leer(d, "FechaVoto"), out DateTime fecha);
                lista.Add(new VotoDetalle
                {
                    VotoId = idx++,
                    NombreVotante = Leer(d, "Participante"),
                    Matricula = Leer(d, "Matricula"),
                    Curso = Leer(d, "Curso"),
                    Seccion = Leer(d, "Seccion"),
                    PlanchaNombre = Leer(d, "PlanchaNombre"),
                    EsNulo = est == "Nulo",
                    FechaVoto = fecha == default ? DateTime.Now : fecha
                });
            }
            return lista;
        }

        private List<ParticipanteReporte> ObtenerParticipantes(int votacionId)
        {
            var rows = _votSvc.GetReporteGeneral(votacionId);
            var lista = new List<ParticipanteReporte>();
            int idx = 1;
            foreach (var r in rows)
            {
                var d = (IDictionary<string, object>)r;
                string est = Leer(d, "EstadoVoto");
                DateTime.TryParse(Leer(d, "FechaVoto"), out DateTime fecha);
                lista.Add(new ParticipanteReporte
                {
                    PadronId = idx++,
                    NombreCompleto = Leer(d, "Participante"),
                    Matricula = Leer(d, "Matricula"),
                    Curso = Leer(d, "Curso"),
                    Seccion = Leer(d, "Seccion"),
                    EstadoVoto = est == "Emitido" ? "Votó" : est == "Nulo" ? "Nulo" : "Pendiente",
                    HoraVoto = fecha != default ? fecha.ToString("HH:mm") : ""
                });
            }
            return lista;
        }

        private static string Leer(IDictionary<string, object> d, string key)
            => d != null && d.ContainsKey(key) && d[key] != null ? d[key].ToString() : "";

        private bool ValidarVotacion()
        {
            if (_votacion != null) return true;
            MessageBox.Show("No existe ninguna votación activa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private static void MostrarError(Exception ex)
            => MessageBox.Show("Error:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}