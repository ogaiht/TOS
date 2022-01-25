using System.Threading.Tasks;
using TOS.Common.DataModel;
using TOS.CQRS.Handlers.Queries;
using TOS.EngagementHub.Data.Queries.Skills;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Application.Queries.Skills
{
    public class GetSkillsByNameAsyncQueryHandler : IAsyncQueryHandler<GetSkillsByNameAsyncQuery, IPagedResult<Skill>>
    {
        private readonly IFindSkillsByNameAsyncQuery _findSkillsByNameAsyncQuery;

        public GetSkillsByNameAsyncQueryHandler(IFindSkillsByNameAsyncQuery findSkillsByNameAsyncQuery)
        {
            _findSkillsByNameAsyncQuery = findSkillsByNameAsyncQuery;
        }

        public async Task<IPagedResult<Skill>> ExecuteAsync(GetSkillsByNameAsyncQuery execution)
        {
            return await _findSkillsByNameAsyncQuery.FindSkillsContainingNameAsync(execution.Filter);
        }
    }
}
