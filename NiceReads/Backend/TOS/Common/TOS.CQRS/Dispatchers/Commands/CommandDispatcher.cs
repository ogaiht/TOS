using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TOS.CQRS.Commands;
using TOS.CQRS.Executions.Commands;
using TOS.CQRS.Handlers;
using TOS.CQRS.Handlers.Commands;

namespace TOS.CQRS.Dispatchers.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IHandlerExecutor _handlerExecutor;
        private readonly IExecutionHandlerProvider _executionHandlerProvider;
        private readonly ILogger<CommandDispatcher> _logger;

        public CommandDispatcher(
            IHandlerExecutor handlerExecutor,
            IExecutionHandlerProvider executionHandlerProvider,
            ILogger<CommandDispatcher> logger)
        {
            _handlerExecutor = handlerExecutor;
            _executionHandlerProvider = executionHandlerProvider;
            _logger = logger;
        }

        public void Execute<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            ICommandHandler<TCommand> handler = _executionHandlerProvider.GetHandlerFor<ICommandHandler<TCommand>>();
            try
            {
                _handlerExecutor.Execute(handler, command);
            }
            catch (Exception ex)
            {
                LogError<TCommand>(ex, handler);
                throw;
            }
        }

        public TResult Execute<TCommand, TResult>(TCommand command)
            where TCommand : ICommand<TResult>
        {
            ICommandHandler<TCommand, TResult> handler = _executionHandlerProvider.GetHandlerFor<ICommandHandler<TCommand, TResult>>();
            try
            {
                return _handlerExecutor.Execute<TCommand, TResult, ICommandHandler<TCommand, TResult>>(handler, command);
            }
            catch (Exception ex)
            {
                LogError<TCommand>(ex, handler);
                throw;
            }

        }

        public async Task ExecuteAsync<TAsyncCommand>(TAsyncCommand asyncCommand)
            where TAsyncCommand : IAsyncCommand
        {
            IAsyncCommandHandler<TAsyncCommand> handler = _executionHandlerProvider.GetHandlerFor<IAsyncCommandHandler<TAsyncCommand>>();
            try
            {
                await _handlerExecutor.ExecuteAsync(handler, asyncCommand);
            }
            catch (Exception ex)
            {
                LogError<TAsyncCommand>(ex, handler);
                throw;
            }

        }

        public async Task<TResult> ExecuteAsync<TAsyncCommand, TResult>(TAsyncCommand asyncCommand)
            where TAsyncCommand : IAsyncCommand<TResult>
        {
            IAsyncCommandHandler<TAsyncCommand, TResult> handler = _executionHandlerProvider.GetHandlerFor<IAsyncCommandHandler<TAsyncCommand, TResult>>();
            try
            {
                return await _handlerExecutor.ExecuteAsync<TAsyncCommand, TResult, IAsyncCommandHandler<TAsyncCommand, TResult>>(handler, asyncCommand);
            }
            catch (Exception ex)
            {
                LogError<TAsyncCommand>(ex, handler);
                throw;
            }
        }

        private void LogError<T>(Exception ex, object handler)
        {
            _logger.LogError(ex, "Error when execution {Command} by handler {Handler}.", typeof(T).FullName, handler.GetType().FullName);
        }
    }
}
