using Microsoft.AspNetCore.Mvc;
using Backend.DTOs.Applications;
using Backend.Services;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApplicationsController : ControllerBase
{
    private readonly IApplicationService _appService;

    public ApplicationsController(IApplicationService appService)
    {
        _appService = appService;
    }

    [HttpGet("job/{jobId}")]
    public async Task<ActionResult<IEnumerable<ApplicationDto>>> GetByJobId(int jobId)
    {
        var apps = await _appService.GetByJobIdAsync(jobId);
        return Ok(apps);
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<ApplicationDto>>> GetByUserId(int userId)
    {
        var apps = await _appService.GetByUserIdAsync(userId);
        return Ok(apps);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApplicationDto>> GetById(int id)
    {
        var app = await _appService.GetByIdAsync(id);
        if (app is null)
            return NotFound();
        return Ok(app);
    }

    [HttpPost]
    public async Task<ActionResult<ApplicationDto>> Create(CreateApplicationDto dto)
    {
        var app = await _appService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = app.Id }, app);
    }

    [HttpPatch("{id}/status")]
    public async Task<ActionResult<ApplicationDto>> UpdateStatus(int id, UpdateApplicationStatusDto dto)
    {
        try
        {
            var app = await _appService.UpdateStatusAsync(id, dto);
            return Ok(app);
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
            await _appService.DeleteAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
