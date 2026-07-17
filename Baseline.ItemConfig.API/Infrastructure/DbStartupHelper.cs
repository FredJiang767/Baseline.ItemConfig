using Microsoft.EntityFrameworkCore;

namespace Baseline.ItemConfig.API.Infrastructure;

public static class DbStartupHelper
{
    public static void MigrateAndSeedDb<TDbContext>(IServiceProvider serviceProvider, Action<TDbContext> seedAction)
        where TDbContext : DbContext
    {
        using var scope = serviceProvider.CreateScope();
        var services = scope.ServiceProvider;
        var logger = services.GetRequiredService<ILogger<TDbContext>>();

        try
        {
            var dbContext = services.GetRequiredService<TDbContext>();
            dbContext.Database.Migrate();
            seedAction.Invoke(dbContext);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while migrating or seeding the database.");
            throw;
        }
    }
}