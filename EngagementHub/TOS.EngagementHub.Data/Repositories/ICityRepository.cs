using System;
using TOS.Data.Repositories;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Data.Repositories
{
    public interface ICityRepository : IRepository<City, Guid>
    {
    }
}
