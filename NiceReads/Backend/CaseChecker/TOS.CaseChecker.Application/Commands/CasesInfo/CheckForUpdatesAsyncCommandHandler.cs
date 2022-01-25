using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TOS.CaseChecker.Application.Utils;
using TOS.CaseChecker.Data.Queries.Cases;
using TOS.CQRS.Handlers.Commands;

namespace TOS.CaseChecker.Application.Commands.CasesInfo
{
    public class CheckForUpdatesAsyncCommandHandler : IAsyncCommandHandler<CheckForUpdatesAsyncCommand, IReadOnlyCollection<CasesUpdatedReport>>
    {
        private readonly ICaseUpdater _caseUpdater;
        private readonly IGetCaseDatesToCheckForUpdateAsyncQuery _getCaseDatesToCheckForUpdateAsyncQuery;

        public CheckForUpdatesAsyncCommandHandler(ICaseUpdater caseUpdater, IGetCaseDatesToCheckForUpdateAsyncQuery getCaseDatesToCheckForUpdateAsyncQuery)
        {
            _caseUpdater = caseUpdater;
            _getCaseDatesToCheckForUpdateAsyncQuery = getCaseDatesToCheckForUpdateAsyncQuery;
        }

        public async Task<IReadOnlyCollection<CasesUpdatedReport>> ExecuteAsync(CheckForUpdatesAsyncCommand execution)
        {
            IReadOnlyCollection<DateTime> datesToCheck = await _getCaseDatesToCheckForUpdateAsyncQuery.ExecuteAsync();
            if (datesToCheck == null || datesToCheck.Count == 0)
            {
                return Array.Empty<CasesUpdatedReport>();
            }
            List<CasesUpdatedReport> reports = new List<CasesUpdatedReport>();
            foreach (DateTime dateToCheck in datesToCheck)
            {
                reports.Add(await _caseUpdater.ExecuteAsync(dateToCheck));
            }
            return reports;
        }
    }
}
