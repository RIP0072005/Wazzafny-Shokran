using Microsoft.AspNetCore.Mvc;
using Backend.Interfaces;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatsController : ControllerBase
{
    private readonly IJobRepository _jobRepo;
    private readonly ICompanyRepository _companyRepo;
    private readonly ICategoryRepository _categoryRepo;
    private readonly IApplicationRepository _appRepo;
    private readonly IUserRepository _userRepo;

    public StatsController(
        IJobRepository jobRepo,
        ICompanyRepository companyRepo,
        ICategoryRepository categoryRepo,
        IApplicationRepository appRepo,
        IUserRepository userRepo)
    {
        _jobRepo = jobRepo;
        _companyRepo = companyRepo;
        _categoryRepo = categoryRepo;
        _appRepo = appRepo;
        _userRepo = userRepo;
    }

    [HttpGet]
    public async Task<ActionResult> GetStats()
    {
        var jobs = await _jobRepo.GetAllAsync();
        var companies = await _companyRepo.GetAllAsync();
        var categories = await _categoryRepo.GetAllAsync();
        var apps = await _appRepo.GetAllAsync();
        var users = await _userRepo.GetAllAsync();

        return Ok(new
        {
            totalJobs = jobs.Count(),
            totalCompanies = companies.Count(),
            totalCategories = categories.Count(),
            totalApplications = apps.Count(),
            totalUsers = users.Count()
        });
    }
}
