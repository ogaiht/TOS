using System.Collections.Generic;
using System.Threading.Tasks;

namespace TOS.CaseChecker.Application.Utils
{
    public interface ICaseInfoLoader
    {
        Task<IEnumerable<CaseInfoDto>> LoadCasesAsync(int julianDate, params int[] caseNumbers);
        Task<IEnumerable<CaseInfoDto>> LoadCasesAsync(params string[] caseNumbers);
    }
}