using TOS.Common.DataModel;
using TOS.CQRS.Executions.Queries;
using TOS.EngagementHub.Models;
using TOS.EngagementHub.Models.Filters;

namespace TOS.EngagementHub.Application.Queries.Skills
{
    public class GetSkillsByNameAsyncQuery : AsyncQuery<IPagedResult<Skill>>
    {
        public GetSkillsByNameAsyncQuery(SkillFilter filter)
        {
            Filter = filter;
        }

        public SkillFilter Filter { get; }
    }
}
