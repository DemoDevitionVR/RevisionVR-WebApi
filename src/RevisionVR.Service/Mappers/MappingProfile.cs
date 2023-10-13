using AutoMapper;
using RevisionVR.Domain.Entities.Devices;
using RevisionVR.Domain.Entities.Positions;
using RevisionVR.Service.DTOs.Devices;
using RevisionVR.Service.DTOs.Positions;

namespace RevisionVR.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DeviceResultDto, Device>().ReverseMap();
        CreateMap<DeviceUpdateDto, Device>().ReverseMap();
        CreateMap<DeviceCreationDto, Device>().ReverseMap();

        CreateMap<UserPositionResultDto, UserPosition>().ReverseMap();
        CreateMap<UserPositionUpdateDto, UserPosition>().ReverseMap();
        CreateMap<UserPositionCreationDto, UserPosition>().ReverseMap();
    }
}