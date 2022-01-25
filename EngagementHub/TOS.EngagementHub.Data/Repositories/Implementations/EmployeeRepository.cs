using TOS.Data.MongoDB;
using TOS.Data.MongoDB.Repositories;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Data.Repositories.Implementations
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDatabaseProvider databaseProvider) : base(databaseProvider)
        {
        }
    }
}
