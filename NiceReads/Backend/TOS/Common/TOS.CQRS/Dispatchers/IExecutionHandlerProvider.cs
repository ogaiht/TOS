using System.Collections.Generic;

namespace TOS.CQRS.Dispatchers
{
    public interface IExecutionHandlerProvider
    {
        T GetHandlerFor<T>(bool throwExceptionIfNotFound = true);
        IEnumerable<T> GetHandlersFor<T>(bool throwExceptionIfNotFound = true);
    }
}