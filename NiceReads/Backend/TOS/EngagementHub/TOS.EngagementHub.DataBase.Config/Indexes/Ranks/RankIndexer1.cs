using MongoDB.Driver;
using System.Threading.Tasks;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.DataBase.Config.Indexes.Ranks
{
    public class RankIndexer1 : Indexer<Rank>
    {
        protected override async Task IndexAsync(IMongoCollection<Rank> collection)
        {
            await collection.Indexes.CreateOneAsync(new CreateIndexModel<Rank>(Builders<Rank>.IndexKeys.Ascending(e => e.Name)));
        }
    }
}
