using TOS.CQRS.Executions;

namespace TOS.CQRS.Commands
{
    public interface ICommand : IExecutionRequest
    {

    }

    public interface ICommand<out result> : ICommand, IExecutionRequest<result>
    {

    }
}
