using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TOS.Common.Security.Tokens;
using TOS.CQRS.Dispatchers.Commands;
using TOS.NiceReads.Application.Commands.Authentications;
using TOS.NiceReads.Web.Models;

namespace TOS.NiceReads.Web.Controllers
{
    [ApiController]
    [Route("authentication")]
    public class AuthenticationController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly ILogger<AuthenticationController> _logger;
        private readonly ISecurityTokenCreator _securityTokenCreator;

        public AuthenticationController(ICommandDispatcher commandDispatcher, ILogger<AuthenticationController> logger, ISecurityTokenCreator securityTokenCreator)
        {
            _commandDispatcher = commandDispatcher;
            _logger = logger;
            _securityTokenCreator = securityTokenCreator;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(CredentialsModel credentialsModel)
        {
            AuthenticateAsyncCommand authenticateAsyncCommand = new AuthenticateAsyncCommand(credentialsModel.Username, credentialsModel.Password);
            try
            {
                AuthenticationResult result = await _commandDispatcher.ExecuteAsync<AuthenticateAsyncCommand, AuthenticationResult>(authenticateAsyncCommand);
                if (result.Status == AuthenticationStatus.Success)
                {
                    TokenResult tokenResult = _securityTokenCreator.CreateSecurityToken(
                        new TokenCreationInfo(
                            result.UserInfo.Id.ToString(),
                            result.UserInfo.Username,
                            result.UserInfo.Email,
                            DateTime.UtcNow.AddDays(1)));
                    return Ok(new { credentialsModel.Username, tokenResult.Token, tokenResult.TimeInSecondsUntilNewTokenIssuance });
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when authenticating.");
                throw;
            }
        }
    }    
}
