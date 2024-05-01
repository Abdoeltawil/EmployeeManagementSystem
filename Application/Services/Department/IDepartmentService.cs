using Application.DTOs.Department;
using Application.Requests.Department;
using DepartmentEntity = Domian.Entities.Department;

namespace Application.Services.Department
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDto>> GetAllDepartments();
        Task AddDepartment(AddDepartmentRequest department);
        Task DeleteDepartment();
        Task UpdateDepartment(DepartmentEntity department);
    }
}
