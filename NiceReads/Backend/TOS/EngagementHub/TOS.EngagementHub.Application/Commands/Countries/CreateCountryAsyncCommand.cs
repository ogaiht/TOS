using System;
using TOS.CQRS.Executions.Commands;

namespace TOS.EngagementHub.Application.Commands.Countries
{
    public class CreateCountryAsyncCommand : AsyncCommand<Guid>
    {
        public CreateCountryAsyncCommand(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
