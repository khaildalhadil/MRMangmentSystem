using Microsoft.AspNetCore.Identity;

namespace HRMangment.Domain.IdentityEntities;
public class ApplicationUser: IdentityUser<Guid>
{
    public string EmployeeName { get; set; } = default!;
}
