using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;
using TOS.CaseChecker.Models;
using TOS.Data.MongoDB;

namespace TOS.CaseChecker.Application.Utils
{
    public class StartingPointProvider : IStartingPointProvider
    {
        private readonly IMongoCollectionProvider _mongoCollectionProvider;

        public StartingPointProvider(IMongoCollectionProvider mongoCollectionProvider)
        {
            _mongoCollectionProvider = mongoCollectionProvider;
        }

        public async Task<CloserStartPoint> FindCloserStartingPointToAsync(DateTime date, bool futureDate)
        {
            if (futureDate)
            {
                return await _mongoCollectionProvider.GetCollection<CaseInfo>()
                    .Find(c => c.SubmittedDate >= date)
                    .SortBy(c => c.SubmittedDate)
                    .ThenBy(c => c.CaseNumber)
                    .Project(c => new CloserStartPoint(c.SubmittedDate, c.CaseNumber))
                    .FirstOrDefaultAsync();
            }
            else
            {
                return await _mongoCollectionProvider.GetCollection<CaseInfo>()
                 .Find(c => c.SubmittedDate <= date)
                 .SortByDescending(c => c.SubmittedDate)
                 .ThenByDescending(c => c.CaseNumber)
                 .Project(c => new CloserStartPoint(c.SubmittedDate, c.CaseNumber))
                 .FirstOrDefaultAsync();
            }
        }
    }
}
