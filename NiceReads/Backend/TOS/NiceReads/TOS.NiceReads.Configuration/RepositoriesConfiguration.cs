using Microsoft.Extensions.DependencyInjection;
using TOS.NiceReads.Data.Repositories;
using TOS.NiceReads.Data.Repositories.Implementations;

namespace TOS.NiceReads.Configuration
{
    internal static class RepositoriesConfiguration
    {
        internal static IServiceCollection AddResporitories(this IServiceCollection services)
        {
            return services
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IAuthorRepository, AuthorRepository>()
                .AddScoped<IBookRepository, BookRepository>()
                .AddScoped<IAuthorRepository, AuthorRepository>()
                .AddScoped<ILoginHistoryRepository, LoginHistoryRepository>();
        }
    }
}
