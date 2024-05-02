using Domian.Entities;
using Infrastructure.Repositories.Employee;
using Infrastructure.Repository;
namespace Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable,IAsyncDisposable
    {
        IEmployeeRepository Employees { get; }
        IBaseRepository<Department> Departments { get; }

        int Commit();
        Task<int> CommitAsync();
    }
}
