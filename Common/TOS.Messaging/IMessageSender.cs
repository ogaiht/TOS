using System;
using System.Threading;
using System.Threading.Tasks;

namespace TOS.Messaging
{
    public interface IMessageSender : IAsyncDisposable
    {
        Task SendMessageAsync(Message message, CancellationToken cancellationToken = default);
        Task CloseAsync();
    }
}