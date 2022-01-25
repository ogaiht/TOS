using NUnit.Framework;
using TOS.EngagementHub.Application.Commands.Employees;
using TOS.EngagementHub.Application.Mappings.Commands.Employees;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Application.Tests.Mappings.Commands.Employees
{
    [TestFixture]
    public class CreateEmployeeAsyncCommandToEmployeeParserTests
    {

        [Test]
        public void Parse_WhenParsingCommand_ShouldReturnEmployee()
        {
            const string firstName = "First Name";
            const string middleName = "Middle Name";
            const string lastName = "Last Name";
            const string email = "email@address.com";

            CreateEmployeeAsyncCommand command = new CreateEmployeeAsyncCommand(firstName, middleName, lastName, email);

            CreateEmployeeAsyncCommandToEmployeeParser parser = new CreateEmployeeAsyncCommandToEmployeeParser();

            Employee employee = parser.Parse(command);

            Assert.AreEqual(firstName, employee.Name.FirstName);
            Assert.AreEqual(middleName, employee.Name.MiddleName);
            Assert.AreEqual(lastName, employee.Name.LastName);
            Assert.AreEqual(email, employee.Email);
            CollectionAssert.IsEmpty(employee.Skills);
        }
    }
}
