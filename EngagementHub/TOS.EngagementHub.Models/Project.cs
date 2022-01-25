using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace TOS.EngagementHub.Models
{
    public class Project : EngagementModel
    {
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid LeadId { get; set; }
        public ICollection<Guid> RoleIds { get; set; } = new List<Guid>();
        public Guid ClientId { get; set; }
        public Location Location { get; set; }
        public ProjectStatus Status { get; set; }
    }
}
