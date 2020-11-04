using MongoDB.Bson;
using System;
using System.Threading.Tasks;
using TOS.Common;
using TOS.CQRS.Handlers.Commands;
using TOS.NiceReads.Application.Utils;
using TOS.NiceReads.Data.Repositories;
using TOS.NiceReads.Models;

namespace TOS.NiceReads.Application.Commands.Users
{
    public class CreateUserAsyncCommandHandler : IAsyncCommandHandler<CreateUserAsyncCommand, CreateUserAsyncCommandResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordUtils _passwordUtils;
        private readonly IDateTimeProvider _dateTimeProvider;
        public CreateUserAsyncCommandHandler(IUserRepository userRepository, IPasswordUtils passwordUtils, IDateTimeProvider dateTimeProvider)
        {
            _userRepository = userRepository;
            _passwordUtils = passwordUtils;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<CreateUserAsyncCommandResult> ExecuteAsync(CreateUserAsyncCommand execution)
        {
            if (!await _userRepository.IsUserNameAvailableAsync(execution.Email))
            {
                return new CreateUserAsyncCommandResult(invalidationMessage: $"Username {execution.Email} already used.");
            }

            PasswordHash passwordHash = _passwordUtils.CreatePasswordHash(execution.Password);

            DateTime utcNow = _dateTimeProvider.UtcNow();

            User user = new User()
            {
                Username = execution.Username,
                FirstName = execution.FirstName,
                LastName = execution.LastName,
                Email = execution.Email,
                CreatedAt = utcNow,
                Password = new Password()
                {
                    Hash = passwordHash,
                    CreatedAt = utcNow
                },
                Active = true
            };
            ObjectId id = await _userRepository.AddAsync(user);
            return new CreateUserAsyncCommandResult(id.ToString());
        }
    }
}
