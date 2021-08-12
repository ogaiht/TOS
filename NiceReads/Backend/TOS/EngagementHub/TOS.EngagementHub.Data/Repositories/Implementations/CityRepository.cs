using TOS.Data.MongoDB;
using TOS.Data.MongoDB.Repositories;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Data.Repositories.Implementations
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(IDatabaseProvider databaseProvider) : base(databaseProvider)
        {
        }
    }
}
