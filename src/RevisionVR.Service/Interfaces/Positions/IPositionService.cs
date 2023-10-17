using RevisionVR.Service.DTOs.Devices;
using RevisionVR.Service.DTOs.Positions;

namespace RevisionVR.Service.Interfaces.Positions;

public interface IPositionService
{
    Task<IEnumerable<DeviceResultDto>> CreateAsync(DevicePosition dto);
    Task<IEnumerable<DeviceResultDto>> UpdateAsync(DevicePosition dto);
}