using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RequestPigeon.Infrastructure.Persistence;

public sealed class RequestPigeonDbContextFactory : IDesignTimeDbContextFactory<RequestPigeonDbContext>
{
    private const string DesignTimeConnectionString =
        "Server=192.168.50.44,1433;Database=RequestPigeonDb;User Id=RequestPigeonApp;Password=n?yZOAMjLouv9Ph;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True";

    public RequestPigeonDbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<RequestPigeonDbContext>()
            .UseSqlServer(DesignTimeConnectionString)
            .Options;

        return new RequestPigeonDbContext(options);
    }
}
