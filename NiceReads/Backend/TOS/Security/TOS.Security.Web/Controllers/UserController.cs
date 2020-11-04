using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using TOS.Common.DataModel;
using TOS.CQRS.Dispatchers.Commands;
using TOS.CQRS.Dispatchers.Queries;

namespace TOS.Security.Web.Controllers
{
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

        [HttpPost("/users/authenticate")]
        public async Task<IActionResult> Authenticate(CredentialsModel credentialsModel)
        {
            AuthenticateAsyncCommand authenticateAsyncCommand = new AuthenticateAsyncCommand(credentialsModel.Username, credentialsModel.Password);
            AuthenticationResult result = await _commandDispatcher.ExecuteAsync<AuthenticateAsyncCommand, AuthenticationResult>(authenticateAsyncCommand);
            if (result.Status == AuthenticationStatus.Success)
            {
                return Ok(new { Username = credentialsModel.Username, Token = credentialsModel.Username });
            }
            return Unauthorized();
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
