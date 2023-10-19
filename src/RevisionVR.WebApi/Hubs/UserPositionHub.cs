using RevisionVR.WepApi.IHubs;
using Microsoft.AspNetCore.SignalR;
using RevisionVR.Service.DTOs.Positions;

namespace RevisionVR.WepApi.Hubs;

public class UserPositionHub : Hub//<IUserPositionHubClient>
{
   // public async Task SendPositionsAsync(DevicePosition dto)
  //  {
   //     var callerConnectionId = Context.ConnectionId;
     //   var otherClients = Clients.AllExcept(callerConnectionId);
       // await otherClients.SendPositionsAsync(dto);
       
    //}
    public async Task BroadcastMessage(int count, float x, float y, float z)
    {
        await Clients.Others.SendAsync("OnMessageReceived", count, x, y, z);
    }
}