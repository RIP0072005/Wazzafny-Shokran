using Microsoft.AspNetCore.Mvc;
using Backend.DTOs.Companies;
using Backend.Services;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompaniesController : ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompaniesController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CompanyDto>>> GetAll()
    {
        var companies = await _companyService.GetAllAsync();
        return Ok(companies);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CompanyDto>> GetById(int id)
    {
        var company = await _companyService.GetByIdAsync(id);
        if (company is null)
            return NotFound();
        return Ok(company);
    }

    [HttpPost]
    public async Task<ActionResult<CompanyDto>> Create(CreateCompanyDto dto)
    {
        var company = await _companyService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = company.Id }, company);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CompanyDto>> Update(int id, CreateCompanyDto dto)
    {
        try
        {
            var company = await _companyService.UpdateAsync(id, dto);
            return Ok(company);
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
            await _companyService.DeleteAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
