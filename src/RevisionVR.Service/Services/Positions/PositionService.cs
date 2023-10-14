using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RevisionVR.DataAccess.IRepositories;
using RevisionVR.Domain.Entities.Devices;
using RevisionVR.Domain.Entities.Positions;
using RevisionVR.Service.DTOs.Positions;
using RevisionVR.Service.Excaptions;
using RevisionVR.Service.Interfaces.Positions;

namespace RevisionVR.Service.Services.Positions;

public class PositionService : IPositionService
{
    private IMapper _mapper;
    private IRepository<Device> _deviceRepository;
    private IRepository<UserPosition> _repository;
    public PositionService(
        IMapper mapper,
        IRepository<UserPosition> repository,
        IRepository<Device> deviseRepository)
    {
        this._mapper = mapper;
        this._repository = repository;
        this._deviceRepository = deviseRepository;
    }

    public async Task<IEnumerable<UserPositionResultDto>> CreateAsync(UserPositionCreationDto dto)
    {
        var dbResult = await _deviceRepository.SelectAsync(x => x.DeviceId.Equals(dto.DeviceId));

        if (dbResult is null)
            throw new DemoException(403, "Not found Device");

        var userPosition = _mapper.Map<UserPosition>(dto);
        userPosition.Device = dbResult;
        await _repository.CreateAsync(userPosition);
        await _repository.SaveAsync();

        return this.GetAll(userPosition.Id);


    }

    public async Task<IEnumerable<UserPositionResultDto>> UpdateAsync(long deviceId, UserPositionUpdateDto dto)
    {
        var dbResult = await _repository.SelectAsync(i => i.DeviceId.Equals(deviceId), new[] { "Device" });
        if (dbResult is null)
            throw new DemoException(404, "Not found Device");

        var userPosition = _mapper.Map(dto, dbResult);
        userPosition.Id = deviceId;
        userPosition.UpdatedAt = DateTime.UtcNow;

        await _repository.SaveAsync();

        return this.GetAll(userPosition.Id);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var dbResult = await _repository.SelectAsync(id => id.Id.Equals(id));

        if (dbResult is null)
            throw new DemoException(404, "Not Found Position");

        _repository.Delete(dbResult);
        await _repository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<UserPositionResultDto>> GetByIdAsync(long id)
    {
        var dbResult = await _repository.SelectAsync(i => i.Id.Equals(id));

        if (dbResult is null)
            throw new DemoException(404, "Not found User Position");

        return this.GetAll(dbResult.Id);
    }

    public async Task<UserPositionResultDto> GetByUserPositionIdAsync(long positionId)
    {
        var dbResult = await _repository.SelectAsync(i => i.Id.Equals(positionId));

        if (dbResult is null)
            throw new DemoException(404, "Not found User Position");

        return _mapper.Map<UserPositionResultDto>(dbResult);
    }

    private IEnumerable<UserPositionResultDto> GetAll(long positionId)
    {
        var positions = _repository.SelectAll(p => !p.Id.Equals(positionId), includes: new[] { "Device" });
        return _mapper.Map<IEnumerable<UserPositionResultDto>>(positions.Where(p => p.Device.IsActive == true).ToList());
    }

    public async Task<IEnumerable<UserPositionResultDto>> GetAllAsync()
    {
        var dbResult = await _repository.SelectAll(includes: new[] { "Device" }).ToListAsync();
        return _mapper.Map<IEnumerable<UserPositionResultDto>>(dbResult);
    }
}