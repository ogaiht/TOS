using System.Threading.Tasks;
using TOS.Common.DataModel;
using TOS.CQRS.Handlers.Queries;
using TOS.EngagementHub.Data.Queries.Cities;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Application.Queries.Cities
{
    public class GetCitiesAsyncQueryHandler : IAsyncQueryHandler<GetCitiesAsyncQuery, IPagedResult<City>>
    {
        private IGetCitiesAsyncQuery _getCitiesAsyncQuery;

        public GetCitiesAsyncQueryHandler(IGetCitiesAsyncQuery getCitiesAsyncQuery)
        {
            _getCitiesAsyncQuery = getCitiesAsyncQuery;
        }

        public async Task<IPagedResult<City>> ExecuteAsync(GetCitiesAsyncQuery execution)
        {
            return await _getCitiesAsyncQuery.GetCitiesAsync(execution.StateId, execution.Name, execution.Offset, execution.Limit);
        }
    }
}
