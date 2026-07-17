using HRMangment.Application.Dtos.DepartmentDto;
using HRMangment.Application.Interfaces;
using HRMangment.Domain.Entities;
using HRMangment.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace HRMangment.Infrastructure.Services;

public class DepartmentService(EmpDbContext empDbContext) : IDepartmentService
{
    private readonly EmpDbContext empDbContext = empDbContext;
    public Task<List<Department>> GetAllDepartmentAsync()
    {
        return empDbContext.Departements.ToListAsync();
    }

    public async Task<Department>? GetDepartmentByID(int id)
    {
        var emp = await empDbContext.Departements.FindAsync(id);
        if (emp != null)
        {
            return emp;
        }
        return null;
    }

    public async Task<Department> UpdateDepartment(int id, CreateDepartmentDto departmentDto)
    {

        Department department = CreateDepartmentDto.ToEntity(departmentDto, id);
        empDbContext.Departements.Update(department);
        await empDbContext.SaveChangesAsync();
        return department;
    }

    public async Task<Department> AddDepartment(CreateDepartmentDto departmentDto)
    {
        Department department = CreateDepartmentDto.ToEntity(departmentDto);
        await empDbContext.Departements.AddAsync(department);
        await empDbContext.SaveChangesAsync();
        return department;
    }

    public async Task DeleteEmp(int id)
    {

        var emp = await this.GetDepartmentByID(id);
        empDbContext.Departements.Remove(emp);
        await empDbContext.SaveChangesAsync();
    }


}
