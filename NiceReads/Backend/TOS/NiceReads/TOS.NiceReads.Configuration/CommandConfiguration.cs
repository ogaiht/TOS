using Microsoft.Extensions.DependencyInjection;
using TOS.CQRS;
using TOS.NiceReads.Application.Commands.Authentications;
using TOS.NiceReads.Application.Commands.Authors;
using TOS.NiceReads.Application.Commands.Books;
using TOS.NiceReads.Application.Commands.Users;

namespace TOS.NiceReads.Configuration
{
    internal static class CommandsConfiguration
    {
        internal static IServiceCollection AddCommands(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddAsyncCommand<CreateAuthorAsyncCommand, string, CreateAuthorAsyncCommandHandler>()
                .AddAsyncCommand<CreateBookAsyncCommand, string, CreateBookAsyncCommandHandler>()
                .AddAsyncCommand<CreateUserAsyncCommand, CreateUserAsyncCommandResult, CreateUserAsyncCommandHandler>()
                .AddAsyncCommand<UpdateAuthorAsyncCommand, UpdateAuthorAsyncCommandHandler>()
                .AddAsyncCommand<AuthenticateAsyncCommand, AuthenticationResult, AuthenticateAsyncCommandHandler>()
                .AddAsyncCommand<DeleteUserAsyncCommand, DeleteUserAsyncCommandHandler>()
                .AddAsyncCommand<DeleteAuthorAsyncCommand, DeleteAuthorAsyncCommandHandler>();
        }
    }
}
