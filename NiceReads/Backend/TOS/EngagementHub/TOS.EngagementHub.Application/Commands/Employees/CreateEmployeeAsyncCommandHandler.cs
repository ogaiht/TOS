using System;
using System.Threading.Tasks;
using TOS.CQRS.Handlers.Commands;
using TOS.EngagementHub.Application.Mappings.Commands.Employees;
using TOS.EngagementHub.Data.Repositories;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Application.Commands.Employees
{
    public class CreateEmployeeAsyncCommandHandler : IAsyncCommandHandler<CreateEmployeeAsyncCommand, Guid>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICreateEmployeeAsyncCommandToEmployeeParser _createEmployeeAsyncCommandToEmployee;

        public CreateEmployeeAsyncCommandHandler(IEmployeeRepository employeeRepository,
            ICreateEmployeeAsyncCommandToEmployeeParser createEmployeeAsyncCommandToEmployee)
        {
            _employeeRepository = employeeRepository;
            _createEmployeeAsyncCommandToEmployee = createEmployeeAsyncCommandToEmployee;
        }

        public async Task<Guid> ExecuteAsync(CreateEmployeeAsyncCommand execution)
        {
            Employee employee = _createEmployeeAsyncCommandToEmployee.Parse(execution);
            return await _employeeRepository.AddAsync(employee);
        }
    }
}
