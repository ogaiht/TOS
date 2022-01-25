using System.Threading.Tasks;
using TOS.CQRS.Handlers.Commands;
using TOS.EngagementHub.Data.Repositories;

namespace TOS.EngagementHub.Application.Commands.Employees
{
    public class DeleteEmployeeAsyncCommandHandler : IAsyncCommandHandler<DeleteEmployeeAsyncCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeAsyncCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task ExecuteAsync(DeleteEmployeeAsyncCommand execution)
        {
            await _employeeRepository.DeleteAsync(execution.EmployeeId);
        }
    }
}
