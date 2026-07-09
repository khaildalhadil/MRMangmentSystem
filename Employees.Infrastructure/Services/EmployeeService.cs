
using HRMangment.Application.Dtos.EmployeeDto;
using HRMangment.Application.Interfaces;
using HRMangment.Domain.Entities;
using HRMangment.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace HRMangment.Infrastructure.services;

public class EmployeeService(EmpDbContext empDb) : IEmployeeService
{
    private readonly EmpDbContext _context = empDb;
    public Task<List<Employee>> GetAllEmps()
    {
        return _context.Employees.ToListAsync();
    }

    public async Task<Employee?> GetEmpByID(int id)
    {
        var emp = await _context.Employees.FindAsync(id);
        return emp;
    }
    public async Task<Employee> AddEmployee(CreateEmployeeDto employeeDto)
    {
        Employee employee = CreateEmployeeDto.ToEntity(employeeDto);
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee> UpdateEmp(CreateEmployeeDto employeeDto)
    {
        Employee employee = CreateEmployeeDto.ToEntity(employeeDto);
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public void DeleteEmp(Employee employee)
    {
        _context.Employees.Remove(employee);
        _context.SaveChanges();
    }
}
