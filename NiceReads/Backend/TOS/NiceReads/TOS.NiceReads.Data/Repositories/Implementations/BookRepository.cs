using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using TOS.Common.DataModel;
using TOS.Data.MongoDB;
using TOS.Data.MongoDB.Repositories;
using TOS.NiceReads.Models;

namespace TOS.NiceReads.Data.Repositories.Implementations
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(IDatabaseProvider databaseProvider) : base(databaseProvider)
        {
        }

        public async Task<IPagedResult<Book>> GetBooksAsync()
        {
            IReadOnlyCollection<Book> books = await Collection.Find(b => true).ToListAsync();
            return new PagedResult<Book>(books, books.Count);
        }

        public async Task<IReadOnlyCollection<Book>> GetByAuthorIdAsync(ObjectId authorId)
        {
            return await Collection.Find(b => b.AuthorId == authorId).ToListAsync();
        }
    }
}
