using System;

namespace TOS.CaseChecker.Application.Utils
{
    public class CaseReportItem
    {
        public CaseReportItem(string status, int count, DateTime oldest, DateTime newest)
        {
            Status = status;
            Count = count;
            Oldest = oldest;
            Newest = newest;
        }

        public string Status { get; }
        public int Count { get; }
        public DateTime Oldest { get; }
        public DateTime Newest { get; }
    }
}
