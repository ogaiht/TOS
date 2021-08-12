using MongoDB.Driver;
using System.Threading.Tasks;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.DataBase.Config.Indexes.Countries
{
    public class CountryIndexer1 : Indexer<Country>
    {
        protected override async Task IndexAsync(IMongoCollection<Country> collection)
        {
            await collection.Indexes.CreateOneAsync(new CreateIndexModel<Country>(Builders<Country>.IndexKeys.Ascending(e => e.Name)));
        }
    }
}
