﻿using System.Collections.Generic;
using TOS.CQRS.Executions.Queries;
using TOS.EngagementHub.Models.Filters;
using TOS.EngagementHub.Models.Projections;

namespace TOS.EngagementHub.Application.Queries.Employees
{
    public class GetEmployeesByFilterAsyncQuery : AsyncQuery<IReadOnlyCollection<EmployeeDetail>>
    {
        public GetEmployeesByFilterAsyncQuery(EmployeeFilter filter)
        {
            Filter = filter;
        }

        public EmployeeFilter Filter { get; }
    }
}
