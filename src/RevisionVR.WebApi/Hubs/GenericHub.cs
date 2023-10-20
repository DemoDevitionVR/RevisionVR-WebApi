using Microsoft.AspNetCore.SignalR;

public class HubGenerator<THub> where THub : Hub
{
    private readonly IHubContext<THub> hubContext;
    private readonly Dictionary<string, int> hubMethodCounts = new Dictionary<string, int>();
    private readonly int maxHubMethods = 5;
    private readonly int maxUsersPerHub = 10;

    public HubGenerator(IHubContext<THub> hubContext)
    {
        this.hubContext = hubContext;
    }

    public async Task BroadcastPosition(float x, float y, float z)
    {
        string hubMethodName = GetHubMethodName();

        if (!hubMethodCounts.ContainsKey(hubMethodName))
            hubMethodCounts[hubMethodName] = 0;
        
        hubMethodCounts[hubMethodName]++;
        if (hubMethodCounts[hubMethodName] > maxUsersPerHub)
        {
            hubMethodCounts[hubMethodName] = 1;
            await hubContext.Clients.All.SendAsync(hubMethodName, x, y, z);
        }
        else
        {
            await hubContext.Clients.All.SendAsync(hubMethodName, x, y, z);
        }
    }

    public string GetHubMethodName()
    {
        int hubMethodCount = hubMethodCounts.Values.Sum();
        if (hubMethodCount >= maxHubMethods)
            return $"{typeof(THub).Name}{hubMethodCount + 1}";
        
        return $"{typeof(THub).Name}{hubMethodCount}";
    }
}

public class HubBase : Hub
{
    protected readonly HubGenerator<HubBase> hubGenerator;

    public HubBase(HubGenerator<HubBase> hubGenerator)
    {
        this.hubGenerator = hubGenerator;
    }
}