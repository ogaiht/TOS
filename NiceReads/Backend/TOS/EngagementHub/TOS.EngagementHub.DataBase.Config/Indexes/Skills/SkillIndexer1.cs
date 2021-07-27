using MongoDB.Driver;
using System.Threading.Tasks;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.DataBase.Config.Indexes.Skills
{
    public class SkillIndexer1 : Indexer<Skill>
    {
        protected override async Task IndexAsync(IMongoCollection<Skill> collection)
        {
            await collection.Indexes.CreateOneAsync(new CreateIndexModel<Skill>(Builders<Skill>.IndexKeys.Ascending(e => e.Name)));
        }
    }
}
