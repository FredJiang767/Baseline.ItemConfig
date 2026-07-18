using AutoMapper;
using Baseline.Common.Uow.Abstractions;
using Baseline.ItemConfig.Application.DTOs;
using Baseline.ItemConfig.Domain;

namespace Baseline.ItemConfig.Application;

public class HuntTypeLicenseYearService
{
    private readonly IUnitOfWork _uow;
    private readonly IRepository<HuntTypeLicenseYear> _licenseYearRepository;
    private readonly IRepository<MasterHuntType> _mhtRepository;
    private readonly IMapper _mapper;

    public HuntTypeLicenseYearService(
        IUnitOfWork uow,
        IRepository<HuntTypeLicenseYear> licenseYearRepository,
        IRepository<MasterHuntType> mhtRepository,
        IMapper mapper)
    {
        _uow = uow;
        _licenseYearRepository = licenseYearRepository;
        _mhtRepository = mhtRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<HuntTypeLicenseYearReadDto>> GetAll(Guid? masterHuntTypeId)
    {
        var items = await _licenseYearRepository.GetAll();
        if (masterHuntTypeId.HasValue)
        {
            items = items.Where(x => x.MasterHuntTypeId == masterHuntTypeId.Value).ToList();
        }

        return _mapper.Map<IEnumerable<HuntTypeLicenseYearReadDto>>(items);
    }

    public async Task<HuntTypeLicenseYearReadDto> Create(Guid masterHuntTypeId, int year, DateTime startDate, DateTime endDate)
    {
        var mht = await _mhtRepository.GetById(masterHuntTypeId);
        if (mht is null)
        {
            throw new InvalidOperationException($"MasterHuntType {masterHuntTypeId} does not exist.");
        }

        var item = HuntTypeLicenseYear.Create(masterHuntTypeId, year, startDate, endDate);
        _licenseYearRepository.Add(item);
        await _uow.SaveChangesAsync();

        return _mapper.Map<HuntTypeLicenseYearReadDto>(item);
    }

    public async Task<bool> Delete(Guid id)
    {
        await _licenseYearRepository.DeleteById(id);
        await _uow.SaveChangesAsync();
        return true;
    }
}