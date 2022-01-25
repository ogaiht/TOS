using System.Threading.Tasks;

namespace TOS.EngagementHub.DataBase.Config
{
    public interface IDatabaseUpdater
    {
        Task UpdateAsync();
    }
}