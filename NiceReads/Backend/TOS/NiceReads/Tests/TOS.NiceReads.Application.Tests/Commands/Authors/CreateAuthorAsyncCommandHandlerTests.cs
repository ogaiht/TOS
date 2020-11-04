using Moq;
using System.Threading.Tasks;
using TOS.Common;
using TOS.NiceReads.Application.Commands.Authors;
using TOS.NiceReads.Data.Repositories;

namespace TOS.NiceReads.Application.Tests.Commands.Authors
{
    public class CreateAuthorAsyncCommandHandlerTests
    {
        private CreateAuthorAsyncCommandHandler _createAuthorAsyncCommandHandler;
        private Mock<IAuthorRepository> _authorRepository;
        private Mock<IUserRepository> _userRepository;
        private Mock<IDateTimeProvider> _dateTimeProvider;

        public void SetUp()
        {
            _userRepository = new Mock<IUserRepository>();
            _authorRepository = new Mock<IAuthorRepository>();
            _dateTimeProvider = new Mock<IDateTimeProvider>();
            _createAuthorAsyncCommandHandler = new CreateAuthorAsyncCommandHandler(
                _authorRepository.Object,
                _userRepository.Object,
                _dateTimeProvider.Object);
        }

        public async Task Test()
        {
            await _createAuthorAsyncCommandHandler.ExecuteAsync(new CreateAuthorAsyncCommand("", "", "", "", "", ""));
        }
    }
}
