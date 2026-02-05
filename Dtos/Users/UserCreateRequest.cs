using System.ComponentModel.DataAnnotations;

namespace UserManagement.API.Dtos.Users;

public class UserCreateRequest
{
    [Required, MinLength(3), MaxLength(100)]
    public string FullName { get; set; } = default!;

    [Required, EmailAddress, MaxLength(150)]
    public string Email { get; set; } = default!;

    [Required, MinLength(6), MaxLength(100)]
    public string Password { get; set; } = default!;
}
