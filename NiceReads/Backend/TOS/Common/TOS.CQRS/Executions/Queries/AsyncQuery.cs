namespace TOS.CQRS.Executions.Queries
{
    public class AsyncQuery<TResult> : ExecutionRequest<TResult>, IAsyncQuery<TResult>
    {

    }
}
