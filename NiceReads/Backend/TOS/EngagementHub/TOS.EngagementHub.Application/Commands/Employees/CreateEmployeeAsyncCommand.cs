using System;
using TOS.CQRS.Executions.Commands;

namespace TOS.EngagementHub.Application.Commands.Employees
{
    public class CreateEmployeeAsyncCommand : AsyncCommand<Guid>
    {
        public CreateEmployeeAsyncCommand(string firstName, string middleName, string lastName, string email)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Email = email;
        }

        public string FirstName { get; }
        public string MiddleName { get; }
        public string LastName { get; }
        public string Email { get; }
    }
}
