using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TOS.CaseChecker.Data.Queries.Cases
{
    public interface IGetCaseDatesToCheckForUpdateAsyncQuery
    {
        Task<IReadOnlyCollection<DateTime>> ExecuteAsync();
    }
}