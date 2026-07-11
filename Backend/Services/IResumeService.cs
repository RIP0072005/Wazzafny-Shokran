using Backend.DTOs.Resumes;

namespace Backend.Services;

public interface IResumeService
{
    Task<IEnumerable<ResumeDto>> GetByUserIdAsync(int userId);
    Task<ResumeDto?> GetByIdAsync(int id);
    Task<ResumeDto> CreateAsync(CreateResumeDto dto);
    Task<ResumeDto> UpdateAsync(int id, UpdateResumeDto dto);
    Task DeleteAsync(int id);
}
