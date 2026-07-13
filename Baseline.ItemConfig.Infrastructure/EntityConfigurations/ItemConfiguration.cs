using Baseline.ItemConfig.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baseline.ItemConfig.Infrastructure.EntityConfigurations;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("Item");

        builder.HasKey(x => x.ItemId);
        builder.Property(x => x.ItemYear).IsRequired();
        builder.Property(x => x.ItemNumber).IsRequired();

        builder.HasOne(x => x.UiSubTab)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.UiSubTabId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.UiTab)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.UiTabId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new { x.ItemYear, x.ItemNumber }).IsUnique();
    }
}
