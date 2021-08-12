using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TOS.Data.MongoDB;

namespace TOS.EngagementHub.DataBase.Config
{
    public class DatabaseUpdater : IDatabaseUpdater
    {

        private readonly IMongoCollectionProvider _mongoCollectionProvider;

        public DatabaseUpdater(IMongoCollectionProvider mongoCollectionProvider)
        {
            _mongoCollectionProvider = mongoCollectionProvider;
        }

        private IReadOnlyCollection<Type> LoadIndexers()
        {
            return GetType()
                .Assembly
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && typeof(IIndexer).IsAssignableFrom(t))
                .OrderBy(t => t.FullName)
                .ToArray();
        }

        public async Task UpdateAsync()
        {
            IReadOnlyCollection<Type> indexerTypes = LoadIndexers();
            Console.WriteLine("{0} indexers found.", indexerTypes.Count);
            foreach (Type indexerType in indexerTypes)
            {
                IIndexer indexer = (IIndexer)Activator.CreateInstance(indexerType);
                try
                {
                    Console.WriteLine("Executing '{0}'", indexerType.Name);
                    await indexer.ExecuteAsync(_mongoCollectionProvider);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error when executing indexer '{0}'. Error message: '{1}'.", indexerType.Name, ex.Message);
                    throw;
                }
            }
        }
    }
}
