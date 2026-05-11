using Microsoft.Reporting.WinForms;
using SistemaVotacion.Models;
using SistemaVotacion.Reports;
using SistemaVotacion.UI.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SistemaVotacion.UI.Reportes
{
    public partial class FrmReporteIntegrantesPlancha : Form
    {
        private readonly IReadOnlyList<Plancha> _planchas;
        private Plancha _planchaActual;
        private readonly int _usuarioId;

        public FrmReporteIntegrantesPlancha(IEnumerable<Plancha> planchas, int usuarioId, Plancha planchaInicial = null)
        {
            _planchas = (planchas ?? throw new ArgumentNullException(nameof(planchas)))
                        .OrderBy(p => p.Nombre)
                        .ToList();

            _planchaActual = planchaInicial ?? _planchas.FirstOrDefault();
            _usuarioId = usuarioId;

            InitializeComponent();
            Text = "Reporte – Integrantes de Plancha";
        }

        private void FrmReporteIntegrantesPlancha_Load(object sender, EventArgs e)
        {
            CargarCombo();

            if (_planchaActual != null)
            {
                cboPlanchas.SelectedValue = _planchaActual.PlanchaId;
                CargarReporte();
            }
        }

        private void CargarCombo()
        {
            cboPlanchas.DataSource = _planchas;
            cboPlanchas.DisplayMember = "Nombre";
            cboPlanchas.ValueMember = "PlanchaId";
        }

        private void CargarReporte()
        {
            if (_planchaActual == null) return;

            try
            {
                Cursor = Cursors.WaitCursor;

                ReportHelper.CargarReporteIntegrantesPlancha(
                    reportViewer,
                    _planchaActual);

                lblInfo.Text =
                    $"Plancha: {_planchaActual.Nombre} | " +
                    $"Integrantes: {_planchaActual.Miembros?.Count ?? 0}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void cboPlanchas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPlanchas.SelectedItem is Plancha p)
            {
                _planchaActual = p;
                CargarReporte();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarReporte();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();

            FrmReportes menu = new FrmReportes(_usuarioId);
            menu.Show();

            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}