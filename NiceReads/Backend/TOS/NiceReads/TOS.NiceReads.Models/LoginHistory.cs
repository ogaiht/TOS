using MongoDB.Bson;
using System;
using TOS.Common.MongoDB;

namespace TOS.NiceReads.Models
{
    public class LoginHistory : DocumentModel
    {
        public ObjectId UserId { get; set; }
        public DateTime At { get; set; }
        public LoginStatus Status { get; set; }
    }
}
