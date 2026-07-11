using Backend.DTOs.Applications;
using Backend.Interfaces;
using Backend.Models;

namespace Backend.Services;

public class ApplicationService : IApplicationService
{
    private readonly IApplicationRepository _appRepo;

    public ApplicationService(IApplicationRepository appRepo)
    {
        _appRepo = appRepo;
    }

    public async Task<IEnumerable<ApplicationDto>> GetByJobIdAsync(int jobId)
    {
        var apps = await _appRepo.GetByJobIdAsync(jobId);
        return apps.Select(MapToDto);
    }

    public async Task<IEnumerable<ApplicationDto>> GetByUserIdAsync(int userId)
    {
        var apps = await _appRepo.GetByUserIdAsync(userId);
        return apps.Select(MapToDto);
    }

    public async Task<ApplicationDto?> GetByIdAsync(int id)
    {
        var app = await _appRepo.GetWithDetailsAsync(id);
        return app is null ? null : MapToDto(app);
    }

    public async Task<ApplicationDto> CreateAsync(CreateApplicationDto dto)
    {
        var app = new Application
        {
            JobId = dto.JobId,
            UserId = dto.UserId
        };

        await _appRepo.AddAsync(app);
        await _appRepo.SaveAsync();

        var saved = await _appRepo.GetWithDetailsAsync(app.Id);
        return MapToDto(saved!);
    }

    public async Task<ApplicationDto> UpdateStatusAsync(int id, UpdateApplicationStatusDto dto)
    {
        var app = await _appRepo.GetWithDetailsAsync(id);
        if (app is null)
            throw new KeyNotFoundException($"Application with id {id} not found.");

        app.Status = dto.Status;

        _appRepo.Update(app);
        await _appRepo.SaveAsync();

        return MapToDto(app);
    }

    public async Task DeleteAsync(int id)
    {
        var app = await _appRepo.GetByIdAsync(id);
        if (app is null)
            throw new KeyNotFoundException($"Application with id {id} not found.");

        _appRepo.Delete(app);
        await _appRepo.SaveAsync();
    }

    private static ApplicationDto MapToDto(Application a)
    {
        return new ApplicationDto
        {
            Id = a.Id,
            JobId = a.JobId,
            JobTitle = a.Job?.Title ?? "",
            UserId = a.UserId,
            UserName = a.User?.FullName ?? "",
            Status = a.Status,
            CreatedAt = a.CreatedAt
        };
    }
}
