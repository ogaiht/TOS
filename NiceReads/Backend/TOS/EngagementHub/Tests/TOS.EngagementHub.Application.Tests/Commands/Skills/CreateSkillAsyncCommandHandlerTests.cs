using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TOS.EngagementHub.Application.Commands.Skills;
using TOS.EngagementHub.Application.Mappings.Skills;
using TOS.EngagementHub.Data.Repositories;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Application.Tests.Commands.Skills
{
    [TestFixture]
    public class CreateSkillAsyncCommandHandlerTests
    {
        private Mock<ISkillRepository> _skillRepository;
        private Mock<ICreateSkillAsyncCommandToSkillParser> _createSkillAsyncCommandToSkillParser;
        private CreateSkillAsyncCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _skillRepository = new Mock<ISkillRepository>();
            _createSkillAsyncCommandToSkillParser = new Mock<ICreateSkillAsyncCommandToSkillParser>();
            _handler = new CreateSkillAsyncCommandHandler(
                _createSkillAsyncCommandToSkillParser.Object,
                _skillRepository.Object);
        }

        [Test]
        public async Task ExecuteAsync_WhenCreatingSkill_ShouldParseCommand_AndCallRepository()
        {
            Guid expectedId = Guid.NewGuid();
            CreateSkillAsyncCommand command = new CreateSkillAsyncCommand("Skill name", "Skill Description");
            Skill skill = new Skill();

            _createSkillAsyncCommandToSkillParser
                .Setup(p => p.Parse(command))
                .Returns(skill);
            _skillRepository
                .Setup(r => r.AddAsync(skill))
                .ReturnsAsync(expectedId);

            Guid actualId = await _handler.ExecuteAsync(command);

            Assert.AreEqual(expectedId, actualId);
        }
    }
}
