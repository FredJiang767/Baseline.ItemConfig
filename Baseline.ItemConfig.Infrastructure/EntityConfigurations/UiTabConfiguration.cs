using Baseline.ItemConfig.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baseline.ItemConfig.Infrastructure.EntityConfigurations;

public class UiTabConfiguration : IEntityTypeConfiguration<UiTab>
{
    public void Configure(EntityTypeBuilder<UiTab> builder)
    {
        builder.ToTable("UiTab");

        builder.HasKey(x => x.UiTabId);
        builder.Property(x => x.Name).IsRequired();
    }
}
