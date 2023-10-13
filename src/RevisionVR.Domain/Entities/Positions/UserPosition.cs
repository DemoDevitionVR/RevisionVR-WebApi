using RevisionVR.Domain.Commons;
using RevisionVR.Domain.Entities.Devices;

namespace RevisionVR.Domain.Entities.Positions;

public class UserPosition : Auditable
{
    public long DeviceId { get; set; }
    public Device Device { get; set; }
    public string Main { get; set; }
    public string Head { get; set; }
    public string LeftHand { get; set; }
    public string RightHand { get; set; }
}