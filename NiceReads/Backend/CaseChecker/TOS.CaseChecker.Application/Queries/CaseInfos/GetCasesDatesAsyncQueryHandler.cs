using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TOS.CaseChecker.Data.Queries.Cases;
using TOS.CQRS.Handlers.Queries;

namespace TOS.CaseChecker.Application.Queries.CaseInfos
{
    public class GetCasesDatesAsyncQueryHandler : IAsyncQueryHandler<GetCasesDatesAsyncQuery, IReadOnlyCollection<DateTime>>
    {
        private readonly IGetCaseDatesAsyncQuery _getCaseDatesAsyncQuery;

        public GetCasesDatesAsyncQueryHandler(IGetCaseDatesAsyncQuery getCaseDatesAsyncQuery)
        {
            _getCaseDatesAsyncQuery = getCaseDatesAsyncQuery;
        }

        public async Task<IReadOnlyCollection<DateTime>> ExecuteAsync(GetCasesDatesAsyncQuery execution)
        {
            return await _getCaseDatesAsyncQuery.ExecuteAsync(execution.Start, execution.End);
        }
    }
}
