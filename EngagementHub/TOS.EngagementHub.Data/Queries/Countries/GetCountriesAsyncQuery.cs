using MongoDB.Driver;
using System.Threading.Tasks;
using TOS.Common.DataModel;
using TOS.Data.MongoDB;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Data.Queries.Countries
{
    public class GetCountrisAsyncQuery : IGetCountrisAsyncQuery
    {
        private readonly IMongoCollectionProvider _mongoCollectionProvider;

        public GetCountrisAsyncQuery(IMongoCollectionProvider mongoCollectionProvider)
        {
            _mongoCollectionProvider = mongoCollectionProvider;
        }

        public async Task<IPagedResult<Country>> GetCountriesAsync(string name = null, int offset = -1, int limit = -1)
        {
            IFindFluent<Country, Country> findFluent;
            if (string.IsNullOrWhiteSpace(name))
            {
                findFluent = _mongoCollectionProvider.GetCollection<Country>().Find(c => true);
            }
            else
            {
                findFluent = _mongoCollectionProvider.GetCollection<Country>().Find(c => c.Name.StartsWith(name));
            }
            return await findFluent.ToPagedResultAsync(offset, limit);
        }
    }
}
