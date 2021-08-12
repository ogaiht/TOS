using System;
using System.Threading.Tasks;

namespace TOS.EngagementHub.DataBase.Config
{
    class Program
    {
        async static Task Main(string[] args)
        {
            Console.WriteLine("Updating Database.");

            IDatabaseUpdater databaseUpdater = UpdaterBuilder.CreateUpdater();
            await databaseUpdater.UpdateAsync();
            Console.WriteLine("Update finished.");
            Console.ReadLine();
        }
    }
}
