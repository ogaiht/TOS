using System;
using System.Collections.Generic;

namespace TOS.CaseChecker.Application.Utils
{
    public class CaseReportByEmployer : CasesReport
    {
        public CaseReportByEmployer(
            DateTime date,
            string employerName,
            int totalCasesImported,
            IReadOnlyCollection<CaseReportItem> importedCasesByStatus)
            : base(date, totalCasesImported, importedCasesByStatus)
        {
            EmployerName = employerName;
        }

        public string EmployerName { get; }
    }
}
