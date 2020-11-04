using MongoDB.Bson;
using System.Threading.Tasks;
using TOS.NiceReads.Application.Commands.Authentications;

namespace TOS.NiceReads.Application.Services.Logins
{
    public interface ILoginHistoryManager
    {
        Task RecoredLoginAsync(ObjectId userId, AuthenticationStatus authenticationStatus);
    }
}