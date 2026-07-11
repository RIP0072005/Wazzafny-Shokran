using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Interfaces;
using Backend.Models;

namespace Backend.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context) { }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}
