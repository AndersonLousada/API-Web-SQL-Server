using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace WEB.API.SQLSERVER.INFRA.Migrations
{
    public static class MigrationBaseSqlServer
    {
        public static void MigrationRun(this IServiceCollection service)
        {
            const string CONNECTION_STRING = "CONNECTION_STRING";
            string stringConnection = Environment.GetEnvironmentVariable(CONNECTION_STRING)!;

            service.ConfigureRunner(x =>
            {
                x.AddSqlServer()
                .WithGlobalConnectionString(stringConnection)
                .ScanIn(typeof(_20240123134201_CriarTabelaCarro).Assembly).For.Migrations();
            })
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            .BuildServiceProvider(false)
            .GetRequiredService<IMigrationRunner>()
            .MigrateUp();
        }
    }
}
