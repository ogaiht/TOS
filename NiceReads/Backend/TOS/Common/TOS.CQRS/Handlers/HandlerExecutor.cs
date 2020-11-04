using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TOS.Common.Serialization.Json;
using TOS.CQRS.Executions;
using TOS.Extensions.Logging;

namespace TOS.CQRS.Handlers
{
    public class HandlerExecutor : IHandlerExecutor
    {
        private readonly IJsonSerializer _jsonSerializer;
        private readonly ILogger<HandlerExecutor> _logger;

        public HandlerExecutor(ILogger<HandlerExecutor> logger, IJsonSerializer jsonSerializer)
        {
            _logger = logger;
            _jsonSerializer = jsonSerializer;
        }

        private static string CreateExecutionId<TExecution>(object executionHandler, TExecution execution)
            where TExecution : IExecutionRequest
        {
            return $"{executionHandler.GetType().FullName}:{execution.GetType().FullName}:{execution.ExecutionId}";
        }

        private Lazy<string> GetSerializedRequest(object request)
        {
            return new Lazy<string>(() => _jsonSerializer.Serialize(request));
        }

        public void Execute<TExecution, THandler>(THandler executionHandler, TExecution execution)
            where TExecution : IExecutionRequest
            where THandler : IExecutionHandler<TExecution>
        {
            string identity = CreateExecutionId(executionHandler, execution);
            Lazy<string> serializedRequest = GetSerializedRequest(execution);

            BeforeExecution(identity, serializedRequest);
            try
            {
                using (_logger.TimeExecution(identity))
                {
                    executionHandler.Execute(execution);
                }
                AfterExecution(identity, serializedRequest);
            }
            catch (Exception ex)
            {
                OnError(identity, serializedRequest, ex);
                throw;
            }
        }

        public TResult Execute<TExecution, TResult, THandler>(THandler executionHandler, TExecution execution)
            where TExecution : IExecutionRequest<TResult>
            where THandler : IExecutionHandler<TExecution, TResult>
        {
            string identity = CreateExecutionId(executionHandler, execution);
            Lazy<string> serializedRequest = GetSerializedRequest(execution);

            BeforeExecution(identity, serializedRequest);
            try
            {
                TResult result;
                using (_logger.TimeExecution(identity))
                {
                    result = executionHandler.Execute(execution);
                }
                AfterExecution(identity, serializedRequest, result);
                return result;
            }
            catch (Exception ex)
            {
                OnError(identity, serializedRequest, ex);
                throw;
            }
        }

        public async Task ExecuteAsync<TExecution, THandler>(THandler executionHandler, TExecution execution)
            where TExecution : IAsyncExecutionRequest
            where THandler : IAsyncExecutionHandler<TExecution>
        {
            string identity = CreateExecutionId(executionHandler, execution);
            Lazy<string> serializedRequest = GetSerializedRequest(execution);

            BeforeExecution(identity, serializedRequest);
            try
            {
                using (_logger.TimeExecution(identity))
                {
                    await executionHandler.ExecuteAsync(execution);
                }
                AfterExecution(identity, serializedRequest);
            }
            catch (Exception ex)
            {
                OnError(identity, serializedRequest, ex);
                throw;
            }
        }

        public async Task<TResult> ExecuteAsync<TExecution, TResult, THandler>(THandler executionHandler, TExecution execution)
            where TExecution : IAsyncExecutionRequest<TResult>
            where THandler : IAsyncExecutionHandler<TExecution, TResult>
        {
            string identity = CreateExecutionId(executionHandler, execution);
            Lazy<string> serializedRequest = GetSerializedRequest(execution);

            BeforeExecution(identity, serializedRequest);
            try
            {
                TResult result;
                using (_logger.TimeExecution(identity))
                {
                    result = await executionHandler.ExecuteAsync(execution);
                }
                AfterExecution(identity, serializedRequest, result);
                return result;
            }
            catch (Exception ex)
            {
                OnError(identity, serializedRequest, ex);
                throw;
            }
        }

        private void BeforeExecution(string identity, Lazy<string> serializedRequest)
        {
            _logger.LogInformation("Executing {identity}.", identity);
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug("Executing {identity} for request '{request}'.",
                    identity, serializedRequest.Value);
            }
        }

        private void AfterExecution(string identity, Lazy<string> serializedRequest)
        {
            _logger.LogInformation("Executed {identity}.", identity);
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug("Executed {identity} for request '{request}'.",
                    identity, serializedRequest.Value);
            }
        }

        private void AfterExecution<TResult>(string identity, Lazy<string> serializedRequest, TResult result)
        {
            _logger.LogInformation("Executed {identity}.", identity);
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug("Executed {identity} for request '{request}' with result '{result}'.",
                        identity, serializedRequest.Value, _jsonSerializer.Serialize(result));
            }
        }

        private void OnError(string identity, Lazy<string> serializedRequest, Exception ex)
        {
            _logger.LogError(ex, "Error on execute {identity} for {request}", identity, serializedRequest.Value);
        }
    }
}
