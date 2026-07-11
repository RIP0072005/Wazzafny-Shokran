using Backend.Models;

namespace Backend.Interfaces;

public interface IApplicationRepository : IRepository<Application>
{
    Task<IEnumerable<Application>> GetByJobIdAsync(int jobId);
    Task<IEnumerable<Application>> GetByUserIdAsync(int userId);
    Task<Application?> GetWithDetailsAsync(int id);
}
