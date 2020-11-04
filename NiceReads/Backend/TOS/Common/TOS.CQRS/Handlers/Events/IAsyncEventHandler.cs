using System.Threading.Tasks;
using TOS.CQRS.Executions.Events;

namespace TOS.CQRS.Handlers.Events
{
    public interface IAsyncEventHandler<in TEvent> where TEvent : IAsyncEvent
    {
        Task ExecuteAsync(TEvent @event);
    }
}
