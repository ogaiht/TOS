using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TOS.Data.MongoDB;
using TOS.EngagementHub.Models;
using TOS.EngagementHub.Models.Filters;
using TOS.EngagementHub.Models.Projections;

namespace TOS.EngagementHub.Data.Queries.Employees
{
    public class EmployeesByFilterAsyncQuery : IEmployeesByFilterAsyncQuery
    {
        private readonly IMongoCollectionProvider _mongoCollectionProvider;

        public EmployeesByFilterAsyncQuery(IMongoCollectionProvider mongoCollectionProvider)
        {
            _mongoCollectionProvider = mongoCollectionProvider;
        }

        public async Task<IReadOnlyCollection<EmployeeDetail>> FindEmployeesAsync(EmployeeFilter filter)
        {
            IReadOnlyCollection<Employee> employees = await LoadEmployeesAsync(filter);
            GetSkillAndSkillLevelIds(employees, out ISet<Guid> skillIds, out ISet<Guid> skillLevelIds);
            IReadOnlyDictionary<Guid, string> skills = await FindSkillsAsync(skillIds);
            IReadOnlyDictionary<Guid, string> skillLevels = await FindSkillsLevelsAsync(skillLevelIds);
            return employees.Select(e =>
            new EmployeeDetail()
            {
                Id = e.Id,
                Name = e.Name,
                DateOfBirth = e.DateOfBirth,
                Email = e.Email,
                Skills = e.Skills.Select(s =>
                    new EmployeeSkillDetail()
                    {
                        SkillId = s.SkillId,
                        SkillName = skills[s.SkillId],
                        SkillLevelId = s.LevelId,
                        SkillLevelName = skillLevels[s.LevelId]
                    }
                    ).ToArray()
            }).ToArray();
        }

        private static void GetSkillAndSkillLevelIds(IReadOnlyCollection<Employee> employees, out ISet<Guid> skillIds, out ISet<Guid> skillLevelIds)
        {
            skillIds = new HashSet<Guid>();
            skillLevelIds = new HashSet<Guid>();
            foreach (Employee employee in employees)
            {
                foreach (EmployeeSkill employeeSkill in employee.Skills)
                {
                    if (!skillIds.Contains(employeeSkill.SkillId))
                    {
                        skillIds.Add(employeeSkill.SkillId);
                    }
                    if (!skillLevelIds.Contains(employeeSkill.LevelId))
                    {
                        skillLevelIds.Add(employeeSkill.LevelId);
                    }
                }
            }
        }

        private async Task<IReadOnlyCollection<Employee>> LoadEmployeesAsync(EmployeeFilter filter)
        {
            FilterDefinitionBuilder<Employee> filterBuilder = Builders<Employee>.Filter;
            FilterDefinition<Employee> queryFilter;
            if (!string.IsNullOrWhiteSpace(filter.NameContains))
            {
                queryFilter = filterBuilder.Where(e => string.IsNullOrWhiteSpace(filter.NameContains) ||
                        e.Name.FirstName.Contains(filter.NameContains) ||
                        e.Name.MiddleName.Contains(filter.NameContains) ||
                        e.Name.LastName.Contains(filter.NameContains));
            }
            else
            {
                queryFilter = filterBuilder.Where(e => true);
            }

            IAsyncCursor<Employee> asyncCursor = await _mongoCollectionProvider.GetCollection<Employee>()
                .FindAsync(queryFilter);
            return await asyncCursor.ToListAsync();
        }

        private async Task<IReadOnlyDictionary<Guid, string>> FindSkillsAsync(ISet<Guid> skillIds)
        {
            IAsyncCursor<Skill> skillsCursor = await _mongoCollectionProvider.GetCollection<Skill>()
                .FindAsync(s => skillIds.Contains(s.Id));
            List<Skill> skills = await skillsCursor.ToListAsync();
            return skills.ToDictionary(s => s.Id, s => s.Name);
        }

        private async Task<IReadOnlyDictionary<Guid, string>> FindSkillsLevelsAsync(ISet<Guid> skillLevelIds)
        {
            IAsyncCursor<SkillLevel> skillsCursor = await _mongoCollectionProvider.GetCollection<SkillLevel>()
                .FindAsync(s => skillLevelIds.Contains(s.Id));
            List<SkillLevel> skillLevels = await skillsCursor.ToListAsync();
            return skillLevels.ToDictionary(s => s.Id, s => s.Name);
        }
    }
}
