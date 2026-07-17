using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HRMangment.Domain.IdentityEntities;
public class ApplicationUser: IdentityUser<Guid>{

    [Required]
    [Length(100, 2)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [Length(100, 2)]
    public string LastName { get; set; } = string.Empty;
}
