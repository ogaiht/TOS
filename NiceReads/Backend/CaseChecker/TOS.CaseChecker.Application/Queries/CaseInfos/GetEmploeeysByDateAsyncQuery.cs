using System;
using System.Collections.Generic;
using TOS.CQRS.Executions.Queries;

namespace TOS.CaseChecker.Application.Queries.CaseInfos
{
    public class GetEmploeeysByDateAsyncQuery : AsyncQuery<IEnumerable<string>>
    {
        public GetEmploeeysByDateAsyncQuery(DateTime submitDate)
        {
            SubmitDate = submitDate;
        }

        public DateTime SubmitDate { get; }
    }
}
