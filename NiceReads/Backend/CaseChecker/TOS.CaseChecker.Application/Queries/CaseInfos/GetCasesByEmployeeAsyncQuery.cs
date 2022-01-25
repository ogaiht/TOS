using System;
using System.Collections.Generic;
using TOS.CaseChecker.Application.Utils;
using TOS.CQRS.Executions.Queries;

namespace TOS.CaseChecker.Application.Queries.CaseInfos
{
    public class GetCasesByEmployeeAsyncQuery : AsyncQuery<IReadOnlyCollection<CaseReportByEmployer>>
    {
        public GetCasesByEmployeeAsyncQuery(DateTime submitDate, string employerName = null)
        {
            SubmitDate = submitDate;
            EmployerName = employerName;
        }

        public string EmployerName { get; }
        public DateTime SubmitDate { get; }
    }
}
