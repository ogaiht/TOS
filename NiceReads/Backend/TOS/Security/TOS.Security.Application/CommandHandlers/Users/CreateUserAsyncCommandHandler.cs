using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TOS.Application.Security.Commands.Users;
using TOS.CQRS.Handlers.Commands;

namespace TOS.Application.Security.CommandHandlers.Users
{
    public class CreateUserAsyncCommandHandler : IAsyncCommandHandler<CreateUserAsyncCommand, string>
    {
        public Task<string> ExecuteAsync(CreateUserAsyncCommand execution)
        {
            throw new NotImplementedException();
        }
    }
}
