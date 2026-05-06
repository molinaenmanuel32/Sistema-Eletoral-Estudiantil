using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace SistemaVotacion.DAL;

/// <summary>
/// Provee conexiones a SQL Server usando la cadena del appsettings.json
/// </summary>
public static class DbConnection
{
    private static string? _connectionString;

    public static void Initialize(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("No se encontró la cadena de conexión 'DefaultConnection'.");
    }

    public static IDbConnection GetConnection()
    {
        if (_connectionString is null)
            throw new InvalidOperationException("DbConnection no ha sido inicializado. Llame a Initialize() primero.");

        return new SqlConnection(_connectionString);
    }
}
