using System.Threading.Tasks;
using TOS.Data.MongoDB;

namespace TOS.EngagementHub.DataBase.Config
{
    public interface IIndexer
    {
        Task ExecuteAsync(IMongoCollectionProvider mongoCollectionProvider);
    }
}
