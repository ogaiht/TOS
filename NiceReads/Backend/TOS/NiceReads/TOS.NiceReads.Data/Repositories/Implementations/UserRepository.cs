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
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IDatabaseProvider databaseProvider) : base(databaseProvider)
        {
        }

        public async Task<bool> IsUserNameAvailableAsync(string username)
        {
            return !(await Collection.Find(u => username == u.Username).AnyAsync());
        }

        public async Task<ObjectId> GetUserIdByUsernameAsync(string username)
        {
            return await Collection
                .Find(u => username == u.Username)
                .Project(u => u.Id).FirstOrDefaultAsync();
        }

        public async Task<IPagedResult<User>> GetAsync()
        {
            IReadOnlyCollection<User> users = await Collection.Find(u => true).ToListAsync();
            return new PagedResult<User>(users, users.Count);
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await Collection
                .Find(u => username == u.Username)
                .FirstOrDefaultAsync();
        }
    }
}
