using System;

namespace TOS.Data
{
    public interface ITransactionScope : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
