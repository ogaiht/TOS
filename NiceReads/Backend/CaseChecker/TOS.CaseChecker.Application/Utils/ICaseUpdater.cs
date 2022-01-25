using System;
using System.Threading.Tasks;

namespace TOS.CaseChecker.Application.Utils
{
    public interface ICaseUpdater
    {
        Task<CasesUpdatedReport> ExecuteAsync(DateTime submitteDate);
    }
}