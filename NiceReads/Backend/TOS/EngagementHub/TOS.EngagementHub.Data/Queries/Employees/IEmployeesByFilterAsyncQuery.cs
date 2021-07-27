using System.Collections.Generic;
using System.Threading.Tasks;
using TOS.EngagementHub.Models.Filters;
using TOS.EngagementHub.Models.Projections;

namespace TOS.EngagementHub.Data.Queries.Employees
{
    public interface IEmployeesByFilterAsyncQuery
    {
        Task<IReadOnlyCollection<EmployeeDetail>> FindEmployeesAsync(EmployeeFilter filter);
    }
}