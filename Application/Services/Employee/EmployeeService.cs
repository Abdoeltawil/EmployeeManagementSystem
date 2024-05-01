using Application.DTOs.Employee;
using Application.Requests.Employee;
using Infrastructure.UnitOfWork;
using EmployeeEntity = Domian.Entities.Employee;

namespace Application.Services.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddEmployee(AddEmployeeRequest employee)
        {
            await _unitOfWork.Employees.AddAsync(new EmployeeEntity
            {
                HireDate = employee.HireDate,
                DepartmentId = employee.DepartmentId,
                IsActive = employee.IsActive,
                Mobile = employee.Mobile,
                Name = employee.Name,
                Phone = employee.Phone,
                SSN = employee.SSN
            });
            await _unitOfWork.CommitAsync();
        }

        public Task DeleteEmployee()
        {
            throw new NotImplementedException();
        }

        public async Task<List<EmployeeDto>> GetAllEmployees()
        {
            var employees = await _unitOfWork.Employees.GetAllAsync();
            return employees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                DepartmentId=e.DepartmentId,
                HireDate=e.HireDate,
                IsActive=e.IsActive,
                Mobile=e.Mobile,
                Name=e.Name,
                Phone=e.Phone,
                SSN=e.SSN
            }).ToList();
        }
        public async Task UpdateEmployee(EmployeeEntity employee)
        {
            var existEmployee = await _unitOfWork.Employees.GetByIdAsync(employee.Id);
            if (existEmployee is not null)
            {
                employee.Department = employee.Department;
                employee.HireDate = employee.HireDate;
                employee.DepartmentId = employee.DepartmentId;
                employee.IsActive = employee.IsActive;
                employee.Mobile = employee.Mobile;
                employee.Name = employee.Name;
                employee.Phone = employee.Phone;
                employee.SSN = employee.SSN;
                await _unitOfWork.CommitAsync();
            }

        }
    }
}
