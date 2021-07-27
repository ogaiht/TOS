using System.Collections.Generic;
using System.Threading.Tasks;
using TOS.CQRS.Handlers.Queries;
using TOS.EngagementHub.Data.Queries.Employees;
using TOS.EngagementHub.Models.Projections;

namespace TOS.EngagementHub.Application.Queries.Employees
{
    public class GetEmployeesByFilterAsyncQueryHandler : IAsyncQueryHandler<GetEmployeesByFilterAsyncQuery, IReadOnlyCollection<EmployeeDetail>>
    {
        private readonly IEmployeesByFilterAsyncQuery _employeesByFilterAsyncQuery;

        public GetEmployeesByFilterAsyncQueryHandler(IEmployeesByFilterAsyncQuery employeesByFilterAsyncQuery)
        {
            _employeesByFilterAsyncQuery = employeesByFilterAsyncQuery;
        }

        public async Task<IReadOnlyCollection<EmployeeDetail>> ExecuteAsync(GetEmployeesByFilterAsyncQuery execution)
        {
            return await _employeesByFilterAsyncQuery.FindEmployeesAsync(execution.Filter);
        }
    }
}
