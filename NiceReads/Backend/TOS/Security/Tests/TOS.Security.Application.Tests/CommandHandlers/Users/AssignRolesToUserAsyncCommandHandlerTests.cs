using MongoDB.Bson;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TOS.Application.Security.CommandHandlers.Users;
using TOS.Common;
using TOS.Data.Security.Repositories;
using TOS.Security.Models;

namespace TOS.Application.Security.Tests.CommandHandlers.Users
{
    [TestFixture]
    public class AssignRolesToUserAsyncCommandHandlerTests
    {
        private string _userId;
        private string[] _roleIds;
        private DateTime _utcNow;
        private Mock<IDateTimeProvider> _dateTimeProvider;
        private Mock<IUserRolesRepository> _userRolesRepository;
        private AssignRolesToUserAsyncCommandHandler _assignRolesToUserAsyncCommandHandler;

        [SetUp]
        public void SetUp()
        {
            _userId = ObjectId.GenerateNewId().ToString();
            _roleIds = new string[] { ObjectId.GenerateNewId().ToString(), ObjectId.GenerateNewId().ToString() };

            _utcNow = DateTime.UtcNow;
            _dateTimeProvider = new Mock<IDateTimeProvider>();
            _dateTimeProvider
                .Setup(p => p.UtcNow())
                .Returns(_utcNow);

            _userRolesRepository = new Mock<IUserRolesRepository>();
            _userRolesRepository
                .Setup(r =>
                    r.AddRangeAsync(
                            It.Is<IEnumerable<UserRole>>(ur =>
                                _roleIds.All(r => ur.Any(i => i.UserId == ObjectId.Parse(_userId) && i.RoleId == ObjectId.Parse(r) && i.CreatedAt == _utcNow)))))
                .Returns(Task.CompletedTask);

            _assignRolesToUserAsyncCommandHandler = new AssignRolesToUserAsyncCommandHandler(_userRolesRepository.Object, _dateTimeProvider.Object);
        }

        [Test]
        public async Task AssignRolesToUserAsyncCommandHandler_ExecuteAsync_ShouldCreateUserRoles()
        {
            await _assignRolesToUserAsyncCommandHandler.ExecuteAsync(new Commands.Users.AssignRolesToUserAsyncCommand(_userId, _roleIds));
        }
    }
}
