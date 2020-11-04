using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using TOS.Common.DataModel;
using TOS.CQRS.Dispatchers.Commands;
using TOS.CQRS.Dispatchers.Queries;
using TOS.NiceReads.Application.Commands.Users;
using TOS.NiceReads.Application.Queries.Users;
using TOS.NiceReads.Models;
using TOS.NiceReads.Web.Models;

namespace TOS.NiceReads.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("users")]
    public class UserController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ILogger<UserController> _logger;

        public UserController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher, ILogger<UserController> logger)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try 
            {
                IPagedResult<User> users = await _queryDispatcher.ExecuteAsync<GetUsersAsyncQuery, IPagedResult<User>>(new GetUsersAsyncQuery());
                return Ok(users.Items.Select(u => 
                    new UserModel()
                    { 
                        Username = u.Username,
                        Email = u.Email,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Id = u.Id.ToString()
                    }).ToArray());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when retrieving users.");
                throw;
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserModel userModel)
        {
            try
            {
                CreateUserAsyncCommand createUserAsyncCommand = new CreateUserAsyncCommand(
                    userModel.Username,
                    userModel.FirstName,
                    userModel.LastName,
                    userModel.Email,
                    userModel.Password);
                CreateUserAsyncCommandResult result = await _commandDispatcher.ExecuteAsync<CreateUserAsyncCommand, CreateUserAsyncCommandResult>(createUserAsyncCommand);
                if (result.Success)
                {
                    return Ok(new { Success = true, result.UserId });
                }
                else
                {
                    return Ok(new { Success = false, result.Message });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when creating new user.");
                throw;
            }
        }       

        [HttpDelete("/users/{userId}")]
        public async Task<IActionResult> Delete([FromRoute] string userId)
        {
            DeleteUserAsyncCommand deleteUserAsyncCommand = new DeleteUserAsyncCommand(userId);
            await _commandDispatcher.ExecuteAsync(deleteUserAsyncCommand);
            return NoContent();
        }
    }
}
