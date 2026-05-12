using System;
using System.IO;
using System.Windows.Forms;
using SistemaVotacion.DAL;

namespace SistemaVotacion
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Cargar configuración desde appsettings.json (usando Newtonsoft.Json)
            string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");
            DbConnection.Initialize(configPath);

            Application.Run(new UI.Forms.FrmL());
        }
    }
}
