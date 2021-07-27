using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using TOS.CQRS.Dispatchers;
using TOS.CQRS.Dispatchers.Events;
using TOS.CQRS.Executions.Events;
using TOS.CQRS.Handlers;
using TOS.CQRS.Handlers.Events;

namespace TOS.CQRS.Tests.Dispatchers.Events
{
    [TestFixture]
    public class EventDispatcherTests
    {
        private Mock<IExecutionHandlerProvider> _executionHandlerProvider;
        private Mock<IHandlerExecutor> _handlerExecutor;
        private Mock<ILogger<EventDispatcher>> _logger;
        private EventDispatcher _eventDispatcher;

        [SetUp]
        public void SetUp()
        {
            _executionHandlerProvider = new Mock<IExecutionHandlerProvider>();
            _handlerExecutor = new Mock<IHandlerExecutor>();
            _logger = new Mock<ILogger<EventDispatcher>>();
            _eventDispatcher = new EventDispatcher(
                _handlerExecutor.Object,
                _executionHandlerProvider.Object,
                _logger.Object);
        }

        [Test]
        public void Dispatch_WhenDispatching_ShouldExecutionAllEventHandlers()
        {
            IEvent @event = new Mock<IEvent>().Object;
            Mock<IEventHandler<IEvent>> eventHandler1 = new Mock<IEventHandler<IEvent>>();
            Mock<IEventHandler<IEvent>> eventHandler2 = new Mock<IEventHandler<IEvent>>();
            IEnumerable<IEventHandler<IEvent>> handlers = new IEventHandler<IEvent>[]
                {
                    eventHandler1.Object,
                    eventHandler2.Object
                };

            _executionHandlerProvider
                .Setup(p => p.GetHandlersFor<IEventHandler<IEvent>>(false))
                .Returns(handlers);

            _eventDispatcher.Dispatch(@event);

            _handlerExecutor
                .Verify(e => e.Execute(eventHandler1.Object, @event));
            _handlerExecutor
                .Verify(e => e.Execute(eventHandler1.Object, @event));
        }

        [Test]
        public async Task DispatchAsync_WhenDispatching_ShouldExecutionAllEventHandlers()
        {
            IAsyncEvent asyncEvent = new Mock<IAsyncEvent>().Object;
            Mock<IAsyncEventHandler<IAsyncEvent>> eventHandler1 = new Mock<IAsyncEventHandler<IAsyncEvent>>();
            eventHandler1
                .Setup(h => h.ExecuteAsync(asyncEvent))
                .Returns(Task.CompletedTask);
            Mock<IAsyncEventHandler<IAsyncEvent>> eventHandler2 = new Mock<IAsyncEventHandler<IAsyncEvent>>();
            eventHandler2
                .Setup(h => h.ExecuteAsync(asyncEvent))
                .Returns(Task.CompletedTask);
            IEnumerable<IAsyncEventHandler<IAsyncEvent>> handlers = new IAsyncEventHandler<IAsyncEvent>[]
                {
                    eventHandler1.Object,
                    eventHandler2.Object
                };

            _executionHandlerProvider
                .Setup(p => p.GetHandlersFor<IAsyncEventHandler<IAsyncEvent>>(false))
                .Returns(handlers);


            await _eventDispatcher.DispatchAsync(asyncEvent);

            _handlerExecutor
                .Verify(e => e.ExecuteAsync(eventHandler1.Object, asyncEvent));
            _handlerExecutor
                .Verify(e => e.ExecuteAsync(eventHandler1.Object, asyncEvent));
        }
    }
}
