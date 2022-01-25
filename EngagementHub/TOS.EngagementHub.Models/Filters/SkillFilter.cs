using TOS.Common.DataModel;

namespace TOS.EngagementHub.Models.Filters
{
    public class SkillFilter : QueryInput
    {
        public SkillFilter(string nameContains = "", int offset = -1, int limit = -1, string sortBy = null, SortDirection sortDirection = SortDirection.Asc)
            : base(offset, limit, sortBy, sortDirection)
        {
            NameContains = nameContains;
        }

        public string NameContains { get; set; }
    }
}
