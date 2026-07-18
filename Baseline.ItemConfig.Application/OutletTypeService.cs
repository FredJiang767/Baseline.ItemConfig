using AutoMapper;
using Baseline.Common.Uow.Abstractions;
using Baseline.ItemConfig.Application.DTOs;
using Baseline.ItemConfig.Domain;

namespace Baseline.ItemConfig.Application;

public class OutletTypeService
{
    private readonly IUnitOfWork _uow;
    private readonly IRepository<OutletType> _outletTypeRepository;
    private readonly IMapper _mapper;

    public OutletTypeService(IUnitOfWork uow, IRepository<OutletType> outletTypeRepository, IMapper mapper)
    {
        _uow = uow;
        _outletTypeRepository = outletTypeRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OutletTypeReadDto>> GetAll()
    {
        var items = await _outletTypeRepository.GetAll();
        return _mapper.Map<IEnumerable<OutletTypeReadDto>>(items);
    }

    public async Task<OutletTypeReadDto> Create(string name)
    {
        var item = OutletType.Create(name);
        _outletTypeRepository.Add(item);
        await _uow.SaveChangesAsync();
        return _mapper.Map<OutletTypeReadDto>(item);
    }

    public async Task<bool> Delete(Guid outletTypeId)
    {
        await _outletTypeRepository.DeleteById(outletTypeId);
        await _uow.SaveChangesAsync();
        return true;
    }
}