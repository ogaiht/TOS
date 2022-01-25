using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TOS.Common.DataModel;
using TOS.CQRS.Dispatchers.Commands;
using TOS.CQRS.Dispatchers.Queries;
using TOS.EngagementHub.Application.Commands.Countries;
using TOS.EngagementHub.Application.Queries.Countries;
using TOS.EngagementHub.Models;
using TOS.EngagementHub.Web.Models;

namespace TOS.EngagementHub.Web.Controllers
{
    [ApiController]
    [Route("contries")]
    public class CountryController : BaseController<CountryController>
    {
        public CountryController(
            ICommandDispatcher commandDispatcher,
            IQueryDispatcher queryDispatcher,
            ILogger<CountryController> logger)
            : base(commandDispatcher, queryDispatcher, logger)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post(CountryModel country)
        {
            try
            {
                CreateCountryAsyncCommand command = new CreateCountryAsyncCommand(country.Name);
                Guid id = await CommandDispatcher.ExecuteAsync<CreateCountryAsyncCommand, Guid>(command);
                return Ok(new FoundResponseModel<dynamic>(new { Id = id }));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error when creating Country {country}.", country);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get(string name = "", int offiset = -1, int limit = -1)
        {
            try
            {
                GetCountriesAsyncQuery query = new GetCountriesAsyncQuery(name, offiset, limit);
                IPagedResult<Country> pagedResult = await QueryDispatcher.ExecuteAsync<GetCountriesAsyncQuery, IPagedResult<Country>>(query);
                return Ok(new FoundResponseModel<IPagedResult<Country>>(pagedResult));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error when loading Countries.");
                throw;
            }
        }
    }
}
