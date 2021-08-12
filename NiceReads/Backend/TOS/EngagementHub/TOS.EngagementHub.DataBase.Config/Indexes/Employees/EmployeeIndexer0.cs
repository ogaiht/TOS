using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.DataBase.Config.Indexes.Employees
{
    public class EmployeeIndexer0 : Indexer<Employee>
    {
        protected override async Task IndexAsync(IMongoCollection<Employee> collection)
        {
            const int length = 10000;
            List<Employee> employees = new List<Employee>(length);
            for (int i = 0; i < length; i++)
            {
                employees.Add(new Employee()
                {
                    Email = $"employee{i}@email.com",
                    Name = new Name()
                    {
                        FirstName = "FirstName_" + i,
                        LastName = "LastName_" + i
                    }

                });
            }
            await collection.InsertManyAsync(employees);
        }
    }
}
