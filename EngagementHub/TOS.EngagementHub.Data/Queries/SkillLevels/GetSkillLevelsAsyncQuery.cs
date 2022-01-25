using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using TOS.Data.MongoDB;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Data.Queries.SkillLevels
{
    public class GetSkillLevelsAsyncQuery : IGetSkillLevelsAsyncQuery
    {
        private readonly IMongoCollectionProvider _mongoCollectionProvider;

        public GetSkillLevelsAsyncQuery(IMongoCollectionProvider mongoCollectionProvider)
        {
            _mongoCollectionProvider = mongoCollectionProvider;
        }

        public async Task<IReadOnlyCollection<SkillLevel>> GetSkillLevelsAsync()
        {
            return await _mongoCollectionProvider.GetCollection<SkillLevel>().Find(s => true).ToListAsync();
        }
    }
}
