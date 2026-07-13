using Baseline.ItemConfig.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baseline.ItemConfig.Infrastructure.EntityConfigurations;

public class OutletTypeConfiguration : IEntityTypeConfiguration<OutletType>
{
    public void Configure(EntityTypeBuilder<OutletType> builder)
    {
        builder.ToTable("OutletType");

        builder.HasKey(x => x.OutletTypeId);
        builder.Property(x => x.Name).IsRequired();
    }
}
