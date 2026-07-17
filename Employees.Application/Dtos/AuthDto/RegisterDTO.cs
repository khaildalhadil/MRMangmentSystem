using System.ComponentModel.DataAnnotations;

namespace HRMangment.Application.Dtos.UserDto;
public class RegisterDTO: LoginDto
{

    [Required]
    [MaxLength(100)]
    [MinLength(2)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    [MinLength(2)]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "PhoneNumber con't be blank")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "ConfirmPassword con't be blank")]
    [Compare("Password", ErrorMessage = "Password and confirm password do not match")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
