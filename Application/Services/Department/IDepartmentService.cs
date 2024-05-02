using Application.DTOs.Department;
using Application.Requests.Department;

namespace Application.Services.Department
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDto>> GetAllDepartments();
        Task AddDepartment(AddDepartmentRequest department);
        Task DeleteDepartment(int id);
    }
}
