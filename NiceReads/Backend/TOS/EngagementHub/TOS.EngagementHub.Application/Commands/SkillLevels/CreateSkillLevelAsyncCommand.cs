using System;
using TOS.CQRS.Executions.Commands;

namespace TOS.EngagementHub.Application.Commands.SkillLevels
{
    public class CreateSkillLevelAsyncCommand : AsyncCommand<Guid>
    {
        public CreateSkillLevelAsyncCommand(string name, int order, string description)
        {
            Name = name;
            Order = order;
            Description = description;
        }

        public string Name { get; }
        public string Description { get; }
        public int Order { get; }
    }
}
