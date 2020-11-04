using System.Collections.Generic;
using TOS.CQRS.Executions.Commands;

namespace TOS.Application.Security.Commands.Users
{
    public class AssignRolesToUserAsyncCommand : AsyncCommand
    {
        public AssignRolesToUserAsyncCommand(string userId, IReadOnlyCollection<string> roleIds)
        {
            UserId = userId;
            RoleIds = roleIds;
        }

        public string UserId { get; }
        public IReadOnlyCollection<string> RoleIds { get; }
    }
}
