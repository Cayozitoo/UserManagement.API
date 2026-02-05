using System.ComponentModel.DataAnnotations;

namespace UserManagement.API.Dtos.Users;

public class UserUpdateRequest
{
    [Required, MinLength(3), MaxLength(100)]
    public string FullName { get; set; } = default!;

    // Se quiser permitir mudar status/role via update:
    public string? Role { get; set; }
    public bool? IsActive { get; set; }
}
