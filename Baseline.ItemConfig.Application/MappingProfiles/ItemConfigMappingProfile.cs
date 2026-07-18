using AutoMapper;
using Baseline.ItemConfig.Application.DTOs;
using Baseline.ItemConfig.Domain;

namespace Baseline.ItemConfig.Application.MappingProfiles;

public class ItemConfigMappingProfile : Profile
{
    public ItemConfigMappingProfile()
    {
        CreateMap<MasterHuntType, MasterHuntTypeReadDto>();
        CreateMap<HuntTypeLicenseYear, HuntTypeLicenseYearReadDto>();
        CreateMap<UiTab, UiTabReadDto>();
        CreateMap<UiSubTab, UiSubTabReadDto>();
        CreateMap<OutletType, OutletTypeReadDto>();
        CreateMap<Outlet, OutletReadDto>();
        CreateMap<RootItemNumber, RootItemNumberReadDto>();
        CreateMap<Item, ItemReadDto>();
        CreateMap<OutletTypeItem, OutletTypeItemReadDto>();
    }
}