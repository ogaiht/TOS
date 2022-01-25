using System;
using TOS.Common.DataModel;
using TOS.CQRS.Executions.Queries;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Application.Queries.Cities
{
    public class GetCitiesAsyncQuery : AsyncQuery<IPagedResult<City>>
    {
        public GetCitiesAsyncQuery(Guid stateId, string name = "", int offset = -1, int limit = -1)
        {
            StateId = stateId;
            Name = name;
            Offset = offset;
            Limit = limit;
        }

        public Guid StateId { get; }
        public string Name { get; }
        public int Offset { get; }
        public int Limit { get; }
    }
}
