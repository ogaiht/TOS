using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace TOS.EngagementHub.Models.Filters
{
    public class RoleFilter
    {
        public string NameContains { get; set; }
        public DateTime? StartsAtOrAfter { get; set; }
        public DateTime? EndsAtOrBefore { get; set; }
        public Guid? ForCityId { get; set; }
        public IReadOnlySet<Guid> ContainSkills { get; set; }
    }
}
