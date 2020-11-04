using System;
using System.Collections.Generic;
using TOS.CQRS.Executions.Events;

namespace TOS.Application.Security.Events.Users
{
    public class RolesAssignToUserEvent : Event
    {
        public RolesAssignToUserEvent(string userId, IReadOnlyCollection<string> roleIds)
        {
            UserId = userId;
            RoleIds = roleIds;
        }

        public string UserId { get;  }
        public IReadOnlyCollection<string> RoleIds { get; }
        public DateTime ExecutedAt { get; }
        public string ExecutedBy { get; }
    }
}
