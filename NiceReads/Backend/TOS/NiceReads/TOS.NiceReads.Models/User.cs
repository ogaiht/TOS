using System;
using TOS.Common.MongoDB;

namespace TOS.NiceReads.Models
{
    public class User : DocumentModel
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public Password Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastAccess { get; set; }
    }
}
