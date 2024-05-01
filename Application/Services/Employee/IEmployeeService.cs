using Application.DTOs.Employee;
using Application.Requests.Employee;
using EmployeeEntity = Domian.Entities.Employee; 
namespace Application.Services.Employee
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAllEmployees();
        Task AddEmployee(AddEmployeeRequest employee);
        Task DeleteEmployee();
        Task UpdateEmployee(EmployeeEntity employee);
    }
}
