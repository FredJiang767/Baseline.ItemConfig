using Baseline.ItemConfig.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baseline.ItemConfig.Infrastructure.EntityConfigurations;

public class UiSubTabConfiguration : IEntityTypeConfiguration<UiSubTab>
{
    public void Configure(EntityTypeBuilder<UiSubTab> builder)
    {
        builder.ToTable("UiSubTab");

        builder.HasKey(x => x.UiSubTabId);
        builder.Property(x => x.Name).IsRequired();

        builder.HasOne(x => x.UiTab)
            .WithMany(x => x.UiSubTabs)
            .HasForeignKey(x => x.UiTabId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
