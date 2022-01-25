using System;

namespace TOS.CaseChecker.Application.Utils
{
    public class CloserStartPoint
    {
        public CloserStartPoint(DateTime date, string caseNumber)
        {
            Date = date;
            CaseNumber = caseNumber;
        }

        public DateTime Date { get; }
        public string CaseNumber { get; }
    }
}
