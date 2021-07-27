using System.Collections.Generic;

namespace TOS.EngagementHub.Data.Calculations
{
    public class SkillMatchingScore
    {
        public SkillMatchingScore(decimal value, IReadOnlyCollection<MatchingSkill> matchingSkills)
        {
            Value = value;
            MatchingSkills = matchingSkills;
        }

        public decimal Value { get; }
        public IReadOnlyCollection<MatchingSkill> MatchingSkills { get; }
    }
}
