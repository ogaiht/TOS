using System;
using System.Collections.Generic;

namespace TOS.EngagementHub.Models.Projections
{
    public class EmployeeDetail
    {
        public Guid Id { get; set; }
        public Name Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public IReadOnlyCollection<EmployeeSkillDetail> Skills { get; set; }
    }
}
