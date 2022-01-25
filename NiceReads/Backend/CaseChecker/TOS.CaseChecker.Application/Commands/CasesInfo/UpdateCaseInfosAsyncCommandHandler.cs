using System.Threading.Tasks;
using TOS.CaseChecker.Application.Utils;
using TOS.CQRS.Handlers.Commands;

namespace TOS.CaseChecker.Application.Commands.CasesInfo
{
    public class UpdateCaseInfosAsyncCommandHandler : IAsyncCommandHandler<UpdateCaseInfosAsyncCommand, CasesUpdatedReport>
    {
        private readonly ICaseUpdater _caseUpdater;

        public UpdateCaseInfosAsyncCommandHandler(ICaseUpdater caseUpdater)
        {
            _caseUpdater = caseUpdater;
        }

        public async Task<CasesUpdatedReport> ExecuteAsync(UpdateCaseInfosAsyncCommand execution)
        {
            return await _caseUpdater.ExecuteAsync(execution.SubmittedDate);
        }
    }
}
