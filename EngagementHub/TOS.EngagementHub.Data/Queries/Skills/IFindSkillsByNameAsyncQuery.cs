using System.Threading.Tasks;
using TOS.Common.DataModel;
using TOS.EngagementHub.Models;
using TOS.EngagementHub.Models.Filters;

namespace TOS.EngagementHub.Data.Queries.Skills
{
    public interface IFindSkillsByNameAsyncQuery
    {
        Task<IPagedResult<Skill>> FindSkillsContainingNameAsync(SkillFilter filter);
    }
}