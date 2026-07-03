using Baseline.Common.Uow.Abstractions;
using Baseline.ItemConfig.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Baseline.ItemConfig.Infrastructure
{
    public class ItemConfigDbContext : DbContext, IBaseDbContext
    {
        public DbSet<MasterHuntType> MasterHuntTypes => Set<MasterHuntType>();

        public ItemConfigDbContext(DbContextOptions<ItemConfigDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        DbSet<T> IBaseDbContext.Set<T>() => base.Set<T>();
        EntityEntry<T> IBaseDbContext.Add<T>(T entity) => base.Add(entity);
        void IBaseDbContext.Update<T>(T entity) => base.Update(entity);
        Task<int> IBaseDbContext.SaveChangesAsync(CancellationToken ct)
            => base.SaveChangesAsync(ct);
    }
}
