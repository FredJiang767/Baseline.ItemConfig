using AutoMapper;
using Baseline.Common.Uow.Abstractions;
using Baseline.ItemConfig.Application.DTOs;
using Baseline.ItemConfig.Domain;

namespace Baseline.ItemConfig.Application;

public class UiTabService
{
    private readonly IUnitOfWork _uow;
    private readonly IRepository<UiTab> _uiTabRepository;
    private readonly IMapper _mapper;

    public UiTabService(IUnitOfWork uow, IRepository<UiTab> uiTabRepository, IMapper mapper)
    {
        _uow = uow;
        _uiTabRepository = uiTabRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UiTabReadDto>> GetAll()
    {
        var items = await _uiTabRepository.GetAll();
        return _mapper.Map<IEnumerable<UiTabReadDto>>(items);
    }

    public async Task<UiTabReadDto> Create(string name)
    {
        var item = UiTab.Create(name);
        _uiTabRepository.Add(item);
        await _uow.SaveChangesAsync();
        return _mapper.Map<UiTabReadDto>(item);
    }

    public async Task<bool> Delete(Guid uiTabId)
    {
        await _uiTabRepository.DeleteById(uiTabId);
        await _uow.SaveChangesAsync();
        return true;
    }
}