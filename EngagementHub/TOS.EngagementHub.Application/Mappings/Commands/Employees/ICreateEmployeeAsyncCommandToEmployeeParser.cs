using TOS.EngagementHub.Application.Commands.Employees;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Application.Mappings.Commands.Employees
{
    public interface ICreateEmployeeAsyncCommandToEmployeeParser
    {
        Employee Parse(CreateEmployeeAsyncCommand input);
    }
}
