using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RequestPigeon.Infrastructure.Persistence;
using RequestPigeon.Infrastructure.Seeding;

namespace RequestPigeon.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("RequestPigeonDb")
            ?? throw new InvalidOperationException("Connection string 'RequestPigeonDb' was not found.");

        services.AddSingleton<AuditableEntitySaveChangesInterceptor>();

        services.AddDbContext<RequestPigeonDbContext>((serviceProvider, options) =>
        {
            options.UseSqlServer(connectionString);
            options.AddInterceptors(serviceProvider.GetRequiredService<AuditableEntitySaveChangesInterceptor>());
        });

        services.AddScoped<RequestPigeonDatabaseInitializer>();
        services.AddScoped<RequestPigeonDemoSeeder>();

        return services;
    }
}
