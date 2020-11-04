using TOS.Data.MongoDB;
using TOS.Data.MongoDB.Repositories;
using TOS.NiceReads.Models;

namespace TOS.NiceReads.Data.Repositories.Implementations
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(IDatabaseProvider databaseProvider) : base(databaseProvider)
        {
        }
    }
}
