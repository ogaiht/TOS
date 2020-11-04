using System;

namespace TOS.CQRS.Executions.Events
{
    public abstract class Event : IEvent
    {
        protected Event(Guid id, DateTime timestamp)
        {
            Id = id;
            Timestamp = timestamp;
        }

        protected Event()
            : this(Guid.NewGuid(), DateTime.UtcNow)
        {

        }

        public Guid Id { get; }

        public DateTime Timestamp { get; }
    }
}
