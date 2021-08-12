using System;
using System.Collections.Generic;

namespace TOS.EngagementHub.Models
{
    public class Employee : EngagementModel
    {
        public Name Name { get; set; } = new Name();
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public Guid? CityId { get; set; }
        public Guid? RankId { get; set; }
        public ICollection<EmployeeSkill> Skills { get; set; } = new List<EmployeeSkill>();
    }
}
