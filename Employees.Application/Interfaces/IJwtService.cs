
using HRMangment.Application.Dtos.AuthDto;
using HRMangment.Domain.IdentityEntities;

namespace HRMangment.Application.Interfaces;

public interface IJwtService
{
    AuthenticationResponse CreateJwtToken(ApplicationUser user);
}
