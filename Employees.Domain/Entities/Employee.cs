
using System.ComponentModel.DataAnnotations;

namespace HRMangment.Domain.Entities;

public class Employee
{
    public int Id { get; set; }

    [Required]
    public required String Name { get; set; }

    [Required]
    public required String Department { get; set; }

    [Required]
    public int Age { get; set; }
    public Boolean IsMar { get; set; }
    public Boolean WorkNow { get; set; }


}
