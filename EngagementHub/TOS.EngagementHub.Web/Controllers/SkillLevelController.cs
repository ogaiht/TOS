using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TOS.CQRS.Dispatchers.Commands;
using TOS.CQRS.Dispatchers.Queries;
using TOS.EngagementHub.Application.Commands.SkillLevels;
using TOS.EngagementHub.Application.Queries.SkillLevels;
using TOS.EngagementHub.Models;
using TOS.EngagementHub.Web.Models;

namespace TOS.EngagementHub.Web.Controllers
{
    [ApiController]
    [Route("skilllevels")]
    public class SkillLevelController : BaseController<SkillLevelController>
    {
        public SkillLevelController(
            ICommandDispatcher commandDispatcher,
            IQueryDispatcher queryDispatcher,
            ILogger<SkillLevelController> logger)
            : base(commandDispatcher, queryDispatcher, logger)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post(SkillLevelModel skillLevel)
        {
            try
            {
                Guid id = await CommandDispatcher.ExecuteAsync<CreateSkillLevelAsyncCommand, Guid>(
                    new CreateSkillLevelAsyncCommand(skillLevel.Name, skillLevel.Order, skillLevel.Description));
                return Ok(new FoundResponseModel<dynamic>(new { Id = id }));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error when creating SkillLevel {skillLevel}.", skillLevel);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IReadOnlyCollection<SkillLevel> skillLevels = await QueryDispatcher.ExecuteAsync<GetSkillLevelsAsyncQuery, IReadOnlyCollection<SkillLevel>>(new GetSkillLevelsAsyncQuery());
                return Ok(new FoundResponseModel<IReadOnlyCollection<SkillLevel>>(skillLevels));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error when loading Skill levels.");
                throw;
            }
        }
    }
}
