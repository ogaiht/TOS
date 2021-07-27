using System;
using TOS.Data.Repositories;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Data.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee, Guid>
    {
    }
}
