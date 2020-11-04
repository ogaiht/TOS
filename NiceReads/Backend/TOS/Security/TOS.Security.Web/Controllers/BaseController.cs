using Microsoft.AspNetCore.Mvc;
using TOS.CQRS.Dispatchers.Commands;

namespace TOS.Web.Security.Controllers
{
    public abstract class BaseController : Controller
    {
        
        protected BaseController(ICommandDispatcher commandDispatcher)
        {
            CommandDispatcher = commandDispatcher;
        }

        protected ICommandDispatcher CommandDispatcher { get; }
    }
}
