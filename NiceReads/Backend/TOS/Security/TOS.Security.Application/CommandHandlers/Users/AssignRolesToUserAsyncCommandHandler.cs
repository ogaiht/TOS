using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TOS.Application.Security.Commands.Users;
using TOS.Common;
using TOS.CQRS.Handlers.Commands;
using TOS.Data.Security.Repositories;
using TOS.Security.Models;

namespace TOS.Application.Security.CommandHandlers.Users
{
    public class AssignRolesToUserAsyncCommandHandler : IAsyncCommandHandler<AssignRolesToUserAsyncCommand>
    {
        private readonly IUserRolesRepository _userRolesRepository;
        private readonly IDateTimeProvider _dateTimeProvider;

        public AssignRolesToUserAsyncCommandHandler(IUserRolesRepository userRolesRepository, IDateTimeProvider dateTimeProvider)
        {
            _userRolesRepository = userRolesRepository;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task ExecuteAsync(AssignRolesToUserAsyncCommand execution)
        {
            ObjectId userId = ObjectId.Parse(execution.UserId);
            DateTime utcNow = _dateTimeProvider.UtcNow();
            IReadOnlyCollection<UserRole> userRoles = execution
                .RoleIds
                .Select(r => new UserRole() 
                    { 
                        UserId = userId, 
                        RoleId = ObjectId.Parse(r), 
                        CreatedAt = utcNow 
                    }).ToArray();

            await _userRolesRepository.AddRangeAsync(userRoles);
        }
    }
}
