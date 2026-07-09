using Baseline.Common.Uow.Abstractions;
using Baseline.ItemConfig.Domain.Abstractions;
using Baseline.ItemConfig.Application.DTOs;
using Baseline.ItemConfig.Infrastructure;
using Baseline.ItemConfig.Domain;

namespace Baseline.ItemConfig.Application
{
    public class MasterHuntTypeService
    {
        private readonly IUnitOfWork<ItemConfigDbContext> _uow;
        private readonly IMasterHuntTypeRepository _mhtRepository;

        public MasterHuntTypeService(IUnitOfWork<ItemConfigDbContext> uow, IMasterHuntTypeRepository mhtRepository)
        {
            _uow = uow;
            _mhtRepository = mhtRepository;
        }

        public async Task<IEnumerable<MasterHuntTypeReadDto>> GetAll()
        {
            var items = await _mhtRepository.GetAll();
            return items.Select(x => new MasterHuntTypeReadDto(x.Id, x.Name));
        }

        public async Task<MasterHuntTypeReadDto> Create(string name)
        {
            var item = MasterHuntType.Create(name);
            _mhtRepository.Add(item);
            await _uow.SaveChangesAsync();
            return new MasterHuntTypeReadDto(item.Id, item.Name);
        }

        public async Task<bool> Delete(Guid id)
        {
            await _mhtRepository.DeleteById(id);
            await _uow.SaveChangesAsync();
            return true;
        }
    }
}
