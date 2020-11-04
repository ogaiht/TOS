using System.Threading.Tasks;
using TOS.Application.Security.Queries.Roles;
using TOS.Common.DataModel;
using TOS.CQRS.Handlers.Queries;
using TOS.Data.Security.Repositories;
using TOS.Security.Models;

namespace TOS.Application.Security.QueryHandlers.Roles
{
    public class GetRolesByNameAsynQueryHandler : IAsyncQueryHandler<GetRolesByNameAsyncQuery, IPagedResult<Role>>
    {
        private readonly IRoleRepository _roleRepository;

        public GetRolesByNameAsynQueryHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IPagedResult<Role>> ExecuteAsync(GetRolesByNameAsyncQuery execution)
        {
            return await _roleRepository.GetByNameLikeAsync(execution.SearchName, execution.Paging.Offset, execution.Paging.Limit);
        }
    }
}
