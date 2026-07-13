using Baseline.ItemConfig.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baseline.ItemConfig.Infrastructure.EntityConfigurations;

public class OutletConfiguration : IEntityTypeConfiguration<Outlet>
{
    public void Configure(EntityTypeBuilder<Outlet> builder)
    {
        builder.ToTable("Outlet");

        builder.HasKey(x => x.OutletId);
        builder.Property(x => x.Name).IsRequired();

        builder.HasOne(x => x.OutletType)
            .WithMany(x => x.Outlets)
            .HasForeignKey(x => x.OutletTypeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
