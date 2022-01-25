using System;

namespace TOS.CaseChecker.Application.Utils
{
    public class CaseInfoDto
    {
        public string CaseNumber { get; set; }
        public string CaseStatus { get; set; }
        public string VisaType { get; set; }
        public string CaseType { get; set; }
        public string EmployerName { get; set; }
        public string JobTitle { get; set; }
        public DateTime SubmittedDate { get; set; }
        public DateTime DhTimestamp { get; set; }
    }
}
