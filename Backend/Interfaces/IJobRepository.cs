using Backend.DTOs.Jobs;
using Backend.Models;

namespace Backend.Interfaces;

public interface IJobRepository : IRepository<Job>
{
    Task<IEnumerable<Job>> GetFilteredAsync(JobFilterDto filter);
    Task<Job?> GetJobWithDetailsAsync(int id);
}
