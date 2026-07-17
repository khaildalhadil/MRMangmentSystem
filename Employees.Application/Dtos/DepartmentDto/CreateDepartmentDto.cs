using HRMangment.Domain.Entities;

namespace HRMangment.Application.Dtos.DepartmentDto;

public class CreateDepartmentDto
{
    public string Name { get; set; } = String.Empty;
    public string HeadOfDp { get; set; } = String.Empty;
    public static Department ToEntity(CreateDepartmentDto dto, int id = 0)
    {
        return new Department() { Id = 0, Name = dto.Name, HeadOfDp = dto.HeadOfDp};
    }
}