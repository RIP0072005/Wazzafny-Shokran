using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.DTOs.Jobs;
using Backend.Interfaces;
using Backend.Models;

namespace Backend.Repositories;

public class JobRepository : Repository<Job>, IJobRepository
{
    public JobRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Job>> GetFilteredAsync(JobFilterDto filter)
    {
        var query = _context.Jobs
            .Include(j => j.Company)
            .Include(j => j.Categories)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(filter.Search))
        {
            var s = filter.Search;
            query = query.Where(j =>
                j.Title.Contains(s) ||
                (j.Description != null && j.Description.Contains(s)) ||
                (j.Skills != null && j.Skills.Contains(s)) ||
                j.Location.Contains(s) ||
                j.Company!.Name.Contains(s));
        }

        if (filter.CategoryIds != null && filter.CategoryIds.Count != 0)
            query = query.Where(j => j.Categories.Any(c => filter.CategoryIds.Contains(c.Id)));

        if (!string.IsNullOrWhiteSpace(filter.LocationType))
            query = query.Where(j => j.LocationType == filter.LocationType);

        if (filter.CompanyId.HasValue)
            query = query.Where(j => j.CompanyId == filter.CompanyId.Value);

        if (filter.MinSalary.HasValue)
            query = query.Where(j => j.Salary >= filter.MinSalary.Value);

        if (filter.MaxSalary.HasValue)
            query = query.Where(j => j.Salary <= filter.MaxSalary.Value);

        return await query.ToListAsync();
    }

    public async Task<Job?> GetJobWithDetailsAsync(int id)
    {
        return await _context.Jobs
            .Include(j => j.Company)
            .Include(j => j.Categories)
            .FirstOrDefaultAsync(j => j.Id == id);
    }
}
