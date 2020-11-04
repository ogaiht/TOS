using System;

namespace TOS.CQRS.Executions.Events
{
    public abstract class AsyncEvent : IAsyncEvent
    {
        protected AsyncEvent(Guid id, DateTime timestamp)
        {
            Id = id;
            Timestamp = timestamp;
        }

        protected AsyncEvent()
            : this(Guid.NewGuid(), DateTime.UtcNow)
        {

        }

        public Guid Id { get; }

        public DateTime Timestamp { get; }
    }
}
