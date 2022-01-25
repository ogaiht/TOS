using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TOS.CaseChecker.Models;
using TOS.Common;
using TOS.Common.Collections;
using TOS.Data.MongoDB;
using TOS.Data.MongoDB.Repositories;

namespace TOS.CaseChecker.Data.Repositories.Implementations
{
    public class CaseInfoRepository : Repository<CaseInfo>, ICaseInfoRepository
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        public CaseInfoRepository(IDatabaseProvider databaseProvider, IDateTimeProvider dateTimeProvider) : base(databaseProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<IReadOnlyCollection<CaseInfo>> GetInProgressCasesForDateAsync(DateTime caseSubmitDate)
        {
            DateTime start = caseSubmitDate.Date;
            DateTime end = start.AddDays(1).AddSeconds(-1);
            return await Collection
                .Find(c => c.SubmittedDate >= start && c.SubmittedDate <= end && c.CaseStatus == CaseStatus.InProcress)
                .ToListAsync();
        }

        public override Guid Add(CaseInfo model)
        {
            SetCreatedAt(model);
            return base.Add(model);
        }

        public override Task<Guid> AddAsync(CaseInfo model)
        {
            SetCreatedAt(model);
            return base.AddAsync(model);
        }

        public override void AddRange(IEnumerable<CaseInfo> models)
        {
            models.ForEach(c => SetCreatedAt(c));
            base.AddRange(models);
        }

        public override Task AddRangeAsync(IEnumerable<CaseInfo> models)
        {
            models.ForEach(c => SetCreatedAt(c));
            return base.AddRangeAsync(models);
        }

        public override void Update(CaseInfo model)
        {
            base.Update(model);
        }

        public override Task UpdateAsync(CaseInfo model)
        {
            return base.UpdateAsync(model);
        }

        private void SetCreatedAt(CaseInfo caseInfo, DateTime? createdAt = null)
        {
            caseInfo.CreatedAt = createdAt ?? _dateTimeProvider.UtcNow(); ;
        }

        private void SetUpdatedAt(CaseInfo caseInfo, DateTime? updatedAt = null)
        {
            caseInfo.LastUpdatedAt = updatedAt ?? _dateTimeProvider.UtcNow(); ;
        }
    }
}
