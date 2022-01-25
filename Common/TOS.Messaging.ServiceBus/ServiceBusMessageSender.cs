using Azure.Messaging.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace TOS.Messaging.ServiceBus
{
    public class ServiceBusMessageSender : IMessageSender
    {
        private readonly ServiceBusSender _serviceBusSender;

        public ServiceBusMessageSender(ServiceBusSender serviceBusSender)
        {
            _serviceBusSender = serviceBusSender;
        }

        public async Task CloseAsync()
        {
            await _serviceBusSender.CloseAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _serviceBusSender.DisposeAsync();
        }

        public async Task SendMessageAsync(Message message, CancellationToken cancellationToken = default)
        {
            ServiceBusMessage serviceBusMessage = new ServiceBusMessage(message.Body)
            {
                TimeToLive = message.TimeToLive
            };
            await _serviceBusSender.SendMessageAsync(serviceBusMessage);
        }
    }
}
