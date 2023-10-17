using RevisionVR.Service.DTOs.Positions;

namespace RevisionVR.WepApi.IHubs;

public interface IUserPositionHubClient
{
    Task SendPositionsAsync(DevicePosition position);
}