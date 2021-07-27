using System;
using System.Collections.Generic;

namespace TOS.EngagementHub.Data.Calculations
{
    public interface IScoreCalculator
    {
        SkillMatchingScore Calculate(IReadOnlyDictionary<Guid, Guid> employeeSkills, IReadOnlyDictionary<Guid, Guid> roleSkills, IReadOnlyDictionary<Guid, int> skillLevels);
    }
}