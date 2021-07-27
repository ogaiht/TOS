using System;
using TOS.Data.Repositories;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Data.Repositories
{
    public interface ISkillRepository : IRepository<Skill, Guid>
    {
    }
}
