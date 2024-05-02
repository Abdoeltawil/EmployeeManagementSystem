using Application.DTOs.Department;
using Application.Requests.Department;
using Infrastructure.UnitOfWork;
using DepartmentEntity = Domian.Entities.Department;

namespace Application.Services.Department
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddDepartment(AddDepartmentRequest department)
        {
            await _unitOfWork.Departments.AddAsync(new DepartmentEntity
            {
                Details = department.Details,
                IsActive = department.IsActive,
                Name = department.Name,
                Order = department.Order
            });
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteDepartment(int id)
        {
            await _unitOfWork.Departments.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<DepartmentDto>> GetAllDepartments()
        {
            var departments = await _unitOfWork.Departments.GetAllAsync();
            return departments.Select(d => new DepartmentDto
            {
                Id = d.Id,
                Details = d.Details,
                IsActive = d.IsActive,
                Name = d.Name,
                Order = d.Order
            }).ToList();
        }

    }
}
