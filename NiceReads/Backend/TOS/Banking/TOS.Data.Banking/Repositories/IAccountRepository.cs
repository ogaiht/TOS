using System;
using TOS.Data.Repositories;
using TOS.Models.Banking;

namespace TOS.Data.Banking.Repositories
{
    public interface IAccountRepository : IRepository<Account, Guid>
    {
    }
}
