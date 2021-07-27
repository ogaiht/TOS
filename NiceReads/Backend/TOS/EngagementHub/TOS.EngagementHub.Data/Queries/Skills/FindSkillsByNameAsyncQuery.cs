using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using TOS.Data.MongoDB;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Data.Queries.Skills
{
    public class FindSkillsByNameAsyncQuery : IFindSkillsByNameAsyncQuery
    {
        private readonly IMongoCollectionProvider _mongoCollectionProvider;

        public FindSkillsByNameAsyncQuery(IMongoCollectionProvider mongoCollectionProvider)
        {
            _mongoCollectionProvider = mongoCollectionProvider;
        }

        public async Task<IReadOnlyCollection<Skill>> FindSkillsContainingNameAsync(string nameLike)
        {
            IMongoCollection<Skill> collection = _mongoCollectionProvider.GetCollection<Skill>();
            if (!string.IsNullOrWhiteSpace(nameLike))
            {
                return await collection.Find(s => s.Name.StartsWith(nameLike)).ToListAsync();
            }
            return await collection.Find(s => true).ToListAsync();
        }
    }
}
