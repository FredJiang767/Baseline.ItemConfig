using AutoMapper;
using Baseline.Common.Uow.Abstractions;
using Baseline.ItemConfig.Application.DTOs;
using Baseline.ItemConfig.Domain;

namespace Baseline.ItemConfig.Application
{
    public class MasterHuntTypeService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<MasterHuntType> _mhtRepository;
        private readonly IMapper _mapper;

        public MasterHuntTypeService(IUnitOfWork uow, IRepository<MasterHuntType> mhtRepository, IMapper mapper)
        {
            _uow = uow;
            _mhtRepository = mhtRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MasterHuntTypeReadDto>> GetAll()
        {
            var items = await _mhtRepository.GetAll();
            return _mapper.Map<IEnumerable<MasterHuntTypeReadDto>>(items);
        }

        public async Task<MasterHuntTypeReadDto> Create(string name)
        {
            var item = MasterHuntType.Create(name);
            _mhtRepository.Add(item);
            await _uow.SaveChangesAsync();
            return _mapper.Map<MasterHuntTypeReadDto>(item);
        }

        public async Task<bool> Delete(Guid id)
        {
            await _mhtRepository.DeleteById(id);
            await _uow.SaveChangesAsync();
            return true;
        }
    }
}