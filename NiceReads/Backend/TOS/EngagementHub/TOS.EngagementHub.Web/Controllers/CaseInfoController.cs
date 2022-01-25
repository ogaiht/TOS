using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TOS.CaseChecker.Application.Commands.CasesInfo;
using TOS.CaseChecker.Application.Queries.CaseInfos;
using TOS.CaseChecker.Application.Utils;
using TOS.CQRS.Dispatchers.Commands;
using TOS.CQRS.Dispatchers.Queries;

namespace TOS.EngagementHub.Web.Controllers
{
    [ApiController]
    [Route("casesinfo")]
    public class CaseInfoController : BaseController<CaseInfoController>
    {
        public CaseInfoController(
            ICommandDispatcher commandDispatcher,
            IQueryDispatcher queryDispatcher,
            ILogger<CaseInfoController> logger)
            : base(commandDispatcher, queryDispatcher, logger)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get(DateTime submitDate, int seedCaseNumber)
        {
            CasesReport cases = await CommandDispatcher.ExecuteAsync<LoadAllCasesForDateAsyncCommand, CasesReport>(new LoadAllCasesForDateAsyncCommand(submitDate, seedCaseNumber));
            return Ok(cases);
        }

        [HttpGet("getallbetweendates")]
        public async Task<IActionResult> GetAllBetweenDates(DateTime startDate, DateTime endDate)
        {
            IReadOnlyCollection<CasesReport> cases = await CommandDispatcher.ExecuteAsync<LoadAllCasesBetweenDatesAsyncCommand, IReadOnlyCollection<CasesReport>>(new LoadAllCasesBetweenDatesAsyncCommand(startDate, endDate));
            return Ok(cases);
        }

        [HttpGet("checkupdates")]
        public async Task<IActionResult> CheckUpdates(DateTime submitDate)
        {
            CasesUpdatedReport updates = await CommandDispatcher.ExecuteAsync<UpdateCaseInfosAsyncCommand, CasesUpdatedReport>(new UpdateCaseInfosAsyncCommand(submitDate));
            return Ok(updates);

        }

        [HttpGet("getcasesbyemployee")]
        public async Task<IActionResult> GetCasesByEmployee(DateTime submitDate)
        {
            IReadOnlyCollection<CaseReportByEmployer> cases = await QueryDispatcher.ExecuteAsync<GetCasesByEmployeeAsyncQuery, IReadOnlyCollection<CaseReportByEmployer>>(new GetCasesByEmployeeAsyncQuery(submitDate));
            return Ok(new
            {
                TotalCases = cases.Sum(c => c.TotalCasesImported),
                Cases = cases
            });
        }

        [HttpGet("getcasedates")]
        public async Task<IActionResult> GetCaseDates(DateTime? start, DateTime? end)
        {
            IReadOnlyCollection<DateTime> dates = await QueryDispatcher.ExecuteAsync<GetCasesDatesAsyncQuery, IReadOnlyCollection<DateTime>>(new GetCasesDatesAsyncQuery(start, end));
            return Ok(dates);
        }

        [HttpGet("getupdates")]
        public async Task<IActionResult> GetUpdates()
        {
            IReadOnlyCollection<CasesUpdatedReport> updates = await CommandDispatcher.ExecuteAsync<CheckForUpdatesAsyncCommand, IReadOnlyCollection<CasesUpdatedReport>>(new CheckForUpdatesAsyncCommand());
            return Ok(updates);
        }
    }
}
