using TOS.CaseChecker.Models;

namespace TOS.CaseChecker.Application.Utils
{
    public interface ICaseInfoParser
    {
        CaseInfo ToCaseInfo(CaseInfoDto caseInfoDto);
    }
}