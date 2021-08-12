using TOS.Common.DataModel;
using TOS.CQRS.Executions.Queries;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Application.Queries.Countries
{
    public class GetCountriesAsyncQuery : AsyncQuery<IPagedResult<Country>>
    {
        public GetCountriesAsyncQuery(string name = "", int offset = -1, int limit = -1)
        {
            Name = name;
            Offset = offset;
            Limit = limit;
        }

        public string Name { get; }
        public int Offset { get; }
        public int Limit { get; }
    }
}
