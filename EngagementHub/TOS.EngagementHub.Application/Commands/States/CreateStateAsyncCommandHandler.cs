using System;
using System.Threading.Tasks;
using TOS.CQRS.Handlers.Commands;
using TOS.EngagementHub.Data.Repositories;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Application.Commands.States
{
    public class CreateStateAsyncCommandHandler : IAsyncCommandHandler<CreateStateAsyncCommand, Guid>
    {
        private readonly IStateRepository _stateRepository;

        public CreateStateAsyncCommandHandler(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public async Task<Guid> ExecuteAsync(CreateStateAsyncCommand execution)
        {
            return await _stateRepository.AddAsync(new State() { Name = execution.Name, CountryId = execution.CountryId });
        }
    }
}
