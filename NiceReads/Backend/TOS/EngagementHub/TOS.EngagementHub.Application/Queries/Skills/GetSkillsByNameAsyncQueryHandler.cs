using System.Collections.Generic;
using System.Threading.Tasks;
using TOS.CQRS.Handlers.Queries;
using TOS.EngagementHub.Data.Queries.Skills;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Application.Queries.Skills
{
    public class GetSkillsByNameAsyncQueryHandler : IAsyncQueryHandler<GetSkillsByNameAsyncQuery, IReadOnlyCollection<Skill>>
    {
        private readonly IFindSkillsByNameAsyncQuery _findSkillsByNameAsyncQuery;

        public GetSkillsByNameAsyncQueryHandler(IFindSkillsByNameAsyncQuery findSkillsByNameAsyncQuery)
        {
            _findSkillsByNameAsyncQuery = findSkillsByNameAsyncQuery;
        }

        public async Task<IReadOnlyCollection<Skill>> ExecuteAsync(GetSkillsByNameAsyncQuery execution)
        {
            return await _findSkillsByNameAsyncQuery.FindSkillsContainingNameAsync(execution.Name);
        }
    }
}
