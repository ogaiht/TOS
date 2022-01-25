using TOS.CaseChecker.Models;

namespace TOS.CaseChecker.Application.Utils
{
    public class CaseInfoParser : ICaseInfoParser
    {
        public CaseInfo ToCaseInfo(CaseInfoDto caseInfoDto)
        {
            return new CaseInfo()
            {
                CaseNumber = caseInfoDto.CaseNumber,
                CaseStatus = caseInfoDto.CaseStatus,
                CaseType = caseInfoDto.CaseType,
                DhTimestamp = caseInfoDto.DhTimestamp,
                EmployerName = caseInfoDto.EmployerName,
                JobTitle = caseInfoDto.JobTitle,
                SubmittedDate = caseInfoDto.SubmittedDate,
                VisaType = caseInfoDto.VisaType
            };
        }
    }
}
