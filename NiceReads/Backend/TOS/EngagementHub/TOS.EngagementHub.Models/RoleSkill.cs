namespace TOS.EngagementHub.Models
{
    public class RoleSkill : EngagementModel
    {
        public Role Role { get; set; }
        public Skill Skill { get; set; }
        public SkillLevel Level { get; set; }
    }
}
