using System;
using TOS.CQRS.Executions.Queries;
using TOS.EngagementHub.Models.Projections;

namespace TOS.EngagementHub.Application.Queries.Employees
{
    public class GetEmployeeByIdAsyncQuery : AsyncQuery<EmployeeDetail>
    {
        public GetEmployeeByIdAsyncQuery(Guid employeeId)
        {
            EmployeeId = employeeId;
        }

        public Guid EmployeeId { get; }
    }
}
