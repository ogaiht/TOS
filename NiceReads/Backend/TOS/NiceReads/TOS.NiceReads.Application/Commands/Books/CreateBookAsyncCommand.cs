using System.Collections.Generic;
using TOS.CQRS.Executions.Commands;

namespace TOS.NiceReads.Application.Commands.Books
{
    public class CreateBookAsyncCommand : AsyncCommand<string>
    {
        public CreateBookAsyncCommand(string title, string synopsis, string authorId, string createdBy, IReadOnlyCollection<string> tags = null)
        {
            Title = title;
            Synopsis = synopsis;
            AuthorId = authorId;
            CreatedBy = createdBy;
            Tags = tags;
        }

        public string Title { get; }
        public string Synopsis { get; }
        public string AuthorId { get; }
        public string CreatedBy { get; }
        public IReadOnlyCollection<string> Tags { get; }
    }
}
