using MongoDB.Bson;
using System;
using TOS.Common.MongoDB;

namespace TOS.Security.Models
{    
    public class Role : DocumentModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }        
        public ObjectId CreatedById { get; set; }
    }
}
