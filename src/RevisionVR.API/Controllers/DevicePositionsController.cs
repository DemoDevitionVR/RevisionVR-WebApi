using RevisionVR.API.Models;
using Microsoft.AspNetCore.Mvc;
using RevisionVR.API.HubClients;
using RevisionVR.API.IHubClients;
using Microsoft.AspNetCore.SignalR;
using RevisionVR.Service.DTOs.Positions;

namespace RevisionVR.API.Controllers;

public class DevicePositionsController : BaseController
{
    private IHubContext<DevicePositionHub, IDevicePositionHubClient> _hubContext;





    public DevicePositionsController(IHubContext<DevicePositionHub, IDevicePositionHubClient> hubContext)
    {
        _hubContext = hubContext;
    }



    [HttpPost]
    public void SendPosition(DevicePosition position)
    {
        _hubContext.Clients.All.SendPosition(position);

        Console.WriteLine("position = " + position);
    }


    [HttpGet]
    public IActionResult Get()
    {
        Response response = new Response();
        DevicePosition position = new DevicePosition()
        {
            MainZ = 12f
            //Name = "warning",
            //DeviceNumber = "test message " + Guid.NewGuid().ToString()
        };
        try
        {
            _hubContext.Clients.All.SendPosition(position);
            response.StatusCode = 200;
            response.Message = "Success";
        }
        catch (Exception e)
        {
            response.StatusCode = 500;
            response.Message = e.Message;
        }
        return Ok(response);
    }


   /* [HttpPost]
    public IActionResult Post([FromBody] DevicePosition position)
    {
        Response response = new Response();
        try
        {
            _hubContext.Clients.All.SendPosition(position);
            response.StatusCode = 200;
            response.Message = "Success";
        }
        catch (Exception e)
        {
            response.StatusCode = 500;
            response.Message = e.Message;
        }
        return Ok(response);
    }*/
}