﻿using RevisionVR.WepApi.IHubs;
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
    private static List<string> ids = new List<string>();


    public async Task BroadcastMessage(float x, float y, float z)
    {

        if (!ids.Contains(Context.ConnectionId.ToString()))
        {
            Console.WriteLine(Context.ConnectionId);
            ids.Add(Context.ConnectionId.ToString());

            Console.WriteLine(ids[ids.Count - 1]);
        }

        Console.WriteLine(ids.IndexOf(Context.ConnectionId.ToString()));

        int id = ids.IndexOf(Context.ConnectionId.ToString());
        await Clients.Others.SendAsync("OnMessageReceived", id, x, y, z);


    }
}