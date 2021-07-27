using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TOS.CQRS.Dispatchers.Commands;
using TOS.CQRS.Dispatchers.Queries;

namespace TOS.EngagementHub.Web.Controllers
{
    public abstract class BaseController<TController> : ControllerBase where TController : BaseController<TController>
    {
        protected ICommandDispatcher CommandDispatcher { get; private set; }
        protected IQueryDispatcher QueryDispatcher { get; private set; }
        protected ILogger<TController> Logger { get; private set; }

        protected BaseController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher, ILogger<TController> logger)
        {
            CommandDispatcher = commandDispatcher;
            QueryDispatcher = queryDispatcher;
            Logger = logger;
        }
    }
}
