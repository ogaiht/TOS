using System;
using System.Collections.Generic;
using TOS.CQRS.Executions.Commands;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Application.Commands.Employees
{
    public class AddSkillsToEmployeeAsyncCommand : AsyncCommand
    {
        public AddSkillsToEmployeeAsyncCommand(Guid employeeId, IReadOnlyCollection<EmployeeSkill> skills)
        {
            EmployeeId = employeeId;
            Skills = skills;
        }

        public Guid EmployeeId { get; }
        public IReadOnlyCollection<EmployeeSkill> Skills { get; }
    }
}
