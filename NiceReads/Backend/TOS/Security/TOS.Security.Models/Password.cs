using System;

namespace TOS.Security.Models
{
    public class Password
    {
        public PasswordHash Hash { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
