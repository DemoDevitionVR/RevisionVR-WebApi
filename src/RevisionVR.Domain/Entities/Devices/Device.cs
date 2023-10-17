using RevisionVR.Domain.Commons;

namespace RevisionVR.Domain.Entities.Devices;

public class Device : Auditable
{
    public string DeviceNumber { get; set; }
    public bool IsActive { get; set; }
}