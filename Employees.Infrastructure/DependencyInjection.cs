using HRMangment.Application.Interfaces;
using HRMangment.Infrastructure.Database;
using HRMangment.Infrastructure.services;
using HRMangment.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRMangment.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EmpDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IJwtService, JwtService>();

        //services.AddAuthentication()
        //    .AddJwtBearer(options =>
        //    {
        //        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        //        {
        //            ValidateIssuer = false,
        //            ValidateAudience = false,
        //            ValidateLifetime = true,
        //            ValidateIssuerSigningKey = true,
        //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? string.Empty))
        //        };
        //    });

        // if now athu.jwtbearer in program.cs

        //services.AddAuthentication(options =>
        //{
        //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //}).AddJwtBearer(options =>
        //    {
        //        options.TokenValidationParameters = 
        //            new TokenValidationParameters()
        //            {
        //                ValidateAudience = true,
        //                ValidAudience = configuration["Jwt:Audience"],
        //                ValidateIssuer = true,
        //                ValidIssuer = configuration["Jwt:Issuer"],
        //                ValidateLifetime = true,
        //                ValidateIssuerSigningKey = true,
        //                IssuerSigningKey = 
        //                    new SymmetricSecurityKey(
        //                        System.Text.Encoding.UTF8.GetBytes(
        //                            configuration["Jwt:Key"] ?? string.Empty
        //                            )
        //                        )

        //            };
        //    });

        //services.AddAuthorization();



    }
}
