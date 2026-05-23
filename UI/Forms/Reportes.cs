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
            QuestPDF.Settings.License = LicenseType.Community;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _votacion = _votSvc.GetActiva() ?? _votSvc.GetAll().FirstOrDefault();
        }

        // ═══════════════════════════════════════
        // VER REPORTE GENERAL
        // ═══════════════════════════════════════
        private void btnVerGeneral_Click(object sender, EventArgs e)
        {
            if (!ValidarVotacion()) return;

            try
            {
                var estadisticas = _votSvc.GetEstadisticas(_votacion.VotacionId);
                var votos = ObtenerVotoDetalle(_votacion.VotacionId);

                new FrmReporteGeneralVotos(estadisticas, votos, _votacion.Titulo).ShowDialog();
            }
            catch (Exception ex) { MostrarError(ex); }
        }

        // ═══════════════════════════════════════
        // PDF REPORTE GENERAL
        // ═══════════════════════════════════════
        private void btnPdfGeneral_Click(object sender, EventArgs e)
        {
            if (!ValidarVotacion()) return;

            try
            {
                SaveFileDialog save = new SaveFileDialog
                {
                    Filter = "PDF Files|*.pdf",
                    Title = "Guardar Reporte General",
                    FileName = "ReporteGeneral.pdf"
                };

                if (save.ShowDialog() != DialogResult.OK) return;

                string ruta = save.FileName;

                var estadisticas = _votSvc.GetEstadisticas(_votacion.VotacionId);
                var votos = ObtenerVotoDetalle(_votacion.VotacionId);
                var participantes = ObtenerParticipantes(_votacion.VotacionId);

                int totalParticipantes = participantes.Count;
                int totalVotaron = participantes.Count(x => x.EstadoVoto == "Votó");
                int totalPendientes = participantes.Count(x => x.EstadoVoto == "Pendiente");

                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Margin(30);

                        page.Header().Column(col =>
                        {
                            col.Item().AlignCenter().Text("LICEO SECUNDARIO").FontSize(24).Bold();
                            col.Item().AlignCenter().Text("Sistema Electoral Estudiantil").FontSize(16);
                            col.Item().PaddingTop(10).AlignCenter().Text("REPORTE GENERAL DE VOTACIÓN").FontSize(20).Bold();
                        });

                        page.Content().PaddingVertical(20).Column(col =>
                        {
                            col.Item().Text($"Votación: {_votacion.Titulo}");
                            col.Item().Text($"Fecha de generación: {DateTime.Now}");
                            col.Item().Text($"Administrador ID: {_usuarioId}");
                            col.Item().PaddingTop(20);

                            col.Item().Text("ESTADÍSTICAS GENERALES").FontSize(16).Bold();
                            col.Item().Text($"Total participantes: {totalParticipantes}");
                            col.Item().Text($"Participantes que votaron: {totalVotaron}");
                            col.Item().Text($"Pendientes por votar: {totalPendientes}");

                            if (estadisticas != null)
                            {
                                col.Item().Text($"Total votos emitidos: {estadisticas.TotalVotos}");
                                col.Item().Text($"Votos nulos: {estadisticas.VotosNulos}");
                            }

                            col.Item().PaddingTop(20);
                            col.Item().Text("RESULTADOS POR PLANCHA").FontSize(16).Bold();

                            if (estadisticas?.PorPlancha != null)
                            {
                                foreach (var p in estadisticas.PorPlancha)
                                {
                                    double porcentaje = estadisticas.TotalVotos > 0
                                        ? (double)p.TotalVotos / estadisticas.TotalVotos * 100
                                        : 0;

                                    col.Item().Text($"{p.NombrePlancha} → {p.TotalVotos} votos ({porcentaje:F1}%)");
                                }
                            }

                            col.Item().PaddingTop(20);
                            col.Item().Text("DETALLE DE VOTOS").FontSize(16).Bold();

                            foreach (var v in votos)
                            {
                                string plancha = string.IsNullOrWhiteSpace(v.PlanchaNombre)
                                    ? "VOTO NULO"
                                    : v.PlanchaNombre;

                                col.Item().Text($"{v.NombreVotante} → {plancha}");
                            }

                            col.Item().PaddingTop(20);
                            col.Item().Text("PADRÓN ELECTORAL").FontSize(16).Bold();

                            foreach (var p in participantes)
                                col.Item().Text($"{p.NombreCompleto} - {p.Curso} {p.Seccion} - {p.EstadoVoto}");

                            col.Item().PaddingTop(30);
                            col.Item().AlignCenter().Text("____________________________");
                            col.Item().AlignCenter().Text("Comisión Electoral");
                        });

                        page.Footer().AlignCenter().Text(x =>
                        {
                            x.Span("Página ");
                            x.CurrentPageNumber();
                        });
                    });
                })
                .GeneratePdf(ruta);

                MessageBox.Show("Reporte PDF generado correctamente.");
                Process.Start(new ProcessStartInfo { FileName = ruta, UseShellExecute = true });
            }
            catch (Exception ex) { MostrarError(ex); }
        }

        // ═══════════════════════════════════════
        // VER INTEGRANTES PLANCHA
        // ✅ FIX Error 4: constructor correcto, sin usuarioId innecesario
        // ═══════════════════════════════════════
        private void btnPdfPlanchas_Click(object sender, EventArgs e)
        {
            try
            {
                var planchas = _plaSvc.GetAll().ToList();

                if (planchas == null || !planchas.Any())
                {
                    MessageBox.Show("No hay planchas registradas.", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (var plancha in planchas)
                    plancha.Miembros = _plaSvc.GetMiembros(plancha.PlanchaId).ToList();

                if (!planchas.Any(p => p.Miembros != null && p.Miembros.Any()))
                {
                    MessageBox.Show("No existen integrantes registrados.", "Sin integrantes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // ✅ FIX: firma correcta (sin el segundo argumento usuarioId que no existe)
                new FrmReporteIntegrantesPlancha(planchas).ShowDialog();
            }
            catch (Exception ex) { MostrarError(ex); }
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
                string est = Leer(d, "EstadoVoto");
                DateTime.TryParse(Leer(d, "FechaVoto"), out DateTime fecha);

                lista.Add(new ParticipanteReporte
                {
                    PadronId = idx++,
                    NombreCompleto = Leer(d, "Participante"),
                    Matricula = Leer(d, "Matricula"),
                    Curso = Leer(d, "Curso"),
                    Seccion = Leer(d, "Seccion"),
                    EstadoVoto = est == "Emitido" ? "Votó"
                                   : est == "Nulo" ? "Nulo"
                                   : "Pendiente",
                    HoraVoto = fecha != default ? fecha.ToString("HH:mm") : ""
                });
            }

            return lista;
        }

        // ═══════════════════════════════════════
        // VER PADRÓN
        // ═══════════════════════════════════════
        private void btnVerPadron_Click(object sender, EventArgs e)
        {
            if (!ValidarVotacion()) return;

            try
            {
                var participantes = ObtenerParticipantes(_votacion.VotacionId);
                new FrmReporteListadoParticipantes(participantes, _votacion.Titulo).ShowDialog();
            }
            catch (Exception ex) { MostrarError(ex); }
        }

        // ═══════════════════════════════════════
        // PDF PADRÓN
        // ═══════════════════════════════════════
        private void btnPdfPadron_Click(object sender, EventArgs e)
        {
            if (!ValidarVotacion()) return;

            try
            {
                SaveFileDialog save = new SaveFileDialog
                {
                    Filter = "PDF Files|*.pdf",
                    Title = "Guardar Reporte Padrón",
                    FileName = "ReportePadron.pdf"
                };

                if (save.ShowDialog() != DialogResult.OK) return;

                string ruta = save.FileName;
                var participantes = ObtenerParticipantes(_votacion.VotacionId);

                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Margin(30);
                        page.Header().Text("REPORTE PADRÓN").FontSize(22).Bold();

                        page.Content().Column(col =>
                        {
                            col.Item().Text($"Votación: {_votacion.Titulo}");
                            col.Item().Text($"Fecha: {DateTime.Now}");
                            col.Item().PaddingTop(20);
                            col.Item().Text("LISTADO DE PARTICIPANTES").FontSize(16).Bold();

                            foreach (var p in participantes)
                                col.Item().Text($"{p.NombreCompleto} - {p.Curso} {p.Seccion} - {p.EstadoVoto}");
                        });

                        page.Footer().AlignCenter().Text(x =>
                        {
                            x.Span("Página ");
                            x.CurrentPageNumber();
                        });
                    });
                })
                .GeneratePdf(ruta);

                MessageBox.Show("PDF generado correctamente.", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(new ProcessStartInfo { FileName = ruta, UseShellExecute = true });
            }
            catch (Exception ex) { MostrarError(ex); }
        }

        // ═══════════════════════════════════════
        // VER GANADOR
        // ═══════════════════════════════════════
        private void btnVerGanador_Click(object sender, EventArgs e)
        {
            if (!ValidarVotacion()) return;

            try
            {
                var estadisticas = _votSvc.GetEstadisticas(_votacion.VotacionId);

                if (estadisticas?.PorPlancha == null || !estadisticas.PorPlancha.Any())
                {
                    MessageBox.Show("No hay datos suficientes para determinar la plancha ganadora.", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                new FrmReportePlanchaGanadora(estadisticas, _votacion.Titulo).ShowDialog();
            }
            catch (Exception ex) { MostrarError(ex); }
        }

        // ═══════════════════════════════════════
        // PDF GANADOR
        // ═══════════════════════════════════════
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

                SaveFileDialog save = new SaveFileDialog
                {
                    Filter = "PDF Files|*.pdf",
                    Title = "Guardar Reporte Ganador",
                    FileName = "ReporteGanador.pdf"
                };

                if (save.ShowDialog() != DialogResult.OK) return;

                string ruta = save.FileName;
                var ganador = estadisticas.PorPlancha.OrderByDescending(x => x.TotalVotos).FirstOrDefault();

                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Margin(30);
                        page.Header().Text("PLANCHA GANADORA").FontSize(22).Bold();

                        page.Content().Column(col =>
                        {
                            col.Item().Text($"Votación: {_votacion.Titulo}");
                            col.Item().Text($"Fecha: {DateTime.Now}");
                            col.Item().PaddingTop(20);

                            if (ganador != null)
                            {
                                col.Item().Text($"Plancha: {ganador.NombrePlancha}").FontSize(18).Bold();
                                col.Item().Text($"Total votos: {ganador.TotalVotos}");
                            }
                        });

                        page.Footer().AlignCenter().Text(x =>
                        {
                            x.Span("Página ");
                            x.CurrentPageNumber();
                        });
                    });
                })
                .GeneratePdf(ruta);

                MessageBox.Show("PDF generado correctamente.", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(new ProcessStartInfo { FileName = ruta, UseShellExecute = true });
            }
            catch (Exception ex) { MostrarError(ex); }
        }

        // ═══════════════════════════════════════
        // PDF INTEGRANTES (botón alternativo)
        // ═══════════════════════════════════════
        private void btnPdfInte_Click(object sender, EventArgs e)
        {
            try
            {
                var planchas = _plaSvc.GetAll().ToList();

                foreach (var plancha in planchas)
                    plancha.Miembros = _plaSvc.GetMiembros(plancha.PlanchaId).ToList();

                if (planchas == null || !planchas.Any())
                {
                    MessageBox.Show("No hay planchas registradas.", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SaveFileDialog save = new SaveFileDialog
                {
                    Filter = "PDF Files|*.pdf",
                    Title = "Guardar Reporte Integrantes",
                    FileName = "ReporteIntegrantesPlancha.pdf"
                };

                if (save.ShowDialog() != DialogResult.OK) return;

                string ruta = save.FileName;

                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Margin(30);
                        page.Header().Text("REPORTE DE INTEGRANTES DE PLANCHA").FontSize(22).Bold().AlignCenter();

                        page.Content().PaddingVertical(15).Column(col =>
                        {
                            col.Spacing(10);

                            foreach (var plancha in planchas)
                            {
                                col.Item().Text($"Plancha: {plancha.Nombre}").FontSize(18).Bold();

                                if (plancha.Miembros != null && plancha.Miembros.Any())
                                {
                                    foreach (var integrante in plancha.Miembros)
                                        col.Item().PaddingLeft(10).Text($"• {integrante.Nombre}");
                                }
                                else
                                {
                                    col.Item().PaddingLeft(10).Text("Sin integrantes.");
                                }

                                col.Item().PaddingBottom(15);
                            }
                        });

                        page.Footer().AlignCenter().Text(x =>
                        {
                            x.Span("Página ");
                            x.CurrentPageNumber();
                        });
                    });
                })
                .GeneratePdf(ruta);

                MessageBox.Show("PDF generado correctamente.", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(new ProcessStartInfo { FileName = ruta, UseShellExecute = true });
            }
            catch (Exception ex) { MostrarError(ex); }
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
            MessageBox.Show("No existe ninguna votación activa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private static void MostrarError(Exception ex)
        {
            MessageBox.Show("Error:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}