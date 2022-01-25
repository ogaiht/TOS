using TOS.Data.MongoDB;
using TOS.Data.MongoDB.Repositories;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Data.Repositories.Implementations
{
    public class StateRepository : Repository<State>, IStateRepository
    {
        public StateRepository(IDatabaseProvider databaseProvider) : base(databaseProvider)
        {
        }
    }
}
