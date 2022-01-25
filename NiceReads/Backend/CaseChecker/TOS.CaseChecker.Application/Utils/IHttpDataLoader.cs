using System.Collections.Generic;
using System.Threading.Tasks;

namespace TOS.CaseChecker.Application.Utils
{
    public interface IHttpDataLoader
    {
        Task<IEnumerable<CaseInfoDto>> LoadCasesAsync(string url);
    }
}