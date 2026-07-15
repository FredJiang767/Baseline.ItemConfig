using Baseline.ItemConfig.Domain;

namespace Baseline.ItemConfig.Infrastructure;

public static class DbInitializer
{
    public static void Initialize(ItemConfigDbContext context)
    {
        context.Database.EnsureCreated();

        if (!context.MasterHuntTypes.Any())
        {
            context.MasterHuntTypes.AddRange(new List<MasterHuntType>
            {
                MasterHuntType.Create("Sports Man"),
                MasterHuntType.Create("Big Game")
            });
        }

        if (!context.OutletTypes.Any())
        {
            var internet = OutletType.Create("Internet");
            var telephone = OutletType.Create("Telephone");

            context.OutletTypes.AddRange(new List<OutletType>
            {
                internet,
                telephone
            });

            context.Outlets.AddRange(new List<Outlet>
            {
                Outlet.Create("Internet Outlet", internet.OutletTypeId),
                Outlet.Create("Telephone Outlet", telephone.OutletTypeId),
            });
        }


        var tab = UiTab.Create("Applications");
        var subTab1 = UiSubTab.Create("GENERAL-SEASON", tab.UiTabId);
        var subTab2 = UiSubTab.Create("LIMITED-ENTRY", tab.UiTabId);

        if (!context.UiTabs.Any())
        {
            context.UiTabs.AddRange(new List<UiTab>
            {
                tab
            });

            context.UiSubTabs.AddRange(new List<UiSubTab>
            {
                subTab1,
                subTab2
            });
        }

        if (!context.RootItemNumbers.Any())
        {
            var bg = RootItemNumber.Create("1000", "Big Game Draw");
            var bg2 = RootItemNumber.Create("1100", "Big Game Application");
            var bg3 = RootItemNumber.Create("1101", "Big Game - GS - Buck Deer");
            var bg4 = RootItemNumber.Create("1103", "Big Game - LE - Buck Deer");

            context.RootItemNumbers.AddRange(new List<RootItemNumber>
            {
                bg, bg2, bg3, bg4
            });

            context.Items.AddRange(new List<Item>
            {
                Item.Create(2026, "GS01", bg3.RootItemNumberId, tab.UiTabId, subTab1.UiSubTabId),
                Item.Create(2026, "LE01", bg4.RootItemNumberId, tab.UiTabId, subTab1.UiSubTabId)
            });
        }

        context.SaveChanges();
    }
}
