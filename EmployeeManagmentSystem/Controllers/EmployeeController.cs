using Application.Requests.Employee;
using Application.Services.Employee;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("Employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(AddEmployeeRequest employee)
        {
            await _employeeService.AddEmployee(employee);
            return Created();
        }


    }
}
