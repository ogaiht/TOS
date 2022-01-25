using System;
using System.Threading.Tasks;
using TOS.Common.DataModel;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Data.Queries.Cities
{
    public interface IGetCitiesAsyncQuery
    {
        Task<IPagedResult<City>> GetCitiesAsync(Guid stateId, string name = null, int offset = -1, int limit = -1);
    }
}