
using HRMangment.Application.Dtos.EmployeeDto;
using HRMangment.Domain.Entities;

namespace HRMangment.Application.Interfaces;

public interface IDepartmentService
{
    Task<List<Department>> GetAllDepartment();
    Task<Department> GetDepartmentByID(int id);
    Task<Department> AddDepartment(CreateDepartmentDto departmentDto);
    Task<Department> UpdateDepartment(int id, CreateDepartmentDto departmentDto);
    void DeleteEmp(Department departement);
}
