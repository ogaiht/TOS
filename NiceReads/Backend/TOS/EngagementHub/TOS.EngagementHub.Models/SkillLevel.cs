namespace TOS.EngagementHub.Models
{
    public class SkillLevel : EngagementModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }

        public override bool Equals(object obj)
        {
            SkillLevel other = obj as SkillLevel;
            return other != null && other.Name != null && other.Name.Equals(this.Name);
        }

        public override int GetHashCode()
        {
            return (Name ?? string.Empty).GetHashCode();
        }

        public static bool operator ==(SkillLevel first, SkillLevel second)
        {
            return first != null && first.Equals(second);
        }

        public static bool operator !=(SkillLevel first, SkillLevel second)
        {
            return !(first.Order == second.Order);
        }

        public static bool operator >(SkillLevel first, SkillLevel second)
        {
            return first.Order > second.Order;
        }

        public static bool operator <(SkillLevel first, SkillLevel second)
        {
            return first.Order < second.Order;
        }

        public static bool operator >=(SkillLevel first, SkillLevel second)
        {
            return first == second || first.Order > second.Order;
        }

        public static bool operator <=(SkillLevel first, SkillLevel second)
        {
            return first == second || first.Order < second.Order;
        }
    }
}
