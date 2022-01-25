using TOS.CaseChecker.Models;
using TOS.Data.MongoDB;
using TOS.Data.MongoDB.Repositories;

namespace TOS.CaseChecker.Data.Repositories.Implementations
{
    public class UpdateCheckRepository : Repository<UpdateCheck>, IUpdateCheckRepository
    {
        public UpdateCheckRepository(IDatabaseProvider databaseProvider) : base(databaseProvider)
        {
        }
    }
}
