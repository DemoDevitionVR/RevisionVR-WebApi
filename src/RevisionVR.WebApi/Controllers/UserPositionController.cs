using RevisionVR.WepApi.Hubs;
using RevisionVR.WepApi.IHubs;
using RevisionVR.WepApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RevisionVR.Service.DTOs.Positions;
using RevisionVR.Service.Interfaces.Positions;

namespace RevisionVR.WepApi.Controllers;

public class UserPositionController : BaseController
{
  /*  private readonly IPositionService _positionService;
    private IHubContext<UserPositionHub, IUserPositionHubClient> _hubContext;
    public UserPositionController(
        IPositionService positionService,
        IHubContext<UserPositionHub, IUserPositionHubClient> hubContext)
    {
        _hubContext = hubContext;
        _positionService = positionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var position = new DevicePosition();
        await _hubContext.Clients.All.SendPositionsAsync(position);
        return Ok(); 
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(DevicePosition position)
    {
        var callerConnectionId = HttpContext.Connection.Id;
        var otherClients = _hubContext.Clients.AllExcept(new[] { callerConnectionId });
        await otherClients.SendPositionsAsync(position);
        Console.WriteLine(position.DeviceNumber);
        Console.WriteLine(position.Name);
        Console.WriteLine(position.Head);
        Console.WriteLine(position.Main);
        Console.WriteLine(position.LeftHand);
        Console.WriteLine(position.RightHand);
        return Ok(); 
    }*/
}
