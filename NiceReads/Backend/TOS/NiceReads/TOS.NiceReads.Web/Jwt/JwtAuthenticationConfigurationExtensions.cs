using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using TOS.Common.Security.Tokens;
using TOS.Common.Security.Tokens.Factories;

namespace TOS.NiceReads.Web.Jwt
{
    public static class JwtAuthenticationConfigurationExtensions
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddJwt(configuration)
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(bearerOptions =>
                {
                    IServiceProvider serviceProvider = services.BuildServiceProvider();
                    ISecurityConfig securityConfig = serviceProvider.GetService<ISecurityConfig>();
                    ISymmetricSecurityKeyFactory symmetricSecurityKeyFactory = serviceProvider.GetService<ISymmetricSecurityKeyFactory>();
                    SymmetricSecurityKey issuerSigningKey = symmetricSecurityKeyFactory.CreateSymmetricKey(securityConfig.TokenSigningSecurityKey);
                    SymmetricSecurityKey tokenDecryptionKey = symmetricSecurityKeyFactory.CreateSymmetricKey(securityConfig.TokenEncryptionKey);
                    bearerOptions.RequireHttpsMetadata = false;
                    bearerOptions.SaveToken = true;
                    TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = securityConfig.Issuer,
                        ValidAudience = securityConfig.Audience,
                        IssuerSigningKey = issuerSigningKey,
                        TokenDecryptionKey = tokenDecryptionKey,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        RequireExpirationTime = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                    bearerOptions.SecurityTokenValidators.Add(
                        new SessionSecurityTokenValidator(serviceProvider, tokenValidationParameters));
                });
            return services;
        }
    }
}
