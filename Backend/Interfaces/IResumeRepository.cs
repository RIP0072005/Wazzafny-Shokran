using Backend.Models;

namespace Backend.Interfaces;

public interface IResumeRepository : IRepository<Resume>
{
    Task<IEnumerable<Resume>> GetByUserIdAsync(int userId);
}
