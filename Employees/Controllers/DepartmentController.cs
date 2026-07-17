using HRMangment.Application.Dtos.DepartmentDto;
using HRMangment.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HRMangment.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class DepartmentController(IDepartmentService departmentService) : Controller
    {
        private readonly IDepartmentService _departmentService = departmentService;

        [HttpGet]
        public async Task<IActionResult> GetAllDepartment()
        {
            var departments = await _departmentService.GetAllDepartmentAsync();
            if(departments.Count == 0)
            {
                return NotFound();
            }
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartment(int id) { 

            var departments = await _departmentService.GetDepartmentByID(id);

            if (departments == null)
            {
                return NotFound();
            }
            return Ok(departments);

        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(CreateDepartmentDto dto)
        {
            await _departmentService.AddDepartment(dto);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, CreateDepartmentDto dto)
        {
            GetDepartment(id);
            await _departmentService.UpdateDepartment(id, dto);
            var dep = CreateDepartmentDto.ToEntity(dto, id);
            return Ok(dep);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var departments = await _departmentService.GetDepartmentByID(id);

            if (departments == null)
            {
                return NotFound();
            }
            await _departmentService.DeleteEmp(id);
            return NoContent();
        }
    }
}
