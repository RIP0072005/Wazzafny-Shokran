using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Interfaces;
using Backend.Models;

namespace Backend.Repositories;

public class ResumeRepository : Repository<Resume>, IResumeRepository
{
    public ResumeRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Resume>> GetByUserIdAsync(int userId)
    {
        return await _context.Resumes
            .Where(r => r.UserId == userId)
            .ToListAsync();
    }
}
