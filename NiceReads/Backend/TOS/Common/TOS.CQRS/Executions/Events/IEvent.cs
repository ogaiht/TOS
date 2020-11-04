using System;

namespace TOS.CQRS.Executions.Events
{
    public interface IEvent
    {
        Guid Id { get; }
        DateTime Timestamp { get; }
    }
}
