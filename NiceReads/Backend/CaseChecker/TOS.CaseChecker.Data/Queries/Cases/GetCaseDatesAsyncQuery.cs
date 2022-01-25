using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOS.CaseChecker.Models;
using TOS.Common;
using TOS.Data.MongoDB;

namespace TOS.CaseChecker.Data.Queries.Cases
{
    public class GetCaseDatesAsyncQuery : IGetCaseDatesAsyncQuery
    {
        private readonly IMongoCollectionProvider _mongoCollectionProvider;
        private readonly IDateTimeProvider _dateTimeProvider;

        public GetCaseDatesAsyncQuery(IMongoCollectionProvider mongoCollectionProvider, IDateTimeProvider dateTimeProvider)
        {
            _mongoCollectionProvider = mongoCollectionProvider;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<IReadOnlyCollection<DateTime>> ExecuteAsync(DateTime? start = null, DateTime? end = null)
        {
            List<BsonDocument> pipelineSteps = new List<BsonDocument>()
            {
                BsonDocument.Parse("{ $set: { date: { $dateTrunc: { date: '$SubmittedDate', unit: 'day' } } } }"),
                BsonDocument.Parse("{ $group: { _id: '$date' } }")
            };
            CreateMatch(pipelineSteps, start, end);
            pipelineSteps.Add(BsonDocument.Parse("{ $sort: { _id: 1 } }"));
            PipelineDefinition<CaseInfo, Result> pipelineDefinition = pipelineSteps.ToArray();
            List<Result> dates = await _mongoCollectionProvider.GetCollection<CaseInfo>()
                .Aggregate(pipelineDefinition)
                .ToListAsync();
            return dates.Select(d => d._id).ToArray();
        }

        private void CreateMatch(List<BsonDocument> pipelineSteps, DateTime? start, DateTime? end)
        {
            if (start == null && end == null)
            {
                return;
            }
            StringBuilder match = new StringBuilder("{ $match: {  _id: { ");
            if (start != null)
            {
                match.AppendFormat(" $gte: ISODate('{0}')", _dateTimeProvider.ToIsoDateString(start.Value.Date));
            }
            if (end != null)
            {
                if (start != null)
                {
                    match.Append(", ");
                }
                match.AppendFormat(" $lte: ISODate('{0}')", _dateTimeProvider.ToIsoDateString(end.Value.Date));
            }
            match.Append(" } } }");
            pipelineSteps.Add(BsonDocument.Parse(match.ToString()));
        }

        private class Result
        {
            public DateTime _id;
        }
    }
}
