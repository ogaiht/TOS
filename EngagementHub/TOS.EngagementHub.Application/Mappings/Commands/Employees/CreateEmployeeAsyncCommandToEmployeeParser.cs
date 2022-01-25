using TOS.EngagementHub.Application.Commands.Employees;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Application.Mappings.Commands.Employees
{
    public class CreateEmployeeAsyncCommandToEmployeeParser : ICreateEmployeeAsyncCommandToEmployeeParser
    {
        public Employee Parse(CreateEmployeeAsyncCommand input)
        {
            return new Employee()
            {
                Email = input.Email,
                Name = new Name()
                {
                    FirstName = input.FirstName,
                    MiddleName = input.MiddleName,
                    LastName = input.LastName
                }
            };
        }
    }
}
