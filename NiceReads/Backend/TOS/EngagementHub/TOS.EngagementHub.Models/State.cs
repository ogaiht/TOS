using System;

namespace TOS.EngagementHub.Models
{
    public class State : EngagementModel
    {
        public string Name { get; set; }
        public Guid CountryId { get; set; }
    }
}
