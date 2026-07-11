using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Interfaces;
using Backend.Models;

namespace Backend.Repositories;

public class ApplicationRepository : Repository<Application>, IApplicationRepository
{
    public ApplicationRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Application>> GetByJobIdAsync(int jobId)
    {
        return await _context.Applications
            .Where(a => a.JobId == jobId)
            .Include(a => a.Job)
            .Include(a => a.User)
            .ToListAsync();
    }

    public async Task<IEnumerable<Application>> GetByUserIdAsync(int userId)
    {
        return await _context.Applications
            .Where(a => a.UserId == userId)
            .Include(a => a.Job)
            .Include(a => a.User)
            .ToListAsync();
    }

    public async Task<Application?> GetWithDetailsAsync(int id)
    {
        return await _context.Applications
            .Include(a => a.Job)
            .Include(a => a.User)
            .FirstOrDefaultAsync(a => a.Id == id);
    }
}
