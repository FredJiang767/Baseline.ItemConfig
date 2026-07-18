using AutoMapper;
using Baseline.Common.Uow.Abstractions;
using Baseline.ItemConfig.Application.DTOs;
using Baseline.ItemConfig.Domain;

namespace Baseline.ItemConfig.Application;

public class OutletTypeItemService
{
    private readonly IUnitOfWork _uow;
    private readonly IRepository<OutletTypeItem> _outletTypeItemRepository;
    private readonly IRepository<OutletType> _outletTypeRepository;
    private readonly IRepository<Item> _itemRepository;
    private readonly IMapper _mapper;

    public OutletTypeItemService(
        IUnitOfWork uow,
        IRepository<OutletTypeItem> outletTypeItemRepository,
        IRepository<OutletType> outletTypeRepository,
        IRepository<Item> itemRepository,
        IMapper mapper)
    {
        _uow = uow;
        _outletTypeItemRepository = outletTypeItemRepository;
        _outletTypeRepository = outletTypeRepository;
        _itemRepository = itemRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OutletTypeItemReadDto>> GetAll()
    {
        var items = await _outletTypeItemRepository.GetAll();
        return _mapper.Map<IEnumerable<OutletTypeItemReadDto>>(items);
    }

    public async Task<OutletTypeItemReadDto> Create(Guid outletTypeId, Guid itemId)
    {
        var outletType = await _outletTypeRepository.GetById(outletTypeId);
        if (outletType is null)
        {
            throw new InvalidOperationException($"OutletType {outletTypeId} does not exist.");
        }

        var item = await _itemRepository.GetById(itemId);
        if (item is null)
        {
            throw new InvalidOperationException($"Item {itemId} does not exist.");
        }

        var outletTypeItem = OutletTypeItem.Create(outletTypeId, itemId);
        _outletTypeItemRepository.Add(outletTypeItem);
        await _uow.SaveChangesAsync();
        return _mapper.Map<OutletTypeItemReadDto>(outletTypeItem);
    }

    public async Task<bool> Delete(Guid outletTypeItemId)
    {
        await _outletTypeItemRepository.DeleteById(outletTypeItemId);
        await _uow.SaveChangesAsync();
        return true;
    }
}