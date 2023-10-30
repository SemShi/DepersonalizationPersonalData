using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.Odbc;

namespace DepersonalizationPersonalData.Serivces.DatabaseService.Base
{
    public abstract class BaseDatabaseFactory
    {
        private readonly ILogger<BaseDatabaseFactory> _logger;


        protected BaseDatabaseFactory(
            ILogger<BaseDatabaseFactory> logger
        )
        {
            _logger = logger;
        }

        public virtual IDbConnection Create()
        {
            _logger.LogDebug("Trying to create database connection...");

            var result = CreateConnection();

            _logger.LogInformation("Database connection created successfully");

            return result;
        }

        public virtual async Task<IDbConnection> Open()
        {
            _logger.LogDebug("Trying to open database connection...");

            var connection = await OpenConnection();

            _logger.LogInformation("Database connection opened successfully");
            return connection;
        }

        protected abstract IDbConnection CreateConnection();

        protected abstract Task<IDbConnection> OpenConnection();

        public virtual async Task<(bool, Exception?)> TestConnection()
        {
            _logger.LogDebug("Trying test database connection...");

            try
            {
                using var connection = await Open();
                connection.Close();

                _logger.LogInformation("Database connection tested successfully");
                return (true, null);
            }
            catch (OdbcException e)
            {
                string message = "";
                if (e.Message.Contains("28000"))
                    message = "Указан неверный логин или пароль.";
                else
                    message = "Источник данных не найден и не указан драйвер, используемый по умолчанию";

                _logger.LogError("Database connection not available. {Message}", message);
                return (false, e);
            }
            catch (Exception e)
            {
                _logger.LogError("Database connection not available");
                return (false, e);
            }
        }
    }
}
