using Demo.Databases.Master;
using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;

namespace Demo.Extentions;

public static class DatabaseExtensions
{
    private static readonly NLogLoggerFactory LogLoggerFactory = new NLogLoggerFactory();
    private static string ConnectionString { get; set; } = string.Empty;

    public static void ConfigureMySqlContext(this IServiceCollection services, string connectionString)
    {
        ConnectionString = connectionString;
        services.AddDbContext<MasterDBContext>(o =>
        {
            // Providing details log on DataBase error
            o.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            o.EnableDetailedErrors();
            o.EnableSensitiveDataLogging();
            o.UseLoggerFactory(LogLoggerFactory);
        });
    }
    public static MasterDBContext GetDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<MasterDBContext>();
        optionsBuilder.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString));
        optionsBuilder.EnableDetailedErrors();
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.UseLoggerFactory(LogLoggerFactory);

        var context = new MasterDBContext(optionsBuilder.Options);
        context.Database.OpenConnection();

        return context;
    }
}