using Backend.DTOs.Jobs;
using Backend.Interfaces;
using Backend.Models;

namespace Backend.Services;

public class JobService : IJobService
{
    private readonly IJobRepository _jobRepo;
    private readonly ICategoryRepository _categoryRepo;

    public JobService(IJobRepository jobRepo, ICategoryRepository categoryRepo)
    {
        _jobRepo = jobRepo;
        _categoryRepo = categoryRepo;
    }

    public async Task<IEnumerable<JobDto>> GetAllAsync(JobFilterDto filter)
    {
        var jobs = await _jobRepo.GetFilteredAsync(filter);
        return jobs.Select(MapToDto);
    }

    public async Task<JobDto?> GetByIdAsync(int id)
    {
        var job = await _jobRepo.GetJobWithDetailsAsync(id);
        return job is null ? null : MapToDto(job);
    }

    public async Task<JobDto> CreateAsync(CreateJobDto dto)
    {
        var categories = await _categoryRepo.GetByIdsAsync(dto.CategoryIds);

        var job = new Job
        {
            Title = dto.Title,
            Description = dto.Description,
            Skills = dto.Skills,
            Location = dto.Location,
            LocationType = dto.LocationType,
            Salary = dto.Salary,
            Color = dto.Color,
            CompanyId = dto.CompanyId,
            Categories = categories
        };

        await _jobRepo.AddAsync(job);
        await _jobRepo.SaveAsync();

        var saved = await _jobRepo.GetJobWithDetailsAsync(job.Id);
        return MapToDto(saved!);
    }

    public async Task<JobDto> UpdateAsync(int id, CreateJobDto dto)
    {
        var job = await _jobRepo.GetJobWithDetailsAsync(id);
        if (job is null)
            throw new KeyNotFoundException($"Job with id {id} not found.");

        var categories = await _categoryRepo.GetByIdsAsync(dto.CategoryIds);

        job.Title = dto.Title;
        job.Description = dto.Description;
        job.Skills = dto.Skills;
        job.Location = dto.Location;
        job.LocationType = dto.LocationType;
        job.Salary = dto.Salary;
        job.Color = dto.Color;
        job.CompanyId = dto.CompanyId;
        job.Categories = categories;

        _jobRepo.Update(job);
        await _jobRepo.SaveAsync();

        var saved = await _jobRepo.GetJobWithDetailsAsync(job.Id);
        return MapToDto(saved!);
    }

    public async Task DeleteAsync(int id)
    {
        var job = await _jobRepo.GetByIdAsync(id);
        if (job is null)
            throw new KeyNotFoundException($"Job with id {id} not found.");

        _jobRepo.Delete(job);
        await _jobRepo.SaveAsync();
    }

    private static JobDto MapToDto(Job job)
    {
        return new JobDto
        {
            Id = job.Id,
            Title = job.Title,
            Description = job.Description,
            Skills = job.Skills,
            Location = job.Location,
            LocationType = job.LocationType,
            Salary = job.Salary,
            Color = job.Color,
            CreatedAt = job.CreatedAt,
            CompanyName = job.Company?.Name ?? "",
            CategoryNames = job.Categories.Select(c => c.NameAr).ToList()
        };
    }
}
