using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using TOS.Common.DataModel;
using TOS.CQRS;
using TOS.NiceReads.Application.Queries.Authors;
using TOS.NiceReads.Application.Queries.Books;
using TOS.NiceReads.Application.Queries.Users;
using TOS.NiceReads.Models;

namespace TOS.NiceReads.Configuration
{
    internal static class QueryConfiguration
    {
        internal static IServiceCollection AddQueries(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddAsyncQuery<GetAuthorByIdAsyncQuery, Author, GetAuthorByIdAsyncQueryHandler>()
                .AddAsyncQuery<GetBooksByAuthorAsyncQuery, IReadOnlyCollection<Book>, GetBooksByAuthorAsyncQueryHandler>()
                .AddAsyncQuery<GetUsersAsyncQuery, IPagedResult<User>, GetUsersAsyncQueryHandler>()
                .AddAsyncQuery<GetAuthorsAsyncQuery, IPagedResult<Author>, GetAuthorsAsyncQueryHandler>()
                .AddAsyncQuery<GetBooksAsyncQuery, IPagedResult<Book>, GetBooksAsyncQueryHandler>();
        }
    }
}
