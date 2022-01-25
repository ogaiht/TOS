using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using TOS.Common.DataModel;
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
        public async Task<IActionResult> Get(string name = "", int offset = -1, int limit = -1)
        {
            try
            {
                IPagedResult<EmployeeDetail> employees = await QueryDispatcher
                    .ExecuteAsync<GetEmployeesByFilterAsyncQuery, IPagedResult<EmployeeDetail>>(
                    new GetEmployeesByFilterAsyncQuery(new EmployeeFilter(name, offset, limit)));
                return Ok(new FoundResponseModel<IPagedResult<EmployeeDetail>>(employees));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error when finding Employee.");
                throw;
            }
        }

        [HttpDelete("{employeeId:Guid}")]
        public async Task<IActionResult> Delete(Guid employeeId)
        {
            try
            {
                await CommandDispatcher.ExecuteAsync(new DeleteEmployeeAsyncCommand(employeeId));
                return Ok();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error when deleting Employee with id '{employeeId}'.");
                throw;
            }
        }

        [HttpPost("{employeeId}/skills")]
        public async Task<IActionResult> AddSkills(Guid employeeId, SkillLevelItem[] skillLevels)
        {
            try
            {
                EmployeeSkill[] employeeSkills = skillLevels.Select(l => new EmployeeSkill()
                {
                    SkillId = l.SkillId,
                    LevelId = l.LevelId
                }).ToArray();
                AddSkillsToEmployeeAsyncCommand command = new AddSkillsToEmployeeAsyncCommand(employeeId, employeeSkills);
                await CommandDispatcher.ExecuteAsync(command);
                return Ok();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error when adding skills to Employee.");
                throw;
            }
        }

        [HttpDelete("{employeeId}/skills")]
        public async Task<IActionResult> DeleteSkills(Guid employeeId, Guid[] skillIds)
        {
            try
            {
                RemoveSkillsFromEmployeeAsyncCommand command = new RemoveSkillsFromEmployeeAsyncCommand(employeeId, skillIds);
                await CommandDispatcher.ExecuteAsync(command);
                return Ok();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error when delete skills from Employee.");
                throw;

            }
        }
    }
}
