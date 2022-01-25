using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TOS.CaseChecker.Models;
using TOS.Data.MongoDB;

namespace TOS.CaseChecker.Data.Queries.Cases
{
    public class GetCaseDatesToCheckForUpdateAsyncQuery : IGetCaseDatesToCheckForUpdateAsyncQuery
    {
        private readonly IMongoCollectionProvider _mongoCollectionProvider;

        public GetCaseDatesToCheckForUpdateAsyncQuery(IMongoCollectionProvider mongoCollectionProvider)
        {
            _mongoCollectionProvider = mongoCollectionProvider;
        }

        public async Task<IReadOnlyCollection<DateTime>> ExecuteAsync()
        {
            PipelineDefinition<CaseInfo, Result> pipelineDefinition = new BsonDocument[]
            {
                BsonDocument.Parse("{ $match: { CaseStatus: '"+ CaseStatus.InProcress + "'} }"),
                BsonDocument.Parse("{ $set: { date: { $dateTrunc: { date: '$SubmittedDate', unit: 'day' } } } }"),
                BsonDocument.Parse("{ $group: { _id: '$date' } }"),
                BsonDocument.Parse("{ $sort: { _id: 1 } }")
            };
            List<Result> dates = await _mongoCollectionProvider.GetCollection<CaseInfo>()
                .Aggregate(pipelineDefinition)
                .ToListAsync();
            return dates.Select(d => d._id).ToArray();
        }

        private class Result
        {
            public DateTime _id;
        }
    }
}
