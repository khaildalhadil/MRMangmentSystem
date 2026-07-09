
using Microsoft.AspNetCore.Identity;

namespace HRMangment.Domain.IdentityEntities;
public class ApplicationRole: IdentityRole<Guid>
{
    // I can add more properties to the role if needed, for example a description or a list of permissions
}
