using System;
using System.Collections.Generic;
using System.Linq;
using TOS.CaseChecker.Models;

namespace TOS.CaseChecker.Application.Utils
{
    public class CaseInfoReportBuilder : ICaseInfoReportBuilder
    {
        public CasesReport Build(DateTime date, IEnumerable<CaseInfo> cases)
        {
            IReadOnlyCollection<CaseReportItem> items = cases
                .GroupBy(c => c.CaseStatus)
                .Select(c => new CaseReportItem(c.Key,
                    c.Count(),
                    c.OrderBy(i => i.DhTimestamp).First().DhTimestamp,
                    c.OrderByDescending(i => i.DhTimestamp).First().DhTimestamp))
                .ToArray();
            return new CasesReport(date, cases.Count(), items);
        }
    }
}
