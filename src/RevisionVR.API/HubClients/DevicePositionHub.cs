using RevisionVR.API.IHubClients;
using Microsoft.AspNetCore.SignalR;

namespace RevisionVR.API.HubClients;

public class DevicePositionHub : Hub<IDevicePositionHubClient>
{ 

}