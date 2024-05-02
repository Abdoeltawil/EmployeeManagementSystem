using Infrastructure.Repository;
using EmployeeEntity = Domian.Entities.Employee;
namespace Infrastructure.Repositories.Employee
{
    public interface IEmployeeRepository:IBaseRepository<EmployeeEntity>
    {
        Task<List<EmployeeEntity>> GetAllIncludeAsync();
    }
}
