using Baseline.ItemConfig.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baseline.ItemConfig.Infrastructure.EntityConfigurations;

public class RootItemNumberConfiguration : IEntityTypeConfiguration<RootItemNumber>
{
    public void Configure(EntityTypeBuilder<RootItemNumber> builder)
    {
        builder.ToTable("RootItemNumber");

        builder.HasKey(x => x.RootItemNumberId);
        builder.Property(x => x.Number).IsRequired();
        builder.Property(x => x.Description).IsRequired();

        builder.HasIndex(x => x.Number).IsUnique();
    }
}
