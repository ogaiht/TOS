using System;
using System.Threading.Tasks;
using TOS.CQRS.Handlers.Commands;
using TOS.EngagementHub.Data.Repositories;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Application.Commands.Countries
{
    public class CreateCountryAsyncCommandHandler : IAsyncCommandHandler<CreateCountryAsyncCommand, Guid>
    {
        private readonly ICountryRepository _countryRepository;

        public CreateCountryAsyncCommandHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<Guid> ExecuteAsync(CreateCountryAsyncCommand execution)
        {
            return await _countryRepository.AddAsync(new Country() { Name = execution.Name });
        }
    }
}
