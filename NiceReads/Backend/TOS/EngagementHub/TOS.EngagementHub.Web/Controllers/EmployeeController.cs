using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TOS.CQRS.Dispatchers.Commands;
using TOS.CQRS.Dispatchers.Queries;
using TOS.EngagementHub.Application.Commands.Employees;
using TOS.EngagementHub.Application.Queries.Employees;
using TOS.EngagementHub.Models;
using TOS.EngagementHub.Models.Filters;
using TOS.EngagementHub.Models.Projections;
using TOS.EngagementHub.Web.Models;

namespace TOS.EngagementHub.Web.Controllers
{
    [ApiController]
    [Route("employees")]
    public class EmployeeController : BaseController<EmployeeController>
    {
        public EmployeeController(
            ICommandDispatcher commandDispatcher,
            IQueryDispatcher queryDispatcher,
            ILogger<EmployeeController> logger)
            : base(commandDispatcher, queryDispatcher, logger)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post(EmployeeModel employee)
        {
            try
            {
                Guid id = await CommandDispatcher.ExecuteAsync<CreateEmployeeAsyncCommand, Guid>(new CreateEmployeeAsyncCommand(
                    employee.FirstName,
                    employee.MiddleName,
                    employee.LastName,
                    employee.Email));
                return Ok(new FoundResponseModel<dynamic>(new { Id = id }));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error when creating Employee {employee}.", employee);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            try
            {
                IReadOnlyCollection<EmployeeDetail> employees = await QueryDispatcher
                    .ExecuteAsync<GetEmployeesByFilterAsyncQuery, IReadOnlyCollection<EmployeeDetail>>(
                    new GetEmployeesByFilterAsyncQuery(new EmployeeFilter(name)));
                return Ok(new FoundResponseModel<IReadOnlyCollection<EmployeeDetail>>(employees));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error when finding Employee.");
                throw;
            }
        }

        [HttpPost("{employeeId}/skills")]
        public async Task<IActionResult> AddSkills(Guid employeeId, SkillLevelItem[] skillLevels)
        {
            EmployeeSkill[] employeeSkills = skillLevels.Select(l => new EmployeeSkill()
            {
                SkillId = l.SkillId,
                LevelId = l.LevelId
            }).ToArray();
            AddSkillsToEmployeeAsyncCommand command = new AddSkillsToEmployeeAsyncCommand(employeeId, employeeSkills);
            try
            {
                await CommandDispatcher.ExecuteAsync(command);
                return Ok();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error when adding skills to Employee.");
                throw;
            }
        }
    }
}
