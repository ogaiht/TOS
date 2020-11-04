using MongoDB.Bson;
using System.Threading.Tasks;
using TOS.Common.DataModel;
using TOS.Data.Repositories;
using TOS.NiceReads.Models;

namespace TOS.NiceReads.Data.Repositories
{
    public interface IUserRepository : IRepository<User, ObjectId>
    {
        Task<bool> IsUserNameAvailableAsync(string username);
        Task<ObjectId> GetUserIdByUsernameAsync(string username);
        Task<IPagedResult<User>> GetAsync();
        Task<User> GetByUsernameAsync(string username);
    }
}
