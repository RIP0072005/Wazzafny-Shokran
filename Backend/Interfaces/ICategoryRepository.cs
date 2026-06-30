using Backend.Models;

namespace Backend.Interfaces;

public interface ICategoryRepository : IRepository<JobCategory>
{
    Task<List<JobCategory>> GetByIdsAsync(List<int> ids);
}
