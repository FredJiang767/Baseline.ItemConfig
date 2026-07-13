using Baseline.Common.Uow.Abstractions;
using Baseline.ItemConfig.Application.DTOs;
using Baseline.ItemConfig.Domain;

namespace Baseline.ItemConfig.Application;

public class UiTabService
{
    private readonly IUnitOfWork _uow;
    private readonly IRepository<UiTab> _uiTabRepository;

    public UiTabService(IUnitOfWork uow, IRepository<UiTab> uiTabRepository)
    {
        _uow = uow;
        _uiTabRepository = uiTabRepository;
    }

    public async Task<IEnumerable<UiTabReadDto>> GetAll()
    {
        var items = await _uiTabRepository.GetAll();
        return items.Select(x => new UiTabReadDto(x.UiTabId, x.Name));
    }

    public async Task<UiTabReadDto> Create(string name)
    {
        var item = UiTab.Create(name);
        _uiTabRepository.Add(item);
        await _uow.SaveChangesAsync();
        return new UiTabReadDto(item.UiTabId, item.Name);
    }

    public async Task<bool> Delete(Guid uiTabId)
    {
        await _uiTabRepository.DeleteById(uiTabId);
        await _uow.SaveChangesAsync();
        return true;
    }
}
