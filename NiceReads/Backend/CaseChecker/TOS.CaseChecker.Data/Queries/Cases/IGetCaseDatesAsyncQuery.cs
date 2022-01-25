using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TOS.CaseChecker.Data.Queries.Cases
{
    public interface IGetCaseDatesAsyncQuery
    {
        Task<IReadOnlyCollection<DateTime>> ExecuteAsync(DateTime? start = null, DateTime? end = null);
    }
}