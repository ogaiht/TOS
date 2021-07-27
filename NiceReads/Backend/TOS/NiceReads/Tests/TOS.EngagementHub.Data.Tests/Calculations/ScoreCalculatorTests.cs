using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TOS.EngagementHub.Data.Calculations;

namespace TOS.EngagementHub.Data.Tests.Calculations
{
    public class ScoreCalculatorTests
    {
        private ScoreCalculator _scoreCalculator;
        private Dictionary<Guid, int> _skillLevels;
        private Dictionary<int, Guid> _skillLevelsMapByLevel;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _scoreCalculator = new ScoreCalculator();
            _skillLevels = new Dictionary<Guid, int>()
            {
                { Guid.NewGuid(), 1 }, // beginner
                { Guid.NewGuid(), 2 }, // mid
                { Guid.NewGuid(), 3 }, // advance
                { Guid.NewGuid(), 4 }, // proficient
                { Guid.NewGuid(), 5 }, // expert
            };
            _skillLevelsMapByLevel = _skillLevels.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);
        }

        [Test]
        public void Calculate_WhenCalculating_ShouldCheckEmployeeSkillsAgainstRoleSkills()
        {
            Dictionary<Guid, Guid> employeeSkills = new Dictionary<Guid, Guid>();
            Dictionary<Guid, Guid> roleSkills = new Dictionary<Guid, Guid>();

            List<Guid> sampleSkills = CreateSkills(4);
            roleSkills.Add(sampleSkills[0], _skillLevelsMapByLevel[2]);
            roleSkills.Add(sampleSkills[1], _skillLevelsMapByLevel[3]);
            roleSkills.Add(sampleSkills[2], _skillLevelsMapByLevel[4]);
            roleSkills.Add(sampleSkills[3], _skillLevelsMapByLevel[2]);

            employeeSkills.Add(sampleSkills[0], _skillLevelsMapByLevel[2]);
            employeeSkills.Add(sampleSkills[1], _skillLevelsMapByLevel[4]);
            employeeSkills.Add(sampleSkills[3], _skillLevelsMapByLevel[1]);
            employeeSkills.Add(Guid.NewGuid(), _skillLevelsMapByLevel[4]);

            SkillMatchingScore skillMatchingScore = _scoreCalculator.Calculate(employeeSkills, roleSkills, _skillLevels);

            decimal expectedScore = 2M / 4;

            Assert.AreEqual(expectedScore, skillMatchingScore.Value);
        }

        [Test]
        public void Calculate_WhenTryingToFindMatchingEmployee()
        {
            List<Guid> skills = CreateSkills(30);

            Dictionary<Guid, Dictionary<Guid, Guid>> employees = CreateItems(50000, skills, 3);
            Dictionary<Guid, Dictionary<Guid, Guid>> roles = CreateItems(1, skills, 6);

            List<SkillMatchingScore> skillMatchingScores = new List<SkillMatchingScore>();

            KeyValuePair<Guid, Dictionary<Guid, Guid>> role = roles.First();

            Stopwatch stopwatch = Stopwatch.StartNew();

            foreach (KeyValuePair<Guid, Dictionary<Guid, Guid>> employee in employees)
            {
                skillMatchingScores.Add(_scoreCalculator.Calculate(employee.Value, role.Value, _skillLevels));
            }

            stopwatch.Stop();

            List<IGrouping<decimal, SkillMatchingScore>> group = skillMatchingScores.GroupBy(s => s.Value).ToList();

            Assert.IsNotNull(skillMatchingScores);
        }


        [Test]
        public void Calculate_WhenTryingToFindMatchingRole()
        {
            List<Guid> skills = CreateSkills(30);

            Dictionary<Guid, Dictionary<Guid, Guid>> employees = CreateItems(1, skills, 10);
            Dictionary<Guid, Dictionary<Guid, Guid>> roles = CreateItems(50, skills, 6);

            List<SkillMatchingScore> skillMatchingScores = new List<SkillMatchingScore>();

            KeyValuePair<Guid, Dictionary<Guid, Guid>> employee = employees.First();

            Stopwatch stopwatch = Stopwatch.StartNew();

            foreach (KeyValuePair<Guid, Dictionary<Guid, Guid>> role in roles)
            {
                skillMatchingScores.Add(_scoreCalculator.Calculate(employee.Value, role.Value, _skillLevels));
            }

            stopwatch.Stop();

            List<IGrouping<decimal, SkillMatchingScore>> group = skillMatchingScores.GroupBy(s => s.Value).ToList();

            Assert.IsNotNull(skillMatchingScores);
        }


        private Dictionary<Guid, Dictionary<Guid, Guid>> CreateItems(int count, List<Guid> skills, int minSkills = 1, int maxSkills = 10)
        {
            Dictionary<Guid, Dictionary<Guid, Guid>> items = new Dictionary<Guid, Dictionary<Guid, Guid>>();
            Random random = new Random();
            HashSet<int> usedSkills = new HashSet<int>();
            for (int i = 0; i < count; i++)
            {
                int totalSkills = random.Next(minSkills, maxSkills);
                Guid id = Guid.NewGuid();
                Dictionary<Guid, Guid> ownedSkills = new Dictionary<Guid, Guid>();
                for (int j = 0; j < totalSkills; j++)
                {
                    bool found = false;
                    while (!found)
                    {
                        int skillIndex = random.Next(skills.Count);
                        if (!usedSkills.Contains(skillIndex))
                        {
                            ownedSkills.Add(skills[skillIndex], _skillLevelsMapByLevel[random.Next(1, 5)]);
                            usedSkills.Add(skillIndex);
                            found = true;
                        }
                    }
                }
                items.Add(id, ownedSkills);
                usedSkills.Clear();
            }
            return items;
        }

        public class ItemSkills
        {
            public Guid Id { get; set; }
            public List<SkillLevel> Skills { get; set; }
        }

        public class SkillLevel
        {
            public Guid SkillId { get; set; }
            public Guid LevelId { get; set; }
        }

        private static List<Guid> CreateSkills(int count)
        {
            List<Guid> skills = new List<Guid>();
            for (int i = 0; i < count; i++)
            {
                skills.Add(Guid.NewGuid());
            }
            return skills;
        }
    }
}