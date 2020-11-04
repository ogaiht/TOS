using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TOS.CQRS.Executions.Events;
using TOS.CQRS.Handlers.Events;

namespace TOS.CQRS.Dispatchers.Events
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly IExecutionHandlerProvider _dispatcherProvider;

        public EventDispatcher(IExecutionHandlerProvider dispatcherProvider)
        {
            _dispatcherProvider = dispatcherProvider;
        }

        public void Dispatch<TEvent>(TEvent @event) where TEvent : IEvent
        {
            IEnumerable<IEventHandler<TEvent>> handlers = _dispatcherProvider.GetHandlersFor<IEventHandler<TEvent>>(false);

            if (!handlers.Any())
            {
                return;
            }

            foreach (IEventHandler<TEvent> handler in handlers)
            {
                handler.Execute(@event);
            }
        }

        public async Task DispatchAsync<TEvent>(TEvent @event) where TEvent : IAsyncEvent
        {
            IEnumerable<IAsyncEventHandler<TEvent>> handlers = _dispatcherProvider.GetHandlersFor<IAsyncEventHandler<TEvent>>(false);

            if (!handlers.Any())
            {
                return;
            }

            foreach (IAsyncEventHandler<TEvent> handler in handlers)
            {
                await handler.ExecuteAsync(@event);
            }
        }
    }
}
