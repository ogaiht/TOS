using MongoDB.Bson;
using System;
using TOS.Common.MongoDB;

namespace TOS.NiceReads.Models
{
    public class Comment : DocumentModel
    {
        public string Content { get; set; }
        public ObjectId ReviewId { get; set; }
        public DateTime CreatedAt { get; set; }
        public ObjectId CreatedBy { get; set; }
    }
}
