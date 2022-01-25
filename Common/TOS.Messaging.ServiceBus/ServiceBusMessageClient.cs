//using Azure.Messaging.ServiceBus;
//using System.Threading.Tasks;

//namespace TOS.Messaging.ServiceBus
//{
//    public class ServiceBusMessageClient : IMessageClient
//    {
//        private readonly ServiceBusClient _serviceBusClient;

//        public ServiceBusMessageClient(ServiceBusClient serviceBusClient)
//        {
//            _serviceBusClient = serviceBusClient;
//        }

//        public IMessageReceiver CreateReceiver(string queueName)
//        {
//            return new ServiceBusMessageReceiver(_serviceBusClient.CreateReceiver(queueName));
//        }

//        public IMessageSender CreateSender(string queueName)
//        {
//            throw new System.NotImplementedException();
//        }

//        public ValueTask DisposeAsync()
//        {
//            return _serviceBusClient.DisposeAsync();
//        }
//    }
//}
