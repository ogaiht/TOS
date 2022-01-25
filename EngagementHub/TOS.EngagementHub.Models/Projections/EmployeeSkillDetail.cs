using System;

namespace TOS.EngagementHub.Models.Projections
{
    public class EmployeeSkillDetail
    {
        public Guid SkillId { get; set; }
        public string SkillName { get; set; }
        public Guid SkillLevelId { get; set; }
        public string SkillLevelName { get; set; }
    }
}
