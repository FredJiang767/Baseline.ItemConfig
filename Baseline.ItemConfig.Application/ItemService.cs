using Baseline.Common.Uow.Abstractions;
using Baseline.ItemConfig.Application.DTOs;
using Baseline.ItemConfig.Domain;

namespace Baseline.ItemConfig.Application;

public class ItemService
{
    private readonly IUnitOfWork _uow;
    private readonly IRepository<Item> _itemRepository;
    private readonly IRepository<RootItemNumber> _rootItemNumberRepository;
    private readonly IRepository<UiSubTab> _uiSubTabRepository;
    private readonly IRepository<UiTab> _uiTabRepository;

    public ItemService(
        IUnitOfWork uow,
        IRepository<Item> itemRepository,
        IRepository<RootItemNumber> rootItemNumberRepository,
        IRepository<UiSubTab> uiSubTabRepository,
        IRepository<UiTab> uiTabRepository)
    {
        _uow = uow;
        _itemRepository = itemRepository;
        _rootItemNumberRepository = rootItemNumberRepository;
        _uiSubTabRepository = uiSubTabRepository;
        _uiTabRepository = uiTabRepository;
    }

    public async Task<IEnumerable<ItemReadDto>> GetAll()
    {
        var items = await _itemRepository.GetAll();
        return items.Select(x => new ItemReadDto(x.ItemId, x.ItemYear, x.ItemNumber, x.RootItemNumberId, x.UiSubTabId, x.UiTabId));
    }

    public async Task<ItemReadDto> Create(int itemYear, string itemNumber, Guid rootItemNumberId, Guid uiTabId, Guid uiSubTabId)
    {
        var rootItemNumber = await _rootItemNumberRepository.GetById(rootItemNumberId);
        if (rootItemNumber is null)
        {
            throw new InvalidOperationException($"RootItemNumber {rootItemNumberId} does not exist.");
        }

        var uiSubTab = await _uiSubTabRepository.GetById(uiSubTabId);
        if (uiSubTab is null)
        {
            throw new InvalidOperationException($"UiSubTab {uiSubTabId} does not exist.");
        }

        var uiTab = await _uiTabRepository.GetById(uiTabId);
        if (uiTab is null)
        {
            throw new InvalidOperationException($"UiTab {uiTabId} does not exist.");
        }

        if (uiSubTab.UiTabId != uiTabId)
        {
            throw new InvalidOperationException("UiSubTab and UiTab relationship does not match.");
        }

        var item = Item.Create(itemYear, itemNumber, rootItemNumberId, uiTabId, uiSubTabId);
        _itemRepository.Add(item);
        await _uow.SaveChangesAsync();
        return new ItemReadDto(item.ItemId, item.ItemYear, item.ItemNumber, item.RootItemNumberId, item.UiTabId, item.UiSubTabId);
    }

    public async Task<bool> Delete(Guid itemId)
    {
        await _itemRepository.DeleteById(itemId);
        await _uow.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<ItemReadDto>> GetItemsBySubTabId(Guid uiSubTabId)
    {
        var items = await _itemRepository.GetAll();
        return items
            .Where(x => x.UiSubTabId == uiSubTabId)
            .Select(x => new ItemReadDto(x.ItemId, x.ItemYear, x.ItemNumber, x.RootItemNumberId, x.UiSubTabId, x.UiTabId));
    }
}
