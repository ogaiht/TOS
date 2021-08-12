using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TOS.Common.DataModel;
using TOS.CQRS.Dispatchers.Commands;
using TOS.CQRS.Dispatchers.Queries;
using TOS.EngagementHub.Application.Commands.States;
using TOS.EngagementHub.Application.Queries.States;
using TOS.EngagementHub.Models;
using TOS.EngagementHub.Web.Models;

namespace TOS.EngagementHub.Web.Controllers
{
    [ApiController]
    [Route("countries/{countryId}/states")]
    public class StateController : BaseController<StateController>
    {
        public StateController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher, ILogger<StateController> logger) : base(commandDispatcher, queryDispatcher, logger)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post(Guid countryId, StateModel state)
        {
            try
            {
                CreateStateAsyncCommand command = new CreateStateAsyncCommand(state.Name, countryId);
                Guid id = await CommandDispatcher.ExecuteAsync<CreateStateAsyncCommand, Guid>(command);
                return Ok(new FoundResponseModel<dynamic>(new { Id = id }));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error when creating State {state}.", state);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid countryId, string name = "", int offset = -1, int limit = -1)
        {
            try
            {
                GetStatesAsyncQuery query = new GetStatesAsyncQuery(countryId, name, offset, limit);
                IPagedResult<State> pagedResult = await QueryDispatcher.ExecuteAsync<GetStatesAsyncQuery, IPagedResult<State>>(query);
                return Ok(new FoundResponseModel<IPagedResult<State>>(pagedResult));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error when loading States.");
                throw;
            }
        }
    }
}
