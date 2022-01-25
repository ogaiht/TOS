//using Azure.Messaging.ServiceBus;
//using System;

//namespace TOS.Messaging.ServiceBus
//{
//    internal class ReceivedMessage : IReceivedMessage
//    {
//        internal ReceivedMessage(ServiceBusReceivedMessage serviceBusReceivedMessage)
//        {
//            ServiceBusReceivedMessage = serviceBusReceivedMessage;
//        }

//        internal ServiceBusReceivedMessage ServiceBusReceivedMessage { get; }
//        public BinaryData Body => ServiceBusReceivedMessage.Body;
//    }
//}
