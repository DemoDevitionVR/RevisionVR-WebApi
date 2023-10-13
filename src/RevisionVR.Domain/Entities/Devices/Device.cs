﻿using RevisionVR.Domain.Commons;
using RevisionVR.Domain.Entities.Positions;

namespace RevisionVR.Domain.Entities.Devices;

public class Device : Auditable
{
    public long DeviceId { get; set; }
    public bool IsActive { get; set; }
    public string? Name { get; set; }
    public ICollection<UserPosition> UserPositions { get; set; }
}