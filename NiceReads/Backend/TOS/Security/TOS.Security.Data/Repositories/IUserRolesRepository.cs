using MongoDB.Bson;
using TOS.Data.Repositories;
using TOS.Security.Models;

namespace TOS.Data.Security.Repositories
{
    public interface IUserRolesRepository : IRepository<UserRole, ObjectId>
    {
    }
}
