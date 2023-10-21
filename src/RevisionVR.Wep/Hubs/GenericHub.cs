using Microsoft.AspNetCore.SignalR;

namespace RevisionVR.Wep.Hubs;

public abstract class BaseHub<THub> : Hub
{ }

public class GenericHub : BaseHub<Hub>
{
    private static Dictionary<string, List<string>> PositionLists = new Dictionary<string, List<string>>();
    private static int MaxUsersPerMethod = 10;
    private const string BaseHubMethodName = "OnPositionReceived";
    private int connectedUserCount = 0;

    public async Task BroadcastPosition(float x, float y, float z)
    {
        string hubMethodName = GetHubMethodName();

        if (!PositionLists.ContainsKey(hubMethodName))
            PositionLists[hubMethodName] = new List<string>();

        if (!PositionLists[hubMethodName].Contains(Context.ConnectionId))
        {
            PositionLists[hubMethodName].Add(Context.ConnectionId);
            connectedUserCount++;

            if (connectedUserCount >= MaxUsersPerMethod)
            {
                connectedUserCount = 0; // Reset the user count
                CreateNewHubMethod();
            }
        }

        int index = PositionLists[hubMethodName].IndexOf(Context.ConnectionId);

        await Clients.Others.SendAsync(hubMethodName, index, x, y, z);
    }

    public string GetHubMethodName()
    {
        return $"{BaseHubMethodName}{PositionLists.Count + 1}";
    }

    private void CreateNewHubMethod()
    {
        string newHubMethodName = GetHubMethodName();
        PositionLists[newHubMethodName] = new List<string>();
    }
}