using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TOS.CQRS.Handlers.Queries;
using TOS.EngagementHub.Data.Queries.Employees;
using TOS.EngagementHub.Data.Repositories;
using TOS.EngagementHub.Models;
using TOS.EngagementHub.Models.Projections;

namespace TOS.EngagementHub.Application.Queries.Employees
{
    public class GetEmployeeByIdAsyncQueryHandler : IAsyncQueryHandler<GetEmployeeByIdAsyncQuery, EmployeeDetail>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeDetailComposer _employeeDetailComposer;

        public GetEmployeeByIdAsyncQueryHandler(IEmployeeRepository employeeRepository, IEmployeeDetailComposer employeeDetailComposer)
        {
            _employeeRepository = employeeRepository;
            _employeeDetailComposer = employeeDetailComposer;
        }

        public async Task<EmployeeDetail> ExecuteAsync(GetEmployeeByIdAsyncQuery execution)
        {
            Employee employee = await _employeeRepository.GetByIdAsync(execution.EmployeeId);
            if (employee == null)
            {
                return null;
            }
            IReadOnlyCollection<EmployeeDetail> employeeDetails = await _employeeDetailComposer.LoadEmployeeDetailsAsync(employee);
            return employeeDetails.Count == 1 ? employeeDetails.First() : null;
        }
    }
}
