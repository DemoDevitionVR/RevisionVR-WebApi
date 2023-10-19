using AutoMapper;
using RevisionVR.Domain.Entities.Devices;
using RevisionVR.Service.DTOs.Devices;

namespace RevisionVR.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DeviceResultDto, Device>().ReverseMap();
        CreateMap<DeviceUpdateDto, Device>().ReverseMap();
        CreateMap<DeviceCreationDto, Device>().ReverseMap();
    }
}