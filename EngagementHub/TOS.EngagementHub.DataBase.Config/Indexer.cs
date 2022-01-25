using MongoDB.Driver;
using System.Threading.Tasks;
using TOS.Data.MongoDB;

namespace TOS.EngagementHub.DataBase.Config
{
    public abstract class Indexer<TDocument> : IIndexer
    {
        public async Task ExecuteAsync(IMongoCollectionProvider mongoCollectionProvider)
        {
            IMongoCollection<TDocument> collection = mongoCollectionProvider.GetCollection<TDocument>();
            await IndexAsync(collection);
        }
        protected abstract Task IndexAsync(IMongoCollection<TDocument> collection);
    }
}
