using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TOS.CaseChecker.Data.Repositories;
using TOS.CaseChecker.Models;

namespace TOS.CaseChecker.Application.Utils
{
    public class CasesLoader : ICasesLoader
    {
        private readonly ICaseInfoDiscoverer _caseInfoDiscoverer;
        private readonly ICaseInfoRepository _caseInfoRepository;
        private readonly ICaseInfoParser _caseInfoParser;
        private readonly ICaseInfoReportBuilder _caseInfoReportBuilder;

        public CasesLoader(ICaseInfoDiscoverer caseInfoDiscoverer, ICaseInfoRepository caseInfoRepository, ICaseInfoParser caseInfoParser, ICaseInfoReportBuilder caseInfoReportBuilder)
        {
            _caseInfoDiscoverer = caseInfoDiscoverer;
            _caseInfoRepository = caseInfoRepository;
            _caseInfoParser = caseInfoParser;
            _caseInfoReportBuilder = caseInfoReportBuilder;
        }

        public async Task<CasesReport> LoadAsync(DateTime currentDate, int seedCaseNumber, SearchDirection searchDirection = SearchDirection.Both)
        {
            IEnumerable<CaseInfoDto> cases = await _caseInfoDiscoverer.DiscoverCasesForDateAsync(currentDate, seedCaseNumber, searchDirection);
            if (cases.Any())
            {
                IEnumerable<CaseInfo> casesToCreate = cases.Select(c => _caseInfoParser.ToCaseInfo(c)).ToArray();
                await _caseInfoRepository.AddRangeAsync(casesToCreate);
                return _caseInfoReportBuilder.Build(currentDate, casesToCreate);
            }
            return _caseInfoReportBuilder.Build(currentDate, Array.Empty<CaseInfo>());
        }
    }
}
