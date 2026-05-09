using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RequestPigeon.Infrastructure.Persistence;

namespace RequestPigeon.Infrastructure.Seeding;

public sealed class RequestPigeonDatabaseInitializer(
    RequestPigeonDbContext dbContext,
    RequestPigeonDemoSeeder seeder,
    ILogger<RequestPigeonDatabaseInitializer> logger)
{
    public async Task InitializeAsync(CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Checking RequestPigeon database connection.");

        if (!await dbContext.Database.CanConnectAsync(cancellationToken))
        {
            logger.LogInformation("Database does not exist or is not reachable yet. EF Core will attempt to create/update it by applying migrations.");
        }

        await dbContext.Database.MigrateAsync(cancellationToken);

        logger.LogInformation("Database migration check completed.");

        await seeder.SeedIfNeededAsync(cancellationToken);

        logger.LogInformation("Database seed check completed.");
    }
}
