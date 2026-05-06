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
    }
}
