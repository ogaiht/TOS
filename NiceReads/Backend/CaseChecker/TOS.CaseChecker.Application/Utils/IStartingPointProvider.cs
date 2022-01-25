using System;
using System.Threading.Tasks;

namespace TOS.CaseChecker.Application.Utils
{
    public interface IStartingPointProvider
    {
        Task<CloserStartPoint> FindCloserStartingPointToAsync(DateTime date, bool futureDate);
    }
}