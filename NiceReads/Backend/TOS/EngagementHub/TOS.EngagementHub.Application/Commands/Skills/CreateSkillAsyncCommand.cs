using System;
using TOS.CQRS.Executions.Commands;

namespace TOS.EngagementHub.Application.Commands.Skills
{
    public class CreateSkillAsyncCommand : AsyncCommand<Guid>
    {
        public CreateSkillAsyncCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; }
        public string Description { get; }
    }
}
