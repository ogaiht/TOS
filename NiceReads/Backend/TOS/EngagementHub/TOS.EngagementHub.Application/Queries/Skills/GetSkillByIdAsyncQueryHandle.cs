using System.Threading.Tasks;
using TOS.CQRS.Handlers.Queries;
using TOS.EngagementHub.Data.Repositories;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Application.Queries.Skills
{
    public class GetSkillByIdAsyncQueryHandle : IAsyncQueryHandler<GetSkillByIdAsyncQuery, Skill>
    {
        private readonly ISkillRepository _skillRepository;

        public GetSkillByIdAsyncQueryHandle(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<Skill> ExecuteAsync(GetSkillByIdAsyncQuery execution)
        {
            return await _skillRepository.GetByIdAsync(execution.SkillId);
        }
    }
}
