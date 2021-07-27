using System;

namespace TOS.EngagementHub.Models
{
    public class City : EngagementModel
    {
        public string Name { get; set; }
        public Guid StateId { get; set; }
    }
}
