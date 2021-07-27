using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TOS.Common.Utils;
using TOS.CQRS.Dispatchers;

namespace TOS.CQRS.Tests.Dispatchers
{
    [TestFixture]
    public class ExecutionHandlerProviderTests
    {
        private Mock<IServiceProvider> _serviceProvider;
        private Mock<IExceptionHelper> _exceptionHelper;
        private Mock<ILogger<ExecutionHandlerProvider>> _logger;
        private ExecutionHandlerProvider _executionHandlerProvider;

        [SetUp]
        public void SetUp()
        {
            _serviceProvider = new Mock<IServiceProvider>();
            _exceptionHelper = new Mock<IExceptionHelper>();
            _logger = new Mock<ILogger<ExecutionHandlerProvider>>();
            _executionHandlerProvider = new ExecutionHandlerProvider(
                _serviceProvider.Object,
                _exceptionHelper.Object,
                _logger.Object);
        }

        [Test]
        [TestCase(true, true)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(false, false)]
        public void GetHandlerFor_WhenFindingHandler_ShouldValidateForNotFound_AndReturnIfFound(bool serviceFound, bool throwIfNotFound)
        {
            TestService1 expectedTestService = new TestService1();
            if (serviceFound)
            {
                _serviceProvider
                .Setup(p => p.GetService(typeof(ITestService)))
                .Returns(expectedTestService);
            }

            ITestService actualTestService = _executionHandlerProvider.GetHandlerFor<ITestService>(throwIfNotFound);
            if (serviceFound)
            {
                Assert.AreEqual(expectedTestService, actualTestService);
            }
            else
            {
                Assert.IsNull(actualTestService);
            }
            _exceptionHelper
                .Verify(e => e.CheckInvalidOperationException(!serviceFound && throwIfNotFound, "No handler was found for " + typeof(ITestService).FullName));
        }

        [Test]
        [TestCase(true, true)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(false, false)]
        public void GetHandlerFor_WhenFindingHandlers_ShouldValidateForNotFound_AndReturnIfFound(bool serviceFound, bool throwIfNotFound)
        {
            TestService1 expectedTestService1 = new TestService1();
            TestService2 expectedTestService2 = new TestService2();
            if (serviceFound)
            {
                _serviceProvider
                .Setup(p => p.GetService(typeof(IEnumerable<ITestService>)))
                .Returns(new ITestService[] { expectedTestService1, expectedTestService2 });
            }

            if (serviceFound)
            {
                IEnumerable<ITestService> actualServices = _executionHandlerProvider.GetHandlersFor<ITestService>(throwIfNotFound);
                CollectionAssert.Contains(actualServices, expectedTestService1);
                CollectionAssert.Contains(actualServices, expectedTestService2);
                _exceptionHelper
                    .Verify(e => e.CheckInvalidOperationException(!serviceFound && throwIfNotFound, "No handler was found for " + typeof(ITestService).FullName));
            }
            else
            {
                Assert.Throws<InvalidOperationException>(() => _executionHandlerProvider.GetHandlersFor<ITestService>(throwIfNotFound), "No service for type 'System.Collections.Generic.IEnumerable`1[TOS.CQRS.Tests.Dispatchers.ITestService]' has been registered");
            }
        }
    }

    public interface ITestService
    {

    }

    public class TestService1 : ITestService
    {

    }

    public class TestService2 : ITestService
    {

    }
}
