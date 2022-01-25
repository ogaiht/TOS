using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using TOS.Common.DataModel;
using TOS.Data.MongoDB;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Data.Queries.Cities
{
    public class GetCitiesAsyncQuery : IGetCitiesAsyncQuery
    {
        private readonly IMongoCollectionProvider _mongoCollectionProvider;

        public GetCitiesAsyncQuery(IMongoCollectionProvider mongoCollectionProvider)
        {
            _mongoCollectionProvider = mongoCollectionProvider;
        }

        public async Task<IPagedResult<City>> GetCitiesAsync(Guid stateId, string name = null, int offset = -1, int limit = -1)
        {
            FilterDefinitionBuilder<City> filterBuilder = Builders<City>.Filter;
            FilterDefinition<City> queryFilter = filterBuilder.Where(s => s.StateId == stateId);
            if (!string.IsNullOrWhiteSpace(name))
            {
                queryFilter &= filterBuilder.Where(s => s.Name.StartsWith(name));
            }
            return await _mongoCollectionProvider.GetCollection<City>().FindPagedResultAsync(queryFilter, offset, limit);
        }
    }
}
