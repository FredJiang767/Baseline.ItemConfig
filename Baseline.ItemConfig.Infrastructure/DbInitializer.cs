using Baseline.ItemConfig.Domain;

namespace Baseline.ItemConfig.Infrastructure;

public static class DbInitializer
{
    public static void Initialize(ItemConfigDbContext context)
    {
        context.Database.EnsureCreated();

        InitMasterHuntType(context);
        InitOutlets(context);
        InitItem(context);

        context.SaveChanges();
    }

    private static void InitItem(ItemConfigDbContext context)
    {
        var tabApplication = UiTab.Create("Applications");
        var tabPackage = UiTab.Create("Package");

        var appTab1 = UiSubTab.Create("GENERAL-SEASON", tabApplication.UiTabId);
        var appTab2 = UiSubTab.Create("LIMITED-ENTRY", tabApplication.UiTabId);

        var packageTab1 = UiSubTab.Create("Big Game", tabPackage.UiTabId);
        var packageTab2 = UiSubTab.Create("Antlerless", tabPackage.UiTabId);

        if (!context.UiTabs.Any())
        {
            context.UiTabs.AddRange(new List<UiTab>
            {
                tabApplication, tabPackage
            });

            context.UiSubTabs.AddRange(new List<UiSubTab>
            {
                appTab1,
                appTab2,
                packageTab1,
                packageTab2
            });
        }

        if (!context.RootItemNumbers.Any())
        {
            var bgDraw = RootItemNumber.Create("1000", "Big Game Draw");
            var bgApplication = RootItemNumber.Create("1100", "Big Game Application");
            var bgGS = RootItemNumber.Create("1101", "Big Game - GS - Buck Deer");
            var bgLE = RootItemNumber.Create("1103", "Big Game - LE - Buck Deer");

            var anDraw = RootItemNumber.Create("2000", "Antlerless Draw");

            context.RootItemNumbers.AddRange(new List<RootItemNumber>
            {
                bgDraw, bgApplication, bgGS, bgLE,
                anDraw
            });

            context.Items.AddRange(new List<Item>
            {
                Item.Create(2026, "1000", bgDraw.RootItemNumberId, tabPackage.UiTabId, packageTab1.UiSubTabId),
                Item.Create(2026, "GS01", bgGS.RootItemNumberId, tabApplication.UiTabId, appTab1.UiSubTabId),
                Item.Create(2026, "LE01", bgLE.RootItemNumberId, tabApplication.UiTabId, appTab1.UiSubTabId),

                Item.Create(2026, "2000", anDraw.RootItemNumberId, tabPackage.UiTabId, packageTab2.UiSubTabId)
            });
        }
    }

    private static void InitMasterHuntType(ItemConfigDbContext context)
    {
        var sportsMan = MasterHuntType.Create("Sports Man");
        var bigGame = MasterHuntType.Create("Big Game");

        if (!context.MasterHuntTypes.Any())
        {
            context.MasterHuntTypes.AddRange(new List<MasterHuntType>
            {
                sportsMan, bigGame
            });

            context.HuntTypeLicenseYears.AddRange(new List<HuntTypeLicenseYear>
            {
                //HuntTypeLicenseYear.Create(sportsMan.Id, 2026),
            });
        }
    }

    private static void InitOutlets(ItemConfigDbContext context)
    {
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
    }
}
