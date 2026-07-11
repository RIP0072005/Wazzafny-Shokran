using Backend.DTOs.Auth;
using Backend.DTOs.Users;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> Create(RegisterDto dto)
    {
        try
        {
            var user = await _userService.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = " Failed to create user ", details = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetById(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        if (user is null)
            return NotFound();
        return Ok(user);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserDto>> Update(int id, UpdateUserDto dto)
    {
        try
        {
            var user = await _userService.UpdateAsync(id, dto);
            return Ok(user);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
