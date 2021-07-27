using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using TOS.Common.Utils;
using System.Linq;
using System;

namespace TOS.CQRS.Dispatchers
{
    public class ExecutionHandlerProvider : IExecutionHandlerProvider
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IExceptionHelper _exceptionHelper;
        private readonly ILogger<ExecutionHandlerProvider> _logger;

        public ExecutionHandlerProvider(IServiceProvider serviceProvider, IExceptionHelper exceptionHelper, ILogger<ExecutionHandlerProvider> logger)
        {
            _serviceProvider = serviceProvider;
            _exceptionHelper = exceptionHelper;
            _logger = logger;
        }

        public T GetHandlerFor<T>(bool throwExceptionIfNotFound = true)
        {
            _logger.LogInformation("Getting handler for '{0}'.", typeof(T).FullName);
            T handler = _serviceProvider.GetService<T>();
            _exceptionHelper.CheckInvalidOperationException(handler == null && throwExceptionIfNotFound, "No handler was found for " + typeof(T).FullName);
            return handler;
        }

        public IEnumerable<T> GetHandlersFor<T>(bool throwExceptionIfNotFound = true)
        {
            _logger.LogInformation("Getting handler for '{0}'.", typeof(T).FullName);
            IEnumerable<T> handlers = _serviceProvider.GetServices<T>();
            _exceptionHelper.CheckInvalidOperationException((handlers == null || !handlers.Any()) && throwExceptionIfNotFound, "No handler was found for " + typeof(T).FullName);
            return handlers;
        }
    }
}
