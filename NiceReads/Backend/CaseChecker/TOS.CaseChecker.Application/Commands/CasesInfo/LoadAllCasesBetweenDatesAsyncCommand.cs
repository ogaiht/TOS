using System;
using System.Collections.Generic;
using TOS.CaseChecker.Application.Utils;
using TOS.CQRS.Executions.Commands;

namespace TOS.CaseChecker.Application.Commands.CasesInfo
{
    public class LoadAllCasesBetweenDatesAsyncCommand : AsyncCommand<IReadOnlyCollection<CaseReportByEmployer>>
    {
        public LoadAllCasesBetweenDatesAsyncCommand(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
    }
}
