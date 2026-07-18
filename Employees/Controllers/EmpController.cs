using HRMangment.Application.Dtos.EmployeeDto;
using HRMangment.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRMangment.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]/[action]")]
public class EmployeesController(IEmployeeService employeeService, ILogger<EmployeesController> logger) : Controller
{
    private readonly IEmployeeService _service = employeeService;
    private readonly ILogger<EmployeesController> _logger = logger;

    [HttpGet]
    public async Task<IActionResult> GetAllEmployees()
    { 
        var allEmp = await _service.GetAllEmps();
        if (allEmp.Count < 1) return NotFound();
        _logger.LogInformation("Show All Employees");
        return Ok(allEmp);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployeeById(int id)
    {
        var employee = await _service.GetEmpByID(id);
        if (employee is null) return NotFound($"Employee with ID: {id} not found.");
        return Ok(employee);
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployee([FromBody] CreateEmployeeDto emp)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        await _service.AddEmployee(emp);
        return Ok(emp);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee([FromRoute] int id, [FromBody] CreateEmployeeDto employeeToUpdate)
    {
        var employee = await _service.UpdateEmp(id, employeeToUpdate);
        if (employee is null) return NotFound($"Employee with ID: {id} not found.");
        return Ok(employee);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
    {
        var employee = await _service.GetEmpByID(id);
        if (employee is null) return NotFound($"Employee with ID: {id} not found.");
        _service.DeleteEmp(employee);
        return NoContent();
    }
}
