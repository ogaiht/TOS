using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;
using TOS.Common.DataModel;
using TOS.Data.Repositories;
using TOS.NiceReads.Models;

namespace TOS.NiceReads.Data.Repositories
{
    public interface IBookRepository : IRepository<Book, ObjectId>
    {
        Task<IReadOnlyCollection<Book>> GetByAuthorIdAsync(ObjectId authorId);
        Task<IPagedResult<Book>> GetBooksAsync();
    }
}
