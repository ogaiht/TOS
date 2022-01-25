using System;

namespace TOS.Common
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow();
        DateTime Now();

        string ToIsoDateString(DateTime dateTime);
    }
}
