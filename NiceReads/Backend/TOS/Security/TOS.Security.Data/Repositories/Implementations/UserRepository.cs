using MongoDB.Driver;
using System.Threading.Tasks;
using TOS.Data.MongoDB;
using TOS.Data.MongoDB.Repositories;
using TOS.Security.Models;

namespace TOS.Data.Security.Repositories.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IDatabaseProvider databaseProvider) : base(databaseProvider)
        {
        }

        public async Task<User> GetByUsername(string username)
        {
            IAsyncCursor<User> asyncCursor = await Collection.FindAsync(u => u.Name == username);
            return await asyncCursor.FirstOrDefaultAsync();
        }
    }
}
