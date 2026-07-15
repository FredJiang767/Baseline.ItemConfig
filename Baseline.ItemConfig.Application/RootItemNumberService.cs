using Baseline.Common.Uow.Abstractions;
using Baseline.ItemConfig.Application.DTOs;
using Baseline.ItemConfig.Domain;

namespace Baseline.ItemConfig.Application;

public class RootItemNumberService
{
    private readonly IUnitOfWork _uow;
    private readonly IRepository<RootItemNumber> _rootItemNumberRepository;

    public RootItemNumberService(IUnitOfWork uow, IRepository<RootItemNumber> rootItemNumberRepository)
    {
        _uow = uow;
        _rootItemNumberRepository = rootItemNumberRepository;
    }

    public async Task<IEnumerable<RootItemNumberReadDto>> GetAll()
    {
        var items = await _rootItemNumberRepository.GetAll();
        return items.Select(x => new RootItemNumberReadDto(x.RootItemNumberId, x.Number, x.Description));
    }

    public async Task<RootItemNumberReadDto> Create(string rootItemNumber, string rootItemDescription)
    {
        var item = RootItemNumber.Create(rootItemNumber, rootItemDescription);
        _rootItemNumberRepository.Add(item);
        await _uow.SaveChangesAsync();
        return new RootItemNumberReadDto(item.RootItemNumberId, item.Number, item.Description);
    }

    public async Task<bool> Delete(Guid rootItemNumberId)
    {
        await _rootItemNumberRepository.DeleteById(rootItemNumberId);
        await _uow.SaveChangesAsync();
        return true;
    }
}
