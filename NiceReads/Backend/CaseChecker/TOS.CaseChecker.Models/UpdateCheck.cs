using System;
using System.Collections.Generic;
using TOS.Common.MongoDB;

namespace TOS.CaseChecker.Models
{
    public class UpdateCheck : DocumentModel
    {
        public DateTime When { get; set; }
        public DateTime SubmittedDate { get; set; }
        public List<Guid> CheckedCaseIds { get; set; } = new List<Guid>();
        public List<Guid> UpdatedCaseIds { get; set; } = new List<Guid>();
    }
}
