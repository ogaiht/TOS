using System.Collections.Generic;
using System.Threading.Tasks;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Data.Queries.SkillLevels
{
    public interface IGetSkillLevelsAsyncQuery
    {
        Task<IReadOnlyCollection<SkillLevel>> GetSkillLevelsAsync();
    }
}