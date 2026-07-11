using Backend.DTOs.Users;
using Backend.DTOs.Auth; // ???? ?? ???? ??? RegisterDto
using Backend.Interfaces;
using Backend.Models;

namespace Backend.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepo;

    public UserService(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }

    public async Task<UserDto?> GetByIdAsync(int id)
    {
        var user = await _userRepo.GetByIdAsync(id);
        return user is null ? null : MapToDto(user);
    }

    // ?????? ??????? ?????? ????????
    public async Task<UserDto> CreateAsync(RegisterDto dto)
    {
        var user = new User
        {
            // ?? ??? DTO ???? ??? Name ??? FullName? ????? ???
            FullName = dto.FullName,
            Email = dto.Email,
            // ????? ???????? ?? ?? ?? ?????? ??? ?? ???? ??? Auth ????????
            PasswordHash = dto.Password,
            Role = dto.Role ?? "graduate",
            CreatedAt = DateTime.UtcNow
        };

        await _userRepo.AddAsync(user);
        await _userRepo.SaveAsync();

        return MapToDto(user);
    }

    public async Task<UserDto> UpdateAsync(int id, UpdateUserDto dto)
    {
        var user = await _userRepo.GetByIdAsync(id);
        if (user is null)
            throw new KeyNotFoundException($"User with id {id} not found.");

        user.FullName = dto.FullName;
        user.Email = dto.Email;

        _userRepo.Update(user);
        await _userRepo.SaveAsync();

        return MapToDto(user);
    }

    private static UserDto MapToDto(User u)
    {
        return new UserDto
        {
            Id = u.Id,
            FullName = u.FullName,
            Email = u.Email,
            Role = u.Role,
            CreatedAt = u.CreatedAt
        };
    }
}