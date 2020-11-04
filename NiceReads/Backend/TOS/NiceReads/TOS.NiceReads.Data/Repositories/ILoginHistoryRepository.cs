using MongoDB.Bson;
using TOS.Data.Repositories;
using TOS.NiceReads.Models;

namespace TOS.NiceReads.Data.Repositories
{
    public interface ILoginHistoryRepository : IRepository<LoginHistory, ObjectId>
    {
    }
}
