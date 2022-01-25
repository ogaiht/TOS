using System;
using System.Collections.Generic;
using TOS.CQRS.Executions.Queries;

namespace TOS.CaseChecker.Application.Queries.CaseInfos
{
    public class GetCasesDatesAsyncQuery : AsyncQuery<IReadOnlyCollection<DateTime>>
    {
        public GetCasesDatesAsyncQuery(DateTime? start = null, DateTime? end = null)
        {
            Start = start;
            End = end;
        }

        public DateTime? Start { get; }
        public DateTime? End { get; }

    }
}
