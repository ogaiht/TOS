using System;

namespace TOS.CQRS.Executions.Events
{
    public interface IAsyncEvent
    {
        Guid Id { get; }
        DateTime Timestamp { get; }
    }
}
