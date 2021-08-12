using MongoDB.Driver;
using System.Threading.Tasks;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.DataBase.Config.Indexes.Cities
{
    public class CitýIndexer1 : Indexer<City>
    {
        protected override async Task IndexAsync(IMongoCollection<City> collection)
        {
            await collection.Indexes.CreateOneAsync(new CreateIndexModel<City>(Builders<City>.IndexKeys.Ascending(e => e.Name)));
            await collection.Indexes.CreateOneAsync(new CreateIndexModel<City>(Builders<City>.IndexKeys.Ascending(e => e.StateId)));
        }
    }
}
