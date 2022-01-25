using System.Collections.Generic;
using TOS.CQRS.Executions.Queries;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Application.Queries.SkillLevels
{
    public class GetSkillLevelsAsyncQuery : AsyncQuery<IReadOnlyCollection<SkillLevel>>
    {
    }
}
