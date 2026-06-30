using Backend.DTOs.Users;

namespace Backend.Services;

public interface IUserService
{
    Task<UserDto?> GetByIdAsync(int id);
    Task<UserDto> UpdateAsync(int id, UpdateUserDto dto);
}
