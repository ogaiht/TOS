using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TOS.CaseChecker.Application.Utils
{
    public interface ICaseInfoDiscoverer
    {
        Task<IEnumerable<CaseInfoDto>> DiscoverCasesForDateAsync(DateTime date, int startCaseNumber, SearchDirection searchDirection = SearchDirection.Both);
    }
}