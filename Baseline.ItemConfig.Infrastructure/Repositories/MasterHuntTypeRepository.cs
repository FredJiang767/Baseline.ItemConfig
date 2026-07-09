using Baseline.Common.Uow.Implement;
using Baseline.ItemConfig.Domain;
using Baseline.ItemConfig.Domain.Abstractions;

namespace Baseline.ItemConfig.Infrastructure.Repositories
{
    public class MasterHuntTypeRepository : Repository<MasterHuntType>, IMasterHuntTypeRepository
    {
        private readonly ItemConfigDbContext _dbContext;

        public MasterHuntTypeRepository(ItemConfigDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var entity = await _dbContext.MasterHuntTypes.FindAsync(id);
            if (entity is null)
            {
                return false;
            }

            _dbContext.MasterHuntTypes.Remove(entity);
            return true;
        }
    }
}
