using System;
using System.Threading.Tasks;
using TOS.CQRS.Handlers.Commands;
using TOS.EngagementHub.Data.Repositories;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Application.Commands.SkillLevels
{
    public class CreateSkillLevelAsyncCommandHandler : IAsyncCommandHandler<CreateSkillLevelAsyncCommand, Guid>
    {
        private readonly ISkillLevelRepository _skillLevelRepository;

        public CreateSkillLevelAsyncCommandHandler(ISkillLevelRepository skillLevelRepository)
        {
            _skillLevelRepository = skillLevelRepository;
        }

        public async Task<Guid> ExecuteAsync(CreateSkillLevelAsyncCommand execution)
        {
            return await _skillLevelRepository.AddAsync(new SkillLevel()
            {
                Name = execution.Name,
                Order = execution.Order,
                Description = execution.Description
            });
        }
    }
}
