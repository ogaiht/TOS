using MongoDB.Bson;
using System.Threading.Tasks;
using TOS.Common.DataModel;
using TOS.Data.Repositories;
using TOS.NiceReads.Models;

namespace TOS.NiceReads.Data.Repositories
{
    public interface IAuthorRepository : IRepository<Author, ObjectId>
    {
        Task<IPagedResult<Author>> GetAsync();
    }
}
