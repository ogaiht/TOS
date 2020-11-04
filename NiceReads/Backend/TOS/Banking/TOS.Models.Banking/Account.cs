using System;
using TOS.Common.DataModel;

namespace TOS.Models.Banking
{
    public class Account : BaseModel<Guid>
    {
        public int Number { get; set; }
        public decimal Balance { get; set; }
    }
}
