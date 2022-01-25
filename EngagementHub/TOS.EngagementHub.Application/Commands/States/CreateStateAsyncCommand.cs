using System;
using TOS.CQRS.Executions.Commands;

namespace TOS.EngagementHub.Application.Commands.States
{
    public class CreateStateAsyncCommand : AsyncCommand<Guid>
    {
        public CreateStateAsyncCommand(string name, Guid countryId)
        {
            Name = name;
            CountryId = countryId;
        }

        public string Name { get; }
        public Guid CountryId { get; }
    }
}
