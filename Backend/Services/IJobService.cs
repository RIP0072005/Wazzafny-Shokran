using Backend.DTOs.Jobs;

namespace Backend.Services;

public interface IJobService
{
    Task<IEnumerable<JobDto>> GetAllAsync(JobFilterDto filter);
    Task<JobDto?> GetByIdAsync(int id);
    Task<JobDto> CreateAsync(CreateJobDto dto);
    Task<JobDto> UpdateAsync(int id, CreateJobDto dto);
    Task DeleteAsync(int id);
}
