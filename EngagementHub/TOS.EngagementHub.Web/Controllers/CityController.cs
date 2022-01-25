using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TOS.Common.DataModel;
using TOS.CQRS.Dispatchers.Commands;
using TOS.CQRS.Dispatchers.Queries;
using TOS.EngagementHub.Application.Commands.Cities;
using TOS.EngagementHub.Application.Queries.Cities;
using TOS.EngagementHub.Models;
using TOS.EngagementHub.Web.Models;

namespace TOS.EngagementHub.Web.Controllers
{
    [ApiController]
    [Route("countries/{countryId}/states/{stateId}/cities")]
    public class CityController : BaseController<CityController>
    {
        public CityController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher, ILogger<CityController> logger) : base(commandDispatcher, queryDispatcher, logger)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post(Guid countryId, Guid stateId, CityModel city)
        {
            try
            {
                CreateCityAsyncCommand command = new CreateCityAsyncCommand(city.Name, stateId);
                Guid id = await CommandDispatcher.ExecuteAsync<CreateCityAsyncCommand, Guid>(command);
                return Ok(new FoundResponseModel<dynamic>(new { Id = id }));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error when creating City {city}.", city);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid countryId, Guid stateId, string name = "", int offset = -1, int limit = -1)
        {
            try
            {
                GetCitiesAsyncQuery query = new GetCitiesAsyncQuery(stateId, name, offset, limit);
                IPagedResult<City> pagedResult = await QueryDispatcher.ExecuteAsync<GetCitiesAsyncQuery, IPagedResult<City>>(query);
                return Ok(new FoundResponseModel<IPagedResult<City>>(pagedResult));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error when loading Cities.");
                throw;
            }
        }
    }
}
