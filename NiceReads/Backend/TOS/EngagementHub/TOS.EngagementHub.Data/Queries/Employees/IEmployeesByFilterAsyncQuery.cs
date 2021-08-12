using System.Threading.Tasks;
using TOS.Common.DataModel;
using TOS.EngagementHub.Models.Filters;
using TOS.EngagementHub.Models.Projections;

namespace TOS.EngagementHub.Data.Queries.Employees
{
    public interface IEmployeesByFilterAsyncQuery
    {
        Task<IPagedResult<EmployeeDetail>> FindEmployeesAsync(EmployeeFilter filter);
    }
}