using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using EmployeeEntity = Domian.Entities.Employee;
namespace Infrastructure.Repositories.Employee
{
    public class EmployeeRepository : BaseRepository<EmployeeEntity>, IEmployeeRepository
    {
        private readonly DatabaseContext _databaseContext;

        public EmployeeRepository(DatabaseContext databaseContext):base(databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<EmployeeEntity>> GetAllIncludeAsync()
            => await _databaseContext.Employees.Include(e=>e.Department).ToListAsync();
        
    }
}
