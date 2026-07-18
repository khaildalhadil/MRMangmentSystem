using HRMangment.Application.Dtos.AuthDto;
using HRMangment.Application.Interfaces;
using HRMangment.Domain.IdentityEntities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HRMangment.Infrastructure.Services;


public class JwtService(IConfiguration configuration) : IJwtService
{
    private readonly IConfiguration _configuration = configuration;
    public AuthenticationResponse CreateJwtToken(ApplicationUser user)
    {
        DateTime expiration = 
            DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:EXPIRATION_MINUTES"]));


        Claim[] claims = new Claim[]
        {
            // Subject (user id)
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            
            // id for token
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            
            // date we create token
            new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString() ),

            // unique name identifier of the user (Email)
            new Claim(ClaimTypes.NameIdentifier, user.Email),

            // name of the user
            new Claim(ClaimTypes.Name, user.FirstName),

            // user rols
            new Claim(ClaimTypes.Role, user.Role),
        };


        SymmetricSecurityKey securityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])
            );

        SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken tokenGenerateor = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: expiration,
            signingCredentials: signingCredentials

            );

        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        string token = handler.WriteToken(tokenGenerateor);

        return new AuthenticationResponse() { 
            Token = token , 
            Email = user.Email, 
            PersonName = user.FirstName, 
            Expiration=expiration 
        };


    }

}
