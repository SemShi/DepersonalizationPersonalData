using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog.Events;
using Serilog;
using System.Text;
using DepersonalizationPersonalData.Serivces.DatabaseService;
using DepersonalizationPersonalData.Repositories.Users;
using DepersonalizationPersonalData.Repositories.UserPermissions;
using DepersonalizationPersonalData.Repositories.PersonalizeData;
using DepersonalizationPersonalData.Repositories.DcPermissions;

namespace DepersonalizationPersonalData
{
    internal static class Program
    {
        public static IServiceProvider? ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            // Serilog setup configuration
            RegisterSerilog(builder);

            Log.Logger.Information("Application starting..");

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<MainForm>());
        }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddSingleton<PostgresDatabaseFactory>();
                    services.AddSingleton<CurrentSession>();
                    services.AddSingleton<IUsersRepository, UsersRepository>();
                    services.AddSingleton<IUserPermissionsRepository, UserPermissionsRepository>();
                    services.AddSingleton<IPersonalizeDataRepository, PersonalizeDataRepository>();
                    services.AddSingleton<IDcPermissionsRepository, DcPermissionsRepository>();
                    services.AddTransient<MainForm>();
                });
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
        }

        static void RegisterSerilog(IConfigurationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.File($"{Directory.GetCurrentDirectory()}\\logs\\logs.txt",
                    rollingInterval: RollingInterval.Day,
                    encoding: Encoding.UTF8,
                    outputTemplate: "{Timestamp:HH:mm:ss:ms} [{Level:u3}] {Message}{NewLine}{Exception}",
                    restrictedToMinimumLevel: LogEventLevel.Information)
                .CreateLogger();
        }
    }
}