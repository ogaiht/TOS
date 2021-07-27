using System;
using System.Threading.Tasks;
using TOS.CQRS.Executions;
using TOS.CQRS.Logging;

namespace TOS.CQRS.Handlers
{
    public class HandlerExecutor : IHandlerExecutor
    {
        private readonly IHandlerExecutorLogger _handlerExecutorLogger;

        public HandlerExecutor(IHandlerExecutorLogger handlerExecutorLogger)
        {
            _handlerExecutorLogger = handlerExecutorLogger;
        }

        public void Execute<TExecution, THandler>(THandler executionHandler, TExecution execution)
            where TExecution : IExecutionRequest
            where THandler : IExecutionHandler<TExecution>
        {
            using (IHandlerExecutorLoggerScope logger = _handlerExecutorLogger.CreateScope(execution, executionHandler))
            {
                logger.BeforeExecution();
                try
                {
                    using (logger.TimeExecution())
                    {
                        executionHandler.Execute(execution);
                    }
                    logger.AfterExecution();
                }
                catch (Exception ex)
                {
                    logger.OnError(ex);
                    throw;
                }
            }
        }

        public TResult Execute<TExecution, THandler, TResult>(THandler executionHandler, TExecution execution)
            where TExecution : IExecutionRequest<TResult>
            where THandler : IExecutionHandler<TExecution, TResult>
        {
            using (IHandlerExecutorLoggerScope<TResult> logger = _handlerExecutorLogger.CreateScope<TExecution, THandler, TResult>(execution, executionHandler))
            {
                logger.BeforeExecution();
                try
                {
                    TResult result;
                    using (logger.TimeExecution())
                    {
                        result = executionHandler.Execute(execution);
                    }
                    logger.AfterExecution(result);
                    return result;
                }
                catch (Exception ex)
                {
                    logger.OnError(ex);
                    throw;
                }
            }
        }

        public async Task ExecuteAsync<TExecution, THandler>(THandler executionHandler, TExecution execution)
            where TExecution : IAsyncExecutionRequest
            where THandler : IAsyncExecutionHandler<TExecution>
        {
            using (IHandlerExecutorLoggerScope logger = _handlerExecutorLogger.CreateScopeForAsync(execution, executionHandler))
            {
                logger.BeforeExecution();
                try
                {
                    using (logger.TimeExecution())
                    {
                        await executionHandler.ExecuteAsync(execution);
                    }
                    logger.AfterExecution();
                }
                catch (Exception ex)
                {
                    logger.OnError(ex);
                    throw;
                }
            }
        }

        public async Task<TResult> ExecuteAsync<TExecution, THandler, TResult>(THandler executionHandler, TExecution execution)
            where TExecution : IAsyncExecutionRequest<TResult>
            where THandler : IAsyncExecutionHandler<TExecution, TResult>
        {
            using (IHandlerExecutorLoggerScope<TResult> logger = _handlerExecutorLogger.CreateScopeForAsync<TExecution, THandler, TResult>(execution, executionHandler))
            {
                logger.BeforeExecution();
                try
                {
                    TResult result;
                    using (logger.TimeExecution())
                    {
                        result = await executionHandler.ExecuteAsync(execution);
                    }
                    logger.AfterExecution(result);
                    return result;
                }
                catch (Exception ex)
                {
                    logger.OnError(ex);
                    throw;
                }
            }
        }
    }
}
