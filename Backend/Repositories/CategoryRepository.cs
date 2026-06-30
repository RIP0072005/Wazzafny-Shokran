using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Interfaces;
using Backend.Models;

namespace Backend.Repositories;

public class CategoryRepository : Repository<JobCategory>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context) { }

    public async Task<List<JobCategory>> GetByIdsAsync(List<int> ids)
    {
        return await _context.JobCategories
            .Where(c => ids.Contains(c.Id))
            .ToListAsync();
    }
}
