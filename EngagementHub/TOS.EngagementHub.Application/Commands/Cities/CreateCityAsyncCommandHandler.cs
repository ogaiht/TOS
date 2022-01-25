using System;
using System.Threading.Tasks;
using TOS.CQRS.Handlers.Commands;
using TOS.EngagementHub.Data.Repositories;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Application.Commands.Cities
{
    public class CreateCityAsyncCommandHandler : IAsyncCommandHandler<CreateCityAsyncCommand, Guid>
    {
        private readonly ICityRepository _cityRepository;

        public CreateCityAsyncCommandHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<Guid> ExecuteAsync(CreateCityAsyncCommand execution)
        {
            return await _cityRepository.AddAsync(new City() { Name = execution.Name, StateId = execution.StateId });
        }
    }
}
