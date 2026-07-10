using Baseline.ItemConfig.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baseline.ItemConfig.Infrastructure.EntityConfigurations;

public class HuntTypeLicenseYearConfiguration : IEntityTypeConfiguration<HuntTypeLicenseYear>
{
    public void Configure(EntityTypeBuilder<HuntTypeLicenseYear> builder)
    {
        builder.ToTable("HuntTypeLicenseYears");

        builder.Property(x => x.Year).IsRequired();
        builder.Property(x => x.StartDate).IsRequired();
        builder.Property(x => x.EndDate).IsRequired();

        builder.HasOne(x => x.MasterHuntType)
            .WithMany(x => x.HuntTypeLicenseYears)
            .HasForeignKey(x => x.MasterHuntTypeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => new { x.MasterHuntTypeId, x.Year }).IsUnique();
    }
}
