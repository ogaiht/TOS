using System;
using TOS.CQRS.Executions.Commands;

namespace TOS.EngagementHub.Application.Commands.Cities
{
    public class CreateCityAsyncCommand : AsyncCommand<Guid>
    {
        public CreateCityAsyncCommand(string name, Guid stateId)
        {
            Name = name;
            StateId = stateId;
        }

        public string Name { get; }
        public Guid StateId { get; }
    }
}
