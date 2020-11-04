using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using TOS.Common.DataModel;
using TOS.Data.MongoDB;
using TOS.Data.MongoDB.Repositories;
using TOS.NiceReads.Models;

namespace TOS.NiceReads.Data.Repositories.Implementations
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(IDatabaseProvider databaseProvider) : base(databaseProvider)
        {
        }

        public async Task<IPagedResult<Author>> GetAsync()
        {
            IReadOnlyCollection<Author> authors = await Collection.Find(u => true).ToListAsync();
            return new PagedResult<Author>(authors, authors.Count);
        }
    }
}
