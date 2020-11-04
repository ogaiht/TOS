using System;
using TOS.CQRS.Executions.Events;

namespace TOS.Application.Security.Events.Roles
{
    public class RoleCreatedEvent : Event
    {
        public RoleCreatedEvent(string name, string description, DateTime createdAt)
        {
            Name = name;
            Description = description;
            CreatedAt = createdAt;
        }

        public string Name { get; }
        public string Description { get; }
        public DateTime CreatedAt { get; }
    }
}