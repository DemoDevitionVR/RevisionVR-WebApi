using Microsoft.AspNetCore.Mvc;
using RevisionVR.API.Models;
using RevisionVR.Service.DTOs.Devices;
using RevisionVR.Service.Interfaces.Devices;

namespace RevisionVR.API.Controllers;

public class DevicesController : BaseController
{
    private readonly IDeviceService deviceService;
    public DevicesController(IDeviceService deviceService)
    {
        this.deviceService = deviceService;
    }
    [HttpPost("create")]
    public async ValueTask<IActionResult> PostAsync(DeviceCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.deviceService.CreateAsync(dto)
        });

    [HttpPut("update")]
    public async ValueTask<IActionResult> PutAsync(long id, DeviceUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.deviceService.UpdateAsync(id, dto)
        });

    [HttpPut("update-isActive")]
    public async ValueTask<IActionResult> UpdateIsActiveAsync(long id, bool isActive)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.deviceService.UpdateIsActiveAsync(id, isActive)
        });


    [HttpDelete("delete/{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.deviceService.DeleteAsync(id)
        });

    [HttpGet("get/{id:long}")]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.deviceService.GetByIdAsync(id)
        });

    [HttpGet("get-all")]
    public async ValueTask<IActionResult> GetAllAsync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.deviceService.GetAllAsync()
        });
}
