using Baseline.ItemConfig.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baseline.ItemConfig.Infrastructure.EntityConfigurations
{
    public class MasterHuntTypeConfiguration : IEntityTypeConfiguration<MasterHuntType>
    {
        public void Configure(EntityTypeBuilder<MasterHuntType> builder)
        {
            builder.ToTable("MasterHuntTypes");
        }
    }
}
