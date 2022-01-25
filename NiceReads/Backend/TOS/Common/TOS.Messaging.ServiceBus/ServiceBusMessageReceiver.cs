//using Azure.Messaging.ServiceBus;
//using System;
//using System.Threading;
//using System.Threading.Tasks;

//namespace TOS.Messaging.ServiceBus
//{
//    public class ServiceBusMessageReceiver : IMessageReceiver
//    {
//        private readonly ServiceBusReceiver _serviceBusReceiver;

//        public ServiceBusMessageReceiver(ServiceBusReceiver serviceBusReceiver)
//        {
//            _serviceBusReceiver = serviceBusReceiver;
//        }

//        public async Task CloseAsync()
//        {
//            await _serviceBusReceiver.CloseAsync();
//        }

//        public async Task CompleteMessageAsync(IReceivedMessage message, CancellationToken cancellationToken = default)
//        {
//            ReceivedMessage receivedMessage = message as ReceivedMessage;
//            await _serviceBusReceiver.CompleteMessageAsync(receivedMessage.ServiceBusReceivedMessage, cancellationToken);
//        }

//        public async ValueTask DisposeAsync()
//        {
//            await _serviceBusReceiver.DisposeAsync();
//        }

//        public async Task<IReceivedMessage> ReceiveMessageAsync(TimeSpan? maxWaitTime = null, CancellationToken cancellationToken = default)
//        {
//            ServiceBusReceivedMessage receivedMessage = await _serviceBusReceiver.ReceiveMessageAsync(maxWaitTime, cancellationToken);
//            return new ReceivedMessage(receivedMessage);
//        }
//    }
//}
