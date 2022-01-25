using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TOS.CaseChecker.Application.Utils;
using TOS.CaseChecker.Data.Repositories;
using TOS.CaseChecker.Models;
using TOS.CQRS.Handlers.Commands;

namespace TOS.CaseChecker.Application.Commands.CasesInfo
{
    public class LoadAllCasesForDateAsyncCommandHandler : IAsyncCommandHandler<LoadAllCasesForDateAsyncCommand, CasesReport>
    {
        private readonly ICaseInfoDiscoverer _caseInfoDiscoverer;
        private readonly ICaseInfoRepository _caseInfoRepository;
        private readonly ICaseInfoParser _caseInfoParser;
        private readonly ICaseInfoReportBuilder _caseInfoReportBuilder;

        public LoadAllCasesForDateAsyncCommandHandler(
            ICaseInfoDiscoverer caseInfoDiscoverer,
            ICaseInfoRepository caseInfoRepository,
            ICaseInfoParser caseInfoParser,
            ICaseInfoReportBuilder caseInfoReportBuilder)
        {
            _caseInfoDiscoverer = caseInfoDiscoverer;
            _caseInfoRepository = caseInfoRepository;
            _caseInfoParser = caseInfoParser;
            _caseInfoReportBuilder = caseInfoReportBuilder;
        }

        public async Task<CasesReport> ExecuteAsync(LoadAllCasesForDateAsyncCommand execution)
        {
            IEnumerable<CaseInfoDto> cases = await _caseInfoDiscoverer.DiscoverCasesForDateAsync(execution.SubmittedDate, execution.SeedCaseNumber);
            if (cases.Any())
            {
                IEnumerable<CaseInfo> casesToCreate = cases.Select(c => _caseInfoParser.ToCaseInfo(c)).ToArray();
                await _caseInfoRepository.AddRangeAsync(casesToCreate);
                return _caseInfoReportBuilder.Build(execution.SubmittedDate, casesToCreate);
            }
            return _caseInfoReportBuilder.Build(execution.SubmittedDate, Array.Empty<CaseInfo>());
        }
    }
}
