using System;
using System.Collections.Generic;
using TOS.CaseChecker.Models;

namespace TOS.CaseChecker.Application.Utils
{
    public interface ICaseInfoReportBuilder
    {
        CasesReport Build(DateTime date, IEnumerable<CaseInfo> cases);
    }
}