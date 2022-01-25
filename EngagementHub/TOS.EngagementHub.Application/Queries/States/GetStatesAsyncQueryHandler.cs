using System.Threading.Tasks;
using TOS.Common.DataModel;
using TOS.CQRS.Handlers.Queries;
using TOS.EngagementHub.Data.Queries.States;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Application.Queries.States
{
    public class GetStatesAsyncQueryHandler : IAsyncQueryHandler<GetStatesAsyncQuery, IPagedResult<State>>
    {
        private IGetStatesAsyncQuery _getStatesAsyncQuery;

        public GetStatesAsyncQueryHandler(IGetStatesAsyncQuery getStatesAsyncQuery)
        {
            _getStatesAsyncQuery = getStatesAsyncQuery;
        }

        public async Task<IPagedResult<State>> ExecuteAsync(GetStatesAsyncQuery execution)
        {
            return await _getStatesAsyncQuery.GetStatesAsync(execution.CountryId, execution.Name, execution.Offset, execution.Limit);
        }
    }
}
