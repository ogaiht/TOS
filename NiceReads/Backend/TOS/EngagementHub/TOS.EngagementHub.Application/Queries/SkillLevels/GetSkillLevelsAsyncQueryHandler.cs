using System.Collections.Generic;
using System.Threading.Tasks;
using TOS.CQRS.Handlers.Queries;
using TOS.EngagementHub.Data.Queries.SkillLevels;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Application.Queries.SkillLevels
{
    public class GetSkillLevelsAsyncQueryHandler : IAsyncQueryHandler<GetSkillLevelsAsyncQuery, IReadOnlyCollection<SkillLevel>>
    {
        private readonly IGetSkillLevelsAsyncQuery _getSkillLevelsAsyncQuery;

        public GetSkillLevelsAsyncQueryHandler(IGetSkillLevelsAsyncQuery getSkillLevelsAsyncQuery)
        {
            _getSkillLevelsAsyncQuery = getSkillLevelsAsyncQuery;
        }

        public async Task<IReadOnlyCollection<SkillLevel>> ExecuteAsync(GetSkillLevelsAsyncQuery execution)
        {
            return await _getSkillLevelsAsyncQuery.GetSkillLevelsAsync();
        }
    }
}
