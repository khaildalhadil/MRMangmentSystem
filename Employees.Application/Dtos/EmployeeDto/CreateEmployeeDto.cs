using HRMangment.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace HRMangment.Application.Dtos.EmployeeDto;

public class CreateEmployeeDto
{
    [Required]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters.")]
    public required String Name { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Department must be between 2 and 50 characters.")]
    public required String Department { get; set; }

    [Required]
    [Range(18, 65, ErrorMessage = "Age must be between 18 and 65.")]
    public int Age { get; set; }
    public Boolean IsMar { get; set; }
    public Boolean WorkNow { get; set; }
    


    public static Employee ToEntity(CreateEmployeeDto dto)
    {
        return new Employee
        {
            Name = dto.Name,
            Department = dto.Department,
            Age = dto.Age,
            IsMar = dto.IsMar,
            WorkNow = dto.WorkNow
        };
    }
}
