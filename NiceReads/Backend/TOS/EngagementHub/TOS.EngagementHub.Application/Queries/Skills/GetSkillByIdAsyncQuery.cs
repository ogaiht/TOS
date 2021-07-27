using System;
using TOS.CQRS.Executions.Queries;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Application.Queries.Skills
{
    public class GetSkillByIdAsyncQuery : AsyncQuery<Skill>
    {
        public GetSkillByIdAsyncQuery(Guid skillId)
        {
            SkillId = skillId;
        }

        public Guid SkillId { get; }
    }
}
