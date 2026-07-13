using HRMangment.Application.Dtos.EmployeeDto;
using HRMangment.Application.Interfaces;
using HRMangment.Domain.Entities;

namespace HRMangment.Infrastructure.Services;

public class DepartmentService : IDepartmentService
{
    public Task<List<Department>> GetAllDepartment()
    {
        throw new NotImplementedException();
    }

    public Task<Department> GetDepartmentByID(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Department> UpdateDepartment(int id, CreateDepartmentDto departmentDto)
    {
        throw new NotImplementedException();
    }

    public Task<Department> AddDepartment(CreateDepartmentDto departmentDto)
    {
        throw new NotImplementedException();
    }

    public void DeleteEmp(Department departement)
    {
        throw new NotImplementedException();
    }

}
