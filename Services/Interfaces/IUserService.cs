using UserManagement.API.Application.DTOs;

namespace UserManagement.API.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserResponseDto>> GetAllAsync(CancellationToken ct = default);
    Task<UserResponseDto?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<UserResponseDto> CreateAsync(CreateUserDto dto, CancellationToken ct = default);
}
