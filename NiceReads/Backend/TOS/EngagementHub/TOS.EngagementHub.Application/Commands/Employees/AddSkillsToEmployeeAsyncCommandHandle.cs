using System.Threading.Tasks;
using TOS.Common.Utils;
using TOS.CQRS.Handlers.Commands;
using TOS.EngagementHub.Data.Repositories;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Application.Commands.Employees
{
    public class AddSkillsToEmployeeAsyncCommandHandle : IAsyncCommandHandler<AddSkillsToEmployeeAsyncCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IExceptionHelper _exceptionHelper;
        public AddSkillsToEmployeeAsyncCommandHandle(IEmployeeRepository employeeRepository, IExceptionHelper exceptionHelper)
        {
            _employeeRepository = employeeRepository;
            _exceptionHelper = exceptionHelper;
        }

        public async Task ExecuteAsync(AddSkillsToEmployeeAsyncCommand execution)
        {
            _exceptionHelper.CheckInvalidOperationException(execution.Skills.Count == 0, "No skill found to be added.");
            Employee employee = await _employeeRepository.GetByIdAsync(execution.EmployeeId);
            _exceptionHelper.CheckInvalidOperationException(employee == null, $"Employee not found for Id '{execution.EmployeeId}'");
            foreach (EmployeeSkill employeeSkill in execution.Skills)
            {
                employee.Skills.Add(employeeSkill);
            }
            await _employeeRepository.UpdateAsync(employee);
        }
    }
}
