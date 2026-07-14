using System.ComponentModel.DataAnnotations;

namespace HRMangment.Application.Dtos.UserDto;
public class RegisterDTO
{
    [Required]
    public string UserName { get; set; } = string.Empty;


    [Required(ErrorMessage = "Email con't be blank")]
    [EmailAddress(ErrorMessage = "Email should be in a proper email address format")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "PhoneNumber con't be blank")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password con't be blank")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "ConfirmPassword con't be blank")]
    [Compare("Password", ErrorMessage = "Password and confirm password do not match")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
