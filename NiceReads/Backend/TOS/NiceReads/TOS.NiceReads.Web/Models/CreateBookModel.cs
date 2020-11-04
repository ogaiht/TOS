using System.Security.Permissions;

namespace TOS.NiceReads.Web.Models
{
    public class CreateBookModel
    {
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public string AuthorId { get; set; }
        public string[] Tags { get; set; }
    }
}
