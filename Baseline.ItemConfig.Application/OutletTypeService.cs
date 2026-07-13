using Baseline.Common.Uow.Abstractions;
using Baseline.ItemConfig.Application.DTOs;
using Baseline.ItemConfig.Domain;

namespace Baseline.ItemConfig.Application;

public class OutletTypeService
{
    private readonly IUnitOfWork _uow;
    private readonly IRepository<OutletType> _outletTypeRepository;

    public OutletTypeService(IUnitOfWork uow, IRepository<OutletType> outletTypeRepository)
    {
        _uow = uow;
        _outletTypeRepository = outletTypeRepository;
    }

    public async Task<IEnumerable<OutletTypeReadDto>> GetAll()
    {
        var items = await _outletTypeRepository.GetAll();
        return items.Select(x => new OutletTypeReadDto(x.OutletTypeId, x.Name));
    }

    public async Task<OutletTypeReadDto> Create(string name)
    {
        var item = OutletType.Create(name);
        _outletTypeRepository.Add(item);
        await _uow.SaveChangesAsync();
        return new OutletTypeReadDto(item.OutletTypeId, item.Name);
    }

    public async Task<bool> Delete(Guid outletTypeId)
    {
        await _outletTypeRepository.DeleteById(outletTypeId);
        await _uow.SaveChangesAsync();
        return true;
    }
}
