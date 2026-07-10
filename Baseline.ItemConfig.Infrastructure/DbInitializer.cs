using Baseline.ItemConfig.Domain;

namespace Baseline.ItemConfig.Infrastructure;

public static class DbInitializer
{
    public static void Initialize(ItemConfigDbContext context)
    {
        context.Database.EnsureCreated();

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
