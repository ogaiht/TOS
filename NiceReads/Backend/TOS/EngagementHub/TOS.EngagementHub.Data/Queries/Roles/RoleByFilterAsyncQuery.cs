using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TOS.Common;
using TOS.Data.MongoDB;
using TOS.EngagementHub.Models;
using TOS.EngagementHub.Models.Filters;

namespace TOS.EngagementHub.Data.Queries.Roles
{
    public class RoleByFilterAsyncQuery : IRoleByFilterAsyncQuery
    {
        private readonly IMongoCollectionProvider _mongoCollectionProvider;
        private readonly IDateTimeProvider _dateTimeProvider;

        public RoleByFilterAsyncQuery(IMongoCollectionProvider mongoCollectionProvider, IDateTimeProvider dateTimeProvider)
        {
            _mongoCollectionProvider = mongoCollectionProvider;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<IReadOnlyCollection<Role>> FindRolesAsync(RoleFilter filters)
        {
            DateTime endDate = filters.EndsAtOrBefore ?? _dateTimeProvider.UtcNow();
            ISet<Guid> projectsIds = await GetProjectIdsAsync(filters, endDate);
            IAsyncCursor<Role> asyncCursor = await _mongoCollectionProvider.GetCollection<Role>()
                .FindAsync(r =>
                    (string.IsNullOrWhiteSpace(filters.NameContains) || r.Name.Contains(filters.NameContains)) &&
                    (!filters.StartsAtOrAfter.HasValue || r.StartDate >= filters.StartsAtOrAfter) &&
                    (!filters.EndsAtOrBefore.HasValue || r.EndDate <= endDate) &&
                    (!filters.ForCityId.HasValue || projectsIds.Contains(r.ProjectId)) &&
                    (filters.ContainSkills.Count == 0 || r.Skills.All(s => filters.ContainSkills.Contains(s.Skill.Id))));
            return await asyncCursor.ToListAsync();
        }

        private async Task<ISet<Guid>> GetProjectIdsAsync(RoleFilter filters, DateTime endDate)
        {
            if (!filters.ForCityId.HasValue)
            {
                return new HashSet<Guid>();
            }
            List<Guid> ids = await _mongoCollectionProvider
                .GetCollection<Project>()
                .Find(p => p.ClientId == filters.ForCityId && p.Status != ProjectStatus.Canceled && p.EndDate >= endDate)
                .Project(p => p.Id)
                .ToListAsync();
            return new HashSet<Guid>(ids);
        }
    }
}
