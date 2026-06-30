using Backend.DTOs.Companies;

namespace Backend.Services;

public interface ICompanyService
{
    Task<IEnumerable<CompanyDto>> GetAllAsync();
    Task<CompanyDto?> GetByIdAsync(int id);
    Task<CompanyDto> CreateAsync(CreateCompanyDto dto);
    Task<CompanyDto> UpdateAsync(int id, CreateCompanyDto dto);
    Task DeleteAsync(int id);
}
