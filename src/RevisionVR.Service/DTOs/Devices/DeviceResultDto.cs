namespace RevisionVR.Service.DTOs.Devices;

public class DeviceResultDto
{
    public long Id { get; set; }
    public long DeviceId { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}