using System;
using System.Collections.Generic;
using TOS.CaseChecker.Models;

namespace TOS.CaseChecker.Application.Utils
{
    public class CasesUpdatedReport
    {
        public CasesUpdatedReport(DateTime date, int casesChecked, int casesUpdated, IReadOnlyCollection<CaseInfo> cases)
        {
            Date = date;
            CasesChecked = casesChecked;
            CasesUpdated = casesUpdated;
            Cases = cases;
        }
        public DateTime Date { get; }
        public int CasesChecked { get; }
        public int CasesUpdated { get; }
        public IReadOnlyCollection<CaseInfo> Cases { get; }
    }
}
