using Microsoft.AspNetCore.SignalR;

namespace RevisionVR.WepApi.Hubs;

public class DevicePositionHub : Hub
{
    private static Dictionary<string, List<string>> PositionLists = new Dictionary<string, List<string>>();
    private static int NumberOfMethodName = 1;
    private const string BaseHubMethodName = "OnPositionReceived";

    public async Task BroadcastPosition(float x, float y, float z)
    {
        string hubMethodName = GetHubMethodName();

        if (!PositionLists.ContainsKey(hubMethodName))
            PositionLists[hubMethodName] = new List<string>();

        if (!PositionLists[hubMethodName].Contains(Context.ConnectionId))
            PositionLists[hubMethodName].Add(Context.ConnectionId);

        int index = PositionLists[hubMethodName].IndexOf(Context.ConnectionId);

        await Clients.Others.SendAsync(hubMethodName, index, x, y, z);
        if (PositionLists[hubMethodName].Count == 2)
        {
            NumberOfMethodName++;
            if (PositionLists[hubMethodName].Count == 0)
                PositionLists[hubMethodName].Clear();

            string newHubMethodName = GetHubMethodName();
            PositionLists[newHubMethodName] = new List<string>();
        }
    }

    public string GetHubMethodName()
    {
        return $"{BaseHubMethodName}{NumberOfMethodName}";
    }
}