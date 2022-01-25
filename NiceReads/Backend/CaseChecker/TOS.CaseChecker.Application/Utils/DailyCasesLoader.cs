using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TOS.CaseChecker.Application.Utils
{
    public class DailyCasesLoader : IDailyCasesLoader
    {
        private readonly IStartingPointProvider _startingPointProvider;
        private readonly ICasesLoader _casesLoader;
        public DailyCasesLoader(IStartingPointProvider startingPointProvider, ICasesLoader casesLoader)
        {
            _startingPointProvider = startingPointProvider;
            _casesLoader = casesLoader;
        }

        public async Task<IReadOnlyCollection<CasesReport>> LoadUntilAsync(DateTime date, bool future)
        {
            CloserStartPoint closerStartPoint = await _startingPointProvider.FindCloserStartingPointToAsync(date, future);
            DateTime current = closerStartPoint.Date;
            int seedNumber = CaseNumberFinder(closerStartPoint.CaseNumber, future);
            List<CasesReport> casesReportList = new List<CasesReport>();
            do
            {
                CasesReport casesReport = await _casesLoader.LoadAsync(current, seedNumber, future ? SearchDirection.Past : SearchDirection.Future);
                if (casesReport.TotalCasesImported > 0)
                {
                    casesReportList.Add(casesReport);
                }
                current = GetNextDate(current, future);
                closerStartPoint = await _startingPointProvider.FindCloserStartingPointToAsync(date, future);
                seedNumber = CaseNumberFinder(closerStartPoint.CaseNumber, future);
            }
            while ((future && current >= date) || (!future && current <= date));
            return casesReportList;
        }

        private static int CaseNumberFinder(string caseNumber, bool future)
        {
            string[] caseNumberParts = caseNumber.Split('-');
            return int.Parse(caseNumberParts[caseNumberParts.Length - 1]) + (future ? -1 : 1);
        }

        private static DateTime GetNextDate(DateTime current, bool future)
        {
            int increment = future ? -1 : 1;
            DateTime nextDate = current;
            do
            {
                nextDate = nextDate.AddDays(increment);
            }
            while (nextDate.DayOfWeek == DayOfWeek.Sunday);
            return nextDate;
        }
    }
}
