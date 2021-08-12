using System.Linq;
using System.Threading.Tasks;
using TOS.Common.Collections;
using TOS.Common.Utils;
using TOS.CQRS.Handlers.Commands;
using TOS.EngagementHub.Data.Repositories;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Application.Commands.Employees
{
    public class RemoveSkillsFromEmployeeAsyncCommandHandler : IAsyncCommandHandler<RemoveSkillsFromEmployeeAsyncCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IExceptionHelper _exceptionHelper;

        public RemoveSkillsFromEmployeeAsyncCommandHandler(IEmployeeRepository employeeRepository, IExceptionHelper exceptionHelper)
        {
            _employeeRepository = employeeRepository;
            _exceptionHelper = exceptionHelper;
        }

        public async Task ExecuteAsync(RemoveSkillsFromEmployeeAsyncCommand execution)
        {
            Employee employee = await _employeeRepository.GetByIdAsync(execution.EmployeeId);
            _exceptionHelper.CheckInvalidOperationException(employee == null, $"No employee found for id '{execution.EmployeeId}'");
            if (employee.Skills.Remove(e => execution.SkillIds.Contains(e.SkillId)).Count > 0)
            {
                await _employeeRepository.UpdateAsync(employee);
            }
        }
    }
}
