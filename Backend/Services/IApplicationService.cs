using Backend.DTOs.Applications;

namespace Backend.Services;

public interface IApplicationService
{
    Task<IEnumerable<ApplicationDto>> GetByJobIdAsync(int jobId);
    Task<IEnumerable<ApplicationDto>> GetByUserIdAsync(int userId);
    Task<ApplicationDto?> GetByIdAsync(int id);
    Task<ApplicationDto> CreateAsync(CreateApplicationDto dto);
    Task<ApplicationDto> UpdateStatusAsync(int id, UpdateApplicationStatusDto dto);
    Task DeleteAsync(int id);
}
