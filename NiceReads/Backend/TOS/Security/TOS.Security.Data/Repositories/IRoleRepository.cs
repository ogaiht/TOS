using MongoDB.Bson;
using System.Threading.Tasks;
using TOS.Common.DataModel;
using TOS.Data.Repositories;
using TOS.Security.Models;

namespace TOS.Data.Security.Repositories
{
    public interface IRoleRepository : IRepository<Role, ObjectId>
    {
        Task<IPagedResult<Role>> GetByNameLikeAsync(string name, int offset = -1, int limit = -1);

        Task<IPagedResult<Role>> GetAllAsync();
    }
}
