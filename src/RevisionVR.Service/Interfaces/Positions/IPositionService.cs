using RevisionVR.Service.DTOs.Positions;

namespace RevisionVR.Service.Interfaces.Positions;

public interface IPositionService
{
    Task<IEnumerable<UserPositionResultDto>> CreateAsync(UserPositionCreationDto dto);
    Task<IEnumerable<UserPositionResultDto>> UpdateAsync(long deviceId, UserPositionUpdateDto dto);
    Task<bool> DeleteAsync(long deviceId);
    Task<IEnumerable<UserPositionResultDto>> GetByIdAsync(long deviceId);
    Task<IEnumerable<UserPositionResultDto>> GetAllAsync();
}