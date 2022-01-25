//using Confluent.Kafka;
//using System;
//using System.Threading;
//using System.Threading.Tasks;

//namespace TOS.Messaging.Kafka
//{
//    public class KafkaMessageReciver<TKey, TValue> : IMessageReceiver
//    {
//        private readonly IConsumer<TKey, TValue> _consumer;

//        public KafkaMessageReciver(IConsumer<TKey, TValue> consumer)
//        {
//            _consumer = consumer;
//        }

//        public Task CloseAsync()
//        {
//            _consumer.Close();
//            return Task.CompletedTask;
//        }

//        public Task CompleteMessageAsync(IReceivedMessage message, CancellationToken cancellationToken = default)
//        {
//            throw new NotImplementedException();
//        }

//        public ValueTask DisposeAsync()
//        {
//            _consumer.Close();
//            _consumer.Dispose();
//            return ValueTask.CompletedTask;
//        }

//        public Task<IReceivedMessage> ReceiveMessageAsync(TimeSpan? maxWaitTime = null, CancellationToken cancellationToken = default)
//        {
//            ConsumeResult<TKey, TValue> consumeResult = _consumer.Consume(cancellationToken);

//        }
//    }

//    public class ReceivedMessage : IReceivedMessage
//    {
//        public string Body => throw new NotImplementedException();
//    }
//}
