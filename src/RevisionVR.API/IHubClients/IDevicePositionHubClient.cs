using RevisionVR.Service.DTOs.Positions;

namespace RevisionVR.API.IHubClients;

public interface IDevicePositionHubClient
{
    Task SendPosition(DevicePosition position);
}