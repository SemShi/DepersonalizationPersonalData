using DepersonalizationPersonalData.Serivces.DatabaseService.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using System.Data;

namespace DepersonalizationPersonalData.Serivces.DatabaseService
{
    public class PostgresDatabaseFactory : BaseDatabaseFactory
    {
        private readonly IConfiguration _cfg;
        public string? ConnectionString { get; set; }

        public PostgresDatabaseFactory(
            ILogger<PostgresDatabaseFactory> logger,
            IConfiguration cfg
        ) : base(logger)
        {
            _cfg = cfg;
            ConnectionString = _cfg.GetSection($"ConnectionStrings").GetValue<string>("Default");
        }

        protected override IDbConnection CreateConnection()
            => new NpgsqlConnection(ConnectionString);

        protected override async Task<IDbConnection> OpenConnection()
        {
            var connection = (NpgsqlConnection)CreateConnection();
            await connection.OpenAsync();
            return connection;
        }
    }
}
