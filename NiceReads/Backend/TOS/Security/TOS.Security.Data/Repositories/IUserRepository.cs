using MongoDB.Bson;
using System.Threading.Tasks;
using TOS.Data.Repositories;
using TOS.Security.Models;

namespace TOS.Data.Security.Repositories
{
    public interface IUserRepository : IRepository<User, ObjectId>
    {
        Task<User> GetByUsername(string username);
    }
}
