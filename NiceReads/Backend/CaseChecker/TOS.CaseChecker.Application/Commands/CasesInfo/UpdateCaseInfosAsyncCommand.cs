using System;
using TOS.CaseChecker.Application.Utils;
using TOS.CQRS.Executions.Commands;

namespace TOS.CaseChecker.Application.Commands.CasesInfo
{
    public class UpdateCaseInfosAsyncCommand : AsyncCommand<CasesUpdatedReport>
    {
        public UpdateCaseInfosAsyncCommand(DateTime submittedDate)
        {
            SubmittedDate = submittedDate;
        }

        public DateTime SubmittedDate { get; }
    }
}
