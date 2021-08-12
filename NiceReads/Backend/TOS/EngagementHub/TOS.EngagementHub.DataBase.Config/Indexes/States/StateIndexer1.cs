using MongoDB.Driver;
using System.Threading.Tasks;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.DataBase.Config.Indexes.Cities
{
    public class StateIndexer1 : Indexer<State>
    {
        protected override async Task IndexAsync(IMongoCollection<State> collection)
        {
            await collection.Indexes.CreateOneAsync(new CreateIndexModel<State>(Builders<State>.IndexKeys.Ascending(e => e.Name)));
            await collection.Indexes.CreateOneAsync(new CreateIndexModel<State>(Builders<State>.IndexKeys.Ascending(e => e.CountryId)));
        }
    }
}
