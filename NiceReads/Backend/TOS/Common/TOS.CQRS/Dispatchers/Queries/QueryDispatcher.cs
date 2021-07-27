using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TOS.CQRS.Executions.Queries;
using TOS.CQRS.Handlers;
using TOS.CQRS.Handlers.Queries;

namespace TOS.CQRS.Dispatchers.Queries
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IHandlerExecutor _handlerExecutor;
        private readonly IExecutionHandlerProvider _executionHandlerProvider;
        private readonly ILogger<QueryDispatcher> _logger;

        public QueryDispatcher(IHandlerExecutor handlerExecutor,
            IExecutionHandlerProvider executionHandlerProvider,
            ILogger<QueryDispatcher> logger)
        {
            _handlerExecutor = handlerExecutor;
            _executionHandlerProvider = executionHandlerProvider;
            _logger = logger;
        }

        public TResult Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            IQueryHandler<TQuery, TResult> handler = _executionHandlerProvider.GetHandlerFor<IQueryHandler<TQuery, TResult>>();
            try
            {
                return _handlerExecutor.Execute<TQuery, IQueryHandler<TQuery, TResult>, TResult>(handler, query);
            }
            catch (Exception ex)
            {
                LogError<TQuery>(ex, handler);
                throw;
            }
        }

        public async Task<TResult> ExecuteAsync<TQuery, TResult>(TQuery query) where TQuery : IAsyncQuery<TResult>
        {
            IAsyncQueryHandler<TQuery, TResult> handler = _executionHandlerProvider.GetHandlerFor<IAsyncQueryHandler<TQuery, TResult>>();
            try
            {
                return await _handlerExecutor.ExecuteAsync<TQuery, IAsyncQueryHandler<TQuery, TResult>, TResult>(handler, query);
            }
            catch (Exception ex)
            {
                LogError<TQuery>(ex, handler);
                throw;
            }
        }

        private void LogError<T>(Exception ex, object handler)
        {
            _logger.LogError(ex, "Error when execution {Query} by handler {Handler}.", typeof(T).FullName, handler.GetType().FullName);
        }
    }

}
