using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using TOS.Common.Security.Tokens.Factories;
using TOS.Common.Security.Tokens.Utils;

namespace TOS.Common.Security.Tokens
{
    internal class JwtSecurityTokenCreator : ISecurityTokenCreator
    {
        private readonly ISecurityConfig _securityConfiguration;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly ISigningCredentialsFactory _signingCredentialsFactory;
        private readonly IEncryptingCredentialsFactory _encryptingCredentialsFactory;
        private readonly ITokenTimerProvider _tokenTimerProvider;

        public JwtSecurityTokenCreator(
            ISecurityConfig securityConfiguration,
            IDateTimeProvider dateTimeProvider,
            ISigningCredentialsFactory signingCredentialsFactory,
            IEncryptingCredentialsFactory encryptingCredentialsFactory,
            ITokenTimerProvider tokenTimerProvider
            )
        {
            _securityConfiguration = securityConfiguration;
            _dateTimeProvider = dateTimeProvider;
            _signingCredentialsFactory = signingCredentialsFactory;
            _encryptingCredentialsFactory = encryptingCredentialsFactory;
            _tokenTimerProvider = tokenTimerProvider;
        }

        public TokenResult CreateSecurityToken(TokenCreationInfo tokenCreationInfo)
        {
            IReadOnlyCollection<Claim> userClaims = LoadUserClaims(tokenCreationInfo);
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new GenericIdentity(tokenCreationInfo.Username, "Token"), userClaims);
            string token = CreateToken(claimsIdentity, tokenCreationInfo.ExpiresAt, 0);
            return new TokenResult(token, GetTokenRefreshTimeInSeconds());
        }

        public TokenResult IssueNewToken(TokenUpdateInfo tokenUpdateInfo)
        {
            ClaimsIdentity claimsIdentity = (ClaimsIdentity)tokenUpdateInfo.ClaimsPrincipal.Identity;
            claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, _dateTimeProvider.UtcNow().Ticks.ToString()));
            string token = CreateToken(claimsIdentity, tokenUpdateInfo.ExpiresAt, tokenUpdateInfo.TokenNotValidBeforeSeconds);
            return new TokenResult(token, GetTokenRefreshTimeInSeconds());
        }

        private string CreateToken(ClaimsIdentity identity, DateTime expiresAt, int tokenNotValidBeforeSeconds)
        {
            DateTime notBefore = _tokenTimerProvider.GetNotValidBefore(tokenNotValidBeforeSeconds);
            SigningCredentials signingCredentials = _signingCredentialsFactory.CreateSigningCredentials(_securityConfiguration.TokenSigningSecurityKey);
            EncryptingCredentials encryptingCredentials = _encryptingCredentialsFactory.CreateEncryptingCredentials(_securityConfiguration.TokenEncryptionKey);

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = identity,
                Expires = expiresAt,
                SigningCredentials = signingCredentials,
                EncryptingCredentials = encryptingCredentials,
                Issuer = _securityConfiguration.Issuer,
                Audience = _securityConfiguration.Audience,
                NotBefore = notBefore
            };

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler()
            {
                TokenLifetimeInMinutes = _tokenTimerProvider.GetTokenExpirationInMinutes(expiresAt)
            };

            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            return jwtSecurityTokenHandler.WriteToken(securityToken);
        }

        private static IReadOnlyCollection<Claim> LoadUserClaims(TokenCreationInfo userInfo)
        {
            IReadOnlyCollection<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userInfo.Username),
                new Claim(ClaimTypes.NameIdentifier, userInfo.Id),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email)
            };

            return claims;
        }

        private int GetTokenRefreshTimeInSeconds()
        {
            return _securityConfiguration.TokenLifetimeInMinutes * 60;
        }
    }
}
