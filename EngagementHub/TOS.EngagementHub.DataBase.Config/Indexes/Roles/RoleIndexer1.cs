using MongoDB.Driver;
using System.Threading.Tasks;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.DataBase.Config.Indexes.Roles
{
    public class RoleIndexer1 : Indexer<Role>
    {
        protected override async Task IndexAsync(IMongoCollection<Role> collection)
        {
            await collection.Indexes.CreateOneAsync(new CreateIndexModel<Role>(Builders<Role>.IndexKeys.Ascending(e => e.Name)));
        }
    }
}
