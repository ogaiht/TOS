using System;
using TOS.Common.DataModel;
using TOS.CQRS.Executions.Queries;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Application.Queries.States
{
    public class GetStatesAsyncQuery : AsyncQuery<IPagedResult<State>>
    {
        public GetStatesAsyncQuery(Guid countrId, string name = "", int offset = -1, int limit = -1)
        {
            CountryId = countrId;
            Name = name;
            Offset = offset;
            Limit = limit;
        }

        public Guid CountryId { get; }
        public string Name { get; }
        public int Offset { get; }
        public int Limit { get; }
    }
}
