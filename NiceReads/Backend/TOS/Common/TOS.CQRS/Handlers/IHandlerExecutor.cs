using System.Threading.Tasks;
using TOS.CQRS.Executions;

namespace TOS.CQRS.Handlers
{
    public interface IHandlerExecutor
    {
        void Execute<TExecution, THandler>(THandler executionHandler, TExecution execution)
            where TExecution : IExecutionRequest
            where THandler : IExecutionHandler<TExecution>;
        TResult Execute<TExecution, TResult, THandler>(THandler executionHandler, TExecution execution)
            where TExecution : IExecutionRequest<TResult>
            where THandler : IExecutionHandler<TExecution, TResult>;
        Task ExecuteAsync<TExecution, THandler>(THandler executionHandler, TExecution execution)
            where TExecution : IAsyncExecutionRequest
            where THandler : IAsyncExecutionHandler<TExecution>;
        Task<TResult> ExecuteAsync<TExecution, TResult, THandler>(THandler executionHandler, TExecution execution)
            where TExecution : IAsyncExecutionRequest<TResult>
            where THandler : IAsyncExecutionHandler<TExecution, TResult>;
    }
}