using Microsoft.AspNetCore.SignalR;

namespace RevisionVR.WebApi.Hubs;

public abstract class BaseHub<THub> : Hub
{ }

public class GenericHub : BaseHub<Hub>
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
        
        if (PositionLists[hubMethodName].Count == 5)
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

//using Microsoft.AspNetCore.SignalR;

//public abstract class BaseHub<THub> : Hub
//{
//}

//public class GenericHub : BaseHub<Hub>
//{
//    private static Dictionary<string, List<string>> PositionLists = new Dictionary<string, List<string>>();
//    private static int MaxUsersPerMethod = 10; 
//    private static int NumberOfMethods = 1;
//    private const string BaseHubMethodName = "OnPositionReceived";

//    public async Task BroadcastPosition(float x, float y, float z)
//    {
//        string hubMethodName = GetHubMethodName();

//        if (!PositionLists.ContainsKey(hubMethodName))
//            PositionLists[hubMethodName] = new List<string>();

//        if (!PositionLists[hubMethodName].Contains(Context.ConnectionId))
//            PositionLists[hubMethodName].Add(Context.ConnectionId);

//        int index = PositionLists[hubMethodName].IndexOf(Context.ConnectionId);

//        await Clients.Others.SendAsync(hubMethodName, index, x, y, z);

//        await Console.Out.WriteLineAsync("Name=" + hubMethodName);
//        await Console.Out.WriteLineAsync("List length=" + PositionLists[hubMethodName].Count);

//        if (PositionLists[hubMethodName].Count == MaxUsersPerMethod)
//        {
//            CreateNewHubMethod();
//        }
//    }

//    public string GetHubMethodName()
//    {
//        return $"{BaseHubMethodName}{NumberOfMethods}";
//    }

//    private void CreateNewHubMethod()
//    {
//        NumberOfMethods++;
//        // Optionally, you can clear the list for the current hub method
//        string currentHubMethodName = GetHubMethodName();
//        PositionLists[currentHubMethodName].Clear();
//    }
//}



//public class HubGenerator<THub> where THub : Hub
//{
//    private readonly IHubContext<THub> hubContext;
//    private readonly Dictionary<string, int> hubMethodCounts = new Dictionary<string, int>();
//    private readonly int maxHubMethods = 5;
//    private readonly int maxUsersPerHub = 10;

//    public HubGenerator(IHubContext<THub> hubContext)
//    {
//        this.hubContext = hubContext;
//    }

//    public async Task BroadcastPosition(float x, float y, float z)
//    {
//        string hubMethodName = GetHubMethodName();

//        if (!hubMethodCounts.ContainsKey(hubMethodName))
//            hubMethodCounts[hubMethodName] = 0;

//        hubMethodCounts[hubMethodName]++;
//        if (hubMethodCounts[hubMethodName] > maxUsersPerHub)
//        {
//            hubMethodCounts[hubMethodName] = 1;
//            await hubContext.Clients.All.SendAsync(hubMethodName, x, y, z);
//        }
//        else
//        {
//            await hubContext.Clients.All.SendAsync(hubMethodName, x, y, z);
//        }
//    }

//    public string GetHubMethodName()
//    {
//        int hubMethodCount = hubMethodCounts.Values.Sum();
//        if (hubMethodCount >= maxHubMethods)
//            return $"{typeof(THub).Name}{hubMethodCount + 1}";

//        return $"{typeof(THub).Name}{hubMethodCount}";
//    }
//}

//public class HubBase : Hub
//{
//    protected readonly HubGenerator<HubBase> hubGenerator;

//    public HubBase(HubGenerator<HubBase> hubGenerator)
//    {
//        this.hubGenerator = hubGenerator;
//    }
//}