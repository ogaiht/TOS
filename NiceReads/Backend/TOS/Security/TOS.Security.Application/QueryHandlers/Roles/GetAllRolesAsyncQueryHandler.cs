using System.Threading.Tasks;
using TOS.Application.Security.Queries.Roles;
using TOS.Common.DataModel;
using TOS.CQRS.Handlers.Queries;
using TOS.Data.Security.Repositories;
using TOS.Security.Models;

namespace TOS.Application.Security.QueryHandlers.Roles
{
    public class GetAllRolesAsyncQueryHandler : IAsyncQueryHandler<GetAllRolesAsyncQuery, IPagedResult<Role>>
    {
        private readonly IRoleRepository _roleRepository;

        public GetAllRolesAsyncQueryHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IPagedResult<Role>> ExecuteAsync(GetAllRolesAsyncQuery execution)
        {
            return await _roleRepository.GetAllAsync();
        }
    }
}
