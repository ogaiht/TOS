using MongoDB.Bson;
using System;
using System.Collections.Generic;
using TOS.Common.MongoDB;

namespace TOS.NiceReads.Models
{
    public class Book : DocumentModel
    {
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public List<string> Tags { get; set; }
        public ObjectId AuthorId { get; set; }
        public DateTime CreatedAt { get; set; }
        public ObjectId CreatedBy { get; set; }
    }
}
