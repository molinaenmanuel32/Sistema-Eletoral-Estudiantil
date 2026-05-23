using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemaVotacion.DAL
{
    /// <summary>
    /// Provee conexiones a SQL Server
    /// </summary>
    public static class DbConnection
    {
        private static string _connectionString;

        public static void Initialize(string connectionString)
        {
            _connectionString = connectionString;

            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new InvalidOperationException(
                    "No se encontró la cadena de conexión.");
            }
        }

        public static IDbConnection GetConnection()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new InvalidOperationException(
                    "DbConnection no ha sido inicializado. Llame a Initialize() primero.");
            }

            return new SqlConnection(_connectionString);
        }
    }
}