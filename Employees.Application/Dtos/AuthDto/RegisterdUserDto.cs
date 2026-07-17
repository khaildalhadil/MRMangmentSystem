using HRMangment.Domain.IdentityEntities;

namespace HRMangment.Application.Dtos.AuthDto;
public class RegisterdUserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public static RegisterdUserDto RegisterdUserDtoEntity(ApplicationUser user)
    {
        return new RegisterdUserDto() { 
            Id = user.Id,
            Email = user.Email, 
            FirstName = user.FirstName, 
            LastName = user.LastName 
        };
    }
}
