using TOS.Data.MongoDB;
using TOS.Data.MongoDB.Repositories;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Data.Repositories.Implementations
{
    public class SkillRepository : Repository<Skill>, ISkillRepository
    {
        public SkillRepository(IDatabaseProvider databaseProvider) : base(databaseProvider)
        {
        }
    }
}
