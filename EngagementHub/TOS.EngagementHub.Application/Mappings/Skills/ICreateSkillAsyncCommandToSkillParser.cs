using TOS.EngagementHub.Application.Commands.Skills;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Application.Mappings.Skills
{
    public interface ICreateSkillAsyncCommandToSkillParser
    {
        Skill Parse(CreateSkillAsyncCommand input);
    }
}