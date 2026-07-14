using System.ComponentModel.DataAnnotations;

namespace HRMangment.Application.Dtos.UserDto;

public class LoginDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
