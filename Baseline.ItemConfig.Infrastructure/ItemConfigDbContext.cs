using Baseline.Common.Uow.Implement;
using Baseline.ItemConfig.Domain;
using Microsoft.EntityFrameworkCore;

namespace Baseline.ItemConfig.Infrastructure
{
    public class ItemConfigDbContext : BaseDbContext
    {
        public DbSet<MasterHuntType> MasterHuntTypes => Set<MasterHuntType>();
        public DbSet<HuntTypeLicenseYear> HuntTypeLicenseYears => Set<HuntTypeLicenseYear>();
        public DbSet<Outlet> Outlets => Set<Outlet>();
        public DbSet<OutletType> OutletTypes => Set<OutletType>();
        public DbSet<OutletTypeItem> OutletTypeItems => Set<OutletTypeItem>();
        public DbSet<Item> Items => Set<Item>();
        public DbSet<UiTab> UiTabs => Set<UiTab>();
        public DbSet<UiSubTab> UiSubTabs => Set<UiSubTab>();

        public ItemConfigDbContext(DbContextOptions<ItemConfigDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ItemConfigDbContext).Assembly);
        }
    }
}
