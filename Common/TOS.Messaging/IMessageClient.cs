using System;

namespace TOS.Messaging
{
    public interface IMessageClient : IAsyncDisposable
    {
        IMessageSender CreateSender(string queueName);
        IMessageReceiver CreateReceiver(string queueName);
    }
}
