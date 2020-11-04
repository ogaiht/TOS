using MongoDB.Bson;
using System.Threading.Tasks;
using TOS.Application.Security.Commands.Roles;
using TOS.Application.Security.Events.Roles;
using TOS.Common;
using TOS.CQRS.Dispatchers.Events;
using TOS.CQRS.Handlers.Commands;
using TOS.Data.Security.Repositories;
using TOS.Security.Models;

namespace TOS.Application.Security.CommandHandlers.Roles
{
    public class CreateRoleAsyncCommandHandler : IAsyncCommandHandler<CreateRoleAsyncCommand, string>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IEventDispatcher _eventDispatcher;
        private readonly IDateTimeProvider _dateTimeProvider;

        public CreateRoleAsyncCommandHandler(
            IRoleRepository roleRepository,
            IEventDispatcher eventDispatcher,
            IDateTimeProvider dateTimeProvider)
        {
            _roleRepository = roleRepository;
            _eventDispatcher = eventDispatcher;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<string> ExecuteAsync(CreateRoleAsyncCommand execution)
        {
            Role role = new Role()
            {
                Name = execution.Name,
                Description = execution.Description,
                CreatedAt = _dateTimeProvider.UtcNow(),
                Active = true
            };
            ObjectId roleId = await _roleRepository.AddAsync(role);
            RoleCreatedEvent roleCreatedEvent = new RoleCreatedEvent(role.Name, role.Description, role.CreatedAt);
            _eventDispatcher.Dispatch(roleCreatedEvent);
            return roleId.ToString();
        }
    }
}
