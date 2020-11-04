using MongoDB.Bson;

namespace TOS.NiceReads.Application.Commands.Authentications
{
    public class UserInfo
    {
        public UserInfo(ObjectId id, string username, string email)
        {
            Id = id;
            Username = username;
            Email = email;
        }

        public ObjectId Id { get; }
        public string Username { get; }
        public string Email { get; }
    }
}
