using System.Collections.Generic;
using System.Threading.Tasks;
using TOS.CaseChecker.Application.Utils;
using TOS.CQRS.Handlers.Commands;

namespace TOS.CaseChecker.Application.Commands.CasesInfo
{
    public class LoadAllCasesBetweenDatesAsyncCommandHandler : IAsyncCommandHandler<LoadAllCasesBetweenDatesAsyncCommand, IReadOnlyCollection<CasesReport>>
    {
        private readonly IDailyCasesLoader _dailyCasesLoader;

        public LoadAllCasesBetweenDatesAsyncCommandHandler(IDailyCasesLoader dailyCasesLoader)
        {
            _dailyCasesLoader = dailyCasesLoader;
        }

        public async Task<IReadOnlyCollection<CasesReport>> ExecuteAsync(LoadAllCasesBetweenDatesAsyncCommand execution)
        {
            List<CasesReport> reports = new List<CasesReport>();
            reports.AddRange(await _dailyCasesLoader.LoadUntilAsync(execution.StartDate, true));
            reports.AddRange(await _dailyCasesLoader.LoadUntilAsync(execution.EndDate, false));
            return reports;
        }
    }
}
