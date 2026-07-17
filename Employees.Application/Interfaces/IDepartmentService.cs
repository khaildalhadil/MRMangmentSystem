
using HRMangment.Application.Dtos.DepartmentDto;
using HRMangment.Domain.Entities;

namespace HRMangment.Application.Interfaces;

public interface IDepartmentService
{
    Task<List<Department>> GetAllDepartmentAsync();
    Task<Department> GetDepartmentByID(int id);
    Task<Department> AddDepartment(CreateDepartmentDto departmentDto);
    Task<Department> UpdateDepartment(int id, CreateDepartmentDto departmentDto);
    Task DeleteEmp(int id);
}
