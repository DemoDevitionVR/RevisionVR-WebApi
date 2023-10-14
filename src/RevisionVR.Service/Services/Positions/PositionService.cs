using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RevisionVR.Service.Excaptions;
using RevisionVR.DataAccess.Contexts;
using RevisionVR.Service.DTOs.Positions;
using RevisionVR.Domain.Entities.Positions;
using RevisionVR.Service.Interfaces.Positions;

namespace RevisionVR.Service.Services.Positions;

public class PositionService : IPositionService
{
    private IMapper _mapper;
    private readonly AppDbContext _appDbContext;
    public PositionService(
        IMapper mapper,
        AppDbContext appDbContext)
    {
        this._mapper = mapper;
        _appDbContext = appDbContext;
    }

    public async Task<IEnumerable<UserPositionResultDto>> CreateAsync(UserPositionCreationDto dto)
    {
        var dbResult = await _appDbContext.Devices.FirstOrDefaultAsync(x => x.DeviceId.Equals(dto.DeviceId));

        if (dbResult is null)
            throw new DemoException(403, "Not found Device");

        var userPosition = _mapper.Map<UserPosition>(dto);
        userPosition.Device = dbResult;
        await _appDbContext.Positions.AddAsync(userPosition);
        await _appDbContext.SaveChangesAsync();

        return this.GetAll(userPosition.Id);
    }

    public async Task<IEnumerable<UserPositionResultDto>> UpdateAsync(long deviceId, UserPositionUpdateDto dto)
    {
        var dbResult = await _appDbContext.Positions
            .Include(p => p.Device)
            .FirstOrDefaultAsync(i => i.DeviceId.Equals(deviceId));
        if (dbResult is null)
            throw new DemoException(404, "Not found Device");

        var userPosition = _mapper.Map(dto, dbResult);
        userPosition.Id = deviceId;
        userPosition.UpdatedAt = DateTime.UtcNow;
        _appDbContext.Positions.Update(userPosition);
        await _appDbContext.SaveChangesAsync();

        return this.GetAll(userPosition.Id);
    }

    public async Task<bool> DeleteAsync(long deviceId)
    {
        var dbResult = await _appDbContext.Positions.FirstOrDefaultAsync(i => i.DeviceId.Equals(deviceId));
        if (dbResult is null)
            throw new DemoException(404, "Not Found Position");

        _appDbContext.Positions.Remove(dbResult);
        await _appDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<IEnumerable<UserPositionResultDto>> GetByIdAsync(long deviceId)
    {
        var dbResult = await _appDbContext.Positions.FirstOrDefaultAsync(i => i.DeviceId.Equals(deviceId));
        if (dbResult is null)
            throw new DemoException(404, "Not found User Position");

        return this.GetAll(dbResult.Id);
    }

    private IEnumerable<UserPositionResultDto> GetAll(long positionId)
    {
        var positions = _appDbContext.Positions
            .Include(p => p.Device)
            .Where(p => !p.Id.Equals(positionId) && p.Device.IsActive == true);
        return _mapper.Map<IEnumerable<UserPositionResultDto>>(positions);
    }

    public async Task<IEnumerable<UserPositionResultDto>> GetAllAsync()
    {
        var dbResult = await _appDbContext.Positions.Include(p => p.Device).ToListAsync();
        return _mapper.Map<IEnumerable<UserPositionResultDto>>(dbResult);
    }
}