using Backend.DTOs.Resumes;
using Backend.Interfaces;
using Backend.Models;

namespace Backend.Services;

public class ResumeService : IResumeService
{
    private readonly IResumeRepository _resumeRepo;

    public ResumeService(IResumeRepository resumeRepo)
    {
        _resumeRepo = resumeRepo;
    }

    public async Task<IEnumerable<ResumeDto>> GetByUserIdAsync(int userId)
    {
        var resumes = await _resumeRepo.GetByUserIdAsync(userId);
        return resumes.Select(MapToDto);
    }

    public async Task<ResumeDto?> GetByIdAsync(int id)
    {
        var resume = await _resumeRepo.GetByIdAsync(id);
        return resume is null ? null : MapToDto(resume);
    }

    public async Task<ResumeDto> CreateAsync(CreateResumeDto dto)
    {
        var resume = new Resume
        {
            UserId = dto.UserId,
            FullName = dto.FullName,
            JobTitle = dto.JobTitle,
            Email = dto.Email,
            Phone = dto.Phone,
            Summary = dto.Summary,
            University = dto.University,
            GraduationYear = dto.GraduationYear,
            Degree = dto.Degree,
            Skills = dto.Skills
        };

        await _resumeRepo.AddAsync(resume);
        await _resumeRepo.SaveAsync();

        return MapToDto(resume);
    }

    public async Task<ResumeDto> UpdateAsync(int id, UpdateResumeDto dto)
    {
        var resume = await _resumeRepo.GetByIdAsync(id);
        if (resume is null)
            throw new KeyNotFoundException($"Resume with id {id} not found.");

        resume.FullName = dto.FullName;
        resume.JobTitle = dto.JobTitle;
        resume.Email = dto.Email;
        resume.Phone = dto.Phone;
        resume.Summary = dto.Summary;
        resume.University = dto.University;
        resume.GraduationYear = dto.GraduationYear;
        resume.Degree = dto.Degree;
        resume.Skills = dto.Skills;
        resume.UpdatedAt = DateTime.UtcNow;

        _resumeRepo.Update(resume);
        await _resumeRepo.SaveAsync();

        return MapToDto(resume);
    }

    public async Task DeleteAsync(int id)
    {
        var resume = await _resumeRepo.GetByIdAsync(id);
        if (resume is null)
            throw new KeyNotFoundException($"Resume with id {id} not found.");

        _resumeRepo.Delete(resume);
        await _resumeRepo.SaveAsync();
    }

    private static ResumeDto MapToDto(Resume r)
    {
        return new ResumeDto
        {
            Id = r.Id,
            UserId = r.UserId,
            FullName = r.FullName,
            JobTitle = r.JobTitle,
            Email = r.Email,
            Phone = r.Phone,
            Summary = r.Summary,
            University = r.University,
            GraduationYear = r.GraduationYear,
            Degree = r.Degree,
            Skills = r.Skills,
            CreatedAt = r.CreatedAt,
            UpdatedAt = r.UpdatedAt
        };
    }
}
