using Baseline.ItemConfig.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baseline.ItemConfig.Infrastructure.EntityConfigurations;

public class OutletTypeItemConfiguration : IEntityTypeConfiguration<OutletTypeItem>
{
    public void Configure(EntityTypeBuilder<OutletTypeItem> builder)
    {
        builder.ToTable("OutletTypeItem");

        builder.HasKey(x => x.OutletTypeItemId);

        builder.HasOne(x => x.OutletType)
            .WithMany(x => x.OutletTypeItems)
            .HasForeignKey(x => x.OutletTypeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Item)
            .WithMany(x => x.OutletTypeItems)
            .HasForeignKey(x => x.ItemId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => new { x.OutletTypeId, x.ItemId }).IsUnique();
    }
}
