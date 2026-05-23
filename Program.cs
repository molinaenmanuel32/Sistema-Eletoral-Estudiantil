using System;
using System.Configuration;
using System.Windows.Forms;
using SistemaVotacion.BLL;
using SistemaVotacion.DAL;

namespace SistemaVotacion
{
    static class Program
    {
        private static System.Windows.Forms.Timer _timerAutoExpire;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Lee la cadena desde app.config
            string connStr = ConfigurationManager.ConnectionStrings[
                "SistemaVotacion.Properties.Settings.SistemaVotacionConnectionString"
            ]?.ConnectionString;

            DbConnection.Initialize(connStr);

            // Timer de fondo: cierra automáticamente votaciones expiradas
            // y marca votos nulos cada 30 segundos
            _timerAutoExpire = new System.Windows.Forms.Timer();
            _timerAutoExpire.Interval = 30000;
            _timerAutoExpire.Tick += (s, e) =>
            {
                try { new VotacionService().CerrarVotacionesExpiradas(); }
                catch { }
            };
            _timerAutoExpire.Start();

            Application.Run(new UI.Forms.FrmL());

            _timerAutoExpire.Stop();
            _timerAutoExpire.Dispose();
        }
    }
}