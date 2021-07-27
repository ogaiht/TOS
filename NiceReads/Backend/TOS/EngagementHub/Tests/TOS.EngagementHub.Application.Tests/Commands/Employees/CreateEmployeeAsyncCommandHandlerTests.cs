using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TOS.EngagementHub.Application.Commands.Employees;
using TOS.EngagementHub.Application.Mappings.Commands.Employees;
using TOS.EngagementHub.Data.Repositories;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Application.Tests.Commands.Employees
{
    [TestFixture]
    public class CreateEmployeeAsyncCommandHandlerTests
    {
        private CreateEmployeeAsyncCommandHandler _createEmployeeAsyncCommandHandler;
        private Mock<IEmployeeRepository> _employeeRepository;
        private Mock<ICreateEmployeeAsyncCommandToEmployeeParser> _createEmployeeAsyncCommandToEmployee;

        [SetUp]
        public void SetUp()
        {
            _employeeRepository = new Mock<IEmployeeRepository>();
            _createEmployeeAsyncCommandToEmployee = new Mock<ICreateEmployeeAsyncCommandToEmployeeParser>();
            _createEmployeeAsyncCommandHandler = new CreateEmployeeAsyncCommandHandler(_employeeRepository.Object, _createEmployeeAsyncCommandToEmployee.Object);
        }

        [Test]
        public async Task ExecuteAsync_WhenCreatingEmployee_ShouldParseCommand_AndCreateEmployee()
        {
            Guid expectedId = Guid.NewGuid();
            CreateEmployeeAsyncCommand command = new CreateEmployeeAsyncCommand("firtName", "middleName", "lastName", "email");
            Employee employee = new Employee()
            {
                Name = new Name()
                {
                    FirstName = "firstName",
                    MiddleName = "middleName",
                    LastName = "lastName"
                },
                Email = "email"
            };
            _createEmployeeAsyncCommandToEmployee
                .Setup(p => p.Parse(command))
                .Returns(employee);
            _employeeRepository
                .Setup(r => r.AddAsync(employee))
                .ReturnsAsync(expectedId);

            Guid actualId = await _createEmployeeAsyncCommandHandler.ExecuteAsync(command);
            Assert.AreEqual(expectedId, actualId);
        }
    }
}
