using System.Collections.Generic;
using TOS.CQRS.Executions.Queries;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Application.Queries.Skills
{
    public class GetSkillsByNameAsyncQuery : AsyncQuery<IReadOnlyCollection<Skill>>
    {
        public GetSkillsByNameAsyncQuery(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
