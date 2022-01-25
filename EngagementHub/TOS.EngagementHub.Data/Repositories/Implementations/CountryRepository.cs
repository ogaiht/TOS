using TOS.Data.MongoDB;
using TOS.Data.MongoDB.Repositories;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Data.Repositories.Implementations
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(IDatabaseProvider databaseProvider) : base(databaseProvider)
        {
        }
    }
}
