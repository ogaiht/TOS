using System;
using TOS.CaseChecker.Models;
using TOS.Data.Repositories;

namespace TOS.CaseChecker.Data.Repositories
{
    public interface IUpdateCheckRepository : IRepository<UpdateCheck, Guid>
    {
    }
}
