using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TOS.CaseChecker.Application.Utils
{
    public interface IDailyCasesLoader
    {
        Task<IReadOnlyCollection<CasesReport>> LoadUntilAsync(DateTime date, bool future);
    }
}