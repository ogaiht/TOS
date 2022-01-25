using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using TOS.Common.DataModel;
using TOS.Data.MongoDB;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Data.Queries.States
{
    public class GetStatesAsyncQuery : IGetStatesAsyncQuery
    {
        private readonly IMongoCollectionProvider _mongoCollectionProvider;

        public GetStatesAsyncQuery(IMongoCollectionProvider mongoCollectionProvider)
        {
            _mongoCollectionProvider = mongoCollectionProvider;
        }

        public async Task<IPagedResult<State>> GetStatesAsync(Guid countryId, string name = null, int offset = -1, int limit = -1)
        {
            FilterDefinitionBuilder<State> filterBuilder = Builders<State>.Filter;
            FilterDefinition<State> queryFilter = filterBuilder.Where(s => s.CountryId == countryId);
            if (!string.IsNullOrWhiteSpace(name))
            {
                queryFilter &= filterBuilder.Where(s => s.Name.StartsWith(name));
            }
            return await _mongoCollectionProvider.GetCollection<State>().FindPagedResultAsync(queryFilter, offset, limit);
        }
    }
}
