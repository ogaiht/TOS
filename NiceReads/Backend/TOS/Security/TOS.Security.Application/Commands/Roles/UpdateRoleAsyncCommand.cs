using TOS.CQRS.Executions.Commands;

namespace TOS.Application.Security.Commands.Roles
{
    public class UpdateRoleAsyncCommand : AsyncCommand
    {
        public UpdateRoleAsyncCommand(string name, string description, bool active)
        {
            Name = name;
            Description = description;
            Active = active;
        }

        public string Name { get; }
        public string Description { get; }
        public bool Active { get; }
    }    
}
