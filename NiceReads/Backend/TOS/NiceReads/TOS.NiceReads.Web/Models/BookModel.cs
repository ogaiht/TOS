using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace TOS.NiceReads.Web.Models
{
    public class BookModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public string AuthorId { get; set; }
        public string CreatedBy { get; set; }
        public string[] Tags { get; set; }        
    }
}
