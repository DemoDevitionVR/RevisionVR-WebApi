using RevisionVR.Service.DTOs.Positions;

namespace RevisionVR.Service.DTOs.Devices;

public class DeviceResultDto
{
    public long Id { get; set; }
    public string DeviceNumber { get; set; }
    public bool IsActive { get; set; }
    public DevicePosition? UserPosition { get; set; }
}