using Application.Requests.Department;
using Application.Services.Department;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("Department")]
    public class DepartmentController: ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] AddDepartmentRequest department)
        {
            await _departmentService.AddDepartment(department);
            return Created();
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _departmentService.GetAllDepartments();
            return Ok(result);
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _departmentService.DeleteDepartment(id);
            return Ok();
        }
    }
}
