using HRMangment.Domain.Entities;
using HRMangment.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HRMangment.Infrastructure.Database;

public class EmpDbContext(DbContextOptions<EmpDbContext> options) : 
    IdentityDbContext<ApplicationUser, ApplicationRole, Guid>(options)
{
    public DbSet<Employee> Employees { get; set; }
}
