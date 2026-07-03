using Baseline.ItemConfig.Domain;

namespace Baseline.ItemConfig.Infrastructure;

public static class DbInitializer
{
    public static void Initialize(ItemConfigDbContext context)
    {
        // Ensure database is created
        context.Database.EnsureCreated();

        // If there are any rows, assume DB has been seeded
        if (context.MasterHuntTypes.Any())
        {
            return;
        }

        var items = new List<MasterHuntType>
        {
            MasterHuntType.Create("Big Game")
        };

        context.MasterHuntTypes.AddRange(items);
        context.SaveChanges();
    }
}
