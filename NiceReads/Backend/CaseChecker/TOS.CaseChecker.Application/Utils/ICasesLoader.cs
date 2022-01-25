using System;
using System.Threading.Tasks;

namespace TOS.CaseChecker.Application.Utils
{
    public interface ICasesLoader
    {
        Task<CasesReport> LoadAsync(DateTime currentDate, int seedCaseNumber, SearchDirection searchDirection = SearchDirection.Both);
    }
}