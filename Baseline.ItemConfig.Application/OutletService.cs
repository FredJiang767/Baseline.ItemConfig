using Baseline.Common.Uow.Abstractions;
using Baseline.ItemConfig.Application.DTOs;
using Baseline.ItemConfig.Domain;

namespace Baseline.ItemConfig.Application;

public class OutletService
{
    private readonly IUnitOfWork _uow;
    private readonly IRepository<Outlet> _outletRepository;
    private readonly IRepository<OutletType> _outletTypeRepository;

    public OutletService(
        IUnitOfWork uow,
        IRepository<Outlet> outletRepository,
        IRepository<OutletType> outletTypeRepository)
    {
        _uow = uow;
        _outletRepository = outletRepository;
        _outletTypeRepository = outletTypeRepository;
    }

    public async Task<IEnumerable<OutletReadDto>> GetAll()
    {
        var items = await _outletRepository.GetAll();
        return items.Select(x => new OutletReadDto(x.OutletId, x.Name, x.OutletTypeId));
    }

    public async Task<OutletReadDto> Create(string name, Guid outletTypeId)
    {
        var outletType = await _outletTypeRepository.GetById(outletTypeId);
        if (outletType is null)
        {
            throw new InvalidOperationException($"OutletType {outletTypeId} does not exist.");
        }

        var item = Outlet.Create(name, outletTypeId);
        _outletRepository.Add(item);
        await _uow.SaveChangesAsync();
        return new OutletReadDto(item.OutletId, item.Name, item.OutletTypeId);
    }

    public async Task<bool> Delete(Guid outletId)
    {
        await _outletRepository.DeleteById(outletId);
        await _uow.SaveChangesAsync();
        return true;
    }
}
