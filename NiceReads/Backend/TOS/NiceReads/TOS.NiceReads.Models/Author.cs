using MongoDB.Bson;
using System;
using TOS.Common.MongoDB;

namespace TOS.NiceReads.Models
{
    public class Author : DocumentModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string KnownAs { get; set; }
        public string Biography { get; set; }
        public DateTime CreatedAt { get; set; }
        public ObjectId CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ObjectId? UpdatedBy { get; set; }
    }
}
