using Baseline.Common.Uow.Implement;
using Baseline.ItemConfig.Domain;
using Baseline.ItemConfig.Domain.Abstractions;

namespace Baseline.ItemConfig.Infrastructure.Repositories
{
    public class MasterHuntTypeRepository : Repository<MasterHuntType>, IMasterHuntTypeRepository
    {
        public MasterHuntTypeRepository(ItemConfigDbContext dbContext) : base(dbContext)
        {
        }
    }
}
