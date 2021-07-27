using TOS.Data.MongoDB;
using TOS.Data.MongoDB.Repositories;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Data.Repositories.Implementations
{
    public class SkillLevelRepository : Repository<SkillLevel>, ISkillLevelRepository
    {
        public SkillLevelRepository(IDatabaseProvider databaseProvider) : base(databaseProvider)
        {
        }
    }
}
