using System;
using TOS.CQRS.Executions.Commands;

namespace TOS.EngagementHub.Application.Commands.Employees
{
    public class DeleteEmployeeAsyncCommand : AsyncCommand
    {
        public DeleteEmployeeAsyncCommand(Guid employeeId)
        {
            EmployeeId = employeeId;
        }

        public Guid EmployeeId { get; }
    }
}
