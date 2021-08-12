using System;
using System.Threading.Tasks;
using TOS.Common.DataModel;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Data.Queries.States
{
    public interface IGetStatesAsyncQuery
    {
        Task<IPagedResult<State>> GetStatesAsync(Guid countryId, string name = null, int offset = -1, int limit = -1);
    }
}