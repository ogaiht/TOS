using System.Collections.Generic;
using System.Threading.Tasks;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Data.Queries.Skills
{
    public interface IFindSkillsByNameAsyncQuery
    {
        Task<IReadOnlyCollection<Skill>> FindSkillsContainingNameAsync(string nameLike);
    }
}