using Domian.Entities;
using Infrastructure.Repository;
namespace Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable,IAsyncDisposable
    {
        IBaseRepository<Employee> Employees { get; }
        IBaseRepository<Department> Departments { get; }

        int Commit();
        Task<int> CommitAsync();
    }
}
