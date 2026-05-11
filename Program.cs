<<<<<<< HEAD
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
=======
using Microsoft.Extensions.Configuration;
using SistemaVotacion.DAL;
using SistemaVotacion.UI.Forms;

namespace SistemaVotacion;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        // Cargar configuración
        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        // Inicializar conexión
        DbConnection.Initialize(config);

        Application.Run(new FrmL());
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
    }
}
