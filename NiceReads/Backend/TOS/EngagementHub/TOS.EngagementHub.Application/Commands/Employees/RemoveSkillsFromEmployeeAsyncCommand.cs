using System;
using System.Collections.Generic;
using TOS.CQRS.Executions.Commands;

namespace TOS.EngagementHub.Application.Commands.Employees
{
    public class RemoveSkillsFromEmployeeAsyncCommand : AsyncCommand
    {
        public RemoveSkillsFromEmployeeAsyncCommand(Guid employeeId, IReadOnlyCollection<Guid> skillIds)
        {
            EmployeeId = employeeId;
            SkillIds = skillIds;
        }

        public Guid EmployeeId { get; }
        public IReadOnlyCollection<Guid> SkillIds { get; }
    }
}
