using MongoDB.Driver;
using System.Threading.Tasks;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.DataBase.Config.Indexes.Employees
{
    public class EmployeeIndexer1 : Indexer<Employee>
    {
        protected override async Task IndexAsync(IMongoCollection<Employee> collection)
        {
            await collection.Indexes.CreateOneAsync(new CreateIndexModel<Employee>(Builders<Employee>.IndexKeys.Ascending(e => e.Name.FirstName)));
            await collection.Indexes.CreateOneAsync(new CreateIndexModel<Employee>(Builders<Employee>.IndexKeys.Ascending(e => e.Name.MiddleName)));
            await collection.Indexes.CreateOneAsync(new CreateIndexModel<Employee>(Builders<Employee>.IndexKeys.Ascending(e => e.Name.LastName)));
            await collection.Indexes.CreateOneAsync(new CreateIndexModel<Employee>(Builders<Employee>.IndexKeys.Ascending(e => e.Email)));
        }
    }
}
