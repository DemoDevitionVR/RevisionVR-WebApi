using Microsoft.AspNetCore.SignalR;

namespace RevisionVR.Wep.Hubs;

public class UserPositionHub : Hub
{
    public async Task SendPositionsAsync(string user, string main, string head, string leftHand,string rightHand, string device)
    {
        var callerConnectionId = Context.ConnectionId;
        var otherClients = Clients.AllExcept(callerConnectionId);
        await otherClients.SendAsync("ReceivePosition", user, main, head, leftHand, rightHand, device);
    }
}