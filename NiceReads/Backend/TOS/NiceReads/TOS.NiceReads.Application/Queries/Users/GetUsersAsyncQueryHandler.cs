using System.Threading.Tasks;
using TOS.Common.DataModel;
using TOS.CQRS.Handlers.Queries;
using TOS.NiceReads.Data.Repositories;
using TOS.NiceReads.Models;

namespace TOS.NiceReads.Application.Queries.Users
{
    public class GetUsersAsyncQueryHandler : IAsyncQueryHandler<GetUsersAsyncQuery, IPagedResult<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersAsyncQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IPagedResult<User>> ExecuteAsync(GetUsersAsyncQuery execution)
        {
            return await _userRepository.GetAsync();
        }
    }
}
