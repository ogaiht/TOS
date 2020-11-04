using TOS.Data.MongoDB;
using TOS.Data.MongoDB.Repositories;
using TOS.NiceReads.Models;

namespace TOS.NiceReads.Data.Repositories.Implementations
{
    public class LoginHistoryRepository : Repository<LoginHistory>, ILoginHistoryRepository
    {
        public LoginHistoryRepository(IDatabaseProvider databaseProvider) : base(databaseProvider)
        {
        }
    }
}
