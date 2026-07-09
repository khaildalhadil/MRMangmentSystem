using HRMangment.Application.Dtos.EmployeeDto;
using HRMangment.Domain.Entities;

namespace HRMangment.Application.Interfaces;

public interface IEmployeeService
{
    Task<List<Employee>> GetAllEmps();
    Task<Employee> GetEmpByID(int id);
    Task<Employee> AddEmployee(CreateEmployeeDto employeeDto);
    Task<Employee> UpdateEmp(CreateEmployeeDto employeeDto);
    void DeleteEmp(Employee employee);
}
