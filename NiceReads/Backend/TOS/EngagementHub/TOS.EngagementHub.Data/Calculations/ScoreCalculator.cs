using System;
using System.Collections.Generic;

namespace TOS.EngagementHub.Data.Calculations
{
    public class ScoreCalculator : IScoreCalculator
    {
        public SkillMatchingScore Calculate(
            IReadOnlyDictionary<Guid, Guid> employeeSkills,
            IReadOnlyDictionary<Guid, Guid> roleSkills,
            IReadOnlyDictionary<Guid, int> skillLevels)
        {
            List<MatchingSkill> matchingSkills = new List<MatchingSkill>();
            foreach (KeyValuePair<Guid, Guid> roleSkill in roleSkills)
            {
                if (employeeSkills.TryGetValue(roleSkill.Key, out Guid employeeSkillLevel) && skillLevels[employeeSkillLevel] >= skillLevels[roleSkill.Value])
                {
                    matchingSkills.Add(new MatchingSkill(roleSkill.Key, employeeSkillLevel, roleSkill.Value));
                }
            }
            decimal score = ((decimal)matchingSkills.Count) / roleSkills.Count;
            return new SkillMatchingScore(score, matchingSkills);
        }
    }
}
