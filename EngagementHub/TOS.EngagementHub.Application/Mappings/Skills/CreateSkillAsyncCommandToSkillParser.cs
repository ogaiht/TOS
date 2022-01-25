using TOS.EngagementHub.Application.Commands.Skills;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Application.Mappings.Skills
{
    public class CreateSkillAsyncCommandToSkillParser : ICreateSkillAsyncCommandToSkillParser
    {
        public Skill Parse(CreateSkillAsyncCommand input)
        {
            return new Skill()
            {
                Name = input.Name,
                Description = input.Description
            };
        }
    }
}
