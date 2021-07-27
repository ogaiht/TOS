using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TOS.CQRS.Dispatchers.Commands;
using TOS.CQRS.Dispatchers.Queries;
using TOS.EngagementHub.Application.Commands.Skills;
using TOS.EngagementHub.Application.Queries.Skills;
using TOS.EngagementHub.Models;
using TOS.EngagementHub.Web.Models;

namespace TOS.EngagementHub.Web.Controllers
{
    [ApiController]
    [Route("skills")]
    public class SkillController : BaseController<SkillController>
    {
        public SkillController(
            ICommandDispatcher commandDispatcher,
            IQueryDispatcher queryDispatcher,
            ILogger<SkillController> logger)
            : base(commandDispatcher, queryDispatcher, logger)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post(SkillModel skill)
        {
            try
            {
                Guid skillId = await CommandDispatcher.ExecuteAsync<CreateSkillAsyncCommand, Guid>(new CreateSkillAsyncCommand(skill.Name, skill.Description));
                return Ok(new FoundResponseModel<dynamic>(new { Id = skillId }));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error when creating Skill {skill}.", skill);
                throw;
            }
        }

        [HttpGet("{skillId}")]
        public async Task<IActionResult> Get(Guid skillId)
        {
            try
            {
                Skill skill = await QueryDispatcher.ExecuteAsync<GetSkillByIdAsyncQuery, Skill>(new GetSkillByIdAsyncQuery(skillId));
                return Ok(new FoundResponseModel<Skill>(skill));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error when find Skill for id {skillId}.", skillId);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            try
            {
                IReadOnlyCollection<Skill> skills = await QueryDispatcher.ExecuteAsync<GetSkillsByNameAsyncQuery, IReadOnlyCollection<Skill>>(new GetSkillsByNameAsyncQuery(name));
                return Ok(new FoundResponseModel<IReadOnlyCollection<Skill>>(skills));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error when find Skill containing name {name}.", name);
                throw;
            }
        }
    }
}
