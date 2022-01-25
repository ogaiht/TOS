using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TOS.CaseChecker.Application.Utils
{
    public class CaseInfoDiscoverer : ICaseInfoDiscoverer
    {
        private readonly ICaseInfoLoader _caseInfoLoader;
        private readonly ICaseNumberGenerator _caseNumberGenerator;
        private readonly IJulianDateConverter _julianDateConverter;

        public CaseInfoDiscoverer(ICaseInfoLoader caseInfoLoader, ICaseNumberGenerator caseNumberGenerator, IJulianDateConverter julianDateConverter)
        {
            _caseInfoLoader = caseInfoLoader;
            _caseNumberGenerator = caseNumberGenerator;
            _julianDateConverter = julianDateConverter;
        }

        public async Task<IEnumerable<CaseInfoDto>> DiscoverCasesForDateAsync(DateTime date, int startCaseNumber, SearchDirection searchDirection = SearchDirection.Both)
        {
            const int batchSize = 200;
            const int increase = 1;
            const int decrease = -1;
            const int emptyExecutionsToSkip = 100;
            int julianDate = (int)_julianDateConverter.ToJulian(date);
            List<CaseInfoDto> cases = new List<CaseInfoDto>();

            if ((searchDirection & SearchDirection.Future) == SearchDirection.Future)
            {
                cases.AddRange(await ExecuteUntilAsync(julianDate, startCaseNumber, batchSize, increase, emptyExecutionsToSkip));
            }
            if ((searchDirection & SearchDirection.Past) == SearchDirection.Past)
            {
                cases.AddRange(await ExecuteUntilAsync(julianDate, startCaseNumber - 1, batchSize, decrease, emptyExecutionsToSkip));
            }
            return cases;
        }

        private async Task<CaseInfoResult> LoadCasesAsync(int date, int startCaseNumber, int count, int increment)
        {
            int[] caseNumbers = _caseNumberGenerator.Generate(count, startCaseNumber, increment, out int nextCaseNumber);
            IEnumerable<CaseInfoDto> caseInfos = await _caseInfoLoader.LoadCasesAsync(date, caseNumbers);
            return new CaseInfoResult(caseInfos, nextCaseNumber);
        }

        private async Task<IEnumerable<CaseInfoDto>> ExecuteUntilAsync(int date, int startCaseNumber, int count, int increment, int emptyExecutionsToSkip)
        {
            int emptyCount = 0;
            List<CaseInfoDto> cases = new List<CaseInfoDto>();
            while (emptyCount != emptyExecutionsToSkip)
            {
                CaseInfoResult result = await LoadCasesAsync(date, startCaseNumber, count, increment);
                if (result.CasesInfo.Count() == 0)
                {
                    emptyCount++;
                }
                else
                {
                    if (result.CasesInfo.Count() > 0)
                    {
                        emptyCount = 0;
                    }
                    cases.AddRange(result.CasesInfo);
                }
                startCaseNumber = result.NextCaseNumber;
            }
            return cases;
        }
    }
}
