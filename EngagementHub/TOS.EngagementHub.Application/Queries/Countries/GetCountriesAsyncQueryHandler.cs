using System.Threading.Tasks;
using TOS.Common.DataModel;
using TOS.CQRS.Handlers.Queries;
using TOS.EngagementHub.Data.Queries.Countries;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Application.Queries.Countries
{
    public class GetCountriesAsyncQueryHandler : IAsyncQueryHandler<GetCountriesAsyncQuery, IPagedResult<Country>>
    {
        private readonly IGetCountrisAsyncQuery _getCountrisAsyncQuery;

        public GetCountriesAsyncQueryHandler(IGetCountrisAsyncQuery getCountrisAsyncQuery)
        {
            _getCountrisAsyncQuery = getCountrisAsyncQuery;
        }

        public async Task<IPagedResult<Country>> ExecuteAsync(GetCountriesAsyncQuery execution)
        {
            return await _getCountrisAsyncQuery.GetCountriesAsync(execution.Name, execution.Offset, execution.Limit);
        }
    }
}
