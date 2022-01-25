using System;
using System.Threading.Tasks;
using TOS.CQRS.Handlers.Commands;
using TOS.EngagementHub.Application.Mappings.Skills;
using TOS.EngagementHub.Data.Repositories;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Application.Commands.Skills
{
    public class CreateSkillAsyncCommandHandler : IAsyncCommandHandler<CreateSkillAsyncCommand, Guid>
    {
        private readonly ICreateSkillAsyncCommandToSkillParser _createSkillAsyncCommandToSkill;
        private readonly ISkillRepository _skillRepository;

        public CreateSkillAsyncCommandHandler(ICreateSkillAsyncCommandToSkillParser createSkillAsyncCommandToSkill, ISkillRepository skillRepository)
        {
            _createSkillAsyncCommandToSkill = createSkillAsyncCommandToSkill;
            _skillRepository = skillRepository;
        }

        public async Task<Guid> ExecuteAsync(CreateSkillAsyncCommand execution)
        {
            Skill skill = _createSkillAsyncCommandToSkill.Parse(execution);
            return await _skillRepository.AddAsync(skill);
        }
    }
}
