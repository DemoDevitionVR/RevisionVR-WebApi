using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RevisionVR.Service.Excaptions;
using RevisionVR.DataAccess.Contexts;
using RevisionVR.Service.DTOs.Devices;
using RevisionVR.Domain.Entities.Devices;
using RevisionVR.Service.Interfaces.Devices;

namespace RevisionVR.Service.Services.Devices;

public class DeviceService : IDeviceService
{
    private readonly IMapper _mapper;
    private readonly AppDbContext _appDbContext;
    public DeviceService(IMapper mapper, AppDbContext appDbContext)
    {
        _mapper = mapper;
        _appDbContext = appDbContext;
    }

    public async Task<DeviceResultDto> CreateAsync(DeviceCreationDto dto)
    {
        var existDevice = await _appDbContext.Devices.FirstOrDefaultAsync(d => d.DeviceId.Equals(dto.DeviceId));
        if (existDevice is not null)
            throw new DemoException(403, "This device already exists");

        var mappedDevice = _mapper.Map<Device>(dto);
        mappedDevice.IsActive = true;
        await _appDbContext.Devices.AddAsync(mappedDevice);
        await _appDbContext.SaveChangesAsync();

        return _mapper.Map<DeviceResultDto>(mappedDevice);
    }

    public async Task<DeviceResultDto> UpdateAsync(long id, DeviceUpdateDto dto)
    {
        var existDevice = await _appDbContext.Devices.FirstOrDefaultAsync(d => d.Id.Equals(id));
        if (existDevice is null)
            throw new DemoException(404, "This device is not found");

        var mappedDevice = _mapper.Map(dto, existDevice);
        _appDbContext.Devices.Update(mappedDevice);
        await _appDbContext.SaveChangesAsync();

        return _mapper.Map<DeviceResultDto>(mappedDevice);
    }
    public async Task<DeviceResultDto> UpdateIsActiveAsync(long id, bool isActive)
    {
        var existDevice = await _appDbContext.Devices.FirstOrDefaultAsync(d => d.Id.Equals(id));
        if (existDevice is null)
            throw new DemoException(404, "This device is not found");

        existDevice.Id = id;
        existDevice.IsActive = isActive;
        _appDbContext.Devices.Update(existDevice);
        await _appDbContext.SaveChangesAsync();

        return _mapper.Map<DeviceResultDto>(existDevice);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existDevice = await _appDbContext.Devices.FirstOrDefaultAsync(d => d.Id.Equals(id));
        if (existDevice is null)
            throw new DemoException(404, "This device is not found");

        _appDbContext.Devices.Remove(existDevice);
        await _appDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<DeviceResultDto> GetByIdAsync(long id)
    {
        var existDevice = await _appDbContext.Devices.FirstOrDefaultAsync(d => d.Id.Equals(id));
        if (existDevice is null)
            throw new DemoException(404, "This device is not found");

        return _mapper.Map<DeviceResultDto>(existDevice);
    }

    public async Task<IEnumerable<DeviceResultDto>> GetAllAsync()
    {
        var devices = await _appDbContext.Devices
            .AsQueryable()
            .AsNoTracking()
            .ToListAsync();
        return _mapper.Map<IEnumerable<DeviceResultDto>>(devices);
    }
}