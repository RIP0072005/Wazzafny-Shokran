using Microsoft.AspNetCore.Mvc;
using Backend.DTOs.Resumes;
using Backend.Services;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResumesController : ControllerBase
{
    private readonly IResumeService _resumeService;

    public ResumesController(IResumeService resumeService)
    {
        _resumeService = resumeService;
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<ResumeDto>>> GetByUserId(int userId)
    {
        var resumes = await _resumeService.GetByUserIdAsync(userId);
        return Ok(resumes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ResumeDto>> GetById(int id)
    {
        var resume = await _resumeService.GetByIdAsync(id);
        if (resume is null)
            return NotFound();
        return Ok(resume);
    }

    [HttpPost]
    public async Task<ActionResult<ResumeDto>> Create(CreateResumeDto dto)
    {
        var resume = await _resumeService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = resume.Id }, resume);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ResumeDto>> Update(int id, UpdateResumeDto dto)
    {
        try
        {
            var resume = await _resumeService.UpdateAsync(id, dto);
            return Ok(resume);
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
            await _resumeService.DeleteAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
