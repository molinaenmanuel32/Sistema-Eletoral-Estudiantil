using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using SistemaVotacion.Models;
using SistemaVotacion.Reports;

namespace SistemaVotacion.UI.Reportes
{
    public partial class FrmReporteIntegrantesPlancha : Form
    {
        // ── Datos ────────────────────────────────────────────────────
        private readonly IReadOnlyList<Plancha> _planchas;
        private Plancha _planchaActual;

        // ── Constructor ──────────────────────────────────────────────
        public FrmReporteIntegrantesPlancha(IEnumerable<Plancha> planchas, Plancha planchaInicial = null)
        {
            _planchas = (planchas ?? throw new ArgumentNullException(nameof(planchas)))
                             .OrderBy(p => p.Nombre).ToList();
            _planchaActual = planchaInicial ?? _planchas.FirstOrDefault();

            InitializeComponent();
            Text = "Reporte – Integrantes de Plancha";
        }

        // ── Load ─────────────────────────────────────────────────────
        private void FrmReporteIntegrantesPlancha_Load(object sender, EventArgs e)
        {
            CargarCombo();

            if (_planchaActual != null)
            {
                cboPlanchas.SelectedValue = _planchaActual.PlanchaId;
                CargarReporte();
            }
        }

        // ── Combo ────────────────────────────────────────────────────
        private void CargarCombo()
        {
            cboPlanchas.DataSource = _planchas.ToList();
            cboPlanchas.DisplayMember = "Nombre";
            cboPlanchas.ValueMember = "PlanchaId";
        }

        // ── Reporte ──────────────────────────────────────────────────
        private void CargarReporte()
        {
            if (_planchaActual == null) return;

            try
            {
                Cursor = Cursors.WaitCursor;
                ReportHelper.CargarReporteIntegrantesPlancha(reportViewer, _planchaActual);
                lblInfo.Text = $"Plancha: {_planchaActual.Nombre}  |  " +
                               $"Integrantes: {_planchaActual.Miembros?.Count ?? 0}";
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
        private void cboPlanchas_SelectedIndexChanged(object sender, EventArgs e)
        {
            _planchaActual = cboPlanchas.SelectedItem as Plancha;
            CargarReporte();
        }

        private void btnActualizar_Click(object sender, EventArgs e) => CargarReporte();
        private void btnCerrar_Click(object sender, EventArgs e) => Close();
    }
}