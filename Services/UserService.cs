using Microsoft.EntityFrameworkCore;
using UserManagement.API.Application.DTOs;
using UserManagement.API.Domain.Entities;
using UserManagement.API.Infrastructure.Data;
using UserManagement.API.Services.Interfaces;

namespace UserManagement.API.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserResponseDto>> GetAllAsync(CancellationToken ct = default)
    {
        return await _context.Users
            .AsNoTracking()
            .Select(u => new UserResponseDto
            {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email,
                Role = u.Role,
                IsActive = u.IsActive,
                CreatedAt = u.CreatedAt
            })
            .ToListAsync(ct);
    }

    public async Task<UserResponseDto?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        var user = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id, ct);

        if (user is null) return null;

        return new UserResponseDto
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            Role = user.Role,
            IsActive = user.IsActive,
            CreatedAt = user.CreatedAt
        };
    }

    public async Task<UserResponseDto> CreateAsync(CreateUserDto dto, CancellationToken ct = default)
    {
        var email = dto.Email.Trim().ToLowerInvariant();

        var userExists = await _context.Users.AnyAsync(u => u.Email == email, ct);
        if (userExists)
            throw new InvalidOperationException("Email já cadastrado.");

        var user = new User
        {
            Id = Guid.NewGuid(),
            FullName = dto.FullName.Trim(),
            Email = email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            CreatedAt = DateTime.UtcNow,
            Role = "User",
            IsActive = true
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync(ct);

        return new UserResponseDto
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            Role = user.Role,
            IsActive = user.IsActive,
            CreatedAt = user.CreatedAt
        };
    }
}
