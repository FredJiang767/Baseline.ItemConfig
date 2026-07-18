using AutoMapper;
using Baseline.Common.Uow.Abstractions;
using Baseline.ItemConfig.Application.DTOs;
using Baseline.ItemConfig.Domain;

namespace Baseline.ItemConfig.Application;

public class UiSubTabService
{
    private readonly IUnitOfWork _uow;
    private readonly IRepository<UiSubTab> _uiSubTabRepository;
    private readonly IRepository<UiTab> _uiTabRepository;
    private readonly IMapper _mapper;

    public UiSubTabService(
        IUnitOfWork uow,
        IRepository<UiSubTab> uiSubTabRepository,
        IRepository<UiTab> uiTabRepository,
        IMapper mapper)
    {
        _uow = uow;
        _uiSubTabRepository = uiSubTabRepository;
        _uiTabRepository = uiTabRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UiSubTabReadDto>> GetAll()
    {
        var items = await _uiSubTabRepository.GetAll();
        return _mapper.Map<IEnumerable<UiSubTabReadDto>>(items);
    }

    public async Task<UiSubTabReadDto> Create(string name, Guid uiTabId)
    {
        var uiTab = await _uiTabRepository.GetById(uiTabId);
        if (uiTab is null)
        {
            throw new InvalidOperationException($"UiTab {uiTabId} does not exist.");
        }

        var item = UiSubTab.Create(name, uiTabId);
        _uiSubTabRepository.Add(item);
        await _uow.SaveChangesAsync();
        return _mapper.Map<UiSubTabReadDto>(item);
    }

    public async Task<bool> Delete(Guid uiSubTabId)
    {
        await _uiSubTabRepository.DeleteById(uiSubTabId);
        await _uow.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<UiSubTabReadDto>> GetSubTabsByTabId(Guid uiTabId)
    {
        var items = await _uiSubTabRepository.GetAll();
        return _mapper.Map<IEnumerable<UiSubTabReadDto>>(items.Where(x => x.UiTabId == uiTabId));
    }
}