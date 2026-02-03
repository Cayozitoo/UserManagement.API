using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagement.API.Application.DTOs;
using UserManagement.API.Domain.Entities;
using UserManagement.API.Infrastructure.Data;
using BCrypt.Net;
using Microsoft.AspNetCore.Authorization;


namespace UserManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {   
    private readonly AppDbContext _context;

    public UsersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [AllowAnonymous] 
    public async Task<IActionResult> Create(CreateUserDto dto)
    {
        var userExists = await _context.Users.AnyAsync(u => u.Email == dto.Email);
        if (userExists)
            return BadRequest("Email já cadastrado.");

        var user = new User
        {
            Id = Guid.NewGuid(),
            FullName = dto.FullName,
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            CreatedAt = DateTime.UtcNow
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = user.Id }, new UserResponseDto
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            Role = user.Role,
            IsActive = user.IsActive,
            CreatedAt = user.CreatedAt
        });
    }

   [HttpGet]
public async Task<IActionResult> GetAll()
{
    var users = await _context.Users
        .Select(u => new UserResponseDto
        {
            Id = u.Id,
            FullName = u.FullName,
            Email = u.Email,
            Role = u.Role,
            IsActive = u.IsActive,
            CreatedAt = u.CreatedAt
        })
        .ToListAsync();

    return Ok(users);
}

[HttpGet("{id}")]
public async Task<IActionResult> GetById(Guid id)
{
    var user = await _context.Users.FindAsync(id);
    if (user == null)
        return NotFound();

    return Ok(new UserResponseDto
    {
        Id = user.Id,
        FullName = user.FullName,
        Email = user.Email,
        Role = user.Role,
        IsActive = user.IsActive,
        CreatedAt = user.CreatedAt
    });
    }   

    }
}
