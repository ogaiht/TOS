using System.Collections.Generic;
using System.Threading.Tasks;
using TOS.EngagementHub.Models;
using TOS.EngagementHub.Models.Projections;

namespace TOS.EngagementHub.Data.Queries.Employees
{
    public interface IEmployeeDetailComposer
    {
        Task<IReadOnlyCollection<EmployeeDetail>> LoadEmployeeDetailsAsync(params Employee[] employees);
    }
}