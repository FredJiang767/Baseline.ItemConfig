using AutoMapper;
using Baseline.Common.Uow.Abstractions;
using Baseline.ItemConfig.Application.DTOs;
using Baseline.ItemConfig.Domain;

namespace Baseline.ItemConfig.Application;

public class RootItemNumberService
{
    private readonly IUnitOfWork _uow;
    private readonly IRepository<RootItemNumber> _rootItemNumberRepository;
    private readonly IMapper _mapper;

    public RootItemNumberService(IUnitOfWork uow, IRepository<RootItemNumber> rootItemNumberRepository, IMapper mapper)
    {
        _uow = uow;
        _rootItemNumberRepository = rootItemNumberRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RootItemNumberReadDto>> GetAll()
    {
        var items = await _rootItemNumberRepository.GetAll();
        return _mapper.Map<IEnumerable<RootItemNumberReadDto>>(items);
    }

    public async Task<RootItemNumberReadDto> Create(string rootItemNumber, string rootItemDescription)
    {
        var item = RootItemNumber.Create(rootItemNumber, rootItemDescription);
        _rootItemNumberRepository.Add(item);
        await _uow.SaveChangesAsync();
        return _mapper.Map<RootItemNumberReadDto>(item);
    }

    public async Task<bool> Delete(Guid rootItemNumberId)
    {
        await _rootItemNumberRepository.DeleteById(rootItemNumberId);
        await _uow.SaveChangesAsync();
        return true;
    }
}