using MongoDB.Driver;
using System.Threading.Tasks;
using TOS.Common.DataModel;
using TOS.Data.MongoDB;
using TOS.EngagementHub.Models;
using TOS.EngagementHub.Models.Filters;

namespace TOS.EngagementHub.Data.Queries.Skills
{
    public class FindSkillsByNameAsyncQuery : IFindSkillsByNameAsyncQuery
    {
        private readonly IMongoCollectionProvider _mongoCollectionProvider;

        public FindSkillsByNameAsyncQuery(IMongoCollectionProvider mongoCollectionProvider)
        {
            _mongoCollectionProvider = mongoCollectionProvider;
        }

        public async Task<IPagedResult<Skill>> FindSkillsContainingNameAsync(SkillFilter filter)
        {
            FilterDefinitionBuilder<Skill> filterBuilder = Builders<Skill>.Filter;
            FilterDefinition<Skill> queryFilter;
            if (!string.IsNullOrWhiteSpace(filter.NameContains))
            {
                queryFilter = filterBuilder.Where(s => s.Name.Contains(filter.NameContains));
            }
            else
            {
                queryFilter = filterBuilder.Where(s => true);
            }

            return await _mongoCollectionProvider.GetCollection<Skill>()
                .FindPagedResultAsync(queryFilter, filter.Paging.Offset, filter.Paging.Limit);
        }
    }
}
