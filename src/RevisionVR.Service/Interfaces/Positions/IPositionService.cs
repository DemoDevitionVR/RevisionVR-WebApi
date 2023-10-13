using RevisionVR.Service.DTOs.Positions;

namespace RevisionVR.Service.Interfaces.Positions;

public interface IPositionService
{
    Task<IEnumerable<UserPositionResultDto>> CreateAsync(UserPositionCreationDto dto);
    Task<IEnumerable<UserPositionResultDto>> UpdateAsync(long id, UserPositionUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<UserPositionResultDto>> GetByIdAsync(long id);
    Task<UserPositionResultDto> GetByUserPositionIdAsync(long positionId);
    Task<IEnumerable<UserPositionResultDto>> GetAllAsync();
}