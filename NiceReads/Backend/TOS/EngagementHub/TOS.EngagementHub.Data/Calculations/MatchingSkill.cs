using System;

namespace TOS.EngagementHub.Data.Calculations
{
    public class MatchingSkill
    {
        public MatchingSkill(Guid skillId, Guid employeeLevelId, Guid roleLevelId)
        {
            SkillId = skillId;
            EmployeeLevelId = employeeLevelId;
            RoleLevelId = roleLevelId;
        }

        public Guid SkillId { get; }
        public Guid EmployeeLevelId { get; }
        public Guid RoleLevelId { get; }
    }
}
