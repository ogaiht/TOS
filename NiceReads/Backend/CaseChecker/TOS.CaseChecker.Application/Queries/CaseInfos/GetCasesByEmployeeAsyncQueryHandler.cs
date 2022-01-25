using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TOS.CaseChecker.Application.Utils;
using TOS.CaseChecker.Models;
using TOS.CQRS.Handlers.Queries;
using TOS.Data.MongoDB;

namespace TOS.CaseChecker.Application.Queries.CaseInfos
{
    public class GetCasesByEmployeeAsyncQueryHandler : IAsyncQueryHandler<GetCasesByEmployeeAsyncQuery, IReadOnlyCollection<CaseReportByEmployer>>
    {
        private readonly IMongoCollectionProvider _mongoCollectionProvider;

        public GetCasesByEmployeeAsyncQueryHandler(IMongoCollectionProvider mongoCollectionProvider)
        {
            _mongoCollectionProvider = mongoCollectionProvider;
        }

        public async Task<IReadOnlyCollection<CaseReportByEmployer>> ExecuteAsync(GetCasesByEmployeeAsyncQuery execution)
        {
            DateTime start = execution.SubmitDate.Date;
            DateTime end = start.AddDays(1).AddSeconds(-1);
            IReadOnlyCollection<CaseInfo> cases = await _mongoCollectionProvider.GetCollection<CaseInfo>().Find(c => c.SubmittedDate >= start && c.SubmittedDate <= end).ToListAsync();
            IReadOnlyCollection<CaseReportByEmployer> report = cases.GroupBy(c => c.EmployerName).Select(c => new CaseReportByEmployer(
                start,
              c.Key,
              c.Count(),
              c.GroupBy(g => g.CaseStatus)
              .Select(g => new CaseReportItem(
                  g.Key,
                  g.Count(),
                  g.OrderBy(d => d.DhTimestamp).First().DhTimestamp,
                  g.OrderByDescending(d => d.DhTimestamp).First().DhTimestamp)
                  ).ToArray()
          )).OrderBy(c => c.EmployerName).ToArray();
            return report;
        }
    }
}
