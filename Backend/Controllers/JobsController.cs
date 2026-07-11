using Microsoft.AspNetCore.Mvc;
using Backend.DTOs.Jobs;
using Backend.Services;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobsController : ControllerBase
{
    private readonly IJobService _jobService;

    public JobsController(IJobService jobService)
    {
        _jobService = jobService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<JobDto>>> GetAll([FromQuery] JobFilterDto filter)
    {
        var jobs = await _jobService.GetAllAsync(filter);
        return Ok(jobs);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<JobDto>> GetById(int id)
    {
        var job = await _jobService.GetByIdAsync(id);
        if (job is null)
            return NotFound();
        return Ok(job);
    }

    [HttpPost]
    public async Task<ActionResult<JobDto>> Create(CreateJobDto dto)
    {
        var job = await _jobService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = job.Id }, job);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<JobDto>> Update(int id, CreateJobDto dto)
    {
        try
        {
            var job = await _jobService.UpdateAsync(id, dto);
            return Ok(job);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            await _jobService.DeleteAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
