using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TOS.NiceReads.Web.Jwt
{
    internal class SessionSecurityTokenValidator : JwtSecurityTokenHandler
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public SessionSecurityTokenValidator(IServiceProvider serviceProvider,
            TokenValidationParameters tokenValidationParameters)
        {
            _serviceProvider = serviceProvider;
            _serviceScopeFactory = _serviceProvider.GetRequiredService<IServiceScopeFactory>();
            _tokenValidationParameters = tokenValidationParameters;
        }

        public override ClaimsPrincipal ValidateToken(string token, TokenValidationParameters validationParameters,
            out SecurityToken validatedToken)
        {
            var claimsPrincipal = base.ValidateToken(token, _tokenValidationParameters, out validatedToken);
            ValidateSession(claimsPrincipal);
            return claimsPrincipal;
        }

        private void ValidateSession(ClaimsPrincipal claimsPrincipal)
        {
            //using (var scope = _serviceScopeFactory.CreateScope())
            //{
            //    var sessionIdRetriever = scope.ServiceProvider.GetService<ISessionIdRetriever>();
            //    var sessionService = scope.ServiceProvider.GetService<ISessionService>();
            //    var sessionId = sessionIdRetriever.GetSessionId(claimsPrincipal.Claims);
            //    if (!sessionService.IsSessionActiveAsync(sessionId).Result)
            //        throw new TokenSessionExpiredException("The user session has finished.");
            //}
        }
    }
}
