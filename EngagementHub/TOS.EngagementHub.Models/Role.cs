using System;
using System.Collections.Generic;

namespace TOS.EngagementHub.Models
{
    public class Role : EngagementModel
    {
        public string Name { get; set; }
        public Guid ProjectId { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ICollection<RoleSkill> Skills { get; set; }
    }
}
