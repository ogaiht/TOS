using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using TOS.Common.DataModel;
using TOS.Data.MongoDB;
using TOS.Data.MongoDB.Repositories;
using TOS.Security.Models;

namespace TOS.Data.Security.Repositories.Implementations
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(IDatabaseProvider databaseProvider) : base(databaseProvider)
        {
        }

        public async Task<IPagedResult<Role>> GetAllAsync()
        {
            IReadOnlyCollection<Role> roles = await Collection.Find(r => true).ToListAsync();
            return new PagedResult<Role>(roles, roles.Count);
        }

        public async Task<IPagedResult<Role>> GetByNameLikeAsync(string name, int offset = -1, int limit = -1)
        {
            IFindFluent<Role, Role> find = Collection.Find(r => r.Name.Contains(name));
            long total = await find.CountDocumentsAsync();
            if (offset > -1)
            {
                find.Skip(offset);
            }
            if (limit > -1)
            {
                find.Limit(limit);
            }
            IReadOnlyCollection<Role> roles = await find.ToListAsync();
            return new PagedResult<Role>(roles, total);
        }
    }
}
