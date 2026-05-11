<<<<<<< HEAD
using System;
using System.Data;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;

namespace SistemaVotacion.DAL
{
    /// <summary>
    /// Provee conexiones a SQL Server usando la cadena del appsettings.json
    /// </summary>
    public static class DbConnection
    {
        private static string _connectionString;

        /// <summary>
        /// Lee appsettings.json con Newtonsoft.Json y almacena la cadena de conexión.
        /// </summary>
        public static void Initialize(string configFilePath)
        {
            if (!File.Exists(configFilePath))
                throw new FileNotFoundException(
                    "No se encontró el archivo de configuración: " + configFilePath);

            var json = File.ReadAllText(configFilePath);
            var obj  = JObject.Parse(json);

            _connectionString = obj["ConnectionStrings"]?["DefaultConnection"]?.Value<string>()
                ?? throw new InvalidOperationException(
                    "No se encontró la cadena de conexión 'DefaultConnection' en appsettings.json.");
        }

        public static IDbConnection GetConnection()
        {
            if (_connectionString == null)
                throw new InvalidOperationException(
                    "DbConnection no ha sido inicializado. Llame a Initialize() primero.");

            return new SqlConnection(_connectionString);
        }
=======
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
>>>>>>> f97a282cd8a81a23f2aa0816f21503305f703739
    }
}
