using Domian.Entities;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext;
        public IBaseRepository<Employee> Employees { get; private set; }
        public IBaseRepository<Department> Departments { get; private set; }

        public UnitOfWork(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            Employees = new BaseRepository<Employee>(databaseContext);
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
