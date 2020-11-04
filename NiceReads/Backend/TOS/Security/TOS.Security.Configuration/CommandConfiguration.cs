using Microsoft.Extensions.DependencyInjection;
using TOS.Application.Security.CommandHandlers.Authentication;
using TOS.Application.Security.CommandHandlers.Roles;
using TOS.Application.Security.CommandHandlers.Users;
using TOS.Application.Security.Commands.Authentication;
using TOS.Application.Security.Commands.Roles;
using TOS.Application.Security.Commands.Users;
using TOS.CQRS.Handlers.Commands;

namespace TOS.Configuration.Security
{
    internal class CommandsConfiguration
    {
        public static void AddCommands(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<IAsyncCommandHandler<AuthenticateAsyncCommand, AuthenticationResult>, AuthenticateAsyncCommandHandler>()
                .AddTransient<IAsyncCommandHandler<CreateRoleAsyncCommand, string>, CreateRoleAsyncCommandHandler>()
                .AddTransient<IAsyncCommandHandler<CreateUserAsyncCommand, string>, CreateUserAsyncCommandHandler>()
                .AddTransient<IAsyncCommandHandler<AssignRolesToUserAsyncCommand>, AssignRolesToUserAsyncCommandHandler>();
        }
    }
}
