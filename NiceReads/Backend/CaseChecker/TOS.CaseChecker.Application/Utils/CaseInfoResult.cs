using System.Collections.Generic;

namespace TOS.CaseChecker.Application.Utils
{
    public class CaseInfoResult
    {
        public CaseInfoResult(IEnumerable<CaseInfoDto> casesInfo, int nextCaseNumber)
        {
            CasesInfo = casesInfo;
            NextCaseNumber = nextCaseNumber;
        }

        public IEnumerable<CaseInfoDto> CasesInfo { get; }
        public int NextCaseNumber { get; }
    }
}
