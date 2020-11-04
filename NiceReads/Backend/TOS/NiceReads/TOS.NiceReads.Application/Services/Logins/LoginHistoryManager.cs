using MongoDB.Bson;
using System.Threading.Tasks;
using TOS.Common;
using TOS.NiceReads.Application.Commands.Authentications;
using TOS.NiceReads.Data.Repositories;
using TOS.NiceReads.Models;

namespace TOS.NiceReads.Application.Services.Logins
{
    public class LoginHistoryManager : ILoginHistoryManager
    {
        private readonly ILoginHistoryRepository _loginHistoryRepository;
        private readonly IDateTimeProvider _dateTimeProvider;

        public LoginHistoryManager(ILoginHistoryRepository loginHistoryRepository, IDateTimeProvider dateTimeProvider)
        {
            _loginHistoryRepository = loginHistoryRepository;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task RecoredLoginAsync(ObjectId userId, AuthenticationStatus authenticationStatus)
        {
            LoginHistory loginHistory = new LoginHistory()
            {
                UserId = userId,
                Status = authenticationStatus == AuthenticationStatus.Success ? LoginStatus.Success : LoginStatus.FailedWrongPassword,
                At = _dateTimeProvider.UtcNow()
            };
            await _loginHistoryRepository.AddAsync(loginHistory);
        }
    }
}
