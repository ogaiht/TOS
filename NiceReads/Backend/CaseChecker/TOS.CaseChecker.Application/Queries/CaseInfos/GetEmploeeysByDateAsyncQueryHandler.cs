using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using TOS.CaseChecker.Models;
using TOS.CQRS.Handlers.Queries;
using TOS.Data.MongoDB;

namespace TOS.CaseChecker.Application.Queries.CaseInfos
{
    public class GetEmploeeysByDateAsyncQueryHandler : IAsyncQueryHandler<GetEmploeeysByDateAsyncQuery, IEnumerable<string>>
    {
        private readonly IMongoCollectionProvider _mongoCollectionProvider;

        public GetEmploeeysByDateAsyncQueryHandler(IMongoCollectionProvider mongoCollectionProvider)
        {
            _mongoCollectionProvider = mongoCollectionProvider;
        }

        public async Task<IEnumerable<string>> ExecuteAsync(GetEmploeeysByDateAsyncQuery execution)
        {
            return await _mongoCollectionProvider.GetCollection<CaseInfo>().Distinct(c => c.EmployerName, c => true).ToListAsync();
        }
    }
}
