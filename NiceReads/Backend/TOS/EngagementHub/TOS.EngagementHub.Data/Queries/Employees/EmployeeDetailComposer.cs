using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TOS.Data.MongoDB;
using TOS.EngagementHub.Models;
using TOS.EngagementHub.Models.Projections;

namespace TOS.EngagementHub.Data.Queries.Employees
{
    public class EmployeeDetailComposer : IEmployeeDetailComposer
    {
        private readonly IMongoCollectionProvider _mongoCollectionProvider;

        public EmployeeDetailComposer(IMongoCollectionProvider mongoCollectionProvider)
        {
            _mongoCollectionProvider = mongoCollectionProvider;
        }

        public async Task<IReadOnlyCollection<EmployeeDetail>> LoadEmployeeDetailsAsync(params Employee[] employees)
        {
            UniqueIds uniqueIds = GetUniqueIds(employees);
            IReadOnlyDictionary<Guid, string> skills = await FindSkillsAsync(uniqueIds.SkillIds);
            IReadOnlyDictionary<Guid, string> skillLevels = await FindSkillsLevelsAsync(uniqueIds.SkillLevelIds);
            IReadOnlyDictionary<Guid, Rank> ranks = await FindRanksAsync(uniqueIds.RankIds);
            IReadOnlyDictionary<Guid, City> cities = await FindCitiesAsync(uniqueIds.CityIds);
            return employees.Select(e =>
                new EmployeeDetail()
                {
                    Id = e.Id,
                    Name = e.Name,
                    DateOfBirth = e.DateOfBirth,
                    Email = e.Email,
                    City = e.CityId.HasValue ? cities[e.CityId.Value] : null,
                    Rank = e.RankId.HasValue ? ranks[e.RankId.Value] : null,
                    Skills = e.Skills.Select(s =>
                        new EmployeeSkillDetail()
                        {
                            SkillId = s.SkillId,
                            SkillName = skills[s.SkillId],
                            SkillLevelId = s.LevelId,
                            SkillLevelName = skillLevels[s.LevelId]
                        }
                        ).ToArray()
                }
            ).ToArray();
        }

        private static UniqueIds GetUniqueIds(IReadOnlyCollection<Employee> employees)
        {
            UniqueIds uniqueIds = new UniqueIds();

            foreach (Employee employee in employees)
            {
                foreach (EmployeeSkill employeeSkill in employee.Skills)
                {
                    if (!uniqueIds.SkillIds.Contains(employeeSkill.SkillId))
                    {
                        uniqueIds.SkillIds.Add(employeeSkill.SkillId);
                    }
                    if (!uniqueIds.SkillLevelIds.Contains(employeeSkill.LevelId))
                    {
                        uniqueIds.SkillLevelIds.Add(employeeSkill.LevelId);
                    }
                    if (employee.CityId.HasValue && !uniqueIds.CityIds.Contains(employee.CityId.Value))
                    {
                        uniqueIds.CityIds.Add(employee.CityId.Value);
                    }
                    if (employee.RankId.HasValue && !uniqueIds.RankIds.Contains(employee.RankId.Value))
                    {
                        uniqueIds.RankIds.Add(employee.RankId.Value);
                    }
                }
            }
            return uniqueIds;
        }

        private async Task<IReadOnlyDictionary<Guid, string>> FindSkillsAsync(ISet<Guid> skillIds)
        {
            return await FindAsync<Skill, string>(skillIds, s => s.Name);
        }

        private async Task<IReadOnlyDictionary<Guid, string>> FindSkillsLevelsAsync(ISet<Guid> skillLevelIds)
        {
            return await FindAsync<SkillLevel, string>(skillLevelIds, s => s.Name);
        }

        private async Task<IReadOnlyDictionary<Guid, Rank>> FindRanksAsync(ISet<Guid> rankIds)
        {
            return await FindAsync<Rank, Rank>(rankIds, r => r);
        }

        private async Task<IReadOnlyDictionary<Guid, City>> FindCitiesAsync(ISet<Guid> cityIds)
        {
            return await FindAsync<City, City>(cityIds, c => c);
        }

        private async Task<IReadOnlyDictionary<Guid, TResult>> FindAsync<TDocument, TResult>(ISet<Guid> ids, Func<TDocument, TResult> elementSelector)
            where TDocument : EngagementModel
        {
            List<TDocument> documents = await _mongoCollectionProvider.GetCollection<TDocument>()
                .Find(s => ids.Contains(s.Id)).ToListAsync();
            return documents.ToDictionary(s => s.Id, elementSelector);
        }

        private class UniqueIds
        {
            public readonly HashSet<Guid> SkillIds = new HashSet<Guid>();
            public readonly HashSet<Guid> SkillLevelIds = new HashSet<Guid>();
            public readonly HashSet<Guid> CityIds = new HashSet<Guid>();
            public readonly HashSet<Guid> RankIds = new HashSet<Guid>();
        }
    }
}
