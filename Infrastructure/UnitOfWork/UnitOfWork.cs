using Domian.Entities;
using Infrastructure.Repositories.Employee;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext;
        public IEmployeeRepository Employees { get; private set; }
        public IBaseRepository<Department> Departments { get; private set; }

        public UnitOfWork(DatabaseContext databaseContext,IEmployeeRepository employeeRepository)
        {
            _databaseContext = databaseContext;
            Employees = employeeRepository;
            Departments = new BaseRepository<Department>(databaseContext);
        }

        public int Commit()
        => _databaseContext.SaveChanges();

        public async Task<int> CommitAsync()
        => await _databaseContext.SaveChangesAsync();

        public void Dispose()
        => _databaseContext.Dispose();

        public async ValueTask DisposeAsync()
        => await _databaseContext.DisposeAsync();
    }
}
