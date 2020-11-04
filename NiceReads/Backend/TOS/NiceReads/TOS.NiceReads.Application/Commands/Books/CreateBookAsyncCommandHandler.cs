using MongoDB.Bson;
using System;
using System.Linq;
using System.Threading.Tasks;
using TOS.Common;
using TOS.CQRS.Handlers.Commands;
using TOS.NiceReads.Data.Repositories;
using TOS.NiceReads.Models;

namespace TOS.NiceReads.Application.Commands.Books
{
    public class CreateBookAsyncCommandHandler : IAsyncCommandHandler<CreateBookAsyncCommand, string>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;
        private readonly IDateTimeProvider _dateTimeProvider;

        public CreateBookAsyncCommandHandler(IBookRepository bookRepository, IUserRepository userRepository, IDateTimeProvider dateTimeProvider)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<string> ExecuteAsync(CreateBookAsyncCommand execution)
        {
            ObjectId userId = await _userRepository.GetUserIdByUsernameAsync(execution.CreatedBy);
            if (ObjectId.Empty == userId)
            {
                throw new InvalidOperationException($"No user found for the user '{execution.CreatedBy}'.");
            }
            Book book = new Book()
            {
                AuthorId = ObjectId.Parse(execution.AuthorId),
                CreatedBy = userId,
                Title = execution.Title,
                Synopsis = execution.Synopsis,
                Tags = execution.Tags?.ToList(),
                CreatedAt = _dateTimeProvider.UtcNow()
            };
            ObjectId id = await _bookRepository.AddAsync(book);
            return id.ToString();
        }
    }
}
