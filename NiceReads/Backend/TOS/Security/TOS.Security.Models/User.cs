using MongoDB.Bson;
using System;
using TOS.Common.MongoDB;

namespace TOS.Security.Models
{
    public class User : DocumentModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public ObjectId CreatedById { get; set; }
        public Password Password { get; set; }
        public DateTime? LastAccess { get; set; }
    }
}
