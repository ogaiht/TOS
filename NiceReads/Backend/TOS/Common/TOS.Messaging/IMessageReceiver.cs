using System;
using System.Threading;
using System.Threading.Tasks;

namespace TOS.Messaging
{
    public interface IMessageReceiver : IAsyncDisposable
    {
        Task CompleteMessageAsync(IReceivedMessage message, CancellationToken cancellationToken = default);
        Task<IReceivedMessage> ReceiveMessageAsync(TimeSpan? maxWaitTime = null, CancellationToken cancellationToken = default);
        Task CloseAsync();
    }
}
