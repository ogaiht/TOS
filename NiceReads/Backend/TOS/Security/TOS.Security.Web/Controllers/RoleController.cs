using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TOS.Application.Security.Queries.Roles;
using TOS.Common.DataModel;
using TOS.CQRS.Dispatchers.Commands;
using TOS.CQRS.Dispatchers.Queries;
using TOS.Security.Models;

namespace TOS.Web.Security.Controllers
{
    public class RoleController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ILogger<RoleController> _logger;

        public RoleController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher, ILogger<RoleController> logger)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {

                IPagedResult<Role> roles = await _queryDispatcher.ExecuteAsync<GetAllRolesAsyncQuery, IPagedResult<Role>>(new GetAllRolesAsyncQuery());
                return View(roles.Items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on reading roles");
                throw;
            }
        }
    }
}