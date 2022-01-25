using System.Collections.Generic;
using System.Threading.Tasks;

namespace TOS.CaseChecker.Application.Utils
{
    public class CaseInfoLoader : ICaseInfoLoader
    {
        private readonly IHttpDataLoader _httpDataLoader;
        private readonly ICaseUrlQueryBuilder _caseUrlQueryBuilder;

        public CaseInfoLoader(IHttpDataLoader httpDataLoader, ICaseUrlQueryBuilder caseUrlQueryBuilder)
        {
            _httpDataLoader = httpDataLoader;
            _caseUrlQueryBuilder = caseUrlQueryBuilder;
        }

        public async Task<IEnumerable<CaseInfoDto>> LoadCasesAsync(int julianDate, params int[] caseNumbers)
        {
            string url = _caseUrlQueryBuilder.Build(julianDate, caseNumbers);
            return await _httpDataLoader.LoadCasesAsync(url);
        }

        public async Task<IEnumerable<CaseInfoDto>> LoadCasesAsync(params string[] caseNumbers)
        {
            string url = _caseUrlQueryBuilder.Build(caseNumbers);
            return await _httpDataLoader.LoadCasesAsync(url);
        }
    }
}
