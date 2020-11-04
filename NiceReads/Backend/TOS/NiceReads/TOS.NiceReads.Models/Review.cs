using MongoDB.Bson;
using System;
using System.Collections.Generic;
using TOS.Common.MongoDB;

namespace TOS.NiceReads.Models
{
    public class Review : DocumentModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ObjectId BookId { get; set; }
        public DateTime CreatedAt { get; set; }
        public ObjectId CreatedBy { get; set; }
    }
}
