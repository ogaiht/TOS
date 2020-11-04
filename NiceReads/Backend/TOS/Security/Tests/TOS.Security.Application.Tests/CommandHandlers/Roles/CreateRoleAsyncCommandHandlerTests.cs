using MongoDB.Bson;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TOS.Application.Security.CommandHandlers.Roles;
using TOS.Application.Security.Commands.Roles;
using TOS.Application.Security.Events.Roles;
using TOS.Common;
using TOS.CQRS.Dispatchers.Events;
using TOS.Data.Security.Repositories;
using TOS.Security.Models;

namespace TOS.Application.Security.Tests
{
    [TestFixture]
    public class CreateRoleAsyncCommandHandlerTests
    {
        private const string RoleName = "Administrator";
        private const string RoleDescription = "Administers the System";

        private ObjectId _newRoleId = ObjectId.GenerateNewId();
        private DateTime _utcNow = DateTime.UtcNow;
        private CreateRoleAsyncCommandHandler _createRoleAsyncCommandHandler;
        private Mock<IRoleRepository> _roleRepository;
        private Mock<IEventDispatcher> _eventDispatcher;
        private Mock<IDateTimeProvider> _dateTimeProvider;
        private CreateRoleAsyncCommand _createRoleAsyncCommand;
        private RoleCreatedEvent _roleCreatedEvent;

        [SetUp]
        public void SetUp()
        {
            _createRoleAsyncCommand = new CreateRoleAsyncCommand(RoleName, RoleDescription);

            _dateTimeProvider = new Mock<IDateTimeProvider>();
            _dateTimeProvider
                .Setup(p => p.UtcNow())
                .Returns(_utcNow);            

            _roleRepository = new Mock<IRoleRepository>();
            _roleRepository
                .Setup(r => r.AddAsync(It.Is<Role>(r => r.Name == RoleName && r.Description == RoleDescription && r.CreatedAt == _utcNow)))
                .ReturnsAsync(_newRoleId);

            _roleCreatedEvent = new RoleCreatedEvent(RoleName, RoleDescription, _utcNow);

            _eventDispatcher = new Mock<IEventDispatcher>();

            _createRoleAsyncCommandHandler = new CreateRoleAsyncCommandHandler(
                _roleRepository.Object,
                _eventDispatcher.Object,
                _dateTimeProvider.Object);
        }

        [Test]
        public async Task CreateRoleAsyncCommandHandler_ExecuteAsync_ShouldCreatedRole_AndDispatchEvent()
        {
            string id = await _createRoleAsyncCommandHandler.ExecuteAsync(_createRoleAsyncCommand);
            Assert.AreEqual(_newRoleId.ToString(), id);
            _eventDispatcher
                .Verify(d => d.Dispatch(_roleCreatedEvent));
        }
    }
}
