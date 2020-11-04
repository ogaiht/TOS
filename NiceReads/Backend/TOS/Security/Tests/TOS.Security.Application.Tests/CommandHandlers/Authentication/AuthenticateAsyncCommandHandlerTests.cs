using Moq;
using Moq.Language.Flow;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TOS.Application.Security.CommandHandlers.Authentication;
using TOS.Application.Security.Commands.Authentication;
using TOS.Application.Security.Utils;
using TOS.Common;
using TOS.Data.Security.Repositories;
using TOS.Security.Models;

namespace TOS.Application.Security.Tests.CommandHandlers.Authentication
{
    [TestFixture]
    public class AuthenticateAsyncCommandHandlerTests
    {
        private const string UserName = "UserName";
        private const string Password = "Password";
        private DateTime _utcNow;
        private User _user;
        private PasswordHash _passwordHash;
        private Mock<IDateTimeProvider> _dateTimeProvider;
        private Mock<IUserRepository> _userRepository;
        private Mock<IPasswordUtils> _passwordUtils;
        private AuthenticateAsyncCommandHandler _authenticateAsyncCommandHandler;

        [SetUp]
        public void SetUp()
        {
            _passwordHash = new PasswordHash();
            _utcNow = DateTime.UtcNow;
            _user = new User()
            {
                Name = UserName,
                LastAccess = _utcNow.AddHours(-20),
                Password = new Password()
                {
                    Hash = _passwordHash
                }
            };

            _dateTimeProvider = new Mock<IDateTimeProvider>();
            _dateTimeProvider
                .Setup(p => p.UtcNow())
                .Returns(_utcNow);

            _userRepository = new Mock<IUserRepository>();
            SetUpUserReturn(true);

            _passwordUtils = new Mock<IPasswordUtils>();
            SetUpValidPassword(true);

            _authenticateAsyncCommandHandler = new AuthenticateAsyncCommandHandler(
                _userRepository.Object,
                _passwordUtils.Object,
                _dateTimeProvider.Object);
        }

        private void SetUpUserReturn(bool findUser)
        {
            ISetup<IUserRepository, Task<User>> setup = _userRepository
                .Setup(r => r.GetByUsername(UserName));
            if (findUser)
            {
                setup.ReturnsAsync(_user);
            }
            else
            {
                setup.ReturnsAsync((User)null);
            }
        }

        private void SetUserActive(bool isActive)
        {
            _user.Active = isActive;
        }

        private void SetUpValidPassword(bool valid)
        {
            _passwordUtils
                .Setup(u => u.ValidatedPassword(Password, _passwordHash))
                .Returns(valid);
        }

        [Test]
        [TestCase(AutheticationResultStatus.Success)]
        [TestCase(AutheticationResultStatus.InactiveUser)]
        [TestCase(AutheticationResultStatus.InvalidUser)]
        [TestCase(AutheticationResultStatus.InvalidPassword)]
        public async Task AuthenticateAsyncCommandHandler_ExecuteAsync_ShouldValidateUser_AndPassword(AutheticationResultStatus expectedResultStatus)
        {
            SetUpUserReturn(expectedResultStatus != AutheticationResultStatus.InvalidUser);
            SetUpValidPassword(expectedResultStatus != AutheticationResultStatus.InvalidPassword);
            SetUserActive(expectedResultStatus != AutheticationResultStatus.InactiveUser);
            AuthenticationResult authenticationResult = await _authenticateAsyncCommandHandler.ExecuteAsync(new AuthenticateAsyncCommand(UserName, Password));
            Assert.AreEqual(expectedResultStatus, authenticationResult.Status);
            if (expectedResultStatus == AutheticationResultStatus.Success)
            {
                _userRepository
                    .Verify(r => r.UpdateAsync(It.Is<User>(u => u.LastAccess == _utcNow)));
            }
        }
    }
}
