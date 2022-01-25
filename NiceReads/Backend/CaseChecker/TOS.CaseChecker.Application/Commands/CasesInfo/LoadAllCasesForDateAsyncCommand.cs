using System;
using TOS.CaseChecker.Application.Utils;
using TOS.CQRS.Executions.Commands;

namespace TOS.CaseChecker.Application.Commands.CasesInfo
{
    public class LoadAllCasesForDateAsyncCommand : AsyncCommand<CasesReport>
    {
        public LoadAllCasesForDateAsyncCommand(DateTime submittedDate, int seedCaseNumber)
        {
            SubmittedDate = submittedDate;
            SeedCaseNumber = seedCaseNumber;
        }

        public DateTime SubmittedDate { get; }
        public int SeedCaseNumber { get; }
    }
}
