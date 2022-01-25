using System.Collections.Generic;
using TOS.CaseChecker.Application.Utils;
using TOS.CQRS.Executions.Commands;

namespace TOS.CaseChecker.Application.Commands.CasesInfo
{
    public class CheckForUpdatesAsyncCommand : AsyncCommand<IReadOnlyCollection<CasesUpdatedReport>>
    {
    }
}
