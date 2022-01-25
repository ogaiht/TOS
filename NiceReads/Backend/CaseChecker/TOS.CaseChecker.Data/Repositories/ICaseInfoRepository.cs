using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TOS.CaseChecker.Models;
using TOS.Data.Repositories;

namespace TOS.CaseChecker.Data.Repositories
{
    public interface ICaseInfoRepository : IRepository<CaseInfo, Guid>
    {
        Task<IReadOnlyCollection<CaseInfo>> GetInProgressCasesForDateAsync(DateTime caseSubmitDate);
    }
}
