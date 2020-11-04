using System;
using System.Data;
using System.Threading.Tasks;

namespace TOS.Data
{
    public interface ITransactionProvider
    {
        ITransactionScope BeginScope();
        ITransactionScope BeginScope(IsolationLevel isolationLevel);
        void ExecuteInTransaction(Action execution);
        void ExecuteInTransaction(Action execution, IsolationLevel isolationLevel);
        Task ExecuteInTransactionAsync(Func<Task> execution);
        Task ExceuteInTransactionAsync(Func<Task> execution, IsolationLevel isolationLevel);
    }
}
