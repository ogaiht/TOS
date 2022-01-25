using System;
using System.Collections.Generic;

namespace TOS.CaseChecker.Application.Utils
{
    public class CasesReport
    {
        public CasesReport(DateTime date, int totalCasesImported, IReadOnlyCollection<CaseReportItem> importedCasesByStatus)
        {
            Date = date;
            TotalCasesImported = totalCasesImported;
            ImportedCasesByStatus = importedCasesByStatus;
        }

        public DateTime Date { get; }
        public int TotalCasesImported { get; }
        public IReadOnlyCollection<CaseReportItem> ImportedCasesByStatus { get; }
    }
}
