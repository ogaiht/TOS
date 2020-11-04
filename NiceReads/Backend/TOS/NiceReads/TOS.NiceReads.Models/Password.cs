using System;

namespace TOS.NiceReads.Models
{
    public class Password
    {
        public PasswordHash Hash { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
