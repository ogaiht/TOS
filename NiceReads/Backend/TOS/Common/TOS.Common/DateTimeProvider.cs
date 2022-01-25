using System;

namespace TOS.Common
{
    public class DateTimeProvider : IDateTimeProvider
    {
        private const string IsoDateFormat = "yyyy-MM-ddTHH:mm:ssZ";
        public DateTime Now()
        {
            return DateTime.Now;
        }

        public DateTime UtcNow()
        {
            return DateTime.UtcNow;
        }

        public string ToIsoDateString(DateTime dateTime)
        {
            return dateTime.ToString(IsoDateFormat);
        }
    }
}
