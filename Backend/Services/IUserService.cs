using Backend.DTOs.Auth;
using Backend.DTOs.Users;

namespace Backend.Services;

public interface IUserService
{
    Task<UserDto?> GetByIdAsync(int id);
    Task<UserDto> CreateAsync(RegisterDto dto);
    Task<UserDto> UpdateAsync(int id, UpdateUserDto dto);
}
