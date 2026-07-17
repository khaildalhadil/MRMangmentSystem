using System.ComponentModel.DataAnnotations;

namespace HRMangment.Application.Dtos.UserDto;

public class LoginDto
{


    [Required(ErrorMessage = "Email con't be blank")]
    [EmailAddress(ErrorMessage = "Email should be in a proper email address format")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password con't be blank")]
    public string Password { get; set; } = string.Empty;
}
