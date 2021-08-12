using System.Threading.Tasks;
using TOS.Common.DataModel;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Data.Queries.Countries
{
    public interface IGetCountrisAsyncQuery
    {
        Task<IPagedResult<Country>> GetCountriesAsync(string name = null, int offset = -1, int limit = -1);
    }
}