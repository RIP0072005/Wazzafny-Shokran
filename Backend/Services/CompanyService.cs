using Backend.DTOs.Companies;
using Backend.DTOs.Jobs;
using Backend.Interfaces;

namespace Backend.Services;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepo;
    private readonly IJobRepository _jobRepo;

    public CompanyService(ICompanyRepository companyRepo, IJobRepository jobRepo)
    {
        _companyRepo = companyRepo;
        _jobRepo = jobRepo;
    }

    public async Task<IEnumerable<CompanyDto>> GetAllAsync()
    {
        var companies = await _companyRepo.GetAllAsync();
        var dtos = new List<CompanyDto>();

        foreach (var c in companies)
        {
            var jobs = await _jobRepo.GetFilteredAsync(new JobFilterDto { CompanyId = c.Id });
            dtos.Add(new CompanyDto
            {
                Id = c.Id,
                Name = c.Name,
                Industry = c.Industry,
                Location = c.Location,
                Description = c.Description,
                Logo = c.Logo,
                Color = c.Color,
                OpenJobsCount = jobs.Count()
            });
        }

        return dtos;
    }

    public async Task<CompanyDto?> GetByIdAsync(int id)
    {
        var c = await _companyRepo.GetByIdAsync(id);
        if (c is null) return null;

        var jobs = await _jobRepo.GetFilteredAsync(new JobFilterDto { CompanyId = c.Id });

        return new CompanyDto
        {
            Id = c.Id,
            Name = c.Name,
            Industry = c.Industry,
            Location = c.Location,
            Description = c.Description,
            Logo = c.Logo,
            Color = c.Color,
            OpenJobsCount = jobs.Count()
        };
    }

    public async Task<CompanyDto> CreateAsync(CreateCompanyDto dto)
    {
        var company = new Models.Company
        {
            Name = dto.Name,
            Industry = dto.Industry,
            Location = dto.Location,
            Description = dto.Description,
            Logo = dto.Logo,
            Color = dto.Color,
            CreatedAt = DateTime.UtcNow
        };

        await _companyRepo.AddAsync(company);
        await _companyRepo.SaveAsync();

        return new CompanyDto
        {
            Id = company.Id,
            Name = company.Name,
            Industry = company.Industry,
            Location = company.Location,
            Description = company.Description,
            Logo = company.Logo,
            Color = company.Color,
            OpenJobsCount = 0
        };
    }

    public async Task<CompanyDto> UpdateAsync(int id, CreateCompanyDto dto)
    {
        var company = await _companyRepo.GetByIdAsync(id);
        if (company is null)
            throw new KeyNotFoundException($"Company with id {id} not found.");

        company.Name = dto.Name;
        company.Industry = dto.Industry;
        company.Location = dto.Location;
        company.Description = dto.Description;
        company.Logo = dto.Logo;
        company.Color = dto.Color;

        _companyRepo.Update(company);
        await _companyRepo.SaveAsync();

        var jobs = await _jobRepo.GetFilteredAsync(new JobFilterDto { CompanyId = company.Id });

        return new CompanyDto
        {
            Id = company.Id,
            Name = company.Name,
            Industry = company.Industry,
            Location = company.Location,
            Description = company.Description,
            Logo = company.Logo,
            Color = company.Color,
            OpenJobsCount = jobs.Count()
        };
    }

    public async Task DeleteAsync(int id)
    {
        var company = await _companyRepo.GetByIdAsync(id);
        if (company is null)
            throw new KeyNotFoundException($"Company with id {id} not found.");

        _companyRepo.Delete(company);
        await _companyRepo.SaveAsync();
    }
}
