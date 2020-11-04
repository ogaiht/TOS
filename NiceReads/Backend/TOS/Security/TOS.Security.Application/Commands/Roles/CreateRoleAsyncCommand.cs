using System;
using TOS.CQRS.Executions.Commands;

namespace TOS.Application.Security.Commands.Roles
{
    public class CreateRoleAsyncCommand : AsyncCommand<string>
    {
        public CreateRoleAsyncCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}
