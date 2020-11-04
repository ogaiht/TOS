using MongoDB.Bson;
using System;
using TOS.Common.MongoDB;

namespace TOS.Security.Models
{    
    public class UserRole : DocumentModel
    {        
        public ObjectId UserId { get; set; }     
        public ObjectId RoleId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
