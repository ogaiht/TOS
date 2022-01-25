using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TOS.CaseChecker.Data.Repositories;
using TOS.CaseChecker.Models;
using TOS.Common;

namespace TOS.CaseChecker.Application.Utils
{
    public class CaseUpdater : ICaseUpdater
    {
        private readonly ICaseInfoRepository _caseInfoRepository;
        private readonly IUpdateCheckRepository _updateCheckRepository;
        private readonly ICaseInfoLoader _caseInfoLoader;
        private readonly IDateTimeProvider _dateTimeProvider;

        public CaseUpdater(
            ICaseInfoRepository caseInfoRepository,
            IUpdateCheckRepository updateCheckRepository,
            ICaseInfoLoader caseInfoLoader,
            IDateTimeProvider dateTimeProvider)
        {
            _caseInfoRepository = caseInfoRepository;
            _updateCheckRepository = updateCheckRepository;
            _caseInfoLoader = caseInfoLoader;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<CasesUpdatedReport> ExecuteAsync(DateTime submitteDate)
        {
            IReadOnlyCollection<CaseInfo> pendingCaseNumbers = await _caseInfoRepository.GetInProgressCasesForDateAsync(submitteDate);
            if (pendingCaseNumbers.Count == 0)
            {
                return new CasesUpdatedReport(submitteDate, pendingCaseNumbers.Count, 0, Array.Empty<CaseInfo>());
            }
            UpdateCheck updateCheck = new UpdateCheck()
            {
                SubmittedDate = submitteDate,
                When = _dateTimeProvider.Now(),
                CheckedCaseIds = pendingCaseNumbers.Select(c => c.Id).ToList()
            };
            IEnumerable<CaseInfoDto> cases = await _caseInfoLoader.LoadCasesAsync(pendingCaseNumbers.Select(c => c.CaseNumber).ToArray());
            List<CaseInfo> updatedCases = new List<CaseInfo>();
            foreach (CaseInfoDto caseInfoDto in cases)
            {
                if (caseInfoDto.CaseStatus != CaseStatus.InProcress)
                {
                    CaseInfo caseToUpdate = pendingCaseNumbers.First(c => c.CaseNumber == caseInfoDto.CaseNumber);
                    caseToUpdate.CaseStatus = caseInfoDto.CaseStatus;
                    caseInfoDto.DhTimestamp = caseInfoDto.DhTimestamp;
                    await _caseInfoRepository.UpdateAsync(caseToUpdate);
                    updatedCases.Add(caseToUpdate);
                    updateCheck.UpdatedCaseIds.Add(caseToUpdate.Id);
                }
            }
            await _updateCheckRepository.AddAsync(updateCheck);
            return new CasesUpdatedReport(submitteDate, pendingCaseNumbers.Count, updatedCases.Count, updatedCases);
        }
    }
}
